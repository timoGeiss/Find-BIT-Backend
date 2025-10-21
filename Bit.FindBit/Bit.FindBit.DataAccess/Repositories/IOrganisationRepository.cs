using Bit.FindBit.Core.Entities;

namespace Bit.FindBit.DataAccess.Repositories;

public interface IOrganisationRepository
{
    public List<Organisation> GetAll(QueryObject queryObject);
}