namespace Proyecto_Pokemon;

public class Batallas
{
    public Entrenadores entrenador1 {get; set;}
    public Entrenadores entrenador2 {get; set;}
    public Entrenadores entrenadorActual {get; set;}
    public int turno {get; set;}
    
    public bool esquivo;
    
    public Batallas(Entrenadores AshKetchup, Entrenadores diezMedallasGary)
    {
        entrenador1 = AshKetchup;
        entrenador2 = diezMedallasGary;
        entrenadorActual = entrenador1;
        turno = 1;
    }
    // Verifica si alguno de los entrenadores ya no tiene pokemones vivos
    public bool ChequerMuerte()
    {
        return !entrenador1.TienePokemonesVivos() || !entrenador2.TienePokemonesVivos();
    }
    
    // Comprobar si el entrenador está participando en esta batalla
    public bool ConfirmarSiEntrenadorEstaPeleando(Entrenadores entrenadores)
    {
        if (entrenadores != null)
        {
            foreach (Entrenadores entrenador in JugadoresDisponibles())
            {
                if (entrenador.Nombre == entrenador.Nombre)
                {
                    return true;
                }
            }
            
        }
        return false;
    }
    
    // Verifica si ambos entrenadores ya tienen sus equipos completos
    public bool ConfirmandoEquipoCompleto()
    {
        return entrenador1.RecibirEquipoPokemon().Count == 6 &&
               entrenador2.RecibirEquipoPokemon().Count == 6;
    }
    
    // Requisitos previos para iniciar batalla
    public string Iniciar(Entrenadores Entrenador1, Entrenadores Entrenador2)
    {
        if(entrenador1.EnBatalla && entrenador2.EnBatalla)
        {
            return "Ya hay una batalla en curso.";
        }
        entrenador1 = Entrenador1;
        entrenador2 = Entrenador2;
        entrenador1.EnBatalla = true;
        entrenador2.EnBatalla = true;
        // Decide aleatoriamente quién empieza
        Random Turno = new Random();
        if (Turno.Next(0, 2) == 0)
        {
            entrenadorActual = entrenador1;
        }
        else
        {
            entrenadorActual = entrenador2;
        }
        return $"{entrenador1.Nombre} y {entrenador2.Nombre} están listos para la batalla \n {entrenadorActual.Nombre} empieza.";
    }

    // Método para gestionar ataque
    public string Atacar(IHabilidades habilidad)
    {
        Random random = new Random();
        Pokemon atacante = entrenadorActual.PokemonActivo;
        Pokemon defensor = (entrenadorActual == entrenador1) ? entrenador2.PokemonActivo : entrenador1.PokemonActivo;
        string estadoResultado;
        
        if (habilidad == null)
        {
            return "No se eligió ninguna habilidad.";
        }

        habilidad.Puntos_de_Poder--;
        
        // Verifica si el atacante está paralizado
        if (atacante.Estado == "paralizado" && random.Next(0, 100) < 20)
        {
            CambiarTurno();
            return $"{atacante.Nombre} está paralizado. No se puede mover. \n";
        }

        if (habilidad.EsDobleTurno)
        {
            // Si la habilidad requiere carga, la prepara
            atacante.HabilidadCargando = habilidad;
            CambiarTurno();
            return $"{atacante.Nombre} está cargando la habilidad {habilidad.Nombre}...\n";
        }

        if (atacante.HabilidadCargando != null)
        {
            // Ejecuta la habilidad cargada
            habilidad = atacante.HabilidadCargando;
            atacante.HabilidadCargando = null;
            bool esEsquivo = esquivo;
            esquivo = false;

            string resultadoAtaque = Pokemon.EjecutarAtaque(atacante, defensor, habilidad, esEsquivo);
            string cambioTurno = CambiarTurno();
            estadoResultado = VerificarEstado(atacante);
            return resultadoAtaque + "\n" + estadoResultado + "\n" + cambioTurno;
        }

        // Ataque normal
        bool esEsquivoNormal = esquivo;
        esquivo = false;
        string resultadoAtaqueNormal = Pokemon.EjecutarAtaque(atacante, defensor, habilidad, esEsquivoNormal);
        string cambioTurnoNormal = CambiarTurno();
        estadoResultado = VerificarEstado(atacante);
        return resultadoAtaqueNormal + "\n" + cambioTurnoNormal + estadoResultado;
    }
    
    // Devuelve lista de entrenadores disponibles
    public List<Entrenadores> JugadoresDisponibles()
    {
        return new List<Entrenadores> { entrenador1, entrenador2 };
    }
    
    // Método interno de esquivo, utilizado en fachada 
    public string Esquivar()
    {
        Pokemon atacante = entrenadorActual.PokemonActivo;
        string estadoResultado = VerificarEstado(atacante);
        esquivo = true;
        return $"{atacante.Nombre} de {entrenadorActual.Nombre} está preparado para esquivar el proximo movimiento\n{estadoResultado}";
    }
    
    // Verificar si ambos entrenadores aún tienen pokemones vivos
    public bool StatusBatalla()
    {
        foreach (var entrenador in JugadoresDisponibles())
        {
            bool continua = false;
            foreach (var pokemon in entrenador.RecibirEquipoPokemon())
            {
                if (pokemon.Vida > 0)
                {
                    continua = true;
                }
            }
            if (!continua)
            {
                return false;
            }
        }
        return true;
    }
    
