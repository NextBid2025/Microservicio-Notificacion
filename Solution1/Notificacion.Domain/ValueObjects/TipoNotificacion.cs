using Notificacion.Domain.Expcetions;

namespace Notificacion.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa el tipo de una notificación.
    /// </summary>
    public class TipoNotificacion
    {
        /// <summary>
        /// Valor del tipo de notificación.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="TipoNotificacion"/>.
        /// </summary>
        /// <param name="value">Valor del tipo de notificación.</param>
        /// <exception cref="ValueObjectValidationException">
        /// Se lanza si el valor es nulo, vacío o supera los 30 caracteres.
        /// </exception>
        public TipoNotificacion(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValueObjectValidationException("El tipo de notificación no puede estar vacío.");

            if (value.Length > 30)
                throw new ValueObjectValidationException("El tipo de notificación no puede tener más de 30 caracteres.");

            Value = value;
        }

        /// <summary>
        /// Devuelve el valor del tipo de notificación como cadena.
        /// </summary>
        public override string ToString() => Value.ToString();
    }
}