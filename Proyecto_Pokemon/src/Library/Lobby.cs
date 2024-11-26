using System.Collections.Generic;

namespace Proyecto_Pokemon;

public class Lobby
{
    private List<Entrenadores> Entrenadoress { get; }= new List<Entrenadores>();
   
    public int Cantidad
    {
        get { return Entrenadoress.Count; }
    }
    
    public bool AgregarEntrenadores(string NombreEntrenador)
    {
        if (string.IsNullOrEmpty(NombreEntrenador))
            throw new ArgumentException(nameof(NombreEntrenador));
        if (EntrenadorPorNombre(NombreEntrenador) != null) 
            return false;
        Entrenadoress.Add(new Entrenadores(NombreEntrenador));
        return true;
    }
    
    public bool SacarEntrenadores(string EntrenadoresName)
    {
        Entrenadores? Entrenadores = EntrenadorPorNombre(EntrenadoresName);
        if (Entrenadores == null)
            return false;
        Entrenadoress.Remove(Entrenadores);
        return true;
    }
    
    public Entrenadores? EntrenadorPorNombre(string EntrenadoresName)
    {
        foreach (Entrenadores Entrenadores in Entrenadoress)
            if (Entrenadores.Nombre == EntrenadoresName)
            {
                return Entrenadores;
            }
        return null;
    }
    
    public Entrenadores? AnadirRandom(string EntrenadoresName)
    {
        Random random = new Random();
        if (Cantidad <= 1)
            return null;
        int numerorandom;
        do
        {
            numerorandom = random.Next(0, Cantidad);
        } while (Entrenadoress[numerorandom].Nombre == EntrenadoresName);
        return Entrenadoress[numerorandom];
    }
    
    public string VerListaLobby()
    {
        string result = null;

        foreach (var entrenador in Entrenadoress)
        {
            result += entrenador.Nombre + "\n";
        }

        return result;
    }
    
}
