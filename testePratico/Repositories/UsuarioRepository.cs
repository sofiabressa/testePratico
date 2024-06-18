using Microsoft.EntityFrameworkCore;
using testePratico.Data;
using testePratico.Models;
using testePratico.Repositories.Interface;

namespace testePratico.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserDbContext _dbContext;
        public UsuarioRepository(UserDbContext userDbContext) 
        { 
            _dbContext = userDbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            /*UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado na base de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;*/

            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId != null)
            {
                _dbContext.Usuarios.Remove(usuarioPorId);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
