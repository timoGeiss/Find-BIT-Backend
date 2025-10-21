using Bit.FindBit.Core.Entities;
using Bit.FindBit.Core.Enums;
using Bit.FindBit.DataAccess.DbAccess;
using Microsoft.EntityFrameworkCore;

namespace Bit.FindBit.DataAccess.Repositories;

public class PersonRepository(AppDbContext appDbContext) : IPersonRepository
{
    public List<Person> GetAll(QueryObject queryObject)
    {
        var query = appDbContext.Persons
            .Include(p => p.PhoneNumbers)
            .AsQueryable();
        
        if (!string.IsNullOrEmpty(queryObject.Query))
        {
            query = query.Where(p => 
                p.Responsibilities.Contains(queryObject.Query)
                || p.FirstName.Contains(queryObject.Query)
                || p.LastName.Contains(queryObject.Query));
        }

        if (queryObject.Picket is true)
        {
            query = query.Where(p => p.PhoneNumbers.Count(n => n.Type == PhoneNumberType.Picket) > 0);
        }
        if (queryObject.Picket is false)
        {
            query = query.Where(p => p.PhoneNumbers.Count(n => n.Type == PhoneNumberType.Picket) == 0);
        }

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
}