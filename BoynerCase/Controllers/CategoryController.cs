
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {

            var categories = await _mediator.Send(new GetCategoryQuery());

            return Ok(categories);
        }
        
        [HttpGet]
        [Route("Page")]
        public async Task<ActionResult> GetCategoryPages(int page = 1)
        {
            var categories = await _mediator.Send(new GetCategoryPageQuery(page));

            return Ok(categories);
        }

        
        [HttpPost]
        public async Task<ActionResult> AddCategory([FromBody] Category category)
        {
            {
                var categoryToReturn = await _mediator.Send(new AddCategoryCommand(category));

                return CreatedAtAction(nameof(GetCategoryById), new { id = categoryToReturn.Id }, categoryToReturn);

            }
        }
        
        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));

            return Ok(category);
        }
        
        [HttpPut("{id:int}", Name = "UpdateCategory")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] Category guncelUrun)
        {
            var category = await _mediator.Send(new UpdateCategoryCommand(id, guncelUrun));

            return Ok(category);
        }

        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _mediator.Send(new DeleteCategoryCommand(id));

            return Ok(category);
        }
        
    }
}
