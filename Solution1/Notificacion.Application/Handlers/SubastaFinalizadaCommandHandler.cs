using BluidingBlocks.CQRS;
using MediatR;
using Notificacion.Application.Commands;
using Notificacion.Domain.Factories;
using Notificacion.Domain.Repositories;
using Notificacion.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notificacion.Application.Handlers
{
    public class SubastaFinalizadaCommandHandler : ICommandHandler<SubastaFinalizadaCommand, SubastaFinalizadaResult>
    {
        private readonly INotificacionRepository _notificacionRepository;
        private readonly INotificacionFactory _notificacionFactory;

        public SubastaFinalizadaCommandHandler(
            INotificacionRepository notificacionRepository,
            INotificacionFactory notificacionFactory)
        {
            _notificacionRepository = notificacionRepository ?? throw new ArgumentNullException(nameof(notificacionRepository));
            _notificacionFactory = notificacionFactory ?? throw new ArgumentNullException(nameof(notificacionFactory));
        }

        public async Task<SubastaFinalizadaResult> Handle(SubastaFinalizadaCommand request, CancellationToken cancellationToken)
        {
            // Validación adicional si es necesario

            var notificacionId = Guid.NewGuid();
            var notificacion = _notificacionFactory.Create(
                new NotificacionId(notificacionId),
                new SubastaId(request.SubastaId),
                request.GanadorId != null ? new UsuarioId(request.GanadorId) : null,
                new TipoNotificacion("SubastaFinalizada"),
                new ContenidoNotificacion(request.Mensaje),
                false,
                request.FechaFinalizacion
            );

            await _notificacionRepository.AddAsync(notificacion);

            return new SubastaFinalizadaResult(notificacionId);
        }
    }
}