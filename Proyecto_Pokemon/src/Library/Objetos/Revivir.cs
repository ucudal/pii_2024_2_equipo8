namespace Proyecto_Pokemon;

public class Revivir : Objetos
{
    // constructor de revivir, llama al constructor base de la clase objetos y le da el nombre "revivir"
    public Revivir() : base("Revivir") { }

    // metodo para usar el objeto "Revivir" en un pokemon. Si el pokemon esta debilitado (vida <= 0),
    // lo revive con la mitad de su vida base. Si no esta debilitado, devuelve un mensaje indicando que no se puede revivir
    public string Usar(Pokemon pokemonParaRevivir, Entrenadores entrenador)
    {
        if (pokemonParaRevivir.Vida <= 0)
        {
            pokemonParaRevivir.Vida = (int)(pokemonParaRevivir.VidaBase / 2);
            return $"{pokemonParaRevivir.Nombre} ha sido revivido con {pokemonParaRevivir.Vida} puntos de vida.";
        }
        else
        {
            return $"{pokemonParaRevivir.Nombre} no está debilitado. No puedes revivirlo.";
        }
    }
}