using testePratico.Models;

namespace testePratico.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task <UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete (int id);

    }
}
