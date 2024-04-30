using Blog.Models;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IDbContext _dbContext;

        public CategoryController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("v1/categorias")]
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            return Ok(categories);
        }

        [HttpGet("v1/categorias/{id:int}")]
        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null) return NotFound();

            return Ok(category);
        }

        [HttpPost("v1/categorias")]
        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsyn([FromBody] Category category)
        {
            if (category is null) return NotFound();

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return Created($"v1/categories/{category.Id}", category);
        }

        [HttpPut("v1/categories/{id:int}")]
        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsyn([FromRoute] int id,
                                                 [FromBody] Category model)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null) return NotFound();
            category.Name = model.Name;
            category.Slug = model.Slug;

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            
            return Ok(category);
        }

        [HttpDelete("v1/categories/{id:int}")]
        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsyn([FromRoute] int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null) return NotFound();

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            
            return Ok(new { situacao = "Categoria removida",categoria = category });
        }
    }
}
