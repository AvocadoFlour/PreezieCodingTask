using PreezieCodingTask.Database;
using Microsoft.EntityFrameworkCore;
using PreezieCodingTask.Entities.User;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<UsersContext>(options =>
options.UseInMemoryDatabase("UserList"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsersContext, UsersContext>();
var app = builder.Build();

DbInizializer.Seed(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("https://localhost:4000");
