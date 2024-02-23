using api_terrawind.Core.Entities;
using api_terrawind.Infraestructure.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_terrawind.Presetation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GestoresController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Gestores.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetGestor")]
        public IActionResult Get(int id)
        {
            try
            {
                var gestor = _context.Gestores.FirstOrDefault(g => g.Id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Gestores gestores)
        {
            try
            {
                _context.Gestores.Add(gestores);
                _context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestores.Id }, gestores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Gestores gestores)
        {
            try
            {
                if (gestores.Id == id)
                {
                    _context.Entry(gestores).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestores.Id }, gestores);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var gestor = _context.Gestores.FirstOrDefault(g => g.Id == id);
                if (gestor != null)
                {
                    _context.Gestores.Remove(gestor);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
