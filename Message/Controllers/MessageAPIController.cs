using Microsoft.AspNetCore.Mvc;
using Notify.Services.MessageAPI.Models.DTO;
using Notify.Services.MessageAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notify.Services.MessageAPI.Controllers
{
	[Route("api/message")]
	[ApiController]
	public class MessageAPIController : ControllerBase
	{
		protected readonly ResponseDTO _response;
		private IMessageRepository _messageRepository;

		public MessageAPIController(IMessageRepository repository)
		{
			_messageRepository= repository;
			_response= new ResponseDTO();
		}

		[HttpGet]
		public async Task<ResponseDTO> GetMessages()
		{
			try
			{
				IEnumerable<MessageDTO> messages = await _messageRepository.GetMessages();
				_response.Result = messages;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}
	
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		[HttpPost]
		public async Task<ResponseDTO> Post([FromBody] MessageDTO message)
		{
			try
			{
			  MessageDTO result = await _messageRepository.CreateMessage(message);
				_response.Result = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
