namespace Proyecto_Pokemon;

public class Restaurartodo : Objetos
{

    public Restaurartodo() : base("Restaurar todo")
    {
    }


    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        int vidaRecuperada = pokemon.VidaBase - pokemon.Vida;
        if (vidaRecuperada == pokemon.VidaBase)
        {
            pokemon.Vida = pokemon.VidaBase;
            return $"{pokemon.Nombre} ha sido revivido";
        }

        pokemon.Vida += vidaRecuperada;
        //return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.\n";

        if (pokemon.Estado == null)
        {
            return $"{pokemon.Nombre} no está afectado por ningún estado alterado.";
        }
        pokemon.Estado = null;

        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.\n";

    }

}


