using Microsoft.EntityFrameworkCore;
using PiesService;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql("Host=hattie.db.elephantsql.com;Port=5432;Database=rlxecvyi;Username=rlxecvyi;Password=XnTYL31vCfvzyNPkZ32kF6FHZ0FjZ9v4"));
//"Host=localhost;Port=5432;Database=AlcoDB;Username=postgres;Password=boberman"
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
builder.Services.AddScoped<IRecipesManager, RecipesManager>();
builder.Services.AddScoped<IRecipeReviewsManager, RecipeReviewsManager>();
builder.Services.AddScoped<IPicturesManager, PicturesManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
