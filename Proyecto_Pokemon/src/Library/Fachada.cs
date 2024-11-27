namespace Proyecto_Pokemon;

//Clase que actúa como interfaz principal del proyecto, hace la conexión entre logica de proyecto y usuario
/// <summary>
/// 
/// </summary>
public static class Fachada
{
    // Instancia de LogicaDePokemones para manejar los Pokémon disponibles
    private static LogicaDePokemones CantidadPokemones { get;  set; } = LogicaDePokemones.Instance;
    
    // Instancia del Lobby para manejar entrenadores que esperan partida
    private static Lobby lobby { get; } = new Lobby();
    
    // Instancia para manejar las batallas activas
    private static BatallasEnCurso batallaencurso { get; } = new BatallasEnCurso();
    
    // Muestra lista de pokemon disponibles para usar
    /// <summary>
    /// 
    /// </summary>
    public static string OpcionesPokemones()
    {
        return "**Opciones para el Equipo:**\n" + CantidadPokemones.MostrarPokemones();
    }
    
    // Inicia batalla entre dos entrenadores dados
    /// <summary>
    /// 
    /// </summary>
    public static string CrearBatalla(string NombreEntrenador1, string NombreEntrenador2)
    {
        Entrenadores entrenador1 = lobby.EntrenadorPorNombre(NombreEntrenador1);
        Entrenadores entrenador2 = lobby.EntrenadorPorNombre(NombreEntrenador2);
        lobby.SacarEntrenadores(NombreEntrenador1);
        lobby.SacarEntrenadores(NombreEntrenador2);
        batallaencurso.CrearPartida(entrenador1, entrenador2);
        return $"**EMPIEZA LA PELEA ENTRE {NombreEntrenador1} CONTRA {NombreEntrenador2}**\n";
    }
    
    // Muestra habilidades de pokemon activo
    /// <summary>
    /// 
    /// </summary>
    public static string VerHabilidades(string nombreEntrenador)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
    
        if (entrenador == null)
            return $"{nombreEntrenador}, no estás en ninguna partida.";
    
        if (entrenador.CantidadDePokemones == 0)
            return $"{nombreEntrenador}, no tenes ningún Pokémon.";
    
        Pokemon pokemonActivo = entrenador.PokemonActivo;
        if (pokemonActivo == null)
            return $"{nombreEntrenador} no tenes un pokemon principal.";
    
        string ataques = pokemonActivo.MostrarHabilidades();
        if (string.IsNullOrEmpty(ataques))
            return $"{nombreEntrenador} tu pokemon actual no tiene ataques disponibles.";
    
