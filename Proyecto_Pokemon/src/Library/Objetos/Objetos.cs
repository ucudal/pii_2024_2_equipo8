namespace Proyecto_Pokemon;
/// <summary>
/// clase abstracta que representa un objeto en el juego, con un nombre y un metodo para usarlo
/// </summary>
public abstract class Objetos
{
    /// <summary>
    /// nombre del objeto que es representativo
    /// </summary>
    public string Nombre { get; }

    /// <summary>
    /// constructor de objetos que solo necesita el nombre
    /// </summary>
    public Objetos(string nombre)
    {
        Nombre = nombre;
    }
    /// <summary>
    /// metodo abstracto para usar el objeto en un pokemon
    /// </summary>
    public abstract string Usar(Pokemon pokemon, Entrenadores entrenador);
}