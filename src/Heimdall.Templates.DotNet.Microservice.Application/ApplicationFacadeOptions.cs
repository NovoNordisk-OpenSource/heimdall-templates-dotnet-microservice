namespace Heimdall.Templates.DotNet.Microservice.Application;

using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

public sealed class ApplicationFacadeOptions
{
    [Required]
    public IConfigurationSection? ConnectionStrings { get; set; }

    public bool EnableAutoMigrations { get; set; } = false;
}