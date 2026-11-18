using System.ComponentModel.DataAnnotations;

namespace Catalog.Module;

public class DatabaseOptions
{
    [Required] public string Host { get; set; } = string.Empty;
    [Required] public string Name { get; set; } = string.Empty;
    [Range(1, 65535)] public int Port { get; set; }

    [Required] public string UserName { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;

    public string ConnectionString =>
        $"Host={Host};Port={Port};Database={Name};Username={UserName};Password={Password}";
}