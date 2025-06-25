using BluidingBlocks.CQRS;
using FluentValidation;
using System;

namespace Notificacion.Application.Commands;

/// <summary>
/// Comando para crear una notificación cuando una subasta finaliza.
/// </summary>
public record SubastaFinalizadaCommand(
    string SubastaId,
    string? GanadorId,
    string Mensaje,
    DateTime FechaFinalizacion
) : ICommand<SubastaFinalizadaResult>;

/// <summary>
/// Resultado del comando SubastaFinalizada.
/// </summary>
public record SubastaFinalizadaResult(Guid NotificacionId);

/// <summary>
/// Validador para SubastaFinalizadaCommand.
/// </summary>
public class SubastaFinalizadaCommandValidator : AbstractValidator<SubastaFinalizadaCommand>
{
    public SubastaFinalizadaCommandValidator()
    {
        RuleFor(x => x.SubastaId).NotEmpty().WithMessage("SubastaId es requerido");
        RuleFor(x => x.Mensaje).NotEmpty().WithMessage("Mensaje es requerido");
        RuleFor(x => x.FechaFinalizacion).NotEmpty().WithMessage("FechaFinalizacion es requerida");
        // GanadorId puede ser null (subasta desierta), así que no se valida como requerido
    }
}