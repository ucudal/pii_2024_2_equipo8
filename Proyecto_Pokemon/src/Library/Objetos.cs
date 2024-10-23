namespace Proyecto_Pokemon;
public enum TipoObjeto
{
    SuperPocion,
    Revivir,
    CuraTotal
}
public class Objetos
{
    public string Nombre { get; }
    public TipoObjeto Tipo { get; }

    public Objetos(TipoObjeto tipo)
    {
        Tipo = tipo;

        switch (tipo)
        {
            case TipoObjeto.SuperPocion:
                Nombre = "Súper Poción";
                break;
            case TipoObjeto.Revivir:
                Nombre = "Revivir";
                break;
            case TipoObjeto.CuraTotal:
                Nombre = "Cura Total";
                break;
        }
    }

    public void Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        switch (Tipo)
        {
            case TipoObjeto.SuperPocion:
                UsarSuperPocion(pokemon, entrenador);
                break;
            case TipoObjeto.Revivir:
                RevivirPokemon(entrenador);
                break;
            case TipoObjeto.CuraTotal:
                UsarCuraTotal(pokemon, entrenador);
                break;
        }
    }

    private void UsarSuperPocion(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida <= 0)
        {
            Console.WriteLine($"{pokemon.Nombre} está debilitado y no puede usar una Super Pocion.");
            return;
        }
        int vidaRecuperada = 70;
        if ((vidaRecuperada + pokemon.Vida) > 500)
        {
            Console.WriteLine($"{pokemon.Nombre} no puede curarse más de la vida base, pierdes el objeto.");
            return;
        } 
        pokemon.Vida += vidaRecuperada;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.");
    }

    private void RevivirPokemon(Entrenadores entrenador)
    {
        Console.WriteLine("Elige el número del Pokémon que quieres revivir:");
        entrenador.MostrarPokemones();

        int opcionPokemon = int.Parse(Console.ReadLine()) - 1;
        Pokemon pokemonParaRevivir = entrenador.Pokemones[opcionPokemon];

        if (pokemonParaRevivir.Vida <= 0)
        {
            pokemonParaRevivir.Vida = 500 / 2;
            Console.WriteLine($"{pokemonParaRevivir.Nombre} ha sido revivido con {pokemonParaRevivir.Vida} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemonParaRevivir.Nombre} no está debilitado. No puedes revivirlo.");
        }
    }

    private void UsarCuraTotal(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado != null)
        {
            Console.WriteLine($"{pokemon.Nombre} no está afectado por ningún estado alterado.");
            return;
        }

        pokemon.Estado = null;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Todos los efectos negativos fueron curados.");
    }
}