namespace Proyecto_Pokemon
{
    public class Fachada
    {
        private Lobby lobbyActual = new Lobby("Mitre", "LATAM", 10);
        private LogicaDePokemones TodosLosPoke = new LogicaDePokemones();
        public Batallas batallaActual;
        public Pokemon pokemonActual;
        private bool esquivo;
        private static Fachada? _instance;

        // Este constructor privado impide que otras clases puedan crear instancias
        // de esta.
        private Fachada()
        {
            
        }

        /// <summary>
        /// Obtiene la única instancia de la clase <see cref="Facade"/>.
        /// </summary>
        public static Fachada Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Fachada();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Inicializa este singleton. Es necesario solo en los tests.
        /// </summary>
        public static void Reset()
        {
            _instance = null;
        }

        // permite al entrenador seleccionar un equipo de 6 pokemones
        public string SeleccionarEquipo(Entrenadores entrenador, List<Pokemon> equipoSeleccionado)
        {
            return entrenador.SeleccionarEquipo(equipoSeleccionado);
        }

        // muestra las habilidades del pokemon actual en formato detallado
        public string MostrarHabilidades()
        {
            GetPokemonActual();
            string habilidades = "";
            List<IHabilidades> habilidadesList = pokemonActual.MostrarHabilidades();
            for (int i = 0; i < habilidadesList.Count; i++)
            {
                var habilidad = habilidadesList[i];
                habilidades += $"{i + 1}. {habilidad.Nombre} - Daño: {habilidad.Danio}, Precisión: {habilidad.Precision}, Tipo: {habilidad.Tipo.Nombre}, PP: {habilidad.PP}, Doble turno: {habilidad.EsDobleTurno}; ";
            }
            return habilidades;
        }

        // muestra la vida actual de los pokemones en batalla
        public string VerVida()
        {
            return batallaActual.VerVida();
        }

        // ejecuta el ataque seleccionado por el usuario
        public string EjecutarAtaque(int indiceHabilidad)
        {
            Pokemon atacante = batallaActual.entrenadorActual == batallaActual.entrenador1 ? batallaActual.pokemonActivo1 : batallaActual.pokemonActivo2;
            Pokemon defensor = batallaActual.entrenadorActual == batallaActual.entrenador1 ? batallaActual.pokemonActivo2 : batallaActual.pokemonActivo1;

            if (atacante.HabilidadCargando != null)
            {
                // resuelve el ataque en el segundo turno de habilidades de doble turno
                string resultado = RealizarAtaque(atacante, defensor, atacante.HabilidadCargando);
                atacante.HabilidadCargando = null;
                CambiarTurno();
                return resultado;
            }
            else
            {
                // verifica el índice de habilidad y realiza el ataque
                if (indiceHabilidad < 0 || indiceHabilidad >= atacante.Habilidades.Count)
                {
                    return "La habilidad que elegiste no existe. Inténtalo de nuevo.";
                }

                IHabilidades habilidad = atacante.Habilidades[indiceHabilidad];

                if (habilidad.PP <= 0)
                {
                    return $"La habilidad {habilidad.Nombre} no tiene PP suficientes, elige otra habilidad.";
                }

                habilidad.PP--;

                if (habilidad.EsDobleTurno)
                {
                    atacante.HabilidadCargando = habilidad;
                    CambiarTurno();
                    return $"{atacante.Nombre} está cargando la habilidad {habilidad.Nombre}...";
                }
                else
                {
                    string resultado = RealizarAtaque(atacante, defensor, habilidad);
                    CambiarTurno();
                    return resultado;
                }
            }
        }

        // hace el cálculo de ataque y daño entre dos pokemones
        private string RealizarAtaque(Pokemon atacante, Pokemon defensor, IHabilidades habilidad)
        {
            double efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoPrincipal);
            double multiplicador = efectividad;

            if (defensor.TipoSecundario != null)
            {
                efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoSecundario);
                multiplicador *= efectividad;
            }

            Random random = new Random();
            int probabilidad = random.Next(0, 100);
            int precisionFinal = habilidad.Precision;

            if (esquivo)
            {
                precisionFinal -= 30;
                esquivo = false; // resetear el estado de esquivar
            }

