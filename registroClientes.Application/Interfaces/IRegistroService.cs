using registroClientes.Domain.Model;

namespace registroClientes.Application.Interfaces;

public interface IRegistroService
{
    Task<Cliente> BuscarPorNumeroContato(string numeroContato);

    Task CadastrarCliente(Cliente cliente);
    Task<IEnumerable<Cliente>> BuscarTodosClientes();


    Task AtualizarEmail(string email);

    Task AtualizarNumeroContato(Cliente cliente);

    Task DeletarPorEmail(string email);
}