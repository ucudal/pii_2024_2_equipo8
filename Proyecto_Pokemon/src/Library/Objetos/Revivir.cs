namespace Proyecto_Pokemon;

public class Revivir : Objetos
{
    public Revivir() : base("Revivir") { }

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