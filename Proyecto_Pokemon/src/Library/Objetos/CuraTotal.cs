namespace Proyecto_Pokemon;

public class CuraTotal : Objetos
{
    public CuraTotal() : base("Cura Total") { }

    public void Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado == null)
        {
            Console.WriteLine($"{pokemon.Nombre} no está afectado por ningún estado alterado.");
            return;
        }

        pokemon.Estado = null;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Todos los efectos negativos fueron curados.");
    }
}