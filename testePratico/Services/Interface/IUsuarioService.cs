using System.Collections.Generic;
using System.Threading.Tasks;
using testePratico.Models;

namespace testePratico.Services.Interface

{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetAllUsers();
        Task<UsuarioModel> GetUserById(int id);
        Task<UsuarioModel> CreateUser(UsuarioModel usuario);
        Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id);
        Task<bool> DeleteUser(int id);
    }
}
