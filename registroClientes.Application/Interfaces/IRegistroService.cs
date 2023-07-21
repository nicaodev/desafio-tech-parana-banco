using registroClientes.Application.Dtos;

namespace registroClientes.Application.Interfaces;

public interface IRegistroService
{
    Task<ClienteDto> BuscarPorNumeroContato(string numeroContato);

    Task CadastrarCliente(ClienteDto cliente);

    Task<IEnumerable<ClienteDto>> BuscarTodosClientes();

    Task AtualizarEmail(ClienteDto cliente);

    Task AtualizarNumeroContato(ClienteDto cliente);

    Task<bool> DeletarPorEmail(string email);
}