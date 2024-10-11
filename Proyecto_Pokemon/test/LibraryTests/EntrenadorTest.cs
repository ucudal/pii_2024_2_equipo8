﻿namespace Proyecto_Pokemon;

using NUnit.Framework;

[TestFixture]
public class EntrenadorTests
{
    private Entrenadores entrenador;

    [SetUp]
    public void Setup()
    {
        entrenador = new Entrenadores("Ash", new List<Pokemon>());  // Ajusta según el constructor
    }

    [Test]
    public void Entrenador_DeberiaTenerElNombreCorrecto()
    {
        Assert.That( entrenador.Nombre,Is.EqualTo("Ash"));
    }

    [Test]
    public void Entrenador_DeberiaAgregarUnPokemonCorrectamente()
    {
        var pikachu = new Pokemon("Pikachu", 100, null, null);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        entrenador.AgregarPokemon(pikachu);
        Assert.That(entrenador.Pokemones.Count, Is.EqualTo(6));
    }

    
}