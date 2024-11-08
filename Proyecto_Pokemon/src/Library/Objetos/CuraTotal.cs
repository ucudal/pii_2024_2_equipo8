namespace Proyecto_Pokemon;

public class CuraTotal : Objetos
{
    // constructor de cura total, llama al constructor base de la clase objetos y le da el nombre "cura total"
    public CuraTotal() : base("Cura Total") { }

    // metodo para usar el objeto en un pokemon, si el pokemon no tiene estado alterado, 
    // devuelve un mensaje indicando que no esta afectado, si tiene, lo cura eliminando cualquier estado alterado
    public string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado == null)
        {
            return $"{pokemon.Nombre} no está afectado por ningún estado alterado.";
        }

        pokemon.Estado = null;
        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Todos los efectos negativos fueron curados.";
    }
}