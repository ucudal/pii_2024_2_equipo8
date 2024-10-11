namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class BatallaTest
{
    private Batallas batalla;
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon charmander;

    [SetUp]
    public void Setup()
    {
        pikachu = new Pokemon("Pikachu", 100, null);
        charmander = new Pokemon("Charmander", 100, null);

        entrenador1 = new Entrenadores("Ash", new List<Pokemon>() { pikachu });
        entrenador2 = new Entrenadores("Brock", new List<Pokemon>() { charmander });

        batalla = new Batallas(entrenador1, entrenador2);
    }

    [Test]
    public void Batalla_DeberiaIniciarConTurno1()
    {
        Assert.That(batalla.Turno, Is.EqualTo(1));
    }

    [Test]
    public void Batalla_DeberiaCambiarDeTurno()
    {
        batalla.Atacar();
        Assert.That(batalla.Turno,Is.EqualTo(2));
    }

    [Test]
    public void Atacar_DeberiaReducirVidaDelPokemonDefensor()
    {
        IHabilidades ataque = new Habilidades("Impactrueno", null, 20, 80,30, false);
        batalla.Atacar();

        Assert.That(charmander.Vida, Is.LessThan(100));
    }

    
}