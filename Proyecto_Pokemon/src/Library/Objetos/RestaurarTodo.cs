namespace Proyecto_Pokemon;

/// <summary>
/// clase que representa el objeto "RestaurarTodo", que se utiliza para curar un pokemon y eliminar todos los estados alterados
/// </summary>
public class RestaurarTodo : Objetos
{
    /// <summary>
    /// constructor de RestaurarTodo, llama al constructor base de la clase Objetos y le asigna el nombre "RestaurarTodo"
    /// </summary>
    public RestaurarTodo() : base("RestaurarTodo") { }
    
    /// <summary>
    /// Metodo para usar el RestaurarTodo en un pokemon. Si el pokemon está debilitado (vida <= 0), se le cura toda la vida.
    /// Si no está debilitado, tambien se le cura toda la vida, esto mientras tengo menos de la vida base. Tambien se podria usar
    /// para eliminar todos los estados alterados del pokemon, o sea, en resumen, cura toda la vida al pokemon y todos los estados alterados.
    /// Si no cumplen esas condiciones, no se puede usar el objeto.
    /// </summary>
    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida == pokemon.VidaBase && pokemon.Estado == null)
        {
            return "No puedes usar el RestaurarTodo debido a que la vida de tu pokemon está maxima y no sufre de ningun estado alterado";
        }
        pokemon.Estado = null;
        pokemon.Vida = pokemon.VidaBase;
        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron todos los puntos de vida de su pokemon y se curó su estado alterado. {pokemon.Vida} / {pokemon.VidaBase} HP.\n";
    }
}