        return $"{nombreEntrenador} estas son las habilidades de tu __{pokemonActivo.Nombre}__:\n{ataques}";
    }

    // Usar habilidad de pokemon activo
    /// <summary>
    /// 
    /// </summary>
    public static string ElegirHabilidad(string nombreEntrenador, string nombreHabilidad) 
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"{nombreEntrenador}, necesitas estar en una batalla para atacar.";
        }
        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        if (!batalla.ConfirmandoEquipoCompleto())
        {
            return "Los entrenadores todavia no eligieron todos los pokemones para su equipo";
        }

        if (batalla == null)
        {
            return "No estás participando en una batalla.";
        }

        if (batalla.entrenadorActual.Nombre != nombreEntrenador)
        {
            return $"{nombreEntrenador} no es tu turno.";
        }

        Pokemon atacante = batalla.entrenadorActual.PokemonActivo;

        if (atacante == null || atacante.Vida == 0)
        {
            return $"{nombreEntrenador} tu pokemon actual está fuera de combate. Cambia de pokemon.";
        }
        
        IHabilidades habilidad = atacante.Habilidades.FirstOrDefault(h => h.Nombre == nombreHabilidad);
        if (habilidad == null)
        {
            return $"La habilidad '{nombreHabilidad}' no se encuentra disponible en la lista del Pokemon {atacante.Nombre}";
        }
        string finaladoAtaque = batalla.Atacar(habilidad);
        string estadoJuego = CierreDeLaBatalla(batalla);
        return $"{finaladoAtaque}{estadoJuego}";
    }

    // Confirma si es el turno del entrenador actual
    /// <summary>
    /// 
    /// </summary>
    public static string RevisarTurno(string nombreEntrenador)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"El entrenador {nombreEntrenador} no se encuentra en ninguna batalla";
        }

        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        if (batalla != null)
        {
            if (batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador))
            {
                if (batalla.entrenadorActual.Nombre == nombreEntrenador)
                {
                    return $"{nombreEntrenador} es tu turno";
                }
                return $"{nombreEntrenador} no es tu turno";
            }
        }
        return null;
    }

    // Verifica si una batalla ha finalizado y anuncia al ganador
    /// <summary>
    /// 
    /// </summary>
    public static string CierreDeLaBatalla(Batallas batalla)
    {
        if (batalla != null)
        {
            if (batalla.StatusBatalla())
            {
                Entrenadores proximoTurno = batalla.JugadoresDisponibles().FirstOrDefault(e => e.Nombre == batalla.entrenadorActual.Nombre);
                return $"\nEl próximo turno es de {proximoTurno?.Nombre ?? "desconocido"} \nVAMOS!";
            }
            batallaencurso.TerminarPartida(batalla);
            return batalla.DeterminarGanador();
        }
        return "La partida no pudo ser encontrada";
    }
    /// <summary>
    /// 
    /// </summary>
    public static string Rendirse(string entrenadorNombre)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(entrenadorNombre);
        if (entrenador == null)
        {
            return $"{entrenadorNombre}, no te podés rendir si no estás en una batalla";
        }
        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        int noEntrenadorActual = (batalla.turno+1)%2;
        batallaencurso.TerminarPartida(batalla);
        if (batalla.JugadoresDisponibles()[batalla.turno].Nombre == entrenadorNombre)
        {
            return $"EL INCREIBLE ENTRENADOR {batalla.JugadoresDisponibles()[batalla.turno].Nombre} SE RINDIÓ.\nEL GANADOR ES {batalla.JugadoresDisponibles()[noEntrenadorActual].Nombre} \nY EL PERDEDOR {batalla.JugadoresDisponibles()[batalla.turno].Nombre}";
        }
        return $"EL INCREIBLE ENTRENADOR {batalla.JugadoresDisponibles()[noEntrenadorActual].Nombre} SE RINDIÓ.\nEL GANADOR ES {batalla.JugadoresDisponibles()[batalla.turno].Nombre} \nY EL PERDEDOR {batalla.JugadoresDisponibles()[noEntrenadorActual].Nombre}";
    }
    
    // Inicia una batalla buscando un oponente en el lobby o con un nombre específico solo si se cumplen requisitos de disponibilidad, se llama a CrearBatalla
    /// <summary>
    /// 
    /// </summary>
    public static string IniciarBatalla(string NombreEntrenador1, string NombreEntrenador2)
    {
        Entrenadores entrenador2;
        Entrenadores entrenador1 = batallaencurso.EntrenadorPorNombre(NombreEntrenador1);
        if (batallaencurso.BatallaPorEntrenador(entrenador1) != null)
        {
            return $"{NombreEntrenador1} se encuentra en una batalla.";
        }

        if (lobby.EntrenadorPorNombre(NombreEntrenador1) == null)
            return $"{NombreEntrenador1} no estás en el lobby.";
        
        if (!RevisarEntrenador2() && !HayEntrenadoresLobby())
            return "no hay nadie en el lobby.";
        
        if (!RevisarEntrenador2())
        {
            entrenador2 = batallaencurso.EntrenadorPorNombre(NombreEntrenador2);
            if (batallaencurso.BatallaPorEntrenador(entrenador2) != null)
            {
                return $"{NombreEntrenador2} se encuentra en una batalla.";
            }
            entrenador2 = lobby.AnadirRandom(NombreEntrenador1);
            if (entrenador2 == null)
            {
                return "No se encuentra un oponente en el Lobby";
            }
            return CrearBatalla(NombreEntrenador1, entrenador2!.Nombre);
        }
        
        entrenador2 = lobby.EntrenadorPorNombre(NombreEntrenador2!);
        if (!BuscarEntrenador2())
        {
            return $"{NombreEntrenador2} no se lo encontró en el Lobby";
        }

        if (batallaencurso.BatallaPorEntrenador(entrenador2) != null)
            return $"{NombreEntrenador2} se encuentra en una batalla.";
        
        return CrearBatalla(NombreEntrenador1, entrenador2!.Nombre);

        bool BuscarEntrenador2()
        {
            return entrenador2 != null;
        }
        
        bool HayEntrenadoresLobby()
        {
            return lobby.Cantidad != 0;
        }
        
        bool RevisarEntrenador2()
        {
            return !string.IsNullOrEmpty(NombreEntrenador2);
        }
    }
    
    // Remueve a un entrenador del lobby
    /// <summary>
    /// 
    /// </summary>
    public static string SacarEntrenadorDelLobby(string nombre)
    {
        if (lobby.SacarEntrenadores(nombre))
        {
            return $"{nombre} fue sacado del Lobby.";
        }
        return $"{nombre} ni siquiera está en el Lobby.";
    }
    
    // Agrega a un entrenador al lobby
    /// <summary>
    /// 
    /// </summary>
    public static string MeterUsuarioAlLobby(string nombre)
    {
        if (batallaencurso.EntrenadorPorNombre(nombre) != null)
        {
            return $"{nombre} ya te encuentras en una batalla y no podes ser agregado al Lobby.";
        }
        
        if (lobby.AgregarEntrenadores(nombre))
        {
            
            return $"{nombre} ha sido agregado en el Lobby para un encuentro.";
        }

        return $"{nombre} ya se encuentra en el Lobby.";
    }
    
    // Muestra los entrenadores actualmente en el lobby
    /// <summary>
    /// 
    /// </summary>
    public static string VerLobby()
    {
        if (lobby.VerListaLobby() == null)
        {
            return "Nadie se encuentra en el Lobby actualmente";
        }
        
        return "Gente en Lobby: \n" + lobby.VerListaLobby();
    }
    
    // Permite a un entrenador esquivar un ataque durante su turno
    /// <summary>
    /// 
    /// </summary>
    public static string EsquivarPokemon(string nombreEntrenador)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }

        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        if (batalla == null)
        {
            return "La partida no pudo ser encontrada";
        }
        
        if (batalla.entrenadorActual.Nombre == nombreEntrenador)
        {
            if (!batalla.ConfirmandoEquipoCompleto())
            {
                return "Los entrenadores todavia no eligieron todos los pokemones para su equipo";
            }
            string final = batalla.Esquivar();
            string cambioDeTurno = batalla.CambiarTurno();
            string cierre = CierreDeLaBatalla(batalla);
            return final + "\n" + cambioDeTurno + cierre;
        }
        return "No es tu turno, no podes hacer movimientos";
    }
    
    // Cambia el pokemon activo de un entrenador
    /// <summary>
    /// 
    /// </summary>
    public static string CambiarPokemones(string nombreEntrenador, string nombrePokemon)
    {
        Entrenadores player = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (player == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }

        Batallas batalla = batallaencurso.BatallaPorEntrenador(player);
        if (batalla == null)
        {
            return "La partida no pudo ser encontrada";
        }

        if (batalla.entrenadorActual.Nombre == nombreEntrenador)
        {
            if (!batalla.ConfirmandoEquipoCompleto())
            {
                return "Los entrenadores todavia no eligieron todos los pokemones para su equipo";
            }

            Pokemon choosenPokemon = player.BuscarPokemonYGuardar(nombrePokemon);
            if (choosenPokemon == null)
            {
                return $"El pokemon {nombrePokemon} no fue encontrado en tu equipo";
            }
            
            if (choosenPokemon.Vida == 0)
            {
                return $"{nombreEntrenador}, tu pokemon actuall está fuera de combate. Cambie de pokemon.";
            }

            string final = batalla.CambiarPokemon(choosenPokemon);
            if (final == "Ese Pokemon no está en tu equipo.")
            {
                return final;
            }

            string cambioDeTurno = batalla.CambiarTurno();
            string cierre = CierreDeLaBatalla(batalla);
            return final + "\n" + cambioDeTurno + cierre;
        }

        return "No es tu turno, no podes hacer movimientos";
    }
    
    // Muestra los objetos disponibles en la mochila de un entrenador
    /// <summary>
    /// 
    /// </summary>
    public static string VerMochila(string nombreEntrenador)
    {
        Entrenadores? entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);

        if (entrenador == null || batallaencurso.BatallaPorEntrenador(entrenador) == null)
        {
            return $"{nombreEntrenador}, no estas en batalla.";
        }

        List<Objetos> listaObjetosUnicos = entrenador.MostrarMochila();
        string final = $"{nombreEntrenador}, tenes en la mochila los siguientes objetos:\n```";
    
        foreach (var objeto in listaObjetosUnicos)
        {
            int cantidad = entrenador.Mochila.Count(o => o.Nombre == objeto.Nombre);
            final += $"{cantidad} {objeto.Nombre}\n";
        }
        return final += "```" ;
    }
    
    // Usa un objeto de la mochila de un entrenador sobre un pokemon
    /// <summary>
    /// 
    /// </summary>
    public static string UsarObjetoMochila(string nombreEntrenador, string item, string pokemon)
    {
        Entrenadores player = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        Batallas batalla = batallaencurso.BatallaPorEntrenador(player);
        
        if (player == null)
        {
            return $"El entrenador {nombreEntrenador} no está en batalla.";
        }

        if (batalla == null)
        {
            return "La batalla no se ha encontrado.";
        }
        
        if (batalla.JugadoresDisponibles()[batalla.entrenadorActual == batalla.entrenador1 ? 0 : 1].Nombre == nombreEntrenador)
        {
            if (!batalla.ConfirmandoEquipoCompleto())
            {
                return "Los entrenadores todavia no eligieron todos los pokemones para su equipo";
            }

            string result = batalla.UsarMochila(player.BuscarObjeto(item), player.BuscarPokemonYGuardar(pokemon));
            if (result.Contains("recuperaron"))
            {
                string nextTurn = batalla.CambiarTurno();
                string batallaStatus = CierreDeLaBatalla(batalla);
                return result + "\n" + nextTurn + "\n" + batallaStatus;
            }
            return result;
        }

        return $"{player.Nombre}, no eres el jugador activo, no puedes realizar acciones";
    }

    // Seleccionar equipo usando strings
    /// <summary>
    /// 
    /// </summary>
    public static string SeleccionarEquipo(string nombreEntrenador, string nombrePokemon)
    {
        LogicaDePokemones logicaDePokemones = new LogicaDePokemones();
        List<Pokemon> listaPokemones = logicaDePokemones.InicializarPokemones();
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            // Solo se elige equipo al estar en una batalla
            return $"{nombreEntrenador}, para poder elegir un equipo, primero debes estar en una batalla";
        }
        if (entrenador.CantidadDePokemones < 6)
        {
            foreach (Pokemon pokemon in listaPokemones)
            {
                if (pokemon.Nombre == nombrePokemon)
                {
                    entrenador.AñadirPokemon(pokemon);
                    if (entrenador.CantidadDePokemones == 6)
                    {
                        return $"El pokemon {nombrePokemon} fue añadido al equipo de {nombreEntrenador}\nTu equipo está completo.";
                    }
                    return $"El pokemon {nombrePokemon} fue añadido al equipo de {nombreEntrenador}.\nQuedan **{entrenador.CantidadDePokemones} / 6** Pokemones por elegir";
                }
            }
            return $"{nombreEntrenador}, el pokemon {nombrePokemon} no fue encontrado";
        }
        return $"{nombreEntrenador} ya tenes 6 pokemones en el equipo, no podes elegir más";
    }
    
    //Método utilizado para formar un equipo de forma aleatoria, sin pasar por selección uno a uno
    /// <summary>
    /// 
    /// </summary>
    public static string elegirRandomente(string nombreEntrenador)
    {
        LogicaDePokemones logicaDePokemones = new LogicaDePokemones();
        List<Pokemon> listaPokemones = logicaDePokemones.InicializarPokemones();
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"{nombreEntrenador}, no estás en una partida.";
        }
        if (entrenador.CantidadDePokemones >= 6)
        {
            return $"{nombreEntrenador}, ya tenes un equipo completo de Pokémon.";
        }
        List<int> availablePokemonIndexes = Enumerable.Range(0, listaPokemones.Count).ToList();
        Random random = new Random();
        string final = $"{nombreEntrenador}, estos son los Pokemones elegidos aleatoriamente:\n**";
        while (entrenador.CantidadDePokemones < 6)
        {
            int valorRandom = random.Next(availablePokemonIndexes.Count);
            Pokemon pokemonElegido = listaPokemones[availablePokemonIndexes[valorRandom]];

            if (!entrenador.BuscarPokemon(pokemonElegido.Nombre))
            {
                entrenador.AñadirPokemon(pokemonElegido);
                final += $"{pokemonElegido.Nombre}\n";
                availablePokemonIndexes.RemoveAt(valorRandom);
            }
        }
        return final += "**";
    }
    // Muestra la lista de pokemon de un entrenador, junto con su estado, vida y tipo.
    // Si se especifica un segundo entrenador, muestra la lista de pokemon de ese entrenador.
    /// <summary>
    /// 
    /// </summary>
    public static string VerPokemones(string nombreEntrenador, string? nombreEntrenador2 = null)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }
        if (nombreEntrenador2 == null)
        {
            // Verifica si el equipo del entrenador está completo
            if (entrenador.CantidadDePokemones < 6)
            {
                return $"{entrenador.Nombre} aún no tenés tu equipo completo.";
            }
            string final = $"__{nombreEntrenador} esta es la vida de tus Pokemones:__ \n";
            foreach (Pokemon pokemon in entrenador.RecibirEquipoPokemon())
            {
                string tipo = "";
                if (pokemon.TipoPrincipal != null)
                {
                    tipo += $"{pokemon.TipoPrincipal.Nombre}";
                }
                
                if (pokemon.TipoSecundario != null)
                {
                    tipo += $" - {pokemon.TipoSecundario.Nombre}";
                }
                // Construye la descripción del pokemon según su estado y vida
                if (pokemon == entrenador.PokemonActivo)
                {
                    if (pokemon.Estado != null)
                    {
                        if (pokemon.Vida == 0)
                        {
                            final += $"~~{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo}) " + $"**({pokemon.Estado})**" + "**-MUERTO-**~~\n";
                        }
                        else
                        {
                            final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})**" + $" **({pokemon.Estado})**\n";
                        }
                    }
                    else
                    {
                        final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})**\n";
                    }
                }
                else if (pokemon.Vida == 0)
                {
                    final += $"~~{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo}) **-MUERTO-**~~\n";
                }
                else
                {
                    if (pokemon.Estado != null)
                    {
                        final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})" + $" **({pokemon.Estado})**\n";
                    }
                    else
                    {
                        final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})\n";
                    }
                }
                
            }
            return final;
        }
        else
        {
            // Si se especifica un segundo entrenador, verifica su existencia y muestra su equipo
            Entrenadores entrenador2 = batallaencurso.EntrenadorPorNombre(nombreEntrenador2);
            string final = $"Esta es la vida de los Pokemones de {nombreEntrenador2}: \n";
            Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
            if (batalla != null && batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador) && batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador2) && entrenador2 != null)
            {
                if (entrenador2.CantidadDePokemones < 6)
                {
                    return $"{nombreEntrenador2} aún no tiene su equipo completo.";
                }
                foreach (Pokemon pokemon in entrenador2.RecibirEquipoPokemon())
                {
                    string tipo = "";
                    if (pokemon.TipoPrincipal != null)
                        tipo += $"{pokemon.TipoPrincipal.Nombre} ";
    
                    if (pokemon == entrenador2.PokemonActivo)
                    {
                        if (pokemon.Estado != null)
                        {
                            if (pokemon.Vida == 0)
                            {
                                final += $"~~{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo}) " + $"**({pokemon.Estado})**" + "**-MUERTO-**~~\n";
                            }
                            else
                            {
                                final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})**" + $" **({pokemon.Estado})**\n";
                            }
                        }
                        else
                        {
                            final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} ({tipo})**\n";
                        }
                    }
                    else if (pokemon.Vida == 0)
                    {
                        final += $"~~{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo}) **-MUERTO-**~~\n";
                    }
                    else
                    {
                        if (pokemon.Estado != null)
                        {
                            final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})" + $" **({pokemon.Estado})**\n";
                        }
                        else
                        {
                            final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})\n";
                        }
                    }
                        
                }
                return final;
            }

            return $"El jugador {nombreEntrenador2} no está en tu partida.";
        }
    }

}
