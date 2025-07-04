using HelpDeskSystem.Application.Interfaces;
using HelpDeskSystem.DTO.Client;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskSystem.API.Controllers.Client;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    [HttpPost]
    public async Task<IActionResult> CreateClientAsync(ClientRequestDto clientRequestDto)
    {
        try
        {
            if (clientRequestDto == null)
            {
                return NotFound();
            }
            var client = await _clientService.CreateClientAsync(clientRequestDto);
        
            return Ok(client);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}