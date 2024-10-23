namespace Proyecto_Pokemon;
public enum TipoObjeto
{
    SuperPocion,
    Revivir,
    CuraTotal
}
public class Objetos
{
    public string Nombre { get; }
    public TipoObjeto Tipo { get; }

    public Objetos(TipoObjeto tipo)
    {
        Tipo = tipo;

        switch (tipo)
        {
            case TipoObjeto.SuperPocion:
                Nombre = "Súper Poción";
                break;
            case TipoObjeto.Revivir:
                Nombre = "Revivir";
                break;
            case TipoObjeto.CuraTotal:
                Nombre = "Cura Total";
                break;
        }
    }

    public void Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        switch (Tipo)
        {
            case TipoObjeto.SuperPocion:
                UsarSuperPocion(pokemon, entrenador);
                break;
            case TipoObjeto.Revivir:
                UsarRevivir(pokemon, entrenador);
                break;
            case TipoObjeto.CuraTotal:
                UsarCuraTotal(pokemon, entrenador);
                break;
        }
    }

    private void UsarSuperPocion(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida <= 0)
        {
            Console.WriteLine($"{pokemon.Nombre} está debilitado y no puede usar una Super Pocion.");
            return;
        }
        int vidaRecuperada = 70;
        if ((vidaRecuperada + pokemon.Vida) > 500)
        {
            Console.WriteLine($"{pokemon.Nombre} no puede curarse más de la vida base, pierdes el objeto.");
            return;
        } 
        pokemon.Vida += vidaRecuperada;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.");
    }

    private void UsarRevivir(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida > 0)
        {
            Console.WriteLine($"{pokemon.Nombre} no está debilitado y no puede usar un Revivir.");
            return;
        }

        pokemon.Vida = 500 / 2;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. {pokemon.Nombre} fue revivido con {pokemon.Vida} HP.");
    }

    private void UsarCuraTotal(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado != null)
        {
            Console.WriteLine($"{pokemon.Nombre} no está afectado por ningún estado alterado.");
            return;
        }

        pokemon.Estado = null;
        Console.WriteLine($"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Todos los efectos negativos fueron curados.");
    }
}