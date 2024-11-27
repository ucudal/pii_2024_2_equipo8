namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class RestaurarTodoTest
{
    private Batallas batalla;
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon arcanine;

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

        ITipo tipoElectrico = new Tipo("Electrico", elementoElectrico);

        // Crea Pokemones, no les meti habilidades porque no las van a usar
        pikachu = new Pokemon("pikachu", 100, tipoElectrico);

        // Crea Entrenadores
        entrenador1 = new Entrenadores("Asho Ketchu");
        entrenador2 = new Entrenadores("Brokoso");

        entrenador1.AñadirPokemon(pikachu);


        // Inicia la batalla con ambos entrenadores
        batalla = new Batallas(entrenador1, entrenador2);
    }

    [Test]
    public void UsarRestaurarTodoCorrectamente_ConVidaBajaYEstadoAlterado()
    {
        Objetos restaurar = new RestaurarTodo();
        entrenador1.Mochila.Add(restaurar);
        entrenador1.PokemonActivo.Vida -= 70;
        entrenador1.PokemonActivo.Estado = "paralisis";

        string resultado = batalla.UsarMochila(restaurar, entrenador1.PokemonActivo);
        Assert.That(resultado, Does.Contain("recuperaron"));
        Assert.That(entrenador1.PokemonActivo.Vida, Is.EqualTo(entrenador1.PokemonActivo.VidaBase));
        Assert.That(entrenador1.PokemonActivo.Estado, Is.EqualTo(null));
    }
    
    [Test]
    public void UsarRestaurarTodoConSoloVidaBaja()
    {
        Objetos restaurar = new RestaurarTodo();
        entrenador1.Mochila.Add(restaurar);
        entrenador1.PokemonActivo.Vida -= 70;

        string resultado = batalla.UsarMochila(restaurar, entrenador1.PokemonActivo);
        Assert.That(resultado, Does.Contain("recuperaron"));
        Assert.That(entrenador1.PokemonActivo.Vida, Is.EqualTo(entrenador1.PokemonActivo.VidaBase));
        Assert.That(entrenador1.PokemonActivo.Estado, Is.EqualTo(null));
    }
    
    [Test]
    public void UsarRestaurarTodoConSoloEstadoAlterado()
    {
        Objetos restaurar = new RestaurarTodo();
        entrenador1.Mochila.Add(restaurar);
        entrenador1.PokemonActivo.Estado = "paralisis";

        string resultado = batalla.UsarMochila(restaurar, entrenador1.PokemonActivo);
        Assert.That(resultado, Does.Contain("recuperaron"));
        Assert.That(entrenador1.PokemonActivo.Vida, Is.EqualTo(entrenador1.PokemonActivo.VidaBase));
        Assert.That(entrenador1.PokemonActivo.Estado, Is.EqualTo(null));
    }
    
    [Test]
    public void UsarRestaurarTodoIncorrectamente()
    {
        Objetos restaurar = new RestaurarTodo();
        entrenador1.Mochila.Add(restaurar);

        string resultado = batalla.UsarMochila(restaurar, entrenador1.PokemonActivo);
        Assert.That(resultado, Does.Contain("No puedes"));
        Assert.That(entrenador1.PokemonActivo.Vida, Is.EqualTo(entrenador1.PokemonActivo.VidaBase));
        Assert.That(entrenador1.PokemonActivo.Estado, Is.EqualTo(null));
    }
    
    
}