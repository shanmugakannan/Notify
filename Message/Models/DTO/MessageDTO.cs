using System.ComponentModel.DataAnnotations;

namespace Notify.Services.MessageAPI.Models.DTO
{
	public class MessageDTO
	{
		public string? Subject { get; set; }
		public string? Body { get; set; }
		public Guid TopicID { get; set; }

	}
}
