namespace Proyecto_Pokemon;

public class SuperPocion : Objetos
{
    // constructor de SuperPocion, llama al constructor base de la clase Objetos y le asigna el nombre "SuperPocion"
    public SuperPocion() : base("SuperPocion") { }

    // metodo para usar la SuperPoción en un pokemon. Si el pokemon esta debilitado (vida <= 0), devuelve un mensaje indicando
    // que no puede usar la poción. Si no está debilitado, se le recuperan 70 puntos de vida. Si la vida total del pokemon
    // superaría su vida base, se le restaura al máximo. Si todo sale bien, devuelve un mensaje con la cantidad de vida recuperada.
    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida <= 0)
        {
            return $"{pokemon.Nombre} está debilitado y no puede usar una Super Poción.";
        }

        int vidaRecuperada = 70;
        if ((vidaRecuperada + pokemon.Vida) > pokemon.VidaBase)
        {
            return $"{pokemon.Nombre} no puede curarse más de la vida base. Se restaura al máximo.";
        }

        pokemon.Vida += vidaRecuperada;
        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.";
    }

}