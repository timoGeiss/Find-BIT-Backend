using Bit.FindBit.Core.Entities;
using Bit.FindBit.DataAccess.Repositories;

namespace Bit.FindBit.Services;

public class SyncService(IRepository<Organisation> organisationRepository, IRepository<Person> personRepository) : ISyncService
{
    public Task<IEnumerable<Organisation>> GetUpdatedOrganisations(DateTime? lastSync) =>
        organisationRepository.GetUpdatedSinceAsync(lastSync);

    public Task<IEnumerable<Person>> GetUpdatedPersons(DateTime? lastSync) =>
        personRepository.GetUpdatedSinceAsync(lastSync);
}