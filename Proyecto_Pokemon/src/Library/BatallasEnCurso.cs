namespace Proyecto_Pokemon;

public class BatallasEnCurso
{
    private List<Batallas> Partidas = new List<Batallas>();
    private Lobby lobby = new Lobby();
    
    public bool TerminarPartida(Batallas partida)
    {
        if (Partidas.Remove(partida))
        {
            return true;
        }
            return false;
        
    }

    public Batallas BatallaPorEntrenador(Entrenadores entrenador)
    {
        foreach (Batallas batalla in Partidas)
        {
            if (batalla.JugadoresDisponibles().Contains(entrenador))
            {
                return batalla;
            }
        }
        return null;
    }
    
    public Entrenadores? EntrenadorPorNombre(string nombre)
    {
        foreach (Batallas partida in Partidas)
        foreach (Entrenadores entrenador in partida.JugadoresDisponibles())
            if (entrenador.Nombre == nombre)
                return entrenador;
        return null;
    }
    
    public Batallas CrearPartida(Entrenadores entrenador1, Entrenadores entrenador2)
    {
        Batallas partida = new Batallas(entrenador1, entrenador2);
        partida.Iniciar(entrenador1, entrenador2);
        Partidas.Add(partida);
        return partida;
    }

}