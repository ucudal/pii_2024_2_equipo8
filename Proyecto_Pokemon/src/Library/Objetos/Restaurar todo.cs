namespace Proyecto_Pokemon;

public class Restaurartodo : Objetos
{

    public Restaurartodo() : base("Restaurar todo"){}
    

    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado == null)
        {
            return $"{pokemon.Nombre} no está afectado por ningún estado alterado.";
        }
        pokemon.Estado = null;
      //  return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron los efectos negativos.\n";
    
       // if (pokemon.Vida <= 0)
        //{
          //  pokemon.Vida = (int)(pokemon.VidaBase / 2);
            //return $"{pokemon.Nombre} ha sido revivido y se recuperaron {pokemon.Vida} puntos de vida.\n";
        //}
        
        int vidaRecuperada = pokemon.VidaBase - pokemon.Vida;
        if (vidaRecuperada == pokemon.VidaBase)
        { 
            pokemon.Vida = (int)(pokemon.VidaBase / 2);
            return $"{pokemon.Nombre} ha sido revivido y se recuperaron {pokemon.Vida} puntos de vida.\n";
        }
        pokemon.Vida += vidaRecuperada; 
        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.\n";
        

        
       
    }

}