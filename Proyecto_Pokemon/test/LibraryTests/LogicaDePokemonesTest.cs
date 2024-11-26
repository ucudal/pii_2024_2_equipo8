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
        }
    }
}