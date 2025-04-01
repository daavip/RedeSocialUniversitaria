using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedeSocialUniversitaria.Infra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Set<Usuario>().ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Set<Usuario>().FindAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Set<Usuario>().FindAsync(id);
            if (usuario != null)
            {
                _context.Set<Usuario>().Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
