using AutoMapper;
using Elastic.Clients.Elasticsearch;
using FluentValidation;
using Infrastructure.Commons;
using Infrastructure.Constants;
using Infrastructure.Entities.Extend;
using Infrastructure.EntityDtos;
using Infrastructure.Exceptions.Extend;
using Infrastructure.Helpers;
using Infrastructure.Reponsitories.Abstractions;
using Infrastructure.Reponsitories.Abstractions.Extend;
using Infrastructure.Services.Abstractions;
using Infrastructure.Services.Base;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ValidationException = Infrastructure.Exceptions.Extend.ValidationException;

namespace Infrastructure.Services.Implementations
{
    public class ProductService : BaseService, IProductService
    {
        private static string functionCode = "QLSP";
        private readonly IProductRepository _entityRepo;
        private readonly ElasticsearchClient _elasticClient;
        private readonly IValidator<Product> _validator;
        private static readonly ILog log = LogMaster.GetLogger("ProductService", "ProductService");

        public ProductService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor contextAccessor,
            IUserContext userContext,
            IProductRepository entityRepo,
            ElasticsearchClient elasticClient,
            IValidator<Product> validator
            ): base(unitOfWork, contextAccessor, userContext)
        {
            _entityRepo = entityRepo;
            _elasticClient = elasticClient;
            _validator = validator;
        }
        public async Task<BaseSearchResponse<ProductDto>> GetByPage(BaseCriteria request)
        {
            await CheckPermision(functionCode, Enums.ApiEnums.TypeAction.VIEW);
            IQueryable<ProductDto> query = _entityRepo.All().Select(ProductDto.Expression);
            return await BaseSearchResponse<ProductDto>.GetResponse(query, request);
        }
        public async Task<Product> GetById(int id)
        {
            await CheckPermision(functionCode, Enums.ApiEnums.TypeAction.VIEW);
            var entity = await _entityRepo.GetByKeyAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(MessageErrorConstant.NOT_FOUND);
            }
            return entity;
        }
        public async Task<Product> SaveData(Product entity)
        {
            await CheckPermision(functionCode, entity.Id <= 0 ? Enums.ApiEnums.TypeAction.CREATE : Enums.ApiEnums.TypeAction.UPDATE);
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join(" , ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errorMessages);
            }
            if(entity.Id <= 0)
            {
                _entityRepo.Add(entity);
            }
            else
            {
                var curEntity = await _entityRepo.GetByKeyAsync(entity.Id);
                if (curEntity == null)
                {
                    throw new NotFoundException(MessageErrorConstant.NOT_FOUND);
                }
                _entityRepo.Update(entity);
            }
            await _unitOfWork.CommitChangesAsync();
            return entity;
        }
        public async Task<Product> DeleteData(int id)
        {
            await CheckPermision(functionCode, Enums.ApiEnums.TypeAction.DELETED);
            Product curEntity = await _entityRepo.GetByKeyAsync(id);
            if (curEntity == null)
            {
                throw new NotFoundException(MessageErrorConstant.NOT_FOUND);
            }
            _entityRepo.RemoveSoft(curEntity);
            await _unitOfWork.CommitChangesAsync();
            return curEntity;
        }
        public async Task<List<Product>> DeleteMultipleData(List<Product> products)
        {
            await CheckPermision(functionCode, Enums.ApiEnums.TypeAction.DELETED);
            var entities = await _entityRepo.All().Where(s => products.Select(x => x.Id).Contains(s.Id)).ToListAsync();
            _entityRepo.RemoveSoftRange(entities);
            await _unitOfWork.CommitChangesAsync();
            return entities;
        }

        #region ElasticSearch
        public async Task IndexAsync(Product entity, string indexName)
        {
            var response = await _elasticClient.IndexAsync(entity, idx => idx
                .Index(indexName)
                .Id(entity.Id!.ToString()) // Gắn Id
            );

            if (!response.IsValidResponse)
                throw new Exception($"Failed to index object: {response.DebugInformation}");
        }
        public async Task<Product?> GetByIdAsync(int id, string indexName)
        {
            var response = await _elasticClient.GetAsync<Product>(id!.ToString(), idx => idx.Index(indexName));
            return response.Found ? response.Source : null;
        }
        public async Task<IEnumerable<Product>> SearchAsync(string fieldName, string searchTerm, string indexName)
        {
            var response = await _elasticClient.SearchAsync<Product>(s => s
                .Index(indexName)
                .Query(q => q
                    .Match(m => m
                        .Field(fieldName)
                        .Query(searchTerm)
                    )
                )
            );

            if (!response.IsValidResponse)
                throw new Exception($"Search failed: {response.DebugInformation}");

            return response.Documents;
        }
        public async Task<bool> DeleteAsync(int id, string indexName)
        {
            var response = await _elasticClient.DeleteAsync<Product>(id!.ToString(), d => d.Index(indexName));
            return response.IsValidResponse;
        }
        #endregion
    }
}
