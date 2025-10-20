using Bit.FindBit.Core.Entities;
using Bit.FindBit.Services;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bit.FindBit.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController(ISearchService searchService) : Controller
{
    [HttpGet]
    public IActionResult GetAll(
        string query,
        bool picket,
        string type,
        int offset,
        int limit)
    {
        try
        {
            var queryObj = new QueryObject
            {
                Query = query,
                Picket = picket,
                Type = type,
                Offset = offset,
                Limit = limit
            };
            return Ok(searchService.GetAll(queryObj));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}