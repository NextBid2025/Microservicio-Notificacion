
using Notificacion.Domain.ValueObjects;

namespace Notificacion.Domain.Aggregates;

/// <summary>
/// Representa una notificación dentro del dominio.
/// </summary>
public class Notificacion
{
    public NotificacionId Id { get; private set; }
    public SubastaId SubastaId { get; private set; }
    public UsuarioId UsuarioId { get; private set; }
    public TipoNotificacion Tipo { get; private set; }
    public ContenidoNotificacion Contenido { get; private set; }
    public bool Enviada { get; private set; }
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaEnvio { get; private set; }
    public DateTime? FechaModificacion { get; private set; }

    /// <summary>
    /// Constructor privado para Entity Framework.
    /// </summary>
    private Notificacion() { }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Notificacion"/>.
    /// </summary>
    public Notificacion(
        NotificacionId id,
        SubastaId subastaId,
        UsuarioId usuarioId,
        TipoNotificacion tipo,
        ContenidoNotificacion contenido,
        bool enviada
    )
    {
        Id = id;
        SubastaId = subastaId;
        UsuarioId = usuarioId;
        Tipo = tipo;
        Contenido = contenido;
        Enviada = enviada;
        FechaCreacion = DateTime.UtcNow;
        FechaEnvio = enviada ? DateTime.UtcNow : null;
        FechaModificacion = null;
    }

    /// <summary>
    /// Actualiza los datos de la notificación.
    /// </summary>
    public void ActualizarNotificacion(
        string? tipo,
        string? contenido,
        bool? enviada = null
    )
    {
        if (tipo != null)
        {
            Tipo = new TipoNotificacion(tipo);
        }
        if (contenido != null)
        {
            Contenido = new ContenidoNotificacion(contenido);
        }
        if (enviada != null)
        {
            Enviada = enviada.Value;
            FechaEnvio = enviada.Value ? DateTime.UtcNow : null;
        }
        FechaModificacion = DateTime.UtcNow;
    }
}