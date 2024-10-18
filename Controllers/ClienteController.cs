using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using smarthintAPI.Data;
using smarthintAPI.Models;
using smarthintAPI.Requests;
using smarthintAPI.Services;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace smarthintAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public IActionResult CadastrarCliente([FromBody] ClienteRequest cliente)
    {
        try
        {
            bool clienteRetorno = _clienteService.CriarCliente(cliente);

            if(clienteRetorno)
            {
                return Ok(new { message = "Cliente cadastrado com sucesso!" });
            }

            return BadRequest(new { message = "Falha ao cadastrar Cliente." });

        }
        catch (Exception ex) {
            return StatusCode(500, new { message = "Erro interno no servidor.", detalhes = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult ConsultarClientes([FromQuery] int pageNumber = 1, int pageSize = 10)
    {
        var pagedResults = _clienteService.GetTodosClientes(pageNumber, pageSize);


        if (pagedResults.Items.Any())
        {
            var response = new
            {
                pagedResults.TotalPages,
                pagedResults.CurrentPage,
                pagedResults.PageSize,
                Items = pagedResults.Items
            };

            return Ok(response);
        }
        else
        {
            return BadRequest("Nenhum cliente encontrado.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult ConsultaClienteId(int id)
    {
        var cliente = _clienteService.GetCliente(id);

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
    public IActionResult ConsultaClienteFiltro([FromQuery]FiltroRequest filtroRequest, int pageNumber = 1, int pageSize = 10)
    {
        var pagedResults = _clienteService.GetClientesFiltro(filtroRequest, pageNumber, pageSize);

        if (pagedResults.Items.Any())
        {
            var response = new
            {
                pagedResults.TotalPages,
                pagedResults.CurrentPage,
                pagedResults.PageSize,
                Items = pagedResults.Items
            };

            return Ok(response);
        }
        else
        {
            return BadRequest("Nenhum cliente encontrado.");
        }
    }

    //PUT: api/produtos/1
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
