namespace Notificacion.Domain.Factories;

using Notificacion.Domain.Aggregates;
using Notificacion.Domain.ValueObjects;

/// <summary>
/// Fábrica estática para la creación de instancias de <see cref="Notificacion"/>.
/// Centraliza la lógica de construcción de notificaciones en el dominio.
/// </summary>
public static class NotificacionFactory
{
    /// <summary>
    /// Crea una nueva instancia de <see cref="Notificacion"/> con los valores proporcionados.
    /// </summary>
    /// <param name="id">Identificador único de la notificación.</param>
    /// <param name="subastaId">Identificador de la subasta.</param>
    /// <param name="usuarioId">Identificador del usuario.</param>
    /// <param name="tipo">Tipo de la notificación.</param>
    /// <param name="contenido">Contenido de la notificación.</param>
    /// <param name="enviada">Indica si la notificación ya fue enviada.</param>
    /// <returns>Una nueva instancia de <see cref="Notificacion"/>.</returns>
    public static Notificacion Create(
        NotificacionId id,
        SubastaId subastaId,
        UsuarioId usuarioId,
        TipoNotificacion tipo,
        ContenidoNotificacion contenido,
        bool enviada)
    {
        return new Notificacion(
            id,
            subastaId,
            usuarioId,
            tipo,
            contenido,
            enviada
        );
    }
}