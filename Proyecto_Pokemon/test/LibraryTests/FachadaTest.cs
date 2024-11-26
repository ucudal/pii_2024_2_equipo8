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
    
       
    

    // test que verifica si se muestra el mensaje cuando faltan pokemon para el equipo
     [Test]
        public void MeterUsuarioAlLobby_NuevoUsuario_DevuelveMensajeExitoso()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.Rendirse(nombreEntrenador);
            // Act
            Fachada.SacarEntrenadorDelLobby(nombreEntrenador);

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
            Assert.That(resultado,Is.EqualTo("Ash ya se encuentra en el Lobby."));
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
            
            string nombreEntrenador = "Ash";
            string nombreEntrenador2 = "Gary";
            Fachada.Rendirse(nombreEntrenador);
            Fachada.Rendirse(nombreEntrenador2);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
            Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
            
            string resultado = Fachada.VerHabilidades(nombreEntrenador);
            string resultado2 = Fachada.VerHabilidades(nombreEntrenador2);

            Assert.That(resultado,Does.Contain("Ash, no tenes ningún Pokémon."));
            Assert.That(resultado2,Does.Contain("Gary, no tenes ningún Pokémon."));

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
            string nombreEntrenador = "Ash";
            string nombreEntrenador2 = "Gary";
            string nombrePokemon = "Pikachu";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
            Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
            Fachada.elegirRandomente(nombreEntrenador);
            Fachada.elegirRandomente(nombreEntrenador2);
            Fachada.SeleccionarEquipo(nombreEntrenador, nombrePokemon);
            Fachada.SeleccionarEquipo(nombreEntrenador2, "SNORLAX");
            string resultado = Fachada.CambiarPokemones(nombreEntrenador, nombrePokemon);
            Assert.That(resultado, Does.Contain("Pikachu"));
        }
    }