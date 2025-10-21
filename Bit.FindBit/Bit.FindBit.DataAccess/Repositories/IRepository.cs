using Bit.FindBit.Core.Entities;

namespace Bit.FindBit.DataAccess.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    public List<T> GetAll(QueryObject queryObject);
    Task<IEnumerable<T>> GetUpdatedSinceAsync(DateTime? lastSync);
}