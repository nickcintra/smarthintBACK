using smarthintAPI.Models;
using smarthintAPI.Requests;
using static smarthintAPI.Services.PaginationHelper;


namespace smarthintAPI.Services
{
    public interface IClienteService
    {
        PagedResult<Cliente> GetTodosClientes(int pageNumber, int pageSize);
        Cliente GetCliente(int id);
        PagedResult<Cliente> GetClientesFiltro(FiltroRequest filtroRequest, int pageNumber, int pageSize);
        bool CriarCliente(ClienteRequest clienteRequest);
    }
}
