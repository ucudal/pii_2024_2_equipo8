using System;
using System.Net.Sockets;

namespace Proyecto_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicaDePokemones todoslospoke = new LogicaDePokemones();
            List<Pokemon> todosLosPokemones = todoslospoke.InicializarPokemones();
            

            Entrenadores entrenador1 = new Entrenadores("Elon Musk", new List<Pokemon>());
            Fachada.SeleccionarEquipo(entrenador1, todosLosPokemones);
            
            Entrenadores entrenador2 = new Entrenadores("Ash Ketchup", new List<Pokemon>());
            Fachada.SeleccionarEquipo(entrenador2, todosLosPokemones);
           
            Entrenadores entrenador3 = new Entrenadores("Marcelo Arrate", new List<Pokemon>());
            //Fachada.SeleccionarEquipo(entrenador3, todosLosPokemones);
            
            Entrenadores entrenador4 = new Entrenadores("Naruto", new List<Pokemon>());
            //Fachada.SeleccionarEquipo(entrenador4, todosLosPokemones);

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