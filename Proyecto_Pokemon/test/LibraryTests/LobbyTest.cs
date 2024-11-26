using NUnit.Framework;
using Proyecto_Pokemon;
using System.Collections.Generic;

<<<<<<< HEAD
namespace Proyecto_Pokemon
{
    [TestFixture]
    public class LobbyTests
    {
=======
namespace Proyecto_Pokemon;

[TestFixture]
public class LobbyTests
{
>>>>>>> 8505a4e59e12baba60efe23f25b5f24d3e5d2b31
        private Lobby lobby;
        private Entrenadores entrenador1;
        private Entrenadores entrenador2;
        
        [SetUp]
        public void SetUp()
        {
            // Crear un Pokémon básico para los entrenadores
            var pokemonBasico = new Pokemon("Pikachu", 100, new Tipo("Eléctrico", new Dictionary<string, double>()));

            // Inicializamos el lobby y los entrenadores con un Pokémon 
            lobby = new Lobby();
            
            entrenador1 = new Entrenadores("Ash");
            entrenador2 = new Entrenadores("Misty");
            entrenador1.AñadirPokemon(pokemonBasico);
            entrenador2.AñadirPokemon(pokemonBasico);
        }

        // se agrega un entrenador cuando hay capacidad disponible en el lobby
        [Test]
        public void AgregarEntrenadorALobby()
        {
            string nombreEntrenador1 = "Ash";
            bool resultadoBool = lobby.AgregarEntrenadores(nombreEntrenador1);
            string resultado = lobby.VerListaLobby();
            Assert.That(resultadoBool, Is.EqualTo(true));
            Assert.That(resultado, Is.EqualTo("Ash\n"));
        }

        // se agrega un entrenador a la lista de espera y luego intentamos agregarlo de nuevo
        [Test]
        public void AgregarEntrenadorQueYaEstaEnListaDeEspera()
        {
            string nombreEntrenador1 = "Ash";
            lobby.AgregarEntrenadores(nombreEntrenador1);
            bool resultado = lobby.AgregarEntrenadores(nombreEntrenador1);

            // tendria que indicar que el entrenador ya está en la lista
            Assert.That(resultado, Is.EqualTo(false));
        }
        // se verifica que la lista de espera contenga los nombres de los entrenadores
        [Test]
        public void VerListaDeEspera()
        {
            string nombreEntrenador1 = "Ash";
            string nombreEntrenador2 = "Misty";
            lobby.AgregarEntrenadores(nombreEntrenador1);
            lobby.AgregarEntrenadores(nombreEntrenador2);

            string listaEsperada =  "Ash\nMisty\n" ;
            Assert.That(lobby.VerListaLobby(), Is.EqualTo(listaEsperada));
        }
        // Prueba para agregar un entrenador con nombre nulo o vacío
        [Test]
        public void AgregarEntrenadorNombreNuloOEmpty()
        {
            Assert.Throws<ArgumentException>(() => lobby.AgregarEntrenadores(null));
            Assert.Throws<ArgumentException>(() => lobby.AgregarEntrenadores(""));
        }

        // Prueba para eliminar un entrenador existente
        [Test]
        public void SacarEntrenadorExiste()
        {
            
            lobby.AgregarEntrenadores("Ash");
            
            bool resultado = lobby.SacarEntrenadores("Ash");

            // Assert
            Assert.That(resultado, Is.EqualTo(true));
            Assert.That(lobby.EntrenadorPorNombre("Ash"),Is.EqualTo(null));
        }

        // Prueba para intentar eliminar un entrenador que no existe
        [Test]
        public void SacarEntrenadorNoExiste()
        {
            bool resultado = lobby.SacarEntrenadores("Ash");
            
            Assert.That(resultado, Is.EqualTo(false));
        }

        // Prueba para eliminar un entrenador con nombre nulo o vacío
        [Test]
        public void SacarEntrenadoresNombreNuloOEmpty()
        {
            lobby.AgregarEntrenadores("Ash");

            bool resultadoNull = lobby.SacarEntrenadores(null);
            bool resultadoEmpty = lobby.SacarEntrenadores("");

            Assert.That(resultadoNull, Is.EqualTo(false));
            Assert.That(resultadoEmpty, Is.EqualTo(false));
        }

