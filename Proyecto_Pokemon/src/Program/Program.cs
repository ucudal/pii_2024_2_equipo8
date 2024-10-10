using System;
using System.Collections.Generic;
using Proyecto_Pokemon;

class Program
{
    static void Main(string[] args)
    {
        var elementoFuego = new Dictionary<string, double>
        {
            { "Acero", 2.0 },
            { "Volador", 0.5 },
            { "Agua", 0.5 },
            { "Hielo", 2.0 },
            { "Planta", 2.0 },
            { "Bicho", 2.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 2.0 },
            { "Tierra", 1.0 },
            { "Fuego", 0.5 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };
        
        var elementoAgua = new Dictionary<string, double>
        {
            { "Acero", 1.0 },
            { "Volador", 0.5 },
            { "Agua", 0.5 },
            { "Hielo", 1.0 },
            { "Planta", 0.5 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 2.0 },
            { "Tierra", 2.0 },
            { "Fuego", 2.0 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoPlanta = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 0.5 },
            { "Agua", 2.0 },
            { "Hielo", 1.0 },
            { "Planta", 0.5 },
            { "Bicho", 0.5 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 2.0 },
            { "Tierra", 2.0 },
            { "Fuego", 0.5 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 0.5 },
            { "Dragon", 0.5 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoVolador = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 2.0 },
            { "Bicho", 2.0 },
            { "Electrico", 0.5 },
            { "Normal", 1.0 },
            { "Roca", 0.5 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 2.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoAcero = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 1.0 },
            { "Agua", 0.5 },
            { "Hielo", 2.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 0.5 },
            { "Normal", 1.0 },
            { "Roca", 2.0 },
            { "Tierra", 1.0 },
            { "Fuego", 0.5 },
            { "Lucha", 1.0 },
            { "Hada", 2.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoBicho = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 0.5 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 2.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 0.5 },
            { "Tierra", 1.0 },
            { "Fuego", 0.5 },
            { "Lucha", 0.5 },
            { "Hada", 0.5 },
            { "Psiquico", 2.0 },
            { "Veneno", 0.5 },
            { "Dragon", 1.0 },
            { "Fantasma", 0.5 },
            { "Siniestro", 2.0 }
        };

        var elementoElectrico = new Dictionary<string, double>
        {
            { "Acero", 1.0 },
            { "Volador", 2.0 },
            { "Agua", 2.0 },
            { "Hielo", 1.0 },
            { "Planta", 0.5 },
            { "Bicho", 1.0 },
            { "Electrico", 0.5 },
            { "Normal", 1.0 },
            { "Roca", 0.5 },
            { "Tierra", 0.0 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 0.5 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoNormal = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 0.5 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 0.0 },
            { "Siniestro", 1.0 }
        };
        var elementoHielo = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 2.0 },
            { "Agua", 0.5 },
            { "Hielo", 0.5 },
            { "Planta", 2.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 2.0 },
            { "Tierra", 2.0 },
            { "Fuego", 0.5 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 2.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoLucha = new Dictionary<string, double>
        {
            { "Acero", 2.0 },
            { "Volador", 0.5 },
            { "Agua", 1.0 },
            { "Hielo", 2.0 },
            { "Planta", 1.0 },
            { "Bicho", 0.5 },
            { "Electrico", 1.0 },
            { "Normal", 2.0 },
            { "Roca", 2.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 0.5 },
            { "Psiquico", 0.5 },
            { "Veneno", 0.5 },
            { "Dragon", 1.0 },
            { "Fantasma", 0.0 },
            { "Siniestro", 2.0 }
        };

        var elementoHada = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 0.5 },
            { "Lucha", 2.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 0.5 },
            { "Dragon", 2.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 2.0 }
        };

