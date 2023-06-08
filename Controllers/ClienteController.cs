using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using smarthintAPI.Data;
using smarthintAPI.Models;
using smarthintAPI.Requests;
using smarthintAPI.Services;
using System;
using System.Linq;

namespace smarthintAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private SmarthintDBContext _context;
    private ClienteService _service;

    public ClienteController(SmarthintDBContext context, ClienteService service)
    {
        _context = context;
        _service = service;
    }

    [HttpPost]
    public IActionResult CadastrarCliente([FromBody] ClienteRequest cliente)
    {
        bool clienteRetorno = _service.CriarCliente(cliente);
        if(clienteRetorno)
        {
            return Ok("Cliente cadastrado com sucesso!");
        }
        else
        {
            return BadRequest("Falha ao cadastrar Cliente.");
        }
    }

    [HttpGet]
    public IActionResult ConsultarClientes([FromQuery] int pageNumber = 1, int pageSize = 10)
    {
        var results = _service.GetAllClientes().ToList();
        var totalCount = results.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var pagedResults = results
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        if (pagedResults != null)
        {
            var response = new
            {
                totalPages,
                currentPage = pageNumber,
                pageSize,
                items = pagedResults
            };

            return Ok(response);
        }
        else
        {
            return BadRequest("Nenhuma cliente encontrado");
        }
    }

    [HttpGet("{id}")]
    public IActionResult ConsultaClienteId(int id)
    {
        var cliente = _service.GetCliente(id);

        if(cliente != null)
        {
            return Ok(cliente);
        }
        else
        {
            return BadRequest("Nenhum cliente encontrado");
        }
    }

    [HttpGet("filtro")]
    public IActionResult ConsultaClienteFiltro([FromQuery]FiltroRequest filtroRequest)
    {
        var result = _service.GetClientesFiltro(filtroRequest);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest("Nenhum cliente encontrado");
        }
    }

    //// PUT: api/produtos/1
    //[HttpPut("{id}")]
    //public IActionResult Put(int id, [FromBody] Produto produtoAtualizado)
    //{
    //    if (produtoAtualizado == null || produtoAtualizado.Id != id)
    //    {
    //        return BadRequest("Dados inválidos");
    //    }

    //    var produto = _apicontext.Produtos.FirstOrDefault(p => p.Id == id);

    //    if (produto == null)
    //    {
    //        return NotFound();
    //    }

    //    produto.Descricao = produtoAtualizado.Descricao;
    //    produto.Valor = produtoAtualizado.Valor;

    //    _apicontext.SaveChanges();

    //    return NoContent();
    //}
}
