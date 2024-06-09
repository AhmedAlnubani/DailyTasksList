using DailyTasksList.Api.Extinstion;
using DailyTasksList.Application.Services;
using DailyTasksList.Persistence.Services;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//Add Services
builder.Services.AddPersistenceServices(config);
builder.Services.AddApplicationServices();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add Swageger 
builder.Services.Swagger();

// Adding Jwt Bearer
builder.Services.JWT(config);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//Add CORS
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
app.UseAuthentication();
app.MapControllers();

app.Run();
