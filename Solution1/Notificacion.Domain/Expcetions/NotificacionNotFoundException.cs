using System;

namespace Notificacion.Domain.Expcetions
{
    /// <summary>
    /// Excepción que se lanza cuando no se encuentra una notificación en el dominio.
    /// </summary>
    public class NotificacionNotFoundException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la excepción <see cref="NotificacionNotFoundException"/> con un mensaje específico.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        public NotificacionNotFoundException(string message) : base(message)
        {
        }
    }
}