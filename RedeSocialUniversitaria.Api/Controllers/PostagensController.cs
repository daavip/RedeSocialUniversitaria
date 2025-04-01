using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversitaria.Domain;
using RedeSocialUniversitaria.Infra;
using Microsoft.EntityFrameworkCore;

namespace RedeSocialUniversitaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagensController : ControllerBase
    {
        private readonly SqlContext _context;

        public PostagensController(SqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postagens = await _context.Postagens.Include(p => p.Autor).ToListAsync();
            return Ok(postagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var postagem = await _context.Postagens.Include(p => p.Autor).FirstOrDefaultAsync(p => p.Id == id);
            if (postagem == null)
            {
                return NotFound();
            }
            return Ok(postagem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = postagem.Id }, postagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Postagem postagem)
        {
            if (id != postagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(postagem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostagemExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var postagem = await _context.Postagens.FindAsync(id);
            if (postagem == null)
            {
                return NotFound();
            }

            _context.Postagens.Remove(postagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostagemExists(int id)
        {
            return _context.Postagens.Any(e => e.Id == id);
        }
    }
}
