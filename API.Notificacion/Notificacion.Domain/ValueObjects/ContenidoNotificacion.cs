using Notificacion.Domain.Expcetions;

namespace Notificacion.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa el contenido de una notificación.
    /// </summary>
    public class ContenidoNotificacion
    {
        /// <summary>
        /// Valor del contenido de la notificación.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ContenidoNotificacion"/>.
        /// </summary>
        /// <param name="value">Contenido de la notificación.</param>
        /// <exception cref="ValueObjectValidationException">
        /// Se lanza si el valor es nulo, vacío o supera los 250 caracteres.
        /// </exception>
        public ContenidoNotificacion(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValueObjectValidationException("El contenido de la notificación no puede estar vacío.");

            if (value.Length > 250)
                throw new ValueObjectValidationException("El contenido de la notificación no puede tener más de 250 caracteres.");

            Value = value;
        }

        /// <summary>
        /// Devuelve el contenido de la notificación como cadena.
        /// </summary>
        public override string ToString() => Value.ToString();
    }
}