namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public abstract class Objetos
{
    /// <summary>
    /// 
    /// </summary>
    public string Nombre { get; }

    // constructor de objetos que solo necesita el nombre
    /// <summary>
    /// 
    /// </summary>
    public Objetos(string nombre)
    {
        Nombre = nombre;
    }
    /// <summary>
    /// 
    /// </summary>
    public abstract string Usar(Pokemon pokemon, Entrenadores entrenador);
}