namespace registroClientes.Domain.Model;

public class Telefone
{
    public int Id { get; set; } 
    public string DDD_Numero { get; set; }

    public string Tipo { get; set; }

    public int ClienteId { get; set; }

    public Cliente Cliente { get; set; }
}