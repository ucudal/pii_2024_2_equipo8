using NUnit.Framework;

namespace Proyecto_Pokemon.Tests
{
    [TestFixture]
    public class FachadaTests
    {
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
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla("Ash", "Gary");

            // Act
            string resultado = Fachada.MeterUsuarioAlLobby(nombreEntrenador);

            // Assert
            Assert.That(resultado, Is.EqualTo("Ash ya te encuentras en una batalla y no podes ser agregado al Lobby."));
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
            Assert.That(resultado.Contains("EMPIEZA LA PELEA ENTRE Ash CONTRA Gary"), Is.True);
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
            Assert.That(resultado.Contains("no tenes un pokemon principal."), Is.True);
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
            Assert.That(resultado, Is.EqualTo("Ash, ya tenes un equipo completo de Pokémon."));
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
            Assert.That(resultado.Contains("Pikachu"), Is.True);
        }
    }
}
