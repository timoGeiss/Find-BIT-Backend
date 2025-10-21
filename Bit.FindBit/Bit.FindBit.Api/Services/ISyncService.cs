using Bit.FindBit.Core.Entities;

namespace Bit.FindBit.Services;

public interface ISyncService
{
    Task<IEnumerable<Organisation>> GetUpdatedOrganisations(DateTime? lastSync);
    Task<IEnumerable<Person>> GetUpdatedPersons(DateTime? lastSync);
}