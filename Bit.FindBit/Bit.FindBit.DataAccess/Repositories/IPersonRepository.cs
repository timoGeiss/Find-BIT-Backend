using Bit.FindBit.Core.Entities;

namespace Bit.FindBit.DataAccess.Repositories;

public interface IPersonRepository
{
    public List<Person> GetAll(QueryObject queryObject);
}