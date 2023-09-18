
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }
        
        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult> GetProductPages(int page = 1)
        {
            var products = await _mediator.Send(new GetProductsPageQuery(page));

            return Ok(products);
        }
        [HttpGet]
        [Route("Category")]
        public async Task<ActionResult> GetCategoryProducts(int categoryId, int page = 1)
        {
            var products = await _mediator.Send(new GetCategoryProductsQuery(categoryId,page));

            return Ok(products);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            {
                var productToReturn = await _mediator.Send(new AddProductCommand(product));

                return CreatedAtAction(nameof(GetProductById), new { id = productToReturn.Id }, productToReturn);

            }
        }
        
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }
        
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product guncelUrun)
        {
            var product = await _mediator.Send(new UpdateProductCommand(id, guncelUrun));

            return Ok(product);
        }
        
        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _mediator.Send(new DeleteProductCommand(id));

            return Ok(product);
        }
        
    }
}
