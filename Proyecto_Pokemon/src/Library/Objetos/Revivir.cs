namespace Proyecto_Pokemon;

public class Revivir : Objetos
{
    public Revivir() : base("Revivir") { }

    public void Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        Console.WriteLine("Elige el número del Pokémon que quieres revivir:");
        entrenador.MostrarPokemones();

        int opcionPokemon = int.Parse(Console.ReadLine()) - 1;
        Pokemon pokemonParaRevivir = entrenador.Pokemones[opcionPokemon];

        if (pokemonParaRevivir.Vida <= 0)
        {
            pokemonParaRevivir.Vida = (int)(pokemonParaRevivir.VidaBase / 2);
            Console.WriteLine($"{pokemonParaRevivir.Nombre} ha sido revivido con {pokemonParaRevivir.Vida} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemonParaRevivir.Nombre} no está debilitado. No puedes revivirlo.");
        }
    }
}