using Microsoft.AspNetCore.Mvc;
using registroClientes.Application.Interfaces;
using registroClientes.Domain.Model;

namespace registroClientes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrarClientesController : ControllerBase
{
    private readonly IRegistroService _registroService;

    public RegistrarClientesController(IRegistroService registroService)
    {
        _registroService = registroService;
    }

    [HttpGet]
    public async Task<ActionResult<Cliente>> BuscarClientes()
    {
        var retorno = await _registroService.BuscarTodosClientes();

        if (!retorno.Any()) return NotFound("Não há Registros.");

        return Ok(retorno);
    }

    [HttpGet("{numeroContato}", Name = "BuscarPorContato")]
    public async Task<ActionResult<Cliente>> Buscar(string numeroContato)
    {
        var retorno = await _registroService.BuscarPorNumeroContato(numeroContato);
        if (retorno is null) return NotFound("Não há Registros.");

        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> CadastrarCliente([FromBody] Cliente cliente)
    {
        if (cliente is null) return BadRequest("Dados nulos.");

        await _registroService.CadastrarCliente(cliente);

        return Ok(cliente);
    }
}