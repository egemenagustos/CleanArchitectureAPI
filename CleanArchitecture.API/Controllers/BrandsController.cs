using CleanArchitecture.Application.Features.Brands.Commands.Create;
using CleanArchitecture.Application.Features.Brands.Commands.Delete;
using CleanArchitecture.Application.Features.Brands.Commands.Update;
using CleanArchitecture.Application.Features.Brands.Queries.GetById;
using CleanArchitecture.Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand request)
        {
            CreatedBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand request)
        {
            UpdatedBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteBrandCommand deleteBrandCommand = new() { Id = id };
            DeletedBrandResponse response = await Mediator.Send(deleteBrandCommand);
            return Ok(response);
        }
    }
}
