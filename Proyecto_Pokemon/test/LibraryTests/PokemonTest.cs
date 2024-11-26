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
        charmander = new Pokemon("Charmeleon", 100, tipoFuego);
    }

    // Se verifica que el pokemon tenga el nombre correcto (Charmeleon) y se verifica que el pokemon tenga 100 de vida
    [Test]
    public void Pokemon_CrearPokemon_DeberiaAsignarNombreYVida()
    {
        Assert.That(charmander.Nombre, Is.EqualTo("Charmeleon"));
        Assert.That(charmander.Vida, Is.EqualTo(100));
    }

    [Test]
    public void Pokemon_AprenderHabilidad_DeberiaAgregarHabilidadALaLista()
    {
        charmander.AprenderHabilidad(habilidad);
        // se verifica que la lista de habilidades tenga un solo elemento
        Assert.That(charmander.Habilidades.Count, Is.EqualTo(1));
        // se verifica que la habilidad que aprendió sea "Llamarada"
        Assert.That(charmander.Habilidades[0].Nombre, Is.EqualTo("Llamarada"));
    }

    [Test]
    public void Pokemon_MostrarHabilidades_DeberiaMostrarHabilidadCorrectamente()
    {
        charmander.AprenderHabilidad(habilidad);
        var habilidades = charmander.MostrarHabilidades();
        // se verifica que la lista de habilidades tenga habilidades (obviamente, hay que confirmar si un vaso con agua tiene agua :D)
        Assert.That(habilidades.Count, Is.EqualTo(1));

        var habilidadObtenida = habilidades[0];
        var resultado = $"1. {habilidadObtenida.Nombre} - Daño: {habilidadObtenida.Danio}, Precisión: {habilidadObtenida.Precision}, Tipo: {habilidadObtenida.Tipo.Nombre}, Puntos de poder: {habilidadObtenida.Puntos_de_Poder}, Doble turno: {habilidadObtenida.EsDobleTurno}";

        // se verifica si la habilidad está bien
        Assert.That(resultado, Is.EqualTo("1. Llamarada - Daño: 50, Precisión: 80, Tipo: Fuego, Puntos de poder: 10, Doble turno: False"));
    }
}