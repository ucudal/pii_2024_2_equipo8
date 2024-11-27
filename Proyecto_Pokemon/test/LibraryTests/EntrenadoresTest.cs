namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class EntrenadoresTest
{
    private Entrenadores entrenador;
    private Pokemon pikachu;
    private Pokemon charmander;

    [SetUp]
    public void Setup()
    {
        var elementoElectrico = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoFuego = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
            { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
            { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        ITipo electrico = new Tipo("Electrico", elementoElectrico);
        ITipo fuego = new Tipo("Fuego", elementoFuego);

        pikachu = new Pokemon("pikachu", 100, electrico);
        charmander = new Pokemon("charmander", 100, fuego);

        entrenador = new Entrenadores("Asho Ketchu");
        entrenador.AñadirPokemon(pikachu);
        entrenador.AñadirPokemon(charmander);
    }

    // verifica que el nombre del entrenador sea el correcto
    [Test]
    public void Entrenador_DeberiaTenerNombreCorrecto()
    {
        Assert.That(entrenador.Nombre, Is.EqualTo("Asho Ketchu"));
    }

    // verifica que el entrenador tenga los Pokémon correctos
    [Test]
    public void Entrenador_DeberiaTenerPokemonesCorrectos()
    {
        Assert.That(entrenador.Pokemones.Count, Is.EqualTo(2));
        Assert.That(entrenador.Pokemones[0].Nombre, Is.EqualTo("pikachu"));
        Assert.That(entrenador.Pokemones[1].Nombre, Is.EqualTo("charmander"));
    }

    // verifica que el entrenador tiene Pokémon vivos
    [Test]
    public void Entrenador_TienePokemonesVivos_DeberiaSerTrueSiHayPokemonesConVida()
    {
        Assert.That(entrenador.TienePokemonesVivos(), Is.True);
    }

    // configura los Pokémon con vida 0 y verifica que no hay Pokémon vivos
    [Test]
    public void Entrenador_TienePokemonesVivos_DeberiaSerFalseSiNoHayPokemonesConVida()
    {
        pikachu.Vida = 0;
        charmander.Vida = 0;
        Assert.That(entrenador.TienePokemonesVivos(), Is.False);

    }
    [Test]
    public void Entrenador_AñadirPokemon_DeberiaAgregarPokemonCorrectamente()
    {
        var squirtle = new Pokemon("squirtle", 80, new Tipo("Agua", new Dictionary<string, double>()));
        bool agregado = entrenador.AñadirPokemon(squirtle);

        Assert.That(agregado, Is.True);
        Assert.That(entrenador.Pokemones.Contains(squirtle), Is.True);
    }
    [Test]
    public void Entrenador_AñadirPokemon_NoDeberiaAgregarMasDeSeisPokemones()
    {
        for (int i = 0; i < 6; i++)
        {
            entrenador.AñadirPokemon(new Pokemon($"pokemon{i}", 50, null));
        }

        bool agregado = entrenador.AñadirPokemon(new Pokemon("extraPokemon", 50, null));
    
        Assert.That(agregado, Is.False);
        Assert.That(entrenador.Pokemones.Count, Is.EqualTo(6));
    }
    [Test]
    public void Entrenador_BuscarPokemon_DeberiaEncontrarPokemonPorNombre()
    {
        bool encontrado = entrenador.BuscarPokemon("pikachu");
        Assert.That(encontrado, Is.True);
    }
    [Test]
    public void Entrenador_BuscarObjeto_NoDeberiaEncontrarObjetoInexistente()
    {
        var objeto = entrenador.BuscarObjeto("MasterBall");
        Assert.That(objeto, Is.Null);
    }
    [Test]
    public void Entrenador_FijarPokemonActual_NoDeberiaEstablecerPokemonConVidaCero()
    {
        pikachu.Vida = 0; 
        bool resultado = entrenador.FijarPokemonActual(pikachu); 

        Assert.That(resultado, Is.False);
        Assert.That(entrenador.PokemonActivo.Nombre, Is.Not.EqualTo(pikachu));
    }

    [Test]
    public void Entrenador_EliminarPokemon_DeberiaEliminarPokemonCorrectamente()
    {
        entrenador.Pokemones.Remove(pikachu);

        Assert.That(entrenador.Pokemones.Count, Is.EqualTo(1));
        Assert.That(entrenador.Pokemones.Contains(pikachu), Is.False);
    }
}