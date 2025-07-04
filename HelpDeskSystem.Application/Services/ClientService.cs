using AutoMapper;
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
    private readonly IMapper _mapper;

    public ClientService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ResultDto<ClientResponseDto>> CreateClientAsync(ClientRequestDto clientRequestDto)
    {
        try
        {
            var existingClient  = _context.Clients.FirstOrDefaultAsync(cl => cl.IdClient == clientRequestDto.Id);
            if (existingClient != null)
            {
                return ResultDto<ClientResponseDto>.Fail($"Já existe um cliente com o ID {clientRequestDto.Id}.");
            }


            var newClient = _mapper.Map<ClientModel>(clientRequestDto);

            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
        
            var clientResponse = _mapper.Map<ClientResponseDto>(newClient);
        
            return ResultDto<ClientResponseDto>.Ok(clientResponse, "Cliente criado com sucesso.");

        }
        catch (Exception ex)
        {
            return ResultDto<ClientResponseDto>.Fail($"Ocorreu um erro ao criar o cliente: {ex.Message}");
        }
    }
}