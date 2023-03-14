using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notify.Services.MessageAPI;
using Notify.Services.MessageAPI.DBContexts;
using Notify.Services.MessageAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

//Controllers
builder.Services.AddControllers();

//DB context
builder.Services.AddDbContext<MessageDBContext>(options => options.UseSqlServer(
														builder.Configuration.GetConnectionString("MessageDBConnection")
														));

//Add services
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

//DTO Mapper
IMapper mapper = DTOMappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Swagger													
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//Dev settings
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
