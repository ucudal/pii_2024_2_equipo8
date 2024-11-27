namespace Proyecto_Pokemon;

public class RestaurarTodo: Objetos
{
    /// <summary>
    /// constructor de RestaurarTodo, llama al constructor base de la clase objetos y le da el nombre "restaurartodo"
    /// </summary>
    public RestaurarTodo() : base("Restaurar Todo") { }
    
    /// <summary>
    /// metodo para usar el objeto RestauraroTodo en un pokemon, vuelve la vida al nivel inicial y anula los efectos generados.
    /// </summary>
    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado == null) 
        {
            if ((pokemon.Vida == pokemon.VidaBase))
            {
                // Se evalua este caso para no perder el objeto si no se hace efectivo su uso
                return $"No fue necesario restaurar, todos los valores al máximo.";
            }
        }
        
        pokemon.Estado = null;
        // Se usa VidaBase para tener una referencia de vida máxima para recuperar
        pokemon.Vida = pokemon.VidaBase;

        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron los efectos negativos y se restauró la vida incial.\n";
    }
}