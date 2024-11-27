using Microsoft.Extensions.DependencyInjection;

namespace Ucu.Poo.DiscordBot.Services;

/// <summary>
/// La interfaz del Bot de Discord para usar con inyección de dependencias.
/// </summary>
public interface IBot
{
    /// <summary>
    /// 
    /// </summary>
    Task StartAsync(ServiceProvider services);

    /// <summary>
    /// 
    /// </summary>
    Task StopAsync();
}