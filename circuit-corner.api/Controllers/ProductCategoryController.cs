using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using circuit_corner.api.Models.Context;
using circuit_corner.api.Models.DTO;

namespace circuit_corner.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly CircuitCornerDbContext _context;

        public ProductCategoryController(CircuitCornerDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetProductCategoryDTO()
        {
          if (_context.ProductCategoryDTO == null)
          {
              return NotFound();
          }
            return await _context.ProductCategoryDTO.ToListAsync();
        }

        // GET: api/ProductCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryDTO>> GetProductCategoryDTO(int id)
        {
          if (_context.ProductCategoryDTO == null)
          {
              return NotFound();
          }
            var productCategoryDTO = await _context.ProductCategoryDTO.FindAsync(id);

            if (productCategoryDTO == null)
            {
                return NotFound();
            }

            return productCategoryDTO;
        }

        // PUT: api/ProductCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategoryDTO(int id, ProductCategoryDTO productCategoryDTO)
        {
            if (id != productCategoryDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(productCategoryDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryDTOExists(id))
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

        // POST: api/ProductCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCategoryDTO>> PostProductCategoryDTO(ProductCategoryDTO productCategoryDTO)
        {
          if (_context.ProductCategoryDTO == null)
          {
              return Problem("Entity set 'CircuitCornerDbContext.ProductCategoryDTO'  is null.");
          }
            _context.ProductCategoryDTO.Add(productCategoryDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategoryDTO", new { id = productCategoryDTO.ID }, productCategoryDTO);
        }

        // DELETE: api/ProductCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategoryDTO(int id)
        {
            if (_context.ProductCategoryDTO == null)
            {
                return NotFound();
            }
            var productCategoryDTO = await _context.ProductCategoryDTO.FindAsync(id);
            if (productCategoryDTO == null)
            {
                return NotFound();
            }

            _context.ProductCategoryDTO.Remove(productCategoryDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductCategoryDTOExists(int id)
        {
            return (_context.ProductCategoryDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
