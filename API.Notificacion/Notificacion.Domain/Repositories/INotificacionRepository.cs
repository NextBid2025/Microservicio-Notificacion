namespace Notificacion.Domain.Repositories;

using Notificacion.Domain.Aggregates;
using Notificacion.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface INotificacionRepository
{
    Task<Notificacion?> GetByIdAsync(NotificacionId id);
    Task<IEnumerable<Notificacion>> GetAllAsync();
    Task AddAsync(Notificacion notificacion);
    Task UpdateAsync(Notificacion notificacion);
    Task DeleteAsync(NotificacionId id);
}