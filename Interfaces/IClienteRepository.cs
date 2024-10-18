using smarthintAPI.Models;
using smarthintAPI.Requests;

namespace smarthintAPI.Services
{
    public interface IClienteRepository
    {
        public int CriarCliente(ClienteRequest clienteRequest);
        public IQueryable<Cliente> GetClientes();
        public Cliente GetClienteId(int id);
        public IQueryable<Cliente> GetClientesFiltro(FiltroRequest filtroRequest);


    }
}
