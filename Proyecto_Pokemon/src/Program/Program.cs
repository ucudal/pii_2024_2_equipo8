using Ucu.Poo.DiscordBot.Services;

namespace Proyecto_Pokemon
{
    class Program
    {
        //Inicialización de programa con bot
        private static void Main()
        {
            DemoBot();
        }
        
        private static void DemoBot()
        {
            BotLoader.LoadAsync().GetAwaiter().GetResult();
        }
    }
}