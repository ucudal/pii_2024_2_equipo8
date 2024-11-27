namespace Proyecto_Pokemon;
using NUnit.Framework;

[TestFixture]
public class FachadaTests
{
    private Entrenadores entrenador1;
    private Entrenadores entrenador2;
    private Pokemon pikachu;
    private Pokemon charmander;
    private List<Pokemon> equipo;
    private ITipo tipoFuego;
    private ITipo tipoAgua;
    private IHabilidades habilidad;
    
       
    

    
        [Test]
        public void MeterUsuarioAlLobby_NuevoUsuario_DevuelveMensajeExitoso()
        {
            string nombreEntrenador = "Ash";
            Fachada.Rendirse(nombreEntrenador);
            Fachada.SacarEntrenadorDelLobby(nombreEntrenador);

            string resultado = Fachada.MeterUsuarioAlLobby(nombreEntrenador);

            Assert.That(resultado, Is.EqualTo("Ash ha sido agregado en el Lobby para un encuentro."));
        }
        [Test]
        public void MeterUsuarioAlLobby_UsuarioYaEnBatalla_DevuelveError()
        {
            string nombreEntrenador = "Ash";
            // Simula que el usuario ya está en una batalla
            Fachada.IniciarBatalla("Ash", "Gary");
            string resultado = Fachada.MeterUsuarioAlLobby(nombreEntrenador);

            Assert.That(resultado,Is.EqualTo("Ash ya se encuentra en el Lobby."));
        }
        [Test]
        public void CrearBatalla_EntrenadoresDisponibles_DevuelveMensajeInicioBatalla()
        {
            string entrenador1 = "Ash";
            string entrenador2 = "Gary";
            Fachada.Rendirse(entrenador1);
            Fachada.Rendirse(entrenador2);
            Fachada.MeterUsuarioAlLobby(entrenador1);
            Fachada.MeterUsuarioAlLobby(entrenador2);
            string verLobby = Fachada.VerLobby();
            Assert.That(verLobby, Does.Contain(entrenador1));
            Assert.That(verLobby, Does.Contain(entrenador2));
            string resultado = Fachada.CrearBatalla(entrenador1, entrenador2);

            Assert.That(resultado,Does.Contain("EMPIEZA LA PELEA ENTRE Ash CONTRA Gary"));
        }
        [Test]
        public void VerHabilidades_EntrenadorSinPokemonActivo_DevuelveError()
        {
            
            string nombreEntrenador = "Ash";
            string nombreEntrenador2 = "Gary";
            Fachada.Rendirse(nombreEntrenador);
            Fachada.Rendirse(nombreEntrenador2);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
            Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
            
            string resultado = Fachada.VerHabilidades(nombreEntrenador);
            string resultado2 = Fachada.VerHabilidades(nombreEntrenador2);

            Assert.That(resultado,Does.Contain("Ash, no tenes ningún Pokémon."));
            Assert.That(resultado2,Does.Contain("Gary, no tenes ningún Pokémon."));

        }
        [Test]
        public void ElegirRandommente_EquipoCompleto_DevuelveError()
        {
            string nombreEntrenador = "Ash";
            string nombreEntrenador2 = "Gary";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
            Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
            // Simula un equipo completo
            Fachada.elegirRandomente(nombreEntrenador);
            string resultado = Fachada.elegirRandomente(nombreEntrenador);
            
            Assert.That(resultado,Is.EqualTo("Ash, ya tenes un equipo completo de Pokémon."));
        }
        [Test]
        public void CambiarPokemones_CambioExitoso_DevuelveMensajeCorrecto()
        {
            string nombreEntrenador = "Ash";
            string nombreEntrenador2 = "Gary";
            string nombrePokemon = "Pikachu";
            string entrenadorActual = "";
            Fachada.MeterUsuarioAlLobby(nombreEntrenador);
            Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
            Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
            Fachada.elegirRandomente(nombreEntrenador);
            Fachada.elegirRandomente(nombreEntrenador2);
            Fachada.SeleccionarEquipo(nombreEntrenador, nombrePokemon);
            Fachada.SeleccionarEquipo(nombreEntrenador2, nombrePokemon);
            if (Fachada.RevisarTurno(nombreEntrenador).Contains(" no es tu turno"))
            {
                entrenadorActual = nombreEntrenador2;
            }
            else
            {
                entrenadorActual = nombreEntrenador;
            }
            string resultado = Fachada.CambiarPokemones(entrenadorActual, nombrePokemon);
            Assert.That(resultado, Does.Contain("Pikachu"));
        }
        [Test]
    public void RevisarTurno_EntrenadorEnBatallaEsSuTurno_DevuelveMensajeEsTuTurno()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.Rendirse(nombreEntrenador2);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador2);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        Fachada.elegirRandomente(nombreEntrenador);
        Fachada.elegirRandomente(nombreEntrenador2);
        string entrenadorActual;
        if (Fachada.RevisarTurno(nombreEntrenador).Contains(" no es tu turno"))
        {
            entrenadorActual = nombreEntrenador2;
        }
        else
        {
            entrenadorActual = nombreEntrenador;
        }
        string resultado = Fachada.RevisarTurno(entrenadorActual);

        Assert.That(resultado, Is.EqualTo($"{entrenadorActual} es tu turno"));
    }

    [Test]
    public void RevisarTurno_EntrenadorEnBatallaNoEsSuTurno_DevuelveMensajeNoEsTuTurno()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.Rendirse(nombreEntrenador2);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador2);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        Fachada.elegirRandomente(nombreEntrenador);
        Fachada.elegirRandomente(nombreEntrenador2);
        // Cambioel turno para que no sea el de Ash
        
        string entrenadorActual;
        if (Fachada.RevisarTurno(nombreEntrenador).Contains(" no es tu turno"))
        {
            entrenadorActual = nombreEntrenador;
        }
        else
        {
            entrenadorActual = nombreEntrenador2;
        }
        string resultado = Fachada.RevisarTurno(entrenadorActual);
        Assert.That(resultado, Is.EqualTo($"{entrenadorActual} no es tu turno"));
    }

    [Test]
    public void RevisarTurno_EntrenadorNoEnBatalla_DevuelveMensajeError()
    {
        string nombreEntrenador = "Ash";
        Fachada.Rendirse(nombreEntrenador);
        string resultado = Fachada.RevisarTurno(nombreEntrenador);

        Assert.That(resultado, Is.EqualTo($"El entrenador {nombreEntrenador} no se encuentra en ninguna batalla"));
    }

    [Test]
    public void Rendirse_EntrenadorSeRinde_DevuelveMensajeGanador()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.Rendirse(nombreEntrenador2);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador2);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        string resultado = Fachada.Rendirse(nombreEntrenador);

        Assert.That(resultado, Does.Contain($"EL GANADOR ES {nombreEntrenador2}"));
    }

    [Test]
    public void Rendirse_EntrenadorNoEnBatalla_DevuelveMensajeError()
    {
        string nombreEntrenador = "Ash";
        string resultado = Fachada.Rendirse(nombreEntrenador);

        Assert.That(resultado, Is.EqualTo($"{nombreEntrenador}, no te podés rendir si no estás en una batalla"));
    }

    [Test]
    public void VerLobby_LobbyConEntrenadores_DevuelveListaEntrenadores()
    {
        string nombreEntrenador1 = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador1);
        Fachada.Rendirse(nombreEntrenador2);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador1);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador2);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador1);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        string resultado = Fachada.VerLobby();

        Assert.That(resultado, Does.Contain("Gente en Lobby:"));
        Assert.That(resultado, Does.Contain(nombreEntrenador1));
        Assert.That(resultado, Does.Contain(nombreEntrenador2));
    }

    [Test]
    public void VerLobby_LobbyVacio_DevuelveMensajeLobbyVacio()
    {
        Fachada.SacarEntrenadorDelLobby("Ash");
        Fachada.SacarEntrenadorDelLobby("Gary");
        string resultado = Fachada.VerLobby();

        Assert.That(resultado, Is.EqualTo("Nadie se encuentra en el Lobby actualmente"));
    }

    [Test]
    public void EsquivarPokemon_EntrenadorPuedeEsquivar_DevuelveMensajeEsquivar()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        string entrenadorActual = "";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.Rendirse(nombreEntrenador2);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador2);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        Fachada.elegirRandomente(nombreEntrenador);
        Fachada.elegirRandomente(nombreEntrenador2);
        if (Fachada.RevisarTurno(nombreEntrenador).Contains(" no es tu turno"))
        {
            entrenadorActual = nombreEntrenador2;
        }
        else
        {
            entrenadorActual = nombreEntrenador;
        }
        
        string resultado = Fachada.EsquivarPokemon(entrenadorActual);

        Assert.That(resultado, Does.Contain("está preparado para esquivar el proximo movimiento"));
    }

    [Test]
    public void EsquivarPokemon_NoEsTurnoDelEntrenador_DevuelveMensajeError()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.Rendirse(nombreEntrenador2);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador2);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        Fachada.elegirRandomente(nombreEntrenador);
        Fachada.elegirRandomente(nombreEntrenador2);
        // Determinar quién NO es el entrenador actual
        string entrenadorNoEsTurno;
        if (Fachada.RevisarTurno(nombreEntrenador).Contains(" no es tu turno"))
        {
            entrenadorNoEsTurno = nombreEntrenador;
        }
        else
        {
            entrenadorNoEsTurno = nombreEntrenador2;
        }

        // Act
        string resultado = Fachada.EsquivarPokemon(entrenadorNoEsTurno);

        Assert.That(resultado, Is.EqualTo("No es tu turno, no podes hacer movimientos"));
    }

    [Test]
    public void VerMochila_EntrenadorEnBatalla_DevuelveListaObjetos()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        Fachada.elegirRandomente(nombreEntrenador);
        string resultado = Fachada.VerMochila(nombreEntrenador);

        Assert.That(resultado, Does.Contain("tenes en la mochila los siguientes objetos"));
    }

    [Test]
    public void VerMochila_EntrenadorNoEnBatalla_DevuelveMensajeError()
    {
        string nombreEntrenador = "Ash";
        Fachada.Rendirse(nombreEntrenador);
        string resultado = Fachada.VerMochila(nombreEntrenador);
 
        Assert.That(resultado, Is.EqualTo($"{nombreEntrenador}, no estas en batalla."));
    }

    [Test]
    public void UsarObjetoMochila_EntrenadorNoEnBatalla_DevuelveMensajeError()
    {
        string nombreEntrenador = "Ash";
        Fachada.Rendirse(nombreEntrenador);
        string item = "Poción";
        string pokemon = "Pikachu";
        string resultado = Fachada.UsarObjetoMochila(nombreEntrenador, item, pokemon);

        Assert.That(resultado, Is.EqualTo($"El entrenador {nombreEntrenador} no está en batalla."));
    }

    [Test]
    public void SeleccionarEquipo_PokemonValido_DevuelveMensajeExitoso()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        string nombrePokemon = "SNORLAX";
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        string resultado = Fachada.SeleccionarEquipo(nombreEntrenador, nombrePokemon);

        Assert.That(resultado, Does.Contain($"El pokemon {nombrePokemon} fue añadido al equipo de {nombreEntrenador}"));
    }

    [Test]
    public void SeleccionarEquipo_PokemonNoEncontrado_DevuelveMensajeError()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        string nombrePokemon = "Mewtwo";
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        string resultado = Fachada.SeleccionarEquipo(nombreEntrenador, nombrePokemon);
    
        Assert.That(resultado, Is.EqualTo($"{nombreEntrenador}, el pokemon {nombrePokemon} no fue encontrado"));
    }

    [Test]
    public void VerPokemones_EntrenadorConEquipoCompleto_DevuelveListaPokemones()
    {
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        Fachada.elegirRandomente(nombreEntrenador);
        string resultado = Fachada.VerPokemones(nombreEntrenador);

        Assert.That(resultado, Does.Contain($"{nombreEntrenador} esta es la vida de tus Pokemones"));
    }

    [Test]
    public void VerPokemones_EntrenadorSinEquipoCompleto_DevuelveMensajeError()
    {
 
        string nombreEntrenador = "Ash";
        string nombreEntrenador2 = "Gary";
        Fachada.Rendirse(nombreEntrenador);
        Fachada.SacarEntrenadorDelLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador);
        Fachada.MeterUsuarioAlLobby(nombreEntrenador2);
        Fachada.IniciarBatalla(nombreEntrenador, nombreEntrenador2);
        string resultado = Fachada.VerPokemones(nombreEntrenador);

        Assert.That(resultado, Is.EqualTo($"{nombreEntrenador} aún no tenés tu equipo completo."));
    }
}