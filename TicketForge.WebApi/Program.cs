using Catalog.Module;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCatalogModule(builder.Configuration);

var app = builder.Build();

app.MapHealthChecks("/health");
app.UseHttpsRedirection();

app.Run();