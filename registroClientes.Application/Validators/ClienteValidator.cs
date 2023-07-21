using FluentValidation;
using registroClientes.Application.Dtos;

namespace registroClientes.Application.Validators;

public class ClienteValidator : AbstractValidator<ClienteDto>
{
    public ClienteValidator()
    {
        RuleFor(p => p.NomeCompleto).NotEmpty().NotNull().WithMessage("Nome Completo é um campo obrigatório");
        RuleFor(p => p.Email).NotEmpty().NotNull().WithMessage("E-mail é um campo obrigatório");
    }
}