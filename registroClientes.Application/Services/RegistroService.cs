using registroClientes.Application.Interfaces;
using registroClientes.Domain.Interfaces;
using registroClientes.Domain.Model;

namespace registroClientes.Application.Services;

public class RegistroService : IRegistroService
{
    public readonly IRegistroRepository _registroRepository;

    public RegistroService(IRegistroRepository registroRepository)
    {
        _registroRepository = registroRepository;
    }




    public async Task AtualizarEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task AtualizarNumeroContato(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public async Task<Cliente> BuscarPorNumeroContato(string numeroContato)
    {
        return await _registroRepository.BuscarPorNumeroContatoAsync(numeroContato);
    }

    public async Task<IEnumerable<Cliente>> BuscarTodosClientes()
    {
       return await _registroRepository.BuscarTodosClientesAsync();
    }

    public async Task CadastrarCliente(Cliente cliente)
    {
         await _registroRepository.CadastrarClienteAsync(cliente);
    }

    public async Task DeletarPorEmail(string email)
    {
        throw new NotImplementedException();
    }
}