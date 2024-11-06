namespace Proyecto_Pokemon;

public class Fachada
{
    
    public static void SeleccionarEquipo(Entrenadores entrenador, List<Pokemon> equipoSeleccionado)
    {
        if (equipoSeleccionado.Count != 6)
        {
            throw new ArgumentException("Debes seleccionar exactamente 6 Pokémon.");
        }

        // Asigna los Pokémon seleccionados al equipo del entrenador
        entrenador.Pokemones.AddRange(equipoSeleccionado);
    }
    
    public string MostrarHabilidades(Pokemon pokemonActual)
    {
        string  habilidades = "";
        for (int i = 0; i < pokemonActual.Habilidades.Count; i++)
        {
            var habilidad = pokemonActual.Habilidades[i];
            habilidades = habilidades + ($"{i + 1}. {habilidad.Nombre} - Daño: {habilidad.Danio}, Precisión: {habilidad.Precision}, Tipo: {habilidad.Tipo.Nombre}, PP: {habilidad.PP}, Doble turno: {habilidad.EsDobleTurno}; ");
        }
        return habilidades;
    }
    
    public string VerVida(Batallas batallaActual)
    {
        string vidaPokemones = "";
        //Console.WriteLine($"Pokemones de {entrenador1.Nombre}:");
        vidaPokemones = batallaActual.entrenador1.MostrarPokemones();
        //Console.WriteLine();
        //Console.WriteLine($"Pokemones de {entrenador2.Nombre}:");
        vidaPokemones += batallaActual.entrenador2.MostrarPokemones();
        
        return vidaPokemones;
    }
    
