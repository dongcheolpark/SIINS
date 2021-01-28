using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIINS_APP_API.Models;

namespace SIINS_APP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedCategoriesController : ControllerBase
    {
        private readonly SelectedCategoriesDBcontext _context;

        public SelectedCategoriesController(SelectedCategoriesDBcontext context)
        {
            _context = context;
        }

        // GET: api/SelectedCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedCategory>>> GetCategories()
        {
            return await _context.SelectedCategories.ToListAsync();
        }

        // GET: api/SelectedCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedCategory>> GetSelectedCategory(int id)
        {
            var selectedCategory = await _context.SelectedCategories.FindAsync(id);

            if (selectedCategory == null)
            {
                return NotFound();
            }

            return selectedCategory;
        }

        // PUT: api/SelectedCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelectedCategory(int id, SelectedCategory selectedCategory)
        {
            if (id != selectedCategory.CatUId)
            {
                return BadRequest();
            }

            _context.Entry(selectedCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SelectedCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SelectedCategory>> PostSelectedCategory(SelectedCategory selectedCategory)
        {
            _context.SelectedCategories.Add(selectedCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelectedCategory", new { id = selectedCategory.CatUId }, selectedCategory);
        }

        // DELETE: api/SelectedCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectedCategory(int id)
        {
            var selectedCategory = await _context.SelectedCategories.FindAsync(id);
            if (selectedCategory == null)
            {
                return NotFound();
            }

            _context.SelectedCategories.Remove(selectedCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SelectedCategoryExists(int id)
        {
            return _context.SelectedCategories.Any(e => e.CatUId == id);
        }
    }
}
