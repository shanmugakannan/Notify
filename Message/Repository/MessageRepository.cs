using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notify.Services.MessageAPI.DBContexts;
using Notify.Services.MessageAPI.Models;
using Notify.Services.MessageAPI.Models.DTO;
using Notify.Services.MessageAPI.Repository.Helpers;

namespace Notify.Services.MessageAPI.Repository
{
	public class MessageRepository : IMessageRepository
	{
		private readonly MessageDBContext _db;
		private IMapper _mapper;

		public MessageRepository(MessageDBContext dbContext,IMapper mapper)
		{
			_db = dbContext;
			_mapper = mapper;
		}
		public async Task<MessageDTO> CreateMessage(MessageDTO message)
		{
			//Argument Null check
			if (message == null)
			{
				throw new ArgumentException(nameof(message));
			}

			//Model validation
			ValidationHelper.ValidateModel(message);
			Message newMessage = _mapper.Map<MessageDTO, Message>(message);
			_db.Messages.Add(newMessage);
			await _db.SaveChangesAsync();
			return _mapper.Map<Message, MessageDTO>(newMessage);
		}

		public async Task<IEnumerable<MessageDTO>> GetMessages()
		{
			List<Message> messages = await _db.Messages.ToListAsync();
			return _mapper.Map<List<MessageDTO>>(messages);
		}
	}
}