    public void EjecutarAtaque(Pokemon atacante, Pokemon defensor, IHabilidades habilidad, bool esquivo)
    {
        double efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoPrincipal);
        int danio = (int)(habilidad.Danio * efectividad);
        if (defensor.TipoSecundario != null)
        {
            efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoSecundario);
            danio = (int)(danio * efectividad);
        }

        Random random = new Random();
        int probabilidad = random.Next(0, 100);
        int precisionfinal = habilidad.Precision;
        if (esquivo)
        {
            
            precisionfinal -= 30;
            Console.WriteLine(precisionfinal);
        }

        Console.WriteLine();
        if (probabilidad <= precisionfinal)
        {
            if (random.Next(0, 100) < 10 && habilidad.EsDobleTurno)
            {
                danio = (int)(danio * 1.2);
                Console.WriteLine("Piña Critica!");
            }
            defensor.Vida -= danio;
            if (defensor.Vida < 0)
            {
                defensor.Vida = 0;
            }
            Console.WriteLine($"{atacante.Nombre} usó {habilidad.Nombre}, hizo {danio} puntos de daño, la vida actual de {defensor.Nombre} = {defensor.Vida}");
        
            if (habilidad.Efectos != null && random.Next(0, 100) < 100 && defensor.Estado == null)
            {
                defensor.Estado = habilidad.Efectos.Nombre;
                Console.WriteLine($"{defensor.Nombre} ahora está {defensor.Estado}!");
            }
        }
        else
        {
            Console.WriteLine($"{atacante.Nombre} falló el ataque");
        }
    }
    
    // Determina si es el turno del jugador
    private string EsTurnoDe(Batallas batallaActual)
    {
        return $"Turno de {batallaActual.entrenadorActual.Nombre}";
    }
    
    // Comprobar si la batalla terminó
    private string CheckFinBatalla(Batallas batallaActual)
    {
        if (!batallaActual.entrenador1.TienePokemonesVivos())
        {
            return $"El ganador de la batalla es {batallaActual.entrenador2.Nombre}!";
        }
        else if (!batallaActual.entrenador2.TienePokemonesVivos())
        {
            return $"El ganador de la batalla es {batallaActual.entrenador1.Nombre}!";
        }
        else
        {
            return "La batalla aún no ha finalizado";
        }
    }
    
    public string CambiarPokemon( Batallas batallaActual, int indicePokemon)
    {
        

        do
        {
            //Console.WriteLine($"{entrenadorActual.Nombre}, elegí el Pokemon que quieras usar:");
            batallaActual.entrenadorActual.MostrarPokemones();

            //indicePokemon = Convert.ToInt32(Console.ReadLine()) - 1;

            if (indicePokemon >= batallaActual.entrenadorActual.Pokemones.Count || indicePokemon < 0)
            {
                return ("El Pokémon que elegiste no existe. Inténtalo de nuevo.");
            }

        } while (indicePokemon >= batallaActual.entrenadorActual.Pokemones.Count || indicePokemon < 0);

        if (batallaActual.entrenadorActual.Pokemones[indicePokemon].Vida > 0)
        {
            if (batallaActual.entrenadorActual == batallaActual.entrenador1)
            {
                batallaActual.pokemonActivo1 = batallaActual.entrenadorActual.Pokemones[indicePokemon];
            }
            else
            {
                batallaActual.pokemonActivo2 = batallaActual.entrenadorActual.Pokemones[indicePokemon];
            }

            return ($"{batallaActual.entrenadorActual.Nombre} cambió a {batallaActual.entrenadorActual.Pokemones[indicePokemon].Nombre}");
        }
        else
        {
            CambiarPokemon(batallaActual, indicePokemon);
            return ("No puedes elegir un Pokémon debilitado.");
        }
    }

    public string UsarMochila(Batallas batallaActual, int objetoElegido)
    {
        Pokemon atacante = batallaActual.entrenadorActual == batallaActual.entrenador1 ? batallaActual.pokemonActivo1 : batallaActual.pokemonActivo2;
        //int objetoElegido;
        List<Objetos> listaObjetosUnicos = batallaActual.entrenadorActual.MostrarMochila();
        
        do
        {
            //Console.WriteLine($"{batallaActual.entrenadorActual.Nombre}, elegí el objeto que quieras usar (0 para VOLVER):");
            //objetoElegido = Convert.ToInt32(Console.ReadLine()) - 1;

            if (objetoElegido == -1)
            {
                //DemoConsola.MostrarOpciones(batallaActual);
                return "Vuelta a menu de mochila";
            }

            if (objetoElegido >= batallaActual.entrenadorActual.Mochila.Count || objetoElegido < 0)
            {
                return ("El objeto que elegiste no existe. Inténtalo de nuevo.");
            }

        } while (objetoElegido >= batallaActual.entrenadorActual.Mochila.Count || objetoElegido < 0);
        Objetos objeto = listaObjetosUnicos[objetoElegido];
        switch (objeto)
        {
            case SuperPocion superPocion:
                superPocion.Usar(atacante, batallaActual.entrenadorActual);
                return "";
            case Revivir revivir:
                revivir.Usar(atacante, batallaActual.entrenadorActual);
                return "";
            case CuraTotal curaTotal:
                curaTotal.Usar(atacante, batallaActual.entrenadorActual);
                return "";
        }
        var objetoARemover = batallaActual.entrenadorActual.Mochila.FirstOrDefault(o => o.Nombre == objeto.Nombre);
        if (objetoARemover != null)
        {
            batallaActual.entrenadorActual.Mochila.Remove(objetoARemover);
            return "";
        }
        return "";
    }
    
    // Agrega un entrenador a la lista de espera si hay capacidad
    public string UnirseALaListaDeEspera(Entrenadores entrenador, Lobby lobby)
    {
        if (lobby.listaEspera.Count >= lobby.Capacidad)
        {
            return $"El lobby '{lobby.Nombre}' está lleno. Capacidad máxima de {lobby.Capacidad} entrenadores.";
        }
        
        if (!lobby.listaEspera.Contains(entrenador))
        {
            lobby.listaEspera.Add(entrenador);
            return $"{entrenador.Nombre} ha sido agregado a la lista de espera en el lobby '{lobby.Nombre}' de la región {lobby.Region}.";
        }
        
        return $"{entrenador.Nombre} ya está en la lista de espera.";
    }

    // Muestra los entrenadores en la lista de espera
    public List<string> VerListaDeEspera(Lobby lobby)
    {
        List<string> nombresJugadores = new List<string>();
        foreach (var jugador in lobby.listaEspera)
        {
            nombresJugadores.Add(jugador.Nombre);
        }
        return nombresJugadores;
    }
    
    // Inicia una batalla entre el entrenador actual y el primer entrenador de la lista de espera
    public string IniciarBatalla(Entrenadores entrenador, Lobby lobby)
    {
        LogicaDePokemones todoslospoke = new LogicaDePokemones();
        List<Pokemon> todosLosPokemones = todoslospoke.InicializarPokemones();
        
        // Remover al entrenador de la lista de espera antes de buscar oponente
        lobby.listaEspera.Remove(entrenador);
        
        if (lobby.listaEspera.Count == 0)
        {
            return "No hay jugadores en la lista de espera.";
        }

        // Seleccionar primer oponente de la lista de espera
        Entrenadores oponente = lobby.listaEspera[0];

        // Retirar al oponente de la lista de espera
        lobby.listaEspera.Remove(oponente);
        
        Fachada.SeleccionarEquipo(entrenador,todosLosPokemones);
        Fachada.SeleccionarEquipo(oponente,todosLosPokemones);
        // Crear una nueva batalla y agregarla a las batallas activas
        Batallas nuevaBatalla = new Batallas(entrenador, oponente);
        lobby.batallasActivas.Add(nuevaBatalla);
        
        nuevaBatalla.Iniciar(); //ARREGLAR 
        

        return $"{entrenador.Nombre} ha comenzado una batalla contra {oponente.Nombre} en el lobby '{lobby.Nombre}'.";
    }

}