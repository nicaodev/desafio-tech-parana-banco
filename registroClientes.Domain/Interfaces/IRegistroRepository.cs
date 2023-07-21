using registroClientes.Domain.Model;

namespace registroClientes.Domain.Interfaces;

public interface IRegistroRepository
{
    Task<Cliente> CadastrarClienteAsync(Cliente cliente);

    Task<IEnumerable<Cliente>> BuscarTodosClientesAsync();

    Task<Cliente> BuscarPorNumeroContatoAsync(string numeroContato);

    Task<Cliente> AtualizarEmailAsync(Cliente cliente);

    Task<Cliente> AtualizarNumeroContatoAsync(Cliente cliente);

    Task<bool> DeletarPorEmailAsync(string email);
}