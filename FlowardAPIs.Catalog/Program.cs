using FlowardEntities.Catalog.DBContexts;
using FlowardEntities.Catalog.Models;
using FlowardRepos.Repos;
using FlowardServices.Catalog.Implementations;
using FlowardServices.Catalog.Interfaces;
using FlowardServices.Implementations;
using FlowardServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services
// Add services to the container.
builder.Services.AddControllers();

//Add DB Contexts
builder.Services.AddDbContext<CatalogContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FlowardDatabse")));
builder.Services.AddTransient<DbContext, CatalogContext>();

//Add DI Services
builder.Services.AddTransient(typeof(IBaseRepoitory<>), typeof(IBaseRepository<>));
builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddTransient<ICatalogService, CatalogService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Gateway
//builder.Services.AddOcelot(builder.Configuration);
#endregion


#region Configure App
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

//app.UseOcelot();

app.Run();
#endregion