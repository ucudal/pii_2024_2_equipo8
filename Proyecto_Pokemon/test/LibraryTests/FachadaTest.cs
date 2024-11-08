using NUnit.Framework;
using Proyecto_Pokemon;
using System.Collections.Generic;

[TestFixture]
public class FachadaTests
{
    private Fachada fachada;
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon charmander;
    private List<Pokemon> equipo;
    private ITipo tipoFuego;
    private ITipo tipoAgua;
    private IHabilidades habilidad;

    [SetUp]
    public void SetUp()
    {
        fachada = new Fachada();
        tipoFuego = new Tipo("Fuego", new Dictionary<string, double> { { "Agua", 0.5 }, { "Planta", 2.0 } });
        tipoAgua = new Tipo("Agua", new Dictionary<string, double> { { "Fuego", 2.0 }, { "Planta", 0.5 } });
        habilidad = new Habilidades("Llamarada", tipoFuego, 50, 80, 10, false);

        // cREA LOS POKEMONES
        pikachu = new Pokemon("Squirtle", 100, tipoAgua);
        charmander = new Pokemon("Charmander", 80, tipoFuego);
        
        charmander.AprenderHabilidad(habilidad);
        pikachu.AprenderHabilidad(habilidad);
        // Crea el equipo para los entrenadores
        equipo = new List<Pokemon> { pikachu, charmander };
        
        // Crea entrenadores con equipos
        entrenador1 = new Entrenadores("Ash Ketchum", equipo);
        entrenador2 = new Entrenadores("Brock", equipo);
        
        fachada.UnirseALaListaDeEspera(entrenador1);
        fachada.IniciarBatalla(entrenador2);
        fachada.GetPokemonActual();
    }

    [Test]
    public void SeleccionarEquipo_DeberiaRetornarQueFaltanPokemones()
    {
        
        var resultado = fachada.SeleccionarEquipo(entrenador1, equipo);
        Assert.That(resultado, Is.EqualTo("Debes seleccionar exactamente 6 Pokémon."));
    }

    [Test]
    public void MostrarHabilidades_DeberiaMostrarHabilidadesDelPokemonActual()
    {
        var habilidades = fachada.MostrarHabilidades();
        
        // Verifica que se muestran habilidades
        Assert.That(habilidades, Is.Not.Empty);
    }

    [Test]
    public void VerVida_DeberiaRetornarVidaDelPokemonEnBatalla()
    {
        fachada.IniciarBatalla(entrenador1);
        var vida = fachada.VerVida();
        Assert.That(vida, Is.Not.Empty);
    }

    [Test]
    public void EjecutarAtaque_DeberiaRealizarAtaqueYRetornarResultado()
    {
        fachada.IniciarBatalla(entrenador1);
        fachada.GetPokemonActual();
        var resultado = fachada.EjecutarAtaque(0);
        Assert.That(resultado, Is.Not.Null);
    }

    [Test]
    public void EsTurnoDe_DeberiaRetornarElNombreDelEntrenadorActual()
    {
        fachada.IniciarBatalla(entrenador1);
        var turno = fachada.EsTurnoDe();
        Assert.That(turno, Is.EqualTo("Turno de Brock"));
    }

    [Test]
    public void CheckFinBatalla_DeberiaRetornarMensajeDeBatallaEnCursoOFinalizada()
    {
        fachada.IniciarBatalla(entrenador1);
        var estadoBatalla = fachada.CheckFinBatalla();
        Assert.That(estadoBatalla, Is.Not.Empty);
    }

    [Test]
    public void CambiarPokemon_DeberiaCambiarPokemonYRetornarMensaje()
    {
        fachada.IniciarBatalla(entrenador1);
        var mensaje = fachada.CambiarPokemon(0);
        Assert.That(mensaje, Does.Contain("cambió a"));
    }

    [Test]
    public void UsarMochila_DeberiaUsarObjetoYRetornarResultado()
    {
        fachada.IniciarBatalla(entrenador1);
        var resultado = fachada.UsarMochila(0);
        Assert.That(resultado, Is.Not.Empty);
    }

    [Test]
    public void UnirseALaListaDeEspera_DeberiaAgregarEntrenadorALaListaYRetornarMensaje()
    {
        var mensaje = fachada.UnirseALaListaDeEspera(entrenador1);
        Assert.That(mensaje, Does.Contain("a la lista de espera en el lobby"));
    }

    [Test]
    public void VerListaDeEspera_DeberiaRetornarEntrenadoresEnLaLista()
    {
        fachada.UnirseALaListaDeEspera(entrenador1);
        fachada.UnirseALaListaDeEspera(entrenador2);
        var lista = fachada.VerListaDeEspera();
        Assert.That(lista, Does.Contain("Ash Ketchum").And.Contain("Brock"));
    }

    [Test]
    public void IniciarBatalla_DeberiaIniciarBatallaYRetornarMensaje()
    {
        fachada.UnirseALaListaDeEspera(entrenador1);
        var mensaje = fachada.IniciarBatalla(entrenador2);
        Assert.That(mensaje, Does.Contain("ha comenzado una batalla contra"));
    }

    [Test]
    public void MostrarPokemones_DeberiaRetornarListaDePokemonesDelEntrenador()
    {
        var pokemones = fachada.MostrarPokemones(entrenador1);
        Assert.That(pokemones, Is.Not.Empty);
    }
}