        // Prueba para obtener un entrenador por nombre cuando existe
        [Test]
        public void EntrenadorPorNombreEntrenadorExiste()
        {
            
            lobby.AgregarEntrenadores("Ash");

            var entrenador = lobby.EntrenadorPorNombre("Ash");
            Assert.That(entrenador.Nombre, Is.EqualTo("Ash"));
        }

        // Prueba para obtener un entrenador por nombre cuando no existe
        [Test]
        public void EntrenadorPorNombreEntrenadorNoExiste()
        {
            
            var entrenador = lobby.EntrenadorPorNombre("Ash");

            Assert.That(entrenador, Is.EqualTo(null));
        }

        // Prueba para obtener un entrenador por nombre nulo o vacío
        [Test]
        public void EntrenadorPorNombreNombreNuloOEmpty()
        {
            
            lobby.AgregarEntrenadores("Ash");

            var entrenadorNull = lobby.EntrenadorPorNombre(null);
            var entrenadorEmpty = lobby.EntrenadorPorNombre("");

            Assert.That(entrenadorNull, Is.EqualTo(null));
            Assert.That(entrenadorEmpty, Is.EqualTo(null));
        }

        // Prueba para asignar un oponente random cuando solo hay un entrenador
        [Test]
        public void AnadirRandomSoloUnEntrenador()
        {
            
            lobby.AgregarEntrenadores("Ash");

            var oponente = lobby.AnadirRandom("Ash");

            Assert.That(oponente, Is.EqualTo(null));
        }

        // Prueba para asignar un oponente random cuando hay varios entrenadores
        [Test]
        public void AnadirRandomVariosEntrenadores()
        {
            
            lobby.AgregarEntrenadores("Ash");
            lobby.AgregarEntrenadores("Misty");
            lobby.AgregarEntrenadores("Brock");

            var oponente = lobby.AnadirRandom("Ash");

            Assert.That(oponente, Is.Not.EqualTo(null));
            Assert.That(oponente.Nombre, Is.Not.EqualTo("Ash"));
        }

        // Prueba para verificar la lista del lobby cuando no hay entrenadores
        [Test]
        public void VerListaLobbySinEntrenadores()
        {
            // No se agregan entrenadores

            string lista = lobby.VerListaLobby();

            Assert.That(lista, Is.EqualTo(null));
        }

        // Prueba para verificar la propiedad Cantidad cuando no hay entrenadores
        [Test]
        public void CantidadSinEntrenadores()
        {
            // No se agregan entrenadores
            Assert.That(lobby.Cantidad, Is.EqualTo(0));
        }

        // Prueba para verificar la propiedad Cantidad con entrenadores
        [Test]
        public void CantidadConEntrenadores()
        {
            lobby.AgregarEntrenadores("Ash");
            lobby.AgregarEntrenadores("Misty");

            Assert.That(lobby.Cantidad, Is.EqualTo(2));
        }

        
<<<<<<< HEAD
        [Test]
        public void IniciarBatallaConEntrenadoresDisponibles()
        {
            lobby.UnirseALaListaDeEspera(entrenador1);
            lobby.UnirseALaListaDeEspera(entrenador2);

            lobby.IniciarBatalla(entrenador1);

            // se verifica que ambos entrenadores estén en batalla
            Assert.That(entrenador1.EnBatalla, Is.EqualTo(true));
            Assert.That(entrenador2.EnBatalla, Is.EqualTo(true));
        }

        [Test]
        public void IniciarBatallaConListaEsperaVacia()
        {
            string resultado = lobby.IniciarBatalla(entrenador1);

            // se verifica que el entrenador no esté en batalla
            Assert.That(entrenador1.EnBatalla, Is.EqualTo(false));
        }
    }
}
=======
    }
>>>>>>> 8505a4e59e12baba60efe23f25b5f24d3e5d2b31
