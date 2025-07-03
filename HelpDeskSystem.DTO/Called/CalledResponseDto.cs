using HelpDeskSystem.DTO.Messages;

namespace DefaultNamespace;

public class CalledResponseDto
{
        public int IdCalled { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;

        public int TechnicalId { get; set; }
        public string Technical { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }
        public DateTime? DateClose { get; set; }

        public string Status { get; set; } = "Open";

        public List<MessageResponseDto> Messages { get; set; } = new();
}