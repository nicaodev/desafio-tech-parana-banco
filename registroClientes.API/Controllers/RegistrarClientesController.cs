using Microsoft.AspNetCore.Mvc;
using registroClientes.Application.Dtos;
using registroClientes.Application.Interfaces;

namespace registroClientes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class RegistrarClientesController : ControllerBase
{
    private readonly IRegistroService _registroService;

    public RegistrarClientesController(IRegistroService registroService)
    {
        _registroService = registroService;
    }

    /// <summary>
    /// Consultar todos os clientes com seus respectivos e-mails e telefones.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ClienteDto>> BuscarClientes()
    {
        var retorno = await _registroService.BuscarTodosClientes();

        if (!retorno.Any()) return NotFound("Não há Registros.");

        return Ok(retorno);
    }

    /// <summary>
    /// Consulta de um cliente através do DDD e número.
    /// </summary>
    /// <param name="numeroContato"></param>
    /// <returns></returns>
    [HttpGet("{numeroContato}", Name = "BuscarPorContato")]
    public async Task<ActionResult<ClienteDto>> Buscar(string numeroContato)
    {
        var retorno = await _registroService.BuscarPorNumeroContato(numeroContato);
        if (retorno is null) return NotFound("Não há Registros.");

        return Ok(retorno);
    }

    /// <summary>
    /// Cadastrar o cliente informando o nome completo, e-mail e uma lista de telefones informando o DDD, número e o tipo [fixo ou celular].
    /// </summary>
    /// <param name="clienteDto"></param>
    /// <returns></returns>
    ///

    [HttpPost]
    public async Task<ActionResult> CadastrarCliente([FromBody] ClienteDto clienteDto)
    {
        if (clienteDto is null) return BadRequest("Dados nulos.");

        await _registroService.CadastrarCliente(clienteDto);

        return Ok(clienteDto);
    }

    /// <summary>
    /// Atualizar o e-mail do cliente cadastrado.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="clienteDto"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult> AtualizarEmailCliente(int id, [FromBody] ClienteDto clienteDto)
    {
        if (id != clienteDto.Id || clienteDto is null) return BadRequest();

        await _registroService.AtualizarEmail(clienteDto);

        return Ok(clienteDto);
    }

    /// <summary>
    /// Atualizar contato de telefone do cliente cadastrado.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="clienteDto"></param>
    /// <returns></returns>
    [HttpPut("{id:int}", Name = "AtualizarContatosCliente")]
    public async Task<ActionResult> AtualizarContatosCliente(int id, [FromBody] ClienteDto clienteDto)
    {
        if (id != clienteDto.Id || clienteDto is null) return BadRequest();

        await _registroService.AtualizarNumeroContato(clienteDto);

        return Ok(clienteDto);
    }

    /// <summary>
    /// Deletar cliente via e-mail.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult<ClienteDto>> Delete(string email)
    {
        var retorno = await _registroService.DeletarPorEmail(email);

        if (!retorno) return BadRequest();
        return Ok("Cliente deletado da base de dados.");
    }
}