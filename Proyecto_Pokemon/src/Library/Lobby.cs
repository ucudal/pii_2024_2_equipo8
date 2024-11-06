using System.Collections.Generic;

namespace Proyecto_Pokemon;

public class Lobby
{
    public string Nombre { get; }
    public string Region { get; }
    public int Capacidad { get; }
    
    public  List<Entrenadores> listaEspera = new List<Entrenadores>();
    public  List<Batallas> batallasActivas = new List<Batallas>();

    public Lobby(string nombre, string region, int capacidad)
    {
        Nombre = nombre;
        Region = region;
        Capacidad = capacidad;
    }
    

    

    

}
