using Bit.FindBit.Core.Entities;
using Bit.FindBit.Core.Enums;
using Bit.FindBit.DataAccess.DbAccess;
using Microsoft.EntityFrameworkCore;

namespace Bit.FindBit.DataAccess.Repositories;

public class PersonRepository(AppDbContext dbContext) : IRepository<Person>
{
    public List<Person> GetAll(QueryObject queryObject)
    {
        var query = dbContext.Persons
            .Include(p => p.PhoneNumbers)
            .AsQueryable();
        
        if (!string.IsNullOrEmpty(queryObject.Query))
        {
            query = query.Where(p => 
                p.Responsibilities.Contains(queryObject.Query)
                || p.FirstName.Contains(queryObject.Query)
                || p.LastName.Contains(queryObject.Query));
        }

        query = queryObject.Picket switch
        {
            true => query.Where(p => p.PhoneNumbers.Count(n => n.Type == PhoneNumberType.Picket) > 0),
            false => query.Where(p => p.PhoneNumbers.Count(n => n.Type == PhoneNumberType.Picket) == 0),
            _ => query
        };
        
        if (queryObject.Offset is >= 0)
        {
            query = query.Skip(queryObject.Offset.Value);
        }

        if (queryObject.Limit is >= 0)
        {
            query = query.Take(queryObject.Limit.Value);
        }
        
        return query.ToList();
    }
    public async Task<IEnumerable<Person>> GetUpdatedSinceAsync(DateTime? lastSync)
    {
        IQueryable<Person> query = dbContext.Persons
            .Include(p => p.PhoneNumbers)
            .Include(p => p.Organisation);

        if (lastSync.HasValue)
            query = query.Where(p => p.UpdatedAt > lastSync.Value
                                     || p.PhoneNumbers.Any(pn => pn.UpdatedAt > lastSync.Value));

        return await query.ToListAsync();
    }
}