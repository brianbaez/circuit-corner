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
    public class UserController : ControllerBase
    {
        private readonly CircuitCornerDbContext _context;

        public UserController(CircuitCornerDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserDTO()
        {
          if (_context.UserDTO == null)
          {
              return NotFound();
          }
            return await _context.UserDTO.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserDTO(int id)
        {
          if (_context.UserDTO == null)
          {
              return NotFound();
          }
            var userDTO = await _context.UserDTO.FindAsync(id);

            if (userDTO == null)
            {
                return NotFound();
            }

            return userDTO;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDTO(int id, UserDTO userDTO)
        {
            if (id != userDTO.ID)
            {
                return BadRequest();
            }

            _context.Entry(userDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDTOExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUserDTO(UserDTO userDTO)
        {
          if (_context.UserDTO == null)
          {
              return Problem("Entity set 'CircuitCornerDbContext.UserDTO'  is null.");
          }
            _context.UserDTO.Add(userDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDTO", new { id = userDTO.ID }, userDTO);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDTO(int id)
        {
            if (_context.UserDTO == null)
            {
                return NotFound();
            }
            var userDTO = await _context.UserDTO.FindAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }

            _context.UserDTO.Remove(userDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDTOExists(int id)
        {
            return (_context.UserDTO?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
