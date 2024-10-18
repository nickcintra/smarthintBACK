using Microsoft.AspNetCore.Mvc;
using smarthintAPI.Data;
using smarthintAPI.Models;
using smarthintAPI.Repositories;
using smarthintAPI.Requests;
using static smarthintAPI.Services.PaginationHelper;

namespace smarthintAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool CriarCliente(ClienteRequest clienteRequest)
        {
            int clienteId = _clienteRepository.CriarCliente(clienteRequest);

            if (clienteId > 0) {
                return true;
            }

            return false;
        }

        public PagedResult<Cliente> GetTodosClientes(int pageNumber, int pageSize)
        {
            var query = _clienteRepository.GetClientes(); 
            return PaginationHelper.Paginate(query.AsQueryable(), pageNumber, pageSize);
        }

        public Cliente GetCliente(int id)
        {
            
            try
            {
                return _clienteRepository.GetClienteId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter cliente: " + ex.Message);
            }
        }

        public PagedResult<Cliente> GetClientesFiltro(FiltroRequest filtroRequest, int pageNumber, int pageSize)
        {
            var query = _clienteRepository.GetClientesFiltro(filtroRequest);
            return PaginationHelper.Paginate(query.AsQueryable(), pageNumber, pageSize);

        }

       

    }
}
