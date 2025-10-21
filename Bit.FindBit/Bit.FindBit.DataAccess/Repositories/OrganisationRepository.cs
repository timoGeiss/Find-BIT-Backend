using Bit.FindBit.Core.Entities;
using Bit.FindBit.DataAccess.DbAccess;
using Microsoft.EntityFrameworkCore;

namespace Bit.FindBit.DataAccess.Repositories;

public class OrganisationRepository(AppDbContext dbContext) : IOrganisationRepository
{
    public List<Organisation> GetAll(QueryObject queryObject)
    {
        var query = dbContext.Organisations
            .Include(p => p.PhoneNumbers)
            .AsQueryable();

        if (!string.IsNullOrEmpty(queryObject.Query))
        {
            query = query.Where(o => 
                o.Responsibilities.Contains(queryObject.Query)
                || o.Name.Contains(queryObject.Query));
        }

        if (queryObject.Picket != null)
        {
            query = query.Where(o => o.Picket == queryObject.Picket);
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