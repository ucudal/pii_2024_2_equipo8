namespace Proyecto_Pokemon;

public abstract class Objetos
{
    public string Nombre { get; }

    // constructor de objetos que solo necesita el nombre
    public Objetos(string nombre)
    {
        Nombre = nombre;
    }
    
    public abstract string Usar(Pokemon pokemon, Entrenadores entrenador);
}