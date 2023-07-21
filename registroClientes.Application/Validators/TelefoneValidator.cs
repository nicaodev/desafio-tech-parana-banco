using FluentValidation;
using registroClientes.Application.Dtos;

namespace registroClientes.Application.Validators;

public class TelefoneValidator : AbstractValidator<TelefoneDto>
{
    public TelefoneValidator()
    {
        RuleFor(t => t.DDD_Numero).NotNull().NotEmpty().WithMessage("Numero de Telefone obrigatório");
        RuleFor(t => t.Tipo).NotNull().NotEmpty().WithMessage("Tipo de Telefone obrigatório");
    }
}