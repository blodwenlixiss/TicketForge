using Catalog.Module;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCatalogModule();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();