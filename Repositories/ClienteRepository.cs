using Microsoft.EntityFrameworkCore;
using smarthintAPI.Data;
using smarthintAPI.Models;
using smarthintAPI.Requests;
using smarthintAPI.Services;
using System.Linq;

namespace smarthintAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SmarthintDBContext _context;

        public ClienteRepository(SmarthintDBContext context)
        {
            _context = context;
        }

        public int CriarCliente(ClienteRequest clienteRequest)
        {
            var cliente = new Cliente(
                clienteRequest.Nome,
                clienteRequest.Email,
                clienteRequest.Telefone,
                clienteRequest.DataCadastro,
                clienteRequest.TipoPessoa,
                clienteRequest.CpfCnpj,
                clienteRequest.InscricaoEstadual,
                clienteRequest.Isento,
                clienteRequest.Genero,
                clienteRequest.Bloqueado,
                clienteRequest.Senha);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente.Id; 

        }

        public IQueryable<Cliente> GetClientes()
        {
            return _context.Clientes;
        }

        public Cliente GetClienteId(int id)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        }

        public IQueryable<Cliente> GetClientesFiltro(FiltroRequest filtroRequest)
        {

            var query = _context.Clientes.Where(c => 
                  ( string.IsNullOrEmpty(filtroRequest.Nome) || c.Nome.Contains(filtroRequest.Nome)) &&
                  ( string.IsNullOrEmpty(filtroRequest.Email) || c.Email.Contains(filtroRequest.Email)) &&
                  ( string.IsNullOrEmpty(filtroRequest.Telefone.ToString()) || c.Telefone.ToString().Contains(filtroRequest.Telefone.ToString())) &&
                  ( filtroRequest.DataCadastro == default || c.DataCadastro.Date == filtroRequest.DataCadastro) &&
                  ( !filtroRequest.Bloqueado || c.Bloqueado == filtroRequest.Bloqueado)
             );

            return query;
        }
    }
}
