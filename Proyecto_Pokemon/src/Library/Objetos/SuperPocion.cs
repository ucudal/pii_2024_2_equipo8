namespace Proyecto_Pokemon;

public class SuperPocion : Objetos
{
    public SuperPocion() : base("Súper Poción") { }

    public void Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida <= 0)
        {
            Console.WriteLine($"{pokemon.Nombre} está debilitado y no puede usar una Super Poción.");
            return;
        }

        int vidaRecuperada = 70;
        if ((vidaRecuperada + pokemon.Vida) > pokemon.VidaBase)
        {
            Console.WriteLine($"{pokemon.Nombre} no puede curarse más de la vida base, pierdes el objeto.");
            return;
        }

        pokemon.Vida += vidaRecuperada;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.");
    }
}