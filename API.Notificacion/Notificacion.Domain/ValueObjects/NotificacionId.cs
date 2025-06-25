using System;
using Notificacion.Domain.Expcetions;

namespace Notificacion.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa el identificador único de una notificación.
    /// </summary>
    public class NotificacionId
    {
        /// <summary>
        /// Valor del identificador.
        /// </summary>
        public Guid Value { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="NotificacionId"/>.
        /// </summary>
        /// <param name="value">Valor del identificador.</param>
        /// <exception cref="ValueObjectValidationException">
        /// Se lanza si el valor es Guid.Empty.
        /// </exception>
        public NotificacionId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ValueObjectValidationException("El identificador de notificación no puede estar vacío.");

            Value = value;
        }

        /// <summary>
        /// Devuelve el valor del identificador como cadena.
        /// </summary>
        public override string ToString() => Value.ToString();
    }
}