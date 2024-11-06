using System;

namespace Proyecto_Pokemon
{
    class Program
    {
        
        static void Main(string[] args)
        {
             
            

            Entrenadores entrenador1 = new Entrenadores("Elon Musk", new List<Pokemon>());
            Entrenadores entrenador2 = new Entrenadores("Ash Ketchup", new List<Pokemon>());
            
           
            Entrenadores entrenador3 = new Entrenadores("Marcelo Arrate", new List<Pokemon>());
            Entrenadores entrenador4 = new Entrenadores("Naruto", new List<Pokemon>());
            

            Lobby lobbys = new Lobby(nombre:"Lobby",region:"Uruguay",capacidad:8);
            lobbys.UnirseALaListaDeEspera(entrenador1);
            lobbys.UnirseALaListaDeEspera(entrenador2);
            lobbys.UnirseALaListaDeEspera(entrenador3);
            lobbys.UnirseALaListaDeEspera(entrenador4);
            lobbys.IniciarBatalla(entrenador1);

            //Batallas batalla = new Batallas(entrenador1, entrenador2);
            //batalla.Iniciar();
        }
    }
}