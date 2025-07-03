using HelpDeskSystem.API.Models;
using HelpDeskSystem.Application.Interfaces;
using HelpDeskSystem.DTO.Client;
using HelpDeskSystem.DTO.DTOs.Shared;
using HelpDeskSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem.Application.Services;

public class ClientService : IClientService
{
    private readonly AppDbContext _context;

    public ClientService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultDto<ClientResponseDto>> CreateClientAsync(ClientRequestDto clientRequestDto)
    {
        var existingClient  = _context.Clients.FirstOrDefaultAsync(cl => cl.IdClient == clientRequestDto.Id);
        if (existingClient != null)
        {
            return ResultDto<ClientResponseDto>.Fail($"Já existe um cliente com o ID {clientRequestDto.Id}.");
        }

        
        var newClient = new ClientModel(//TODO);
        
    }
}