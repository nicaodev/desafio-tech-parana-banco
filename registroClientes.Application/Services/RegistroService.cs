using AutoMapper;
using registroClientes.Application.Dtos;
using registroClientes.Application.Interfaces;
using registroClientes.Domain.Interfaces;
using registroClientes.Domain.Model;

namespace registroClientes.Application.Services;

public class RegistroService : IRegistroService
{
    public readonly IRegistroRepository _registroRepository;
    public readonly IMapper _mapper;

    public RegistroService(IRegistroRepository registroRepository, IMapper mapper)
    {
        _registroRepository = registroRepository;
        _mapper = mapper;
    }

    public async Task AtualizarEmail(ClienteDto cliente)
    {
        var modelCliente = _mapper.Map<Cliente>(cliente);

        await _registroRepository.AtualizarEmailAsync(modelCliente);
    }

    public async Task AtualizarNumeroContato(ClienteDto cliente)
    {
        var modelCliente = _mapper.Map<Cliente>(cliente);

        await _registroRepository.AtualizarNumeroContatoAsync(modelCliente);
    }

    public async Task<ClienteDto> BuscarPorNumeroContato(string numeroContato)
    {
        var retorno = await _registroRepository.BuscarPorNumeroContatoAsync(numeroContato);

        return _mapper.Map<ClienteDto>(retorno);
    }

    public async Task<IEnumerable<ClienteDto>> BuscarTodosClientes()
    {
        var retorno = await _registroRepository.BuscarTodosClientesAsync();

        return _mapper.Map<IEnumerable<ClienteDto>>(retorno);
    }

    public async Task CadastrarCliente(ClienteDto cliente)
    {
        var modelCliente = _mapper.Map<Cliente>(cliente);

        await _registroRepository.CadastrarClienteAsync(modelCliente);
    }

    public async Task<bool> DeletarPorEmail(string email)
    {
        return await _registroRepository.DeletarPorEmailAsync(email);
    }
}