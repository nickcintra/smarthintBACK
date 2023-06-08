using Microsoft.AspNetCore.Mvc;
using smarthintAPI.Data;
using smarthintAPI.Models;
using smarthintAPI.Repositories;
using smarthintAPI.Requests;

namespace smarthintAPI.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository clienteRepository;
        public ClienteService(SmarthintDBContext context)
        {
            clienteRepository = new ClienteRepository(context);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return clienteRepository.GetClientes();
        }

        public Cliente GetCliente(int id)
        {
            
            try
            {
                return clienteRepository.GetClientesId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter cliente: " + ex.Message);
            }
        }

        public IQueryable GetClientesFiltro(FiltroRequest filtroRequest)
        {
            
            try
            {
                return clienteRepository.GetClientesFiltro(filtroRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter cliente: " + ex.Message);
            }
        }

        public bool CriarCliente(ClienteRequest clienteRequest)
        {
            try
            {
                clienteRepository.CriarCliente(clienteRequest);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
