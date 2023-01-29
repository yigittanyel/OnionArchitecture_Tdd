using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnArch.Application.Features.Commands;
using OnArch.Application.Features.Queries;

namespace OnArch.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            return Ok(await _mediator.Send(query));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand entity)
        {
            var request = new UpdateProductCommand{ Id = entity.Id,Name=entity.Name,Stock=entity.Stock,Value=entity.Value };
            var updatedEntity = await _mediator.Send(request);
            return Ok(updatedEntity);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteProductCommand { Id = id };
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