        var elementoPsiquico = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 2.0 },
            { "Hada", 1.0 },
            { "Psiquico", 0.5 },
            { "Veneno", 2.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 0.5 }
        };

        var elementoVeneno = new Dictionary<string, double>
        {
            { "Acero", 0.0 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 2.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 0.5 },
            { "Tierra", 0.5 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 2.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 0.5 },
            { "Dragon", 1.0 },
            { "Fantasma", 0.5 },
            { "Siniestro", 1.0 }
        };

        var elementoDragon = new Dictionary<string, double>
        {
            { "Acero", 0.5 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 0.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 2.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoFantasma = new Dictionary<string, double>
        {
            { "Acero", 1.0 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 0.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 2.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 2.0 },
            { "Siniestro", 0.5 }
        };

        var elementoSiniestro = new Dictionary<string, double>
        {
            { "Acero", 1.0 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 0.5 },
            { "Hada", 0.5 },
            { "Psiquico", 2.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 2.0 },
            { "Siniestro", 1.0 }
        };
        
        var elementoTierra = new Dictionary<string, double>
        {
            { "Acero", 1.0 },
            { "Volador", 1.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 0.5 },
            { "Bicho", 1.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 1.0 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
        };

        var elementoRoca = new Dictionary<string, double>
        {
            { "Acero", 1.0 },
            { "Volador", 2.0 },
            { "Agua", 1.0 },
            { "Hielo", 1.0 },
            { "Planta", 1.0 },
            { "Bicho", 2.0 },
            { "Electrico", 1.0 },
            { "Normal", 1.0 },
            { "Roca", 1.0 },
            { "Tierra", 1.0 },
            { "Fuego", 1.0 },
            { "Lucha", 0.5 },
            { "Hada", 1.0 },
            { "Psiquico", 1.0 },
            { "Veneno", 1.0 },
            { "Dragon", 1.0 },
            { "Fantasma", 1.0 },
            { "Siniestro", 1.0 }
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


        Pokemon charmander = new Pokemon("Charmander", 100, tipoFuego);
        Pokemon squirtle = new Pokemon("Squirtle", 100, tipoAgua);

        IHabilidades lanzallamas = new Habilidades("Lanzallamas", tipoFuego, 50, 90, false);
        IHabilidades hidrobomba = new Habilidades("Hidrobomba", tipoAgua, 80, 70, true);

        charmander.AprenderHabilidad(lanzallamas);
        squirtle.AprenderHabilidad(hidrobomba);

        Console.WriteLine($"¡{charmander.Nombre} se enfrenta a {squirtle.Nombre}!");

        IHabilidades habilidadCharmander = charmander.Habilidades[0];
        Console.WriteLine($"{charmander.Nombre} usa {habilidadCharmander.Nombre}!");

        double efectividadCharmander = habilidadCharmander.Tipo.EsEfectivoOPocoEfectivo(squirtle.TipoPrincipal);
        int dañoCharmander = (int)(habilidadCharmander.Daño * efectividadCharmander);
        squirtle.Vida -= dañoCharmander;


        Console.WriteLine(
            $"{squirtle.Nombre} recibe {dañoCharmander} de daño. Le quedan {squirtle.Vida} puntos de vida.");

        IHabilidades habilidadSquirtle = squirtle.Habilidades[0];
        Console.WriteLine($"{squirtle.Nombre} usa {habilidadSquirtle.Nombre}!");

        double efectividadSquirtle = habilidadSquirtle.Tipo.EsEfectivoOPocoEfectivo(charmander.TipoPrincipal);
        int dañoSquirtle = (int)(habilidadSquirtle.Daño * efectividadSquirtle);
        charmander.Vida -= dañoSquirtle;

        Console.WriteLine(
            $"{charmander.Nombre} recibe {dañoSquirtle} de daño. Le quedan {charmander.Vida} puntos de vida.");

        if (charmander.Vida <= 0)
        {
            Console.WriteLine($"{charmander.Nombre} ha sido derrotado.");
        }
        else if (squirtle.Vida <= 0)
        {
            Console.WriteLine($"{squirtle.Nombre} ha sido derrotado.");
        }
        else
        {
            Console.WriteLine("¡La batalla continúa!");
        }
    }
}