using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notificacion.Application.Commands;
using Notificacion.Domain.Factories;
using Notificacion.Domain.Repositories;
using Notificacion.Domain.ValueObjects;

namespace Notificacion.Application.Handlers
{
    /// <summary>
    /// Manejador para el comando de subasta finalizada.
    /// Se encarga de crear la notificación correspondiente.
    /// </summary>
    public class SubastaFinalizadaCommandHandler : IRequestHandler<SubastaFinalizadaCommand, SubastaFinalizadaResult>
    {
        private readonly INotificacionRepository _notificacionRepository;

        /// <summary>
        /// Inicializa una nueva instancia del manejador de subasta finalizada.
        /// </summary>
        /// <param name="notificacionRepository">Repositorio de notificaciones.</param>
        public SubastaFinalizadaCommandHandler(
            INotificacionRepository notificacionRepository)
        {
            _notificacionRepository = notificacionRepository ?? throw new ArgumentNullException(nameof(notificacionRepository));
        }

        /// <summary>
        /// Maneja la creación de la notificación por subasta finalizada.
        /// </summary>
        /// <param name="request">Comando de subasta finalizada.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Resultado con el identificador de la notificación creada.</returns>
        public async Task<SubastaFinalizadaResult> Handle(SubastaFinalizadaCommand request, CancellationToken cancellationToken)
        {
            var notificacionId = Guid.NewGuid();

            var notificacion = NotificacionFactory.Create(
                new NotificacionId(notificacionId),
                new SubastaId(Guid.Parse(request.SubastaId)),
                string.IsNullOrEmpty(request.GanadorId) ? null : new UsuarioId(Guid.Parse(request.GanadorId)),
                new TipoNotificacion("Ganador"),
                new ContenidoNotificacion(request.Mensaje),
                false
            );

            if (notificacion == null)
                throw new InvalidOperationException("No se pudo crear la notificación.");

            await _notificacionRepository.AddAsync(notificacion);

            return new SubastaFinalizadaResult(notificacionId);
        }
    }
}