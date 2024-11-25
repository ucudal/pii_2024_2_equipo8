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
    
    // Agrega un entrenador a la lista de espera si hay capacidad
    public string UnirseALaListaDeEspera(Entrenadores entrenador)
    {
        if (listaEspera.Count >= Capacidad)
        {
            return $"El lobby '{Nombre}' está lleno. Capacidad máxima de {Capacidad} entrenadores.";
        }
        
        if (!listaEspera.Contains(entrenador))
        {
            listaEspera.Add(entrenador);
            return $"{entrenador.Nombre} ha sido agregado a la lista de espera en el lobby '{Nombre}' de la región {Region}.";
        }
        
        return $"{entrenador.Nombre} ya está en la lista de espera.";
    }

    // Muestra los entrenadores en la lista de espera
    public List<string> VerListaDeEspera()
    {
        List<string> nombresJugadores = new List<string>();
        foreach (var jugador in listaEspera)
        {
            nombresJugadores.Add(jugador.Nombre);
        }
        return nombresJugadores;
    }
    
    // Inicia una batalla entre el entrenador actual y el primer entrenador de la lista de espera
    public string IniciarBatalla(Entrenadores entrenador, Entrenadores oponente)
    {
        
        
        
        // Remover al entrenador de la lista de espera antes de buscar oponente
        listaEspera.Remove(entrenador);
        
        if (listaEspera.Count == 0)
        {
            return "No hay jugadores en la lista de espera.";
        }
        

        // Seleccionar primer oponente de la lista de espera
        //Entrenadores oponente = listaEspera[0];
        // Retirar al oponente de la lista de espera
        listaEspera.Remove(oponente);
        
        //entrenador.SeleccionarEquipo(todosLosPokemones);
        //oponente.SeleccionarEquipo(todosLosPokemones);
        // Crear una nueva batalla y agregarla a las batallas activas
        Batallas nuevaBatalla = new Batallas(entrenador, oponente);
        batallasActivas.Add(nuevaBatalla);
        
        
        
        nuevaBatalla.Iniciar(); //ARREGLAR 
        

        return $"{entrenador.Nombre} ha comenzado una batalla contra {oponente.Nombre} en el lobby '{Nombre}'.";
    }
    

    

}
