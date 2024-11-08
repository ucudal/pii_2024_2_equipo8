namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class BatallasTest
{
    private Batallas batalla;
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon charmander;

    [SetUp]
    public void Setup()
    {
        // Crea Pokemones, no les meti habilidades porque no las van a usar
        pikachu = new Pokemon("pikachu", 100, null);
        charmander = new Pokemon("charmander", 100, null);
        
        // Crea Entrenadores
        entrenador1 = new Entrenadores("Asho Ketchu", new List<Pokemon>() { pikachu });
        entrenador2 = new Entrenadores("Brokoso", new List<Pokemon>() { charmander });
        
        // Inicia la batalla con ambos entrenadores
        batalla = new Batallas(entrenador1, entrenador2);
    }

    [Test]
    public void Batalla_DeberiaIniciarConTurno1()
    {
        Assert.That(batalla.Turno, Is.EqualTo(1));
    }

    [Test]
    
    public void Iniciar_DeberiaEstablecerEntrenadoresEnBatalla()
    {
        batalla.Iniciar();
        Assert.That(entrenador1.EnBatalla, Is.True);
        Assert.That(entrenador2.EnBatalla, Is.True);
    }


    [Test]
    public void CambiarTurno_DeberiaCambiarEntrenadorActualYIncrementarTurno()
    {
        var entrenadorInicial = batalla.entrenadorActual;
        batalla.CambiarTurno();

        Assert.That(batalla.entrenadorActual, Is.Not.EqualTo(entrenadorInicial));
        Assert.That(batalla.Turno, Is.EqualTo(2));
    }

    [Test]
    public void VerVida_DeberiaMostrarVidaDeLosPokemones()
    {
        var resultadoEsperado = $"{entrenador1.Nombre}:\n{entrenador1.MostrarPokemones()}\n" +
                                $"{entrenador2.Nombre}:\n{entrenador2.MostrarPokemones()}\n";

        Assert.That(batalla.VerVida(), Is.EqualTo(resultadoEsperado));
    }

}
