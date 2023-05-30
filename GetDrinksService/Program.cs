using Microsoft.EntityFrameworkCore;
using DrinksService;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql("Host=hattie.db.elephantsql.com;Port=5432;Database=rlxecvyi;Username=rlxecvyi;Password=XnTYL31vCfvzyNPkZ32kF6FHZ0FjZ9v4"));
//"Host=localhost;Port=5432;Database=AlcoDB;Username=postgres;Password=boberman"

builder.Services.AddScoped<IDrinksManager, DrinksManager>();
builder.Services.AddScoped<IDrinkReviewsManager, DrinkReviewManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();