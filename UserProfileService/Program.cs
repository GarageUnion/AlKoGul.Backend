using Microsoft.EntityFrameworkCore;
using UserProfileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UsersContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=AlcoDB;Username=postgres;Password=boberman"));
//"Host=localhost;Port=5432;Database=AlcoDB;Username=postgres;Password=boberman"
//"Host=hattie.db.elephantsql.com;Port=5432;Database=rlxecvyi;Username=rlxecvyi;Password=XnTYL31vCfvzyNPkZ32kF6FHZ0FjZ9v4"
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000"); // add the allowed origins  
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();


                          
                      });
});
builder.Services.AddScoped<IUsersManager, UsersManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
