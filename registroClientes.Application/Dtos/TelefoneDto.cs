using registroClientes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace registroClientes.Application.Dtos;
public class TelefoneDto
{

    public int Id { get; set; }
    public string? DDD_Numero { get; set; }

    public string? Tipo { get; set; }

    public int ClienteId { get; set; }
}