    // Cambio interno de cambiar pokemon, utilizado en fachada
    public string CambiarPokemon(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            return "Ese Pokémon no está en tu equipo.";
        }
        if (pokemon.Nombre == entrenadorActual.PokemonActivo.Nombre)
        {
            return "Ese ya es tu Pokémon activo.";
        }
        bool cambioExitoso = entrenadorActual.FijarPokemonActual(pokemon);

        if (cambioExitoso)
        {
            return $"{pokemon.Nombre} AHORA SE ENCUENTRA A LA CABEZA. \n";
        }
        return $"{entrenadorActual.Nombre} no pudo cambiar a {pokemon.Nombre}.";
    }
    
    // Método interno de usar mochila, uso de objetos presentes en mochila
    public string UsarMochila(Objetos? objeto, Pokemon? pokemon)
    {
        Entrenadores entrenador = JugadoresDisponibles()[turno];
        if (pokemon == null)
        {
            return $" {JugadoresDisponibles()[turno].Nombre} ese pokemon no está en tu equipo.\nBusca otro.\n";
        }
        if (objeto == null)
        {
            return $"{JugadoresDisponibles()[turno].Nombre} no cuentas con ese objeto.\nBusca otro.\n";
        }
        string final = objeto.Usar(pokemon, entrenadorActual);
        esquivo = false;
        if (final.Contains("recuperaron"))
        {
            // Remueve el objeto usado de la mochila
            Objetos objetoEnMochila = entrenador.Mochila.FirstOrDefault(o => o.Nombre == objeto.Nombre);
            if (objetoEnMochila != null)
            {
                entrenador.GetItemList().Remove(objetoEnMochila);
            }
        }
        return final;
    }

    // Verifica el caso de cada pokemon para ver como se gestiona
    public string VerificarEstado(Pokemon atacante)
    {
        Random random = new Random();
        int turnos_noqueado = 4;
        switch (atacante.Estado)
        {
            case "envenenado":
                atacante.Vida -= (int)(atacante.VidaBase * 0.05);
                if (atacante.Vida <= 0)
                {
                    atacante.Vida = 0;
                    return $"{atacante.Nombre} fue derrotado por el veneno.";
                }
                return $"{atacante.Nombre} está envenenado y pierde {(int)(atacante.VidaBase * 0.10)} puntos de vida. Vida restante: {atacante.Vida} / {atacante.VidaBase}";
                break;
            
            case "quemado":
                atacante.Vida -= (int)(atacante.VidaBase * 0.10);
                if (atacante.Vida <= 0)
                {
                    atacante.Vida = 0;
                    return $"{atacante.Nombre} fue derrotado por la quemadura.";
                }
                return $"{atacante.Nombre} está quemado y pierde {(int)(atacante.VidaBase * 0.10)} puntos de vida. Vida restante: {atacante.Vida} / {atacante.VidaBase}";
                break;

            case "noqueado":
                if (random.Next(1, 5) < turnos_noqueado)
                {
                    atacante.Estado = null;
                    return $"{atacante.Nombre} se ha recuperado del noqueo y puede volver a atacar.";
                }
                entrenadorActual = (entrenadorActual == entrenador1) ? entrenador2 : entrenador1;
                return $"{atacante.Nombre} está noqueado. No puede moverse.";
                break;
        }

        return "";
    }

    // En cambio de turno se chequea estado de batalla, 
    public string CambiarTurno()
    {
        if (ChequerMuerte())
        {
            string ganador = DeterminarGanador();
            return $"LA BATALLA TERMINÓ! EL GANADOR ES {ganador}!";
        }
        
        // Cambia al entrenador contrario
        entrenadorActual = (entrenadorActual == entrenador1) ? entrenador2 : entrenador1;
        Pokemon atacante = entrenadorActual.PokemonActivo;
        VerificarEstado(atacante);
        Pokemon defensor = (entrenadorActual == entrenador1) ? entrenador2.PokemonActivo : entrenador1.PokemonActivo;
        if (defensor.Vida == 0)
        {
            return $"{defensor.Vida} ESTÁ FUERA DE COMBATE";
        }
        if (atacante.HabilidadCargando != null)
        {
            // Ejecuta la habilidad cargada después del cambio de turno
            IHabilidades habilidad = atacante.HabilidadCargando;
            atacante.HabilidadCargando = null;
            bool esEsquivo = esquivo;
            esquivo = false;

            string resultadoAtaque = Pokemon.EjecutarAtaque(atacante, defensor, habilidad, esEsquivo);
            string estadoResultado = VerificarEstado(atacante);
            estadoResultado += "\n";
            string estaCargando = $"{atacante.Nombre} TERMINÓ DE CARGAR LA HABILIDAD!";
            entrenadorActual = (entrenadorActual == entrenador1) ? entrenador2 : entrenador1;
            return estaCargando + resultadoAtaque + "\n" + estadoResultado;
        }
        return null;
    }
    
    // Chequeo de ganador según si tiene pokemones vivos, el que tenga vivos gana, si ninguno tiene es empate
    public string DeterminarGanador()
    {
        if (entrenador1.TienePokemonesVivos()) return entrenador1.Nombre;
        if (entrenador2.TienePokemonesVivos()) return entrenador2.Nombre;
        return "Empate";
    }
    
}