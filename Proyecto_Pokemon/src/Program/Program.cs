using System;

namespace Proyecto_Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Fachada fachada = new Fachada();
            fachada.InicializarDatos();
            
            List<Pokemon> todosLosPokemones = new List<Pokemon>
            {
                fachada.ObtenerSceptile(),
                fachada.ObtenerArcanine(),
                fachada.ObtenerBlastoise(),
                fachada.ObtenerSnorlax(),
                fachada.ObtenerPikachu(),
                fachada.ObtenerJynx(),
                fachada.ObtenerLucario(),
                fachada.ObtenerTyranitar(),
                fachada.ObtenerFlygon(),
                fachada.ObtenerPidgeot(),
                fachada.ObtenerScyther(),
                fachada.ObtenerAmoonguss(),
                fachada.ObtenerUmbreon(),
                fachada.ObtenerGengar(),
                fachada.ObtenerLapras(),
                fachada.ObtenerMetagross(),
                fachada.ObtenerDragonite(),
                fachada.ObtenerSylveon()
            };

            Entrenadores entrenador1 = new Entrenadores("Elon Musk", new List<Pokemon>());
            Fachada.SeleccionarEquipo(entrenador1, todosLosPokemones);
            
            Entrenadores entrenador2 = new Entrenadores("Ash Ketchup", new List<Pokemon>());
            Fachada.SeleccionarEquipo(entrenador2, todosLosPokemones);
            
            Batallas batalla = new Batallas(entrenador1, entrenador2);
            batalla.Iniciar();
        }
    }
}