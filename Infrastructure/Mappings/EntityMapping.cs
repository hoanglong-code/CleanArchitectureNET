using AutoMapper;
using Infrastructure.Commons;
using Infrastructure.Entities.Extend;
using Infrastructure.EntityDtos;
using Infrastructure.Queries.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            CreateMap<Product, SaveProductCommand>();
            CreateMap<SaveProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedById, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<BaseCriteria, GetProductByPageCommand>();
            CreateMap<GetProductByPageCommand, BaseCriteria>();

        }
    }
}
