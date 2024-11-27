using NUnit.Framework;

namespace Proyecto_Pokemon.Tests
{
    [TestFixture]
    public class FachadaTests
    {
        // Métodos de prueba existentes...

        // Métodos de prueba para los métodos que no tienen pruebas

        [Test]
        public void OpcionesPokemones_DevuelveListaDePokemones()
        {
            // Arrange
            string resultadoEsperado = "**Opciones para el Equipo:**\n"; // Ajusta según la implementación
            Fachada.MeterUsuarioAlLobby("Ash");

            // Act
            string resultado = Fachada.OpcionesPokemones();

            // Assert
            Assert.That(resultado.StartsWith(resultadoEsperado), Is.True);
        }

        [Test]
        public void ElegirHabilidad_PokemonActivoSinHabilidad_DevuelveError()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");
            Fachada.SeleccionarEquipo(nombreEntrenador, "Pikachu"); // Asegúrate de que Pikachu esté en el equipo

            // Act
            string resultado = Fachada.ElegirHabilidad(nombreEntrenador, "HabilidadInexistente");

            // Assert
            Assert.That(resultado.Contains("no se encuentra disponible"), Is.True);
        }

        [Test]
        public void RevisarTurno_EntrenadorNoEnBatalla_DevuelveError()
        {
            // Arrange
            string nombreEntrenador = "Ash";

            // Act
            string resultado = Fachada.RevisarTurno(nombreEntrenador);

            // Assert
            Assert.That(resultado.Contains("no se encuentra en ninguna batalla"), Is.True);
        }

        [Test]
        public void CierreDeLaBatalla_BatallaFinalizada_DevuelveGanador()
        {
            // Arrange
            string nombreEntrenador1 = "Ash";
            string nombreEntrenador2 = "Gary";

            Fachada.MeterUsuarioAlLobby(nombreEntrenador1);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
            Fachada.CrearBatalla(nombreEntrenador1, nombreEntrenador2);
            // Simula una batalla finalizada
            Batallas batalla = Fachada.batallaencurso.BatallaPorEntrenador(Fachada.batallaencurso.EntrenadorPorNombre(nombreEntrenador1));
            // Aquí deberías simular que la batalla ha finalizado

            // Act
            string resultado = Fachada.CierreDeLaBatalla(batalla);

            // Assert
            Assert.That(resultado.Contains("ganador"), Is.True);
        }

        [Test]
        public void IniciarBatalla_EntrenadoresEnLobby_DevuelveMensajeInicioBatalla()
        {
            // Arrange
            string entrenador1 = "Ash";
            string entrenador2 = "Gary";

            Fachada.MeterUsuarioAlLobby(entrenador1);
            Fachada.MeterUsuarioAlLobby(entrenador2);

            // Act
            string resultado = Fachada.IniciarBatalla(entrenador1, entrenador2);

            // Assert
            Assert.That(resultado.Contains("EMPIEZA LA PELEA ENTRE"), Is.True);
        }

        [Test]
        public void SacarEntrenadorDelLobby_EntrenadorEnLobby_DevuelveMensajeExitoso()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);

            // Act
            string resultado = Fachada.SacarEntrenadorDelLobby(nombreEntrenador);

            // Assert
            Assert.That(resultado, Is.EqualTo("Ash fue sacado del Lobby."));
        }

        [Test]
        public void VerLobby_NoHayEntrenadores_DevuelveMensajeVacio()
        {
            // Act
            string resultado = Fachada.VerLobby();

            // Assert
            Assert.That(resultado, Is.EqualTo("Nadie se encuentra en el Lobby actualmente"));
        }

        [Test]
        public void UsarObjetoMochila_EntrenadorConObjeto_DevuelveMensajeUso()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");
                       // Simula que Ash tiene un objeto en su mochila
            Fachada.AgregarObjetoAMochila(nombreEntrenador, "Poción");

            // Act
            string resultado = Fachada.UsarObjetoMochila(nombreEntrenador, "Poción");

            // Assert
            Assert.That(resultado, Is.EqualTo("Has usado una Poción."));
        }

        [Test]
        public void SeleccionarEquipo_EntrenadorSinPokemon_DevuelveError()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");

            // Act
            string resultado = Fachada.SeleccionarEquipo(nombreEntrenador, "Pikachu");

            // Assert
            Assert.That(resultado.Contains("no tienes ese Pokémon en tu equipo"), Is.True);
        }

        [Test]
        public void VerPokemones_EntrenadorConPokemones_DevuelveListaDePokemones()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.IniciarBatalla(nombreEntrenador, "Gary");
            // Simula que Ash tiene pokemones en su equipo
            Fachada.SeleccionarEquipo(nombreEntrenador, "Pikachu");

            // Act
            string resultado = Fachada.VerPokemones(nombreEntrenador);

            // Assert
            Assert.That(resultado.Contains("Pikachu"), Is.True);
        }

        [Test]
        public void EsquivarPokemon_EntrenadorActivo_DevuelveMensajeEsquive()
        {
            // Arrange
            string nombreEntrenador = "Ash";
            string oponente = "Gary";

            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.MeterUsuarioAlLobby(oponente);
            Fachada.IniciarBatalla(nombreEntrenador, oponente);
            Fachada.SeleccionarEquipo(nombreEntrenador, "Pikachu"); // Asegúrate de que Pikachu esté en el equipo

            // Act
            string resultado = Fachada.EsquivarPokemon(nombreEntrenador);

            // Assert
            Assert.That(resultado, Is.EqualTo("Ash ha esquivado el ataque de Gary."));
        }
    }
}