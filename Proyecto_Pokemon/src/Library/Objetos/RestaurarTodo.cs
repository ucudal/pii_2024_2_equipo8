namespace Proyecto_Pokemon;

public class RestaurarTodo: Objetos
{
    /// <summary>
    /// constructor de RestaurarTodo, llama al constructor base de la clase objetos y le da el nombre "restaurartodo"
    /// </summary>
    public RestaurarTodo() : base("Restaurar Todo") { }
    
    /// <summary>
    /// metodo para usar el objeto en un pokemon, 
    /// </summary>
    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado == null) 
        {
            if ((pokemon.Vida == pokemon.VidaBase))
            {
                return $"No fue necesario restaurar, todos los valores al máximo.";
            }
        }
        pokemon.Estado = null;
        pokemon.Vida = pokemon.VidaBase;

        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron los efectos negativos y se restauró la vida incial.\n";
    }
}