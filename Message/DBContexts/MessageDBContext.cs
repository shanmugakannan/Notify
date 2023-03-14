using Microsoft.EntityFrameworkCore;
using Notify.Services.MessageAPI.Models;

namespace Notify.Services.MessageAPI.DBContexts
{
	public class MessageDBContext:DbContext
	{
		public MessageDBContext(DbContextOptions<MessageDBContext> options) : base(options)
		{
		}

		public DbSet<Message> Messages { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Message>().ToTable("Messages");
		}
	}
}
