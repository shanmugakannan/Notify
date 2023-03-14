using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notify.Services.MessageAPI.Models
{
	public class Message
	{
		[Key]
		public Guid Id { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }
		[Required]
		public Guid TopicID { get; set; }

	}
}
