using Notify.Services.MessageAPI.Models.DTO;

namespace Notify.Services.MessageAPI.Repository
{
	public interface IMessageRepository
	{
		Task<MessageDTO> CreateMessage(MessageDTO message);
		Task<IEnumerable<MessageDTO>> GetMessages();
	}
}
