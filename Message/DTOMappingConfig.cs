using AutoMapper;
using Notify.Services.MessageAPI.Models.DTO;
using Notify.Services.MessageAPI.Models;

namespace Notify.Services.MessageAPI
{
	public class DTOMappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<Message, MessageDTO>();
				config.CreateMap<MessageDTO, Message>();
			});
			return mappingConfig;
		}
	}
}
