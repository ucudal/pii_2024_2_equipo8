using NUnit.Framework;
using Proyecto_Pokemon;
using System.Collections.Generic;

[TestFixture]
public class FachadaTests
{
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon charmander;
    private List<Pokemon> equipo;
    private ITipo tipoFuego;
    private ITipo tipoAgua;
    private IHabilidades habilidad;

    [SetUp]
    public void SetUp()
    {
        tipoFuego = new Tipo("Fuego", new Dictionary<string, double> { { "Agua", 0.5 }, { "Planta", 2.0 } });
        tipoAgua = new Tipo("Agua", new Dictionary<string, double> { { "Fuego", 2.0 }, { "Planta", 0.5 } });
        habilidad = new Habilidades("Llamarada", tipoFuego, 50, 80, 10, false);

        // cREA LOS POKEMONES
        pikachu = new Pokemon("Squirtle", 100, tipoAgua);
        charmander = new Pokemon("Charmander", 80, tipoFuego);

        charmander.AprenderHabilidad(habilidad);
        pikachu.AprenderHabilidad(habilidad);
        // Crea el equipo para los entrenadores
        equipo = new List<Pokemon> { pikachu, charmander };

        // Crea entrenadores con equipos
        entrenador1 = new Entrenadores("Ash Ketchum");
        entrenador2 = new Entrenadores("Brock");

       
    }

    // test que verifica si se muestra el mensaje cuando faltan pokemon para el equipo
     [Test]
        public void MeterUsuarioAlLobby_NuevoUsuario_DevuelveMensajeExitoso()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            // Act
            string resultado = Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            // Assert
            Assert.That(resultado, Is.EqualTo("Ash ha sido agregado en el Lobby para un encuentro."));
        }
        [Test]
        public void MeterUsuarioAlLobby_UsuarioYaEnBatalla_DevuelveError()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            // Simula que el usuario ya está en una batalla
            Fachada.IniciarBatalla("Ash", "Gary");
            // Act
            string resultado = Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            // Assert
            Assert.That(resultado,Is.EqualTo("Ash ya te encuentras en una batalla y no podes ser agregado al Lobby."));
        }
        [Test]
        public void CrearBatalla_EntrenadoresDisponibles_DevuelveMensajeInicioBatalla()
        {
            // Arrange
            string entrenador1 = "Ash";
            string entrenador2 = "Gary";
            Fachada.MeterUsuarioAlLobby(entrenador1);
            Fachada.MeterUsuarioAlLobby(entrenador2);
            // Act
            string resultado = Fachada.CrearBatalla(entrenador1, entrenador2);
            // Assert
            Assert.That(resultado,Does.Contain("EMPIEZA LA PELEA ENTRE Ash CONTRA Gary"));
        }
        [Test]
        public void VerHabilidades_EntrenadorSinPokemonActivo_DevuelveError()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");
            // Act
            string resultado = Fachada.VerHabilidades(nombreEntrenador);
            // Assert
            Assert.That(resultado,Does.Contain("no tenes un pokemon principal."));
        }
        [Test]
        public void ElegirRandommente_EquipoCompleto_DevuelveError()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");
            // Simula un equipo completo
            for (int i = 0; i < 6; i++)
            {
                Fachada.SeleccionarEquipo(nombreEntrenador, $"Pokemon_{i}");
            }
            // Act
            string resultado = Fachada.elegirRandomente(nombreEntrenador);
            // Assert
            Assert.That(resultado,Is.EqualTo("Ash, ya tenes un equipo completo de Pokémon."));
        }
        [Test]
        public void CambiarPokemones_CambioExitoso_DevuelveMensajeCorrecto()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            string nombrePokemon = "Pikachu";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");
            Fachada.SeleccionarEquipo(nombreEntrenador, nombrePokemon);
            // Act
            string resultado = Fachada.CambiarPokemones(nombreEntrenador, nombrePokemon);
            // Assert
            Assert.That(resultado,Does.Contain("Pikachu"));
        }
    }