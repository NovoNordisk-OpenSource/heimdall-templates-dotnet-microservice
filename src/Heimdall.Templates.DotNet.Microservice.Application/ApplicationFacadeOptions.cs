namespace Heimdall.Templates.DotNet.Microservice.Application;

/// <summary>
///     Represents the options for the application facade.
/// </summary>
public sealed class ApplicationFacadeOptions
{
    /// <summary>
    ///     Gets or sets the connection strings configuration section.
    /// </summary>
    [Required]
    public IConfigurationSection? ConnectionStrings { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether auto migrations are enabled.
    /// </summary>
    public bool EnableAutoMigrations { get; set; } = false;
}