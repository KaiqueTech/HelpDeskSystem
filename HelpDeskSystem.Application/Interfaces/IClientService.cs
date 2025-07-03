using HelpDeskSystem.DTO.Client;
using HelpDeskSystem.DTO.DTOs.Shared;

namespace HelpDeskSystem.Application.Interfaces;

public interface IClientService
{
    public Task<ResultDto<ClientResponseDto>> CreateClientAsync(ClientRequestDto clientRequestDto);
}