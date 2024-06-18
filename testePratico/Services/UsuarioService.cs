using testePratico.Models;
using testePratico.Repositories.Interface;
using testePratico.Services.Interface;

namespace testePratico.Services

{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<UsuarioModel>> GetAllUsers()
        {
            return await _usuarioRepository.BuscarTodosUsuarios();
        }
        public async Task<UsuarioModel> GetUserById(int id)
        {
            return await _usuarioRepository.BuscarPorId(id);
        }
        public async Task<UsuarioModel> CreateUser(UsuarioModel usuario)
        {
            return await _usuarioRepository.Create(usuario);
        }
        public async Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioExistente = await _usuarioRepository.BuscarPorId(id);

            if (usuarioExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado na base de dados.");
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;

            return await _usuarioRepository.Update(usuarioExistente, id);
        }
        public async Task<bool> DeleteUser(int id)
        {
            UsuarioModel usuarioExistente = await _usuarioRepository.BuscarPorId(id);

            if (usuarioExistente == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado na base de dados.");
            }

            return await _usuarioRepository.Delete(id);
        }
    }
}
