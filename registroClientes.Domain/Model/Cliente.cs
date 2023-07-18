namespace registroClientes.Domain.Model;

public class Cliente
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public List<Telefone> Telefones { get; set; } = new List<Telefone>();
}