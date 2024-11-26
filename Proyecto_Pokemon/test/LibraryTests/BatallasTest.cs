namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class BatallasTest
{
    private Batallas batalla;
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon arcanine;
    private Habilidades electrobola; 
    private Habilidades ascuas; 
    private Habilidades trueno;
     
    [SetUp]
    public void Setup()
    {
        var elementoFuego = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
            { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
            { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };
        var elementoElectrico = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };
        
        ITipo tipoFuego = new Tipo("Fuego", elementoFuego);
        ITipo tipoElectrico = new Tipo("Electrico", elementoElectrico);
        
        IEfectos paralisis = new Efectos("paralizado");
        IEfectos quemadura = new Efectos("quemado");
       
        
        //Anadir habilidades
        trueno = new Habilidades("Trueno", tipoElectrico, 120, 50, 5, true, paralisis);
        electrobola = new Habilidades("Electrobola",tipoFuego, 90, 90, 6, false,paralisis);
        ascuas = new Habilidades("Ascuas", tipoFuego, 40, 100, 25, false,quemadura);

        // Crea Pokemones, no les meti habilidades porque no las van a usar
        pikachu = new Pokemon("pikachu", 100, tipoElectrico);
        arcanine = new Pokemon("arcaine", 100, tipoFuego);
        
        // Crea Entrenadores
        entrenador1 = new Entrenadores("Asho Ketchu");
        entrenador2 = new Entrenadores("Brokoso");

        entrenador1.AñadirPokemon(pikachu);
        entrenador2.AñadirPokemon(arcanine);
        
        pikachu.AprenderHabilidad(electrobola);
        pikachu.AprenderHabilidad(trueno);
        arcanine.AprenderHabilidad(ascuas);
        
        
        // Inicia la batalla con ambos entrenadores
        batalla = new Batallas(entrenador1, entrenador2);
    }
    [Test]
    public void Pokemon_DeberiaTenerHabilidadesAsignadas()
    {
        Assert.That(pikachu.Habilidades.Contains(electrobola));
        Assert.That(arcanine.Habilidades.Contains(ascuas));
    }
    [Test]
    public void Atacar_DeberiaUsarHabilidadCorrectamente()
    {
        electrobola.Precision = 100; 
        string resultado = batalla.Atacar(electrobola);

        Assert.That(resultado, Does.Contain("Electrobola"));
        Assert.That(electrobola.Puntos_de_Poder, Is.EqualTo(5)); // Se reduce el PP despues de usarse
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
        string entrenadorInicial = batalla.entrenadorActual.Nombre;

        //batalla.Atacar(electrobola);
        batalla.CambiarTurno();

        Assert.That(batalla.entrenadorActual.Nombre, Is.Not.EqualTo(entrenadorInicial));
        
    }

    // verifica que devuelva el estado de los pokemon
    [Test]
    public void VerVida_DeberiaMostrarVidaDeLosPokemones()
    {
        entrenador1.PokemonActivo.Estado = "quemado";
        entrenador2.PokemonActivo.Estado = "envenenado";
        string estadoPikachu = batalla.VerificarEstado(entrenador1.PokemonActivo);
        string estadoArcanine = batalla.VerificarEstado(entrenador2.PokemonActivo);
        Assert.That(estadoPikachu, Does.Contain("Vida restante"));
        Assert.That(estadoArcanine, Does.Contain("Vida restante"));
        
        
    }
    [Test]
    public void Atacar_DeberiaAplicarEstadoAlteradoCorrectamente()
    {
        // Habilidad con efecto secundario paralizado
        string resultado = batalla.Atacar(electrobola);

        Assert.That(entrenador2.PokemonActivo.Estado, Is.EqualTo("paralizado"));
        Assert.That(resultado, Does.Contain("paralizado"));
    }
    [Test]
    public void DeterminarGanador_DeberiaFinalizarBatallaYAnunciarGanador()
    {
        string ganador = batalla.DeterminarGanador();
        Assert.That(ganador, Does.Contain(entrenador1.Nombre));
       
    }
    [Test]
    public void Esquivar_DeberiaEvitarAtaque()
    {
        string resultadoAtaque = batalla.Atacar(electrobola);
        string esquivarMensaje = batalla.Esquivar();
        Assert.That(esquivarMensaje, Does.Contain("está preparado para esquivar"));
       // Assert.That(resultadoAtaque, Does.Contain("esquivar")); 
    }
    [Test]
    public void UsarMochila_DeberiaRecuperarVidaCorrectamente()
    {
        Objetos pocion = new SuperPocion();
        entrenador1.Mochila.Add(pocion);
        entrenador1.PokemonActivo.Vida -= 70;

        string resultado = batalla.UsarMochila(pocion, entrenador1.PokemonActivo);
        Assert.That(resultado, Does.Contain("recuperaron"));
        Assert.That(entrenador1.PokemonActivo.Vida, Is.EqualTo(100));
    }
    [Test]
    public void VerificarEstado_DeberiaAplicarEfectosDeEstadoAlterado()
    {
        entrenador1.PokemonActivo.Estado = "quemado";
        entrenador1.PokemonActivo.Vida = 100;

        string resultado = batalla.VerificarEstado(entrenador1.PokemonActivo);

        Assert.That(resultado, Does.Contain("pikachu está quemado y pierde 10 puntos de vida. Vida restante: 90 / 100"));
        Assert.That(entrenador1.PokemonActivo.Vida, Is.LessThan(100));
    }
    [Test]
    public void Atacar_HabilidadDeCarga_DeberiaCargarYEjecutar()
    {
        {
            string mensajeCarga = batalla.Atacar(trueno);
            Assert.That(mensajeCarga, Does.Contain("está cargando la habilidad"));

            batalla.CambiarTurno();

            // Simular varios intentos si el Pokémon está paralizado
            string mensajeEjecucion = "";
            for (int i = 0; i < 1000000000; i++) 
            {
                mensajeEjecucion = batalla.Atacar(trueno);
                if (!mensajeEjecucion.Contains("paralizado")) break;

                batalla.CambiarTurno(); 
            }
            Assert.That(mensajeEjecucion, Does.Contain("Trueno")); 
            Assert.That(entrenador2.PokemonActivo.Vida, Is.LessThan(entrenador2.PokemonActivo.VidaBase)); 
        
        }
        
    }
    [Test]
    public void CambiarPokemon_DeberiaCambiarElPokemonActivo()
    {
        Pokemon otroPokemon = new Pokemon("Bulbasaur", 100, new Tipo("Planta", new Dictionary<string, double>()));
        entrenador1.RecibirEquipoPokemon().Add(otroPokemon);
        string resultado = batalla.CambiarPokemon(otroPokemon);

        Assert.That(resultado, Does.Contain("Bulbasaur AHORA SE ENCUENTRA A LA CABEZA."));
        Assert.That(entrenador1.PokemonActivo.Nombre, Is.EqualTo("Bulbasaur"));
    }


}
