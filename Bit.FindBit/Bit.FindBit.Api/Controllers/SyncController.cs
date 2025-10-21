using System.ComponentModel.DataAnnotations;
using Bit.FindBit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bit.FindBit.Controllers;
[ApiController]
[Route("api/sync")]
public class SyncController(ISyncService syncService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Sync([FromQuery , Required] DateTime? lastSync)
    {
        var organisations = await syncService.GetUpdatedOrganisations(lastSync);
        var persons = await syncService.GetUpdatedPersons(lastSync);

        return Ok(new
        {
            Organisations = organisations,
            Persons = persons
        });
    }
}