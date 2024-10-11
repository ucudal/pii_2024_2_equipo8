namespace Proyecto_Pokemon;

public class Fachada
{
    private Pokemon Sceptile;
    private Pokemon Arcanine;
    private Pokemon Blastoise;
    private Pokemon Eevee;
    private Pokemon Pikachu;
    private Pokemon Jynx;
    private Pokemon Lucario;
    private Pokemon Tyranitar;
    private Pokemon Flygon;
    private Pokemon Pidgeot;
    private Pokemon Scyther;
    private Pokemon Amoonguss;
    private Pokemon Umbreon;
    private Pokemon Gengar;
    private Pokemon Lapras;
    private Pokemon Metagross;
    private Pokemon Dragonite;
    private Pokemon Sylveon;

    public void MostrarOpciones(Batallas batalla)
    {
        bool opcionvalida = false;
        while (!opcionvalida)
        {
            Console.WriteLine();
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Cambiar Pokémon");
            Console.WriteLine("3. Esquivar");
            string opcion = Console.ReadLine();
            Console.WriteLine();
            switch (opcion)
            {
                case "1":
                    batalla.Atacar();
                    opcionvalida = true;
                    break;
                case "2":
                    batalla.CambiarPokemon();
                    opcionvalida = true;
                    break;
                case "3":
                    batalla.Esquivar();
                    opcionvalida = true;
                    break;
                default:
                    Console.WriteLine("Opción invalida. Ingrese nuevamente");
                    break;
            }
        }
    }

