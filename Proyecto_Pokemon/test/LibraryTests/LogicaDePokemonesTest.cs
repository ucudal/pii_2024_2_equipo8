using NUnit.Framework;
using Proyecto_Pokemon;

namespace Proyecto_Pokemon
{
    public class LogicaDePokemonesTests
    {
        private LogicaDePokemones logicaDePokemones;

        [SetUp]
        public void Setup()
        {
            // se inicializa la logica de los pokemones antes de cada prueba
            logicaDePokemones = new LogicaDePokemones();
        }

        [Test]
        public void InicializarPokemones_CreaDosPokemonesConHabilidades()
        {
            var pokemones = logicaDePokemones.InicializarPokemones();

            // se verifica que se hayan creado exactamente 18 pokemones
            Assert.That(pokemones.Count, Is.EqualTo(18));

            // se verifica que el primer pokemon (SCEPTILE) tenga las características correctas
            Assert.That(pokemones[0].Nombre, Is.EqualTo("SCEPTILE"));
            Assert.That(pokemones[0].Vida, Is.EqualTo(281));
            Assert.That(pokemones[0].Habilidades.Count, Is.EqualTo(4));

            // se verifican las habilidades del primer pokemon (SCEPTILE)
            Assert.That(pokemones[0].Habilidades[0].Nombre, Is.EqualTo("Corte furia"));
            Assert.That(pokemones[0].Habilidades[1].Nombre, Is.EqualTo("Energibola"));
            Assert.That(pokemones[0].Habilidades[2].Nombre, Is.EqualTo("Hoja Aguda"));
            Assert.That(pokemones[0].Habilidades[3].Nombre, Is.EqualTo("Lluevehojas"));

            // se verifica que el segundo pokemon (ARCANINE) tenga las características correctas
            Assert.That(pokemones[1].Nombre, Is.EqualTo("ARCANINE"));
            Assert.That(pokemones[1].Vida, Is.EqualTo(321));
            Assert.That(pokemones[1].Habilidades.Count, Is.EqualTo(4));

            // se verifican las habilidades del segundo pokemon (ARCANINE)
            Assert.That(pokemones[1].Habilidades[0].Nombre, Is.EqualTo("Ascuas"));
            Assert.That(pokemones[1].Habilidades[1].Nombre, Is.EqualTo("Lanzallamas"));
            Assert.That(pokemones[1].Habilidades[2].Nombre, Is.EqualTo("Velocidad Extrema"));
            Assert.That(pokemones[1].Habilidades[3].Nombre, Is.EqualTo("Envite igneo"));
            
            // se verifica que el segundo pokemon (BLASTOISE) tenga las características correctas
            Assert.That(pokemones[2].Nombre, Is.EqualTo("BLASTOISE"));
            Assert.That(pokemones[2].Vida, Is.EqualTo(299));
            Assert.That(pokemones[2].Habilidades.Count, Is.EqualTo(4));

            // se verifican las habilidades del segundo pokemon (BLASTOISE)
            Assert.That(pokemones[2].Habilidades[0].Nombre, Is.EqualTo("Hidroomba"));
            Assert.That(pokemones[2].Habilidades[1].Nombre, Is.EqualTo("Hidropulso"));
            Assert.That(pokemones[2].Habilidades[2].Nombre, Is.EqualTo("Acua cola"));
            Assert.That(pokemones[2].Habilidades[3].Nombre, Is.EqualTo("Pistola Agua"));
          
            // Verificación de SNORLAX
            Assert.That(pokemones[3].Nombre, Is.EqualTo("SNORLAX"));
            Assert.That(pokemones[3].Vida, Is.EqualTo(461));
            Assert.That(pokemones[3].Habilidades.Count, Is.EqualTo(4));

            // Verificación de las habilidades de SNORLAX
            Assert.That(pokemones[3].Habilidades[0].Nombre, Is.EqualTo("Golpe cuerpo"));
            Assert.That(pokemones[3].Habilidades[1].Nombre, Is.EqualTo("Mordisco"));
            Assert.That(pokemones[3].Habilidades[2].Nombre, Is.EqualTo("Fuerza equina"));
            Assert.That(pokemones[3].Habilidades[3].Nombre, Is.EqualTo("Gigaimpacto"));

            // Verificación de PIKACHU
            Assert.That(pokemones[4].Nombre, Is.EqualTo("PIKACHU"));
            Assert.That(pokemones[4].Vida, Is.EqualTo(211));
            Assert.That(pokemones[4].Habilidades.Count, Is.EqualTo(4));

            // Verificación de las habilidades de PIKACHU
            Assert.That(pokemones[4].Habilidades[0].Nombre, Is.EqualTo("Electrobola"));
            Assert.That(pokemones[4].Habilidades[1].Nombre, Is.EqualTo("Rayo"));
            Assert.That(pokemones[4].Habilidades[2].Nombre, Is.EqualTo("Puño Trueno"));
            Assert.That(pokemones[4].Habilidades[3].Nombre, Is.EqualTo("Trueno"));

            // Verificación de JYNX
            Assert.That(pokemones[5].Nombre, Is.EqualTo("JYNX"));
            Assert.That(pokemones[5].Vida, Is.EqualTo(271));
            Assert.That(pokemones[5].Habilidades.Count, Is.EqualTo(4));

            // Verificación de las habilidades de JYNX
            Assert.That(pokemones[5].Habilidades[0].Nombre, Is.EqualTo("Bola Sombra"));
            Assert.That(pokemones[5].Habilidades[1].Nombre, Is.EqualTo("Psiquico"));
            Assert.That(pokemones[5].Habilidades[2].Nombre, Is.EqualTo("Confusion"));
            Assert.That(pokemones[5].Habilidades[3].Nombre, Is.EqualTo("Cabezazo Zen"));
            
        }
    }
}