using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Application;
using HR.LeaveManagement.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
	.WriteTo.Console()
	.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers();

// Allow CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("All", o =>
								o.AllowAnyOrigin()
								.AllowAnyHeader()
								.AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseCors("All");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
