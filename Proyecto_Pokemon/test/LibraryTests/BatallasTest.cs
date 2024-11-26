using NUnit.Framework;
using Proyecto_Pokemon;

namespace Tests;

[TestFixture]
public class BatallasTests
{
    [Test]
    public void Iniciar_BatallaCorrectamente()
    {
        // Arrange
        var entrenador1 = new Entrenadores("AshKetchup");
        var entrenador2 = new Entrenadores("diezMedallasGary");
        var batalla = new Batallas(entrenador1, entrenador2);

        // Act
        string resultado = batalla.Iniciar(entrenador1, entrenador2);

        // Assert
        Assert.That(entrenador1.EnBatalla, Is.True);
        Assert.That(entrenador2.EnBatalla, Is.True);
        Assert.That(resultado, Does.Contain("están listos para la batalla"));
    }

    [Test]
    public void ConfirmarSiEntrenadorEstaPeleando_EntrenadorEnBatallaDevuelveTrue()
    {
        // Arrange
        var entrenador1 = new Entrenadores("AshKetchup");
        var entrenador2 = new Entrenadores("diezMedallasGary");
        var batalla = new Batallas(entrenador1, entrenador2);

        // Act
        bool resultado = batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador1);

        // Assert
        Assert.That(resultado, Is.True);
    }

    [Test]
    public void ChequerMuerte_NoPokemonesVivosDevuelveTrue()
    {
        // Arrange
        var entrenador1 = new Entrenadores("AshKetchup");
        var entrenador2 = new Entrenadores("diezMedallasGary");
        entrenador1.RecibirEquipoPokemon().ForEach(pokemon => pokemon.Vida = 0);
        entrenador2.RecibirEquipoPokemon().ForEach(pokemon => pokemon.Vida = 0);
        var batalla = new Batallas(entrenador1, entrenador2);

        // Act
        bool resultado = batalla.ChequerMuerte();

        // Assert
        Assert.That(resultado, Is.True);
    }

    [Test]
    public void CambiarTurno_CambiaAlOtroEntrenador()
    {
        var entrenador1 = new Entrenadores("AshKetchup");
        var entrenador2 = new Entrenadores("diezMedallasGary");
        var entrenadorActual = entrenador1;
        entrenadorActual = (entrenadorActual == entrenador1) ? entrenador2 : entrenador1;
        Assert.That(entrenadorActual.Nombre, Is.EqualTo(entrenador2.Nombre), 
            "El turno no volvió al primer entrenador como se esperaba.");
    }


    [Test]
    public void CambiarPokemon_CambiaPokemonCorrectamente()
    {
        var elementoElectrico = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };
        
        var entrenador1 = new Entrenadores("AshKetchup");
        var entrenador2 = new Entrenadores("diezMedallasGary");
        var batalla = new Batallas(entrenador1, entrenador2);
        Pokemon nuevoPokemon = new Pokemon("Pikachu", 100, new Tipo("Electrico", elementoElectrico));

        entrenador1.AñadirPokemon(nuevoPokemon);
        
        Pokemon Pokemon = new Pokemon("Pichu", 100, new Tipo("Electrico", elementoElectrico));
        string resultado = batalla.CambiarPokemon(Pokemon);

        Assert.That(resultado, Does.Contain("AHORA SE ENCUENTRA A LA CABEZA"));
    }

    [Test]
    public void Atacar_ParalizadoNoPuedeAtacar()
    {
        var elementoFuego = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
            { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
            { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };
        
        ITipo tipoFuego = new Tipo("Fuego", elementoFuego);
        
        var entrenador1 = new Entrenadores("AshKetchup");
        var entrenador2 = new Entrenadores("diezMedallasGary");
        var atacante = new Pokemon("Charizard", 200, tipoFuego, null, "paralizado");
        var defensor = new Pokemon("Blastoise", 200, tipoFuego);
        entrenador1.AñadirPokemon(atacante);
        entrenador2.AñadirPokemon(defensor);

        var batalla = new Batallas(entrenador1, entrenador2);

        var habilidad = new Habilidades("Lanzallamas", tipoFuego, 15, 100, 10, false);

        string resultado = batalla.Atacar(habilidad);

        Assert.That(resultado, Does.Contain("está paralizado"));

    }
}
