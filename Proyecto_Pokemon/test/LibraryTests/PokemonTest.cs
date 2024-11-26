namespace Proyecto_Pokemon;

using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class PokemonTest
{
    private ITipo tipoFuego;
    private ITipo tipoAgua;
    private IHabilidades habilidad;
    private Pokemon charmander;

    [SetUp]
    public void Setup()
    {
        tipoFuego = new Tipo("Fuego", new Dictionary<string, double> { { "Agua", 0.5 }, { "Planta", 2.0 } });
        tipoAgua = new Tipo("Agua", new Dictionary<string, double> { { "Fuego", 2.0 }, { "Planta", 0.5 } });
        habilidad = new Habilidades("Llamarada", tipoFuego, 50, 80, 10, false);
        charmander = new Pokemon("Charmander", 100, tipoFuego);
    }

    [Test]
    public void Pokemon_CrearPokemon_DeberiaAsignarNombreYVida()
    {
        Assert.That(charmander.Nombre, Is.EqualTo("Charmander"));
        Assert.That(charmander.Vida, Is.EqualTo(100));
        Assert.That(charmander.VidaBase, Is.EqualTo(100));
        Assert.That(charmander.TipoPrincipal, Is.EqualTo(tipoFuego));
        Assert.That(charmander.TipoSecundario, Is.Null);
        Assert.That(charmander.Habilidades.Count, Is.EqualTo(0));
        Assert.That(charmander.Estado, Is.Null);
    }

    [Test]
    public void Pokemon_AprenderHabilidad_DeberiaAgregarHabilidadALaLista()
    {
        charmander.AprenderHabilidad(habilidad);
        Assert.That(charmander.Habilidades.Count, Is.EqualTo(1));
        Assert.That(charmander.Habilidades[0].Nombre, Is.EqualTo("Llamarada"));
    }

    [Test]
    public void Pokemon_MostrarHabilidades_DeberiaMostrarHabilidadCorrectamente()
    {
        charmander.AprenderHabilidad(habilidad);
        var habilidades = charmander.MostrarHabilidades();
        
        // Se verifica que el formato sea correcto
        var resultadoEsperado = "**1. Llamarada** | Daño: 50 | Precisión: 80 | Tipo: Fuego | PP: 10 | Ataque Cargado: *False*\n";
        Assert.That(habilidades, Is.EqualTo(resultadoEsperado));
    }

    [Test]
    public void Pokemon_EjecutarAtaque_DeberiaReducirVidaDelDefensor()
    {
        var squirtle = new Pokemon("Squirtle", 100, tipoAgua);
        var resultado = Pokemon.EjecutarAtaque(charmander, squirtle, habilidad, esquivo: false);

        // El daño es afectado por la efectividad (50 * 0.5 = 25)
        Assert.That(squirtle.Vida, Is.EqualTo(75));
        Assert.That(resultado, Does.Contain("usó Llamarada, causando 25 puntos de daño"));
    }

    [Test]
    public void Pokemon_EjecutarAtaque_DeberiaFallarloSiNoTienePrecision()
    {
        var squirtle = new Pokemon("Squirtle", 100, tipoAgua);
        habilidad.Precision = 0; // Simulamos que la precisión es 0
        var resultado = Pokemon.EjecutarAtaque(charmander, squirtle, habilidad, esquivo: false);

        Assert.That(squirtle.Vida, Is.EqualTo(100));
        Assert.That(resultado, Does.Contain("falló el ataque"));
    }

    [Test]
    public void Pokemon_EjecutarAtaque_DeberiaAplicarEstadoSiCorresponde()
    {
        var quemar = new Efectos("Quemado"); // Usamos el constructor correcto
        habilidad.Efectos = quemar;
        var squirtle = new Pokemon("Squirtle", 100, tipoAgua);

        var resultado = Pokemon.EjecutarAtaque(charmander, squirtle, habilidad, esquivo: false);

        Assert.That(squirtle.Estado, Is.EqualTo("Quemado"));
        Assert.That(resultado, Does.Contain("ahora está Quemado"));
    }

}