            if (probabilidad <= precisionFinal)
            {
                int danio = (int)(habilidad.Danio * multiplicador);

                if (random.Next(0, 100) < 10 && habilidad.EsDobleTurno)
                {
                    danio = (int)(danio * 1.2);
                    // Puedes retornar un mensaje indicando el golpe crítico si lo deseas
                }

                defensor.Vida -= danio;
                if (defensor.Vida <= 0)
                {
                    defensor.Vida = 0;
                    return $"{atacante.Nombre} usó {habilidad.Nombre}, hizo {danio} puntos de daño, {defensor.Nombre} ha sido debilitado!";
                }

                string resultado = $"{atacante.Nombre} usó {habilidad.Nombre}, hizo {danio} puntos de daño, la vida actual de {defensor.Nombre} = {defensor.Vida}";

                if (habilidad.Efectos != null && random.Next(0, 100) < 100 && defensor.Estado == null)
                {
                    defensor.Estado = habilidad.Efectos.Nombre;
                    resultado += $"\n{defensor.Nombre} ahora está {defensor.Estado}!";
                }

                return resultado;
            }
            else
            {
                return $"{atacante.Nombre} falló el ataque";
            }
        }

        // activa el estado de esquivar en el próximo turno
        public void Esquivar()
        {
            esquivo = true;
        }

        // devuelve el nombre del entrenador que tiene el turno actual
        public string EsTurnoDe()
        {
            return $"Turno de {batallaActual.entrenadorActual.Nombre}";
        }

        // chequea si la batalla terminó y retorna el ganador
        public string CheckFinBatalla()
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

        // cambia el pokemon activo por otro del equipo del entrenador actual
        public string CambiarPokemon(int indicePokemon)
        {
            if (indicePokemon >= batallaActual.entrenadorActual.Pokemones.Count || indicePokemon < 0)
            {
                return "El Pokémon que elegiste no existe. Inténtalo de nuevo.";
            }

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
                Entrenadores entrenadorPre = batallaActual.entrenadorActual;
                // Cambiar el turno después de cambiar de Pokémon
                CambiarTurno();

                return $"{entrenadorPre.Nombre} cambió a {entrenadorPre.Pokemones[indicePokemon].Nombre}";
            }
            else
            {
                return "No puedes elegir un Pokémon debilitado.";
            }
        }
        
        // usa un objeto de la mochila del entrenador y lo aplica al pokemon objetivo
        public string UsarMochila(int indiceObjeto, int indicePokemon = -1)
        {
            Entrenadores entrenador = batallaActual.entrenadorActual;
            Pokemon objetivo = entrenador == batallaActual.entrenador1 ? batallaActual.pokemonActivo1 : batallaActual.pokemonActivo2;

            if (indiceObjeto >= entrenador.Mochila.Count || indiceObjeto < 0)
            {
                return "El objeto que elegiste no existe. Inténtalo de nuevo.";
            }

            Objetos objeto = entrenador.Mochila[indiceObjeto];

            string resultado = "";

            switch (objeto)
            {
                case SuperPocion superPocion:
                    resultado = superPocion.Usar(objetivo, entrenador);
                    break;
                case Revivir revivir:
                    if (indicePokemon == -1)
                    {
                        return "Debes indicar el índice del Pokémon que quieres revivir.";
                    }
                    if (indicePokemon < 0 || indicePokemon >= entrenador.Pokemones.Count)
                    {
                        return "El Pokémon seleccionado no existe.";
                    }
                    Pokemon pokemonParaRevivir = entrenador.Pokemones[indicePokemon];
                    resultado = revivir.Usar(pokemonParaRevivir, entrenador);
                    break;
                case CuraTotal curaTotal:
                    resultado = curaTotal.Usar(objetivo, entrenador);
                    break;
                default:
                    return "No se puede usar ese objeto.";
            }

            // Remover el objeto usado de la mochila
            entrenador.Mochila.RemoveAt(indiceObjeto);
            CambiarTurno();
            return resultado;
        }

        // agrega un entrenador a la lista de espera del lobby
        public string UnirseALaListaDeEspera(Entrenadores entrenador)
        {
            return lobbyActual.UnirseALaListaDeEspera(entrenador);
        }

        // muestra todos los entrenadores que están en la lista de espera
        public string VerListaDeEspera()
        {
            string nombresJugadores = "Entrenadores en lista de espera: ";
            foreach (string nombreJugador in lobbyActual.VerListaDeEspera())
            {
                nombresJugadores += nombreJugador + " ";
            }
            return nombresJugadores;
        }

        // inicia una batalla entre el entrenador actual y el primero en la lista de espera
        public string IniciarBatalla(Entrenadores entrenador)
        {
            string nuevaBatalla = lobbyActual.IniciarBatalla(entrenador);
            GetBatallaActual();
            return nuevaBatalla;
        }

        // cambia el turno al siguiente entrenador
        public void GetBatallaActual()
        {
            if (lobbyActual.batallasActivas.Count > 0)
            {
                batallaActual = lobbyActual.batallasActivas[0];
            }
        }

        // retorna el pokemon actual del turno
        public void GetPokemonActual()
        {
            if (batallaActual.entrenadorActual == batallaActual.entrenador1)
            {
                pokemonActual = batallaActual.pokemonActivo1;
            }
            else
            {
                pokemonActual = batallaActual.pokemonActivo2;
            }
        }

        public string MostrarPokemones(Entrenadores entrenador)
        {
            return entrenador.MostrarPokemones();
        }

        private void CambiarTurno()
        {
            batallaActual.CambiarTurno();
        }
    }
}
