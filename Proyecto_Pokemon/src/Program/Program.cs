using System;

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
            
            Batallas batalla = new Batallas(entrenador1, entrenador2);
            batalla.Iniciar();
        }
    }
}