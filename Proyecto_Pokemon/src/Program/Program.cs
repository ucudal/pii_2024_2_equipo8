using System;

namespace Proyecto_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Fachada fachada = new Fachada();
            fachada.InicializarDatos();
            
            Entrenadores entrenador1 = new Entrenadores("Elon Musk", new List<Pokemon> { fachada.ObtenerArcanine() });
            Entrenadores entrenador2 = new Entrenadores("Ash Ketchup", new List<Pokemon> { fachada.ObtenerBlastoise(), fachada.ObtenerSceptile() });

            Batallas batalla = new Batallas(entrenador1, entrenador2);
            batalla.Iniciar();
        }
    }
}