    public void InicializarDatos()
    {
        var elementoFuego = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
            { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
            { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoAgua = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 1.0 }, { "Planta", 0.5 },
            { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 2.0 },
            { "Fuego", 2.0 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoPlanta = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 0.5 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 0.5 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 2.0 }, { "Fuego", 0.5 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 0.5 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoVolador = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 2.0 }, { "Bicho", 2.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 2.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoAcero = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 0.5 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 1.0 }, { "Fuego", 0.5 }, { "Lucha", 1.0 },
            { "Hada", 2.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoBicho = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 0.5 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 2.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 1.0 }, { "Fuego", 0.5 }, { "Lucha", 0.5 },
            { "Hada", 0.5 }, { "Psiquico", 2.0 }, { "Veneno", 0.5 }, { "Dragon", 1.0 },
            { "Fantasma", 0.5 }, { "Siniestro", 2.0 }
        };

        var elementoElectrico = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoNormal = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 0.0 }, { "Siniestro", 1.0 }
        };

        var elementoHielo = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 2.0 }, { "Agua", 0.5 }, { "Hielo", 0.5 },
            { "Planta", 2.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 2.0 }, { "Fuego", 0.5 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 2.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoLucha = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 1.0 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 0.5 }, { "Electrico", 1.0 }, { "Normal", 2.0 },
            { "Roca", 2.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 0.5 }, { "Psiquico", 0.5 }, { "Veneno", 0.5 }, { "Dragon", 1.0 },
            { "Fantasma", 0.0 }, { "Siniestro", 2.0 }
        };

        var elementoHada = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 0.5 }, { "Lucha", 2.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 0.5 }, { "Dragon", 2.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 2.0 }
        };

        var elementoPsiquico = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 2.0 },
            { "Hada", 1.0 }, { "Psiquico", 0.5 }, { "Veneno", 2.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 0.5 }
        };

        var elementoVeneno = new Dictionary<string, double>
        {
            { "Acero", 0.0 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 2.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.5 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 2.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 0.5 }, { "Siniestro", 1.0 }
        };

        var elementoRoca = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 2.0 }, { "Agua", 1.0 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 0.5 }, { "Fuego", 2.0 }, { "Lucha", 0.5 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoTierra = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 0.5 }, { "Electrico", 2.0 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 1.0 }, { "Fuego", 2.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 2.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoFantasma = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 0.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 2.0 }, { "Siniestro", 0.5 }
        };

        var elementoSiniestro = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 0.5 },
            { "Hada", 0.5 }, { "Psiquico", 2.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 2.0 }, { "Siniestro", 0.5 }
        };

        var elementoDragon = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 0.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 2.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        ITipo tipoFuego = new Tipo("Fuego", elementoFuego);
        ITipo tipoAgua = new Tipo("Agua", elementoAgua);
        ITipo tipoHielo = new Tipo("Hielo", elementoHielo);
        ITipo tipoLucha = new Tipo("Lucha", elementoLucha);
        ITipo tipoHada = new Tipo("Hada", elementoHada);
        ITipo tipoPsiquico = new Tipo("Psiquico", elementoPsiquico);
        ITipo tipoVeneno = new Tipo("Veneno", elementoVeneno);
        ITipo tipoDragon = new Tipo("Dragon", elementoDragon);
        ITipo tipoFantasma = new Tipo("Fantasma", elementoFantasma);
        ITipo tipoSiniestro = new Tipo("Siniestro", elementoSiniestro);
        ITipo tipoElectrico = new Tipo("Electrico", elementoElectrico);
        ITipo tipoBicho = new Tipo("Bicho", elementoBicho);
        ITipo tipoPlanta = new Tipo("Planta", elementoPlanta);
        ITipo tipoTierra = new Tipo("Tierra", elementoTierra);
        ITipo tipoRoca = new Tipo("Roca", elementoRoca);
        ITipo tipoAcero = new Tipo("Acero", elementoAcero);
        ITipo tipoNormal = new Tipo("Normal", elementoNormal);
        ITipo tipoVolador = new Tipo("Volador", elementoVolador);

        Sceptile = new Pokemon("Sceptile", 100, tipoPlanta);
        Arcanine = new Pokemon("Arcanine", 100, tipoFuego);
        Blastoise = new Pokemon("Blastoise", 100, tipoAgua);
        Eevee = new Pokemon("Eevee", 1000, tipoNormal);
        Pikachu = new Pokemon("Pikachu", 1000, tipoElectrico);
        Jynx = new Pokemon("Jynx", 1000, tipoPsiquico, tipoHielo);
        Lucario = new Pokemon("Lucario", 1000, tipoLucha, tipoAcero);
        Tyranitar = new Pokemon("Tyranitar", 1000, tipoRoca, tipoSiniestro);
        Flygon = new Pokemon("Flygon", 1000, tipoTierra, tipoDragon);
        Pidgeot = new Pokemon("Pidgeot", 1000, tipoVolador, tipoNormal);
        Scyther = new Pokemon("Scyther", 1000, tipoBicho, tipoVolador);
        Amoonguss = new Pokemon("Amoonguss", 1000, tipoVeneno, tipoPlanta);
        Umbreon = new Pokemon("Umbreon", 1000, tipoSiniestro);
        Gengar = new Pokemon("Gengar", 1000, tipoFantasma, tipoSiniestro);
        Lapras = new Pokemon("Lapras", 1000, tipoHielo, tipoAgua);
        Metagross = new Pokemon("Metagross", 1000, tipoAcero, tipoPsiquico);
        Dragonite = new Pokemon("Dragonite", 1000, tipoDragon, tipoVolador);
        Sylveon = new Pokemon("Sylveon", 1000, tipoHada);

        IHabilidades cortefuria = new Habilidades("Corte furia", tipoBicho, 40, 95, 20, false);
        IHabilidades energibola = new Habilidades("Energibola", tipoPlanta, 90, 100, 10, false);
        IHabilidades hojaguda = new Habilidades("Hoja Aguda", tipoPlanta, 90, 100, 15, false);
        IHabilidades lluevehojas = new Habilidades("Lluevehojas", tipoPlanta, 130, 80, 5, true);

        IHabilidades ascuas = new Habilidades("Ascuas", tipoFuego, 40, 100, 25, false);
        IHabilidades lanzallamas = new Habilidades("Lanzallamas", tipoFuego, 90, 90, 15, false);
        IHabilidades velocidadExtrema = new Habilidades("Velocidad Extrema", tipoNormal, 80, 70, 5, false);
        IHabilidades enviteigneo = new Habilidades("Envite Ígneo", tipoFuego, 120, 60, 15, true);

        IHabilidades hidroBomba = new Habilidades("HidroBomba", tipoAgua, 110, 80, 5, true);
        IHabilidades pistolaAgua = new Habilidades("Pistola Agua", tipoAgua, 40, 100, 25, false);
        IHabilidades hidropulso = new Habilidades("Hidropulso", tipoAgua, 60, 100, 20, false);
        IHabilidades acuacola = new Habilidades("Acua cola", tipoAgua, 90, 90, 10, false);

        Sceptile.AprenderHabilidad(cortefuria);
        Sceptile.AprenderHabilidad(energibola);
        Sceptile.AprenderHabilidad(lluevehojas);
        Sceptile.AprenderHabilidad(hojaguda);

        Arcanine.AprenderHabilidad(ascuas);
        Arcanine.AprenderHabilidad(lanzallamas);
        Arcanine.AprenderHabilidad(velocidadExtrema);
        Arcanine.AprenderHabilidad(enviteigneo);

        Blastoise.AprenderHabilidad(hidroBomba);
        Blastoise.AprenderHabilidad(hidropulso);
        Blastoise.AprenderHabilidad(acuacola);
        Blastoise.AprenderHabilidad(pistolaAgua);
    }

    public Pokemon ObtenerSceptile() => Sceptile;
    public Pokemon ObtenerArcanine() => Arcanine;
    public Pokemon ObtenerBlastoise() => Blastoise;
}