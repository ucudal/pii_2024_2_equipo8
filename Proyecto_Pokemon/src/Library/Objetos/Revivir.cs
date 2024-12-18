namespace Proyecto_Pokemon;
/// <summary>
/// clase que representa el objeto "Revivir", que se utiliza para revivir a un pokemon debilitado con la mitad de su vida
/// </summary>
public class Revivir : Objetos
{
    /// <summary>
    /// constructor de revivir, llama al constructor base de la clase objetos y le da el nombre "revivir"
    /// </summary>
    public Revivir() : base("Revivir") { }

    /// <summary>
    /// metodo para usar el objeto "Revivir" en un pokemon. Si el pokemon esta debilitado (vida <= 0),
    /// lo revive con la mitad de su vida base. Si no esta debilitado, devuelve un mensaje indicando que no se puede revivir
    /// </summary>
    public override string Usar(Pokemon pokemonParaRevivir, Entrenadores entrenador)
    {
        if (pokemonParaRevivir.Vida <= 0)
        {
            pokemonParaRevivir.Vida = (int)(pokemonParaRevivir.VidaBase / 2);
            return $"{pokemonParaRevivir.Nombre} ha sido revivido y se recuperaron {pokemonParaRevivir.Vida} puntos de vida.\n";
        }
        else
        {
            return $"{pokemonParaRevivir.Nombre} no está debilitado. No puedes revivirlo.";
        }
    }
}