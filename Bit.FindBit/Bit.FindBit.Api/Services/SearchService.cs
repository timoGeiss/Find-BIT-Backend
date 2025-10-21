using Bit.FindBit.Core.Entities;
using Bit.FindBit.DataAccess.Repositories;
using Bit.FindBit.Dtos;
using Microsoft.OpenApi.Services;

namespace Bit.FindBit.Services;

public class SearchService(IPersonRepository personRepository, IOrganisationRepository organisationRepository) : ISearchService
{
    public GeneralResponse GetAll(QueryObject queryObject)
    {
        var result = new GeneralResponse();
        
        result.queryObject = queryObject;
        
        if (queryObject.Type is null or "person")
        {
            result.Persons = personRepository.GetAll(queryObject); 
        }

        if (queryObject.Type is null or "organization")
        {
            result.Organisations = organisationRepository.GetAll(queryObject);
        }
        
        return result;
    }
}