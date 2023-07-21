namespace registroClientes.Application.Dtos;

public class ClienteDto
{
    public int Id { get; set; }
    public string? NomeCompleto { get; set; }
    public string? Email { get; set; }
    public List<TelefoneDto>? Telefones { get; set; }
}