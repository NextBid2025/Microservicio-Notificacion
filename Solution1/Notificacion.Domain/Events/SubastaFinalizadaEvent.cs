using MediatR;
using System;

namespace Notificacion.Domain.Events
{
    public class SubastaFinalizadaEvent : INotification
    {
        public string SubastaId { get; }
        public string? GanadorId { get; }
        public string Mensaje { get; }
        public DateTime FechaFinalizacion { get; }

        public SubastaFinalizadaEvent(
            string subastaId,
            string? ganadorId,
            string mensaje,
            DateTime fechaFinalizacion)
        {
            SubastaId = subastaId;
            GanadorId = ganadorId;
            Mensaje = mensaje;
            FechaFinalizacion = fechaFinalizacion;
        }
    }
}