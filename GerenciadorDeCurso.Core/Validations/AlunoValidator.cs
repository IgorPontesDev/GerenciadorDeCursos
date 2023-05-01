using FluentValidation;
using GerenciadorDeCurso.Core.DTOs;

namespace GerenciadorDeCurso.Core.Validations;

public class AlunoValidator : AbstractValidator<AlunoDTO>
{
    public AlunoValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(p => p.CPF).NotEmpty().Length(11).WithMessage("CPF INVÁLIDO - PRECISA TER 11 CARACTERES");
        RuleFor(p => p.Email).NotEmpty().EmailAddress().WithMessage("Email inválido");
        RuleFor(p => p.TurmaId).NotEmpty().WithMessage("O aluno precisa estar cadastrado em pelo menos uma turma");
    }
}
