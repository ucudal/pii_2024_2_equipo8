namespace Proyecto_Pokemon;

public class RestaurarTodo : Objetos
{
    public RestaurarTodo() : base("RestaurarTodo") { }

    //Metodo para usar el objeto y restaurarle en los Pokemon
    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        // Si el Pokemon esta debilitado no no dejara  usar el ítem
        if  ( pokemon.Vida <=0 )
        {
            return $"{ pokemon.Nombre } está debilitado y nose puede usar { Nombre }.";
        }

      
        
        int vidaDeAntes = pokemon.Vida;
        pokemon.Vida = pokemon.VidaBase;
        
        //Eliminariamos todos los estados alterados
        pokemon.Estado = null;

        return $"{ entrenador.Nombre } ha hecho uso de { Nombre } en { pokemon.Nombre }. La vida se restaura al maximo y los estados alterados han sido sacados. ( Se restauro { pokemon.VidaBase - vidaDeAntes } HP )\n";
    }
}