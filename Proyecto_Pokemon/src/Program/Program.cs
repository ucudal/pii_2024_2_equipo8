using System;

namespace Proyecto_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Fachada fachada = new Fachada();
            fachada.InicializarDatos();
            
            Entrenadores entrenador1 = new Entrenadores("El mas capito", new List<Pokemon> { fachada.ObtenerArcanine() });
            Entrenadores entrenador2 = new Entrenadores("Juan", new List<Pokemon> { fachada.ObtenerBlastoise(), fachada.ObtenerSceptile() });

            Batallas batalla = new Batallas(entrenador1, entrenador2);
            batalla.Iniciar();
        }
    }
}