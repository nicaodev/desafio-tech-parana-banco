using AutoMapper;
using registroClientes.Application.Dtos;
using registroClientes.Domain.Model;

namespace registroClientes.Application.MappingAutoMapper;

public class DomainToDto : Profile
{
    public DomainToDto()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Telefone, TelefoneDto>().ReverseMap();
    }
}