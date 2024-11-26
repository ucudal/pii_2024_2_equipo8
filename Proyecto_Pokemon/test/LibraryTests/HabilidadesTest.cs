using NUnit.Framework;

namespace Proyecto_Pokemon
{
    [TestFixture]
    public class HabilidadesTest
    {
        private Habilidades habilidad;
        private ITipo tipoFuego;

        [SetUp]
        public void Setup()
        {
            // definimos un diccionario con las relaciones de efectividad de los tipos
            var elementoFuego = new Dictionary<string, double>
            {
                { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
                { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
                { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
                { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
            };
            tipoFuego = new Tipo("Fuego", elementoFuego);
            habilidad = new Habilidades("Llama", tipoFuego, 50, 90, 10, false);
        }

        // test que verifica si el nombre de la habilidad es el correcto
        [Test]
        public void Habilidad_DeberiaTenerNombreCorrecto()
        {
            Assert.That(habilidad.Nombre, Is.EqualTo("Llama"));
        }

        // test que verifica si el tipo de la habilidad es el correcto
        [Test]
        public void Habilidad_DeberiaTenerTipoCorrecto()
        {
            Assert.That(habilidad.Tipo, Is.EqualTo(tipoFuego));
        }

        // test que verifica si el daño de la habilidad es el correcto
        [Test]
        public void Habilidad_DeberiaTenerDanioCorrecto()
        {
            Assert.That(habilidad.Danio, Is.EqualTo(50));
        }

        // test que verifica si la precisión de la habilidad es la correcta
        [Test]
        public void Habilidad_DeberiaTenerPrecisionCorrecta()
        {
            Assert.That(habilidad.Precision, Is.EqualTo(90));
        }
        
        // test que verifica si los puntos de poder (PP) de la habilidad son los correctos
        [Test]
        public void Habilidad_DeberiaTenerPPCorrecto()
        {
            Assert.That(habilidad.Puntos_de_Poder, Is.EqualTo(10));
        }

        // test que verifica si la habilidad es de tipo doble turno (en este caso no lo es)
        [Test]
        public void Habilidad_DeberiaSerDobleTurno()
        {
            Assert.That(habilidad.EsDobleTurno, Is.EqualTo(false));
        }
    }
}