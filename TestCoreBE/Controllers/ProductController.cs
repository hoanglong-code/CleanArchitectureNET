using ExcelDataReader.Log;
using Infrastructure.Commons;
using Infrastructure.Entities.Extend;
using Infrastructure.Enums;
using Infrastructure.Queries.Commands;
using Infrastructure.Services.Abstractions;
using MailKit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NON.EXE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _entityService;
        private readonly IMediator _mediator;
        public ProductController(IProductService entityService, IMediator mediator)
        {
            _entityService = entityService;
            _mediator = mediator;
        }
        //[HttpGet("GetByPage")]
        //public async Task<IActionResult> GetByPage([FromQuery] BaseCriteria request)
        //{
        //    return Ok(await _entityService.GetByPage(request));
        //}        
        [HttpPost("GetByPage")]
        public async Task<IActionResult> GetByPage([FromBody] GetProductByPageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await _entityService.GetById(id));
        //}
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(GetProductByIdCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        //[HttpPost]
        //public async Task<IActionResult> SaveData([FromBody] Product data)
        //{
        //    return Ok(await _entityService.SaveData(data));
        //}
        [HttpPost("SaveData")]
        public async Task<IActionResult> SaveData([FromBody] SaveProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteData(int id)
        //{
        //    return Ok(await _entityService.DeleteData(id));
        //}        
        [HttpPost("DeleteData")]
        public async Task<IActionResult> DeleteData(DeleteProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        //[HttpPost("DeleteMultiple")]
        //public async Task<IActionResult> DeleteMultipleData([FromBody] List<Product> products)
        //{
        //    return Ok(await _entityService.DeleteMultipleData(products));
        //}
        [HttpPost("DeleteMultiple")]
        public async Task<IActionResult> DeleteMultipleData(DeleteMultipleProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("SearchByElastic")]
        public async Task<IActionResult> SearchByElastic(SearchProductElasticCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
