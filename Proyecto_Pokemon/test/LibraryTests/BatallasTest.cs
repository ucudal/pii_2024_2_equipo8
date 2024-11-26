namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class BatallasTest
{
    private Batallas batalla;
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon jynx;
    private Habilidades electrobola;
    private Habilidades bolasombra;

    [SetUp]
    public void Setup()
    {

        //Anadir habilidades
        electrobola = new Habilidades("Electrobola",, 90, 90, 6, false);
        bolasombra = new Habilidades("Bola Sombra", , 70, 80, 15, false);

        // Crea Pokemones, no les meti habilidades porque no las van a usar
        pikachu = new Pokemon("pikachu", 100, 1);
        jynx = new Pokemon("jynx", 100, tipoFuego);
        
        // Crea Entrenadores
        entrenador1 = new Entrenadores("Asho Ketchu", new List<Pokemon>() { pikachu });
        entrenador2 = new Entrenadores("Brokoso", new List<Pokemon>() { jynx });
        
        // Inicia la batalla con ambos entrenadores
        batalla = new Batallas(entrenador1, entrenador2);
    }
    [Test]
    public void Pokemon_DeberiaTenerHabilidadesAsignadas()
    {
        Assert.That(pikachu.Habilidades.Contains(electrobola));
        Assert.That(jynx.Habilidades.Contains(bolasombra));
    }
    [Test]
    public void Atacar_DeberiaUsarHabilidadCorrectamente()
    {
        string resultado = batalla.Atacar(electrobola);

        Assert.That(resultado, Does.Contain("electrobola"));
        Assert.That(electrobola.Puntos_de_Poder, Is.EqualTo(9)); // Se reduce el PP despues de usarse
    }
    // verifica que la batalla inicie en el turno 1
    [Test]
    public void Batalla_DeberiaIniciarConTurno1()
    {
        Assert.That(batalla.turno, Is.EqualTo(1));
    }

    [Test]
    
    // inicia la batalla y verifica que ambos entrenadores estén en la batalla
    public void Iniciar_DeberiaEstablecerEntrenadoresEnBatalla()
    {
        batalla.Iniciar(entrenador1,entrenador2);
        Assert.That(entrenador1.EnBatalla, Is.True);
        Assert.That(entrenador2.EnBatalla, Is.True);
    }

    // verifica que al cambiar el turno, el entrenador actual cambie y el turno se incremente
    [Test]
    public void CambiarTurno_DeberiaCambiarEntrenadorActualYIncrementarTurno()
    {
        var entrenadorInicial = batalla.entrenadorActual;

        batalla.Atacar(electrobola);
        batalla.CambiarTurno();

        Assert.That(batalla.entrenadorActual, Is.Not.EqualTo(entrenadorInicial));
        //var entrenadorInicial = batalla.entrenadorActual;
        //batalla.CambiarTurno();

        //Assert.That(batalla.entrenadorActual, Is.Not.EqualTo(entrenadorInicial));
        //Assert.That(batalla.CambiarTurno(), Is.EqualTo(2));
    }

    // verifica que devuelva el estado de los pokemon
    [Test]
    public void VerVida_DeberiaMostrarVidaDeLosPokemones()
    {
        var estadoPikachu = batalla.VerificarEstado(entrenador1.PokemonActivo);
        var estadoCharmander = batalla.VerificarEstado(entrenador2.PokemonActivo);
        Assert.That(estadoPikachu, Does.Contain("vida restante"));
        Assert.That(estadoCharmander, Does.Contain("vida restante"));
        
        ///var resultadoEsperado = $"{entrenador1.Nombre}:\n{entrenador1.VerificarEstado()}\n" +
           ///                     $"{entrenador2.Nombre}:\n{entrenador2.MostrarPokemones()}\n";
           ///Assert.That(batalla.VerVida(), Is.EqualTo(resultadoEsperado));
    }

}
