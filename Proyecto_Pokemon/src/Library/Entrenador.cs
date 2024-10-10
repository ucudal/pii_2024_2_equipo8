namespace Proyecto_Pokemon;
using System;
using System.Collections.Generic;

public class Entrenador
{
    public string Nombre { get; set; }
    public List<Pokemon> ListaPokemons { get; private set; }
    
    public Entrenador(string nombre)
    {
        Nombre = nombre;
        ListaPokemons = new List<Pokemon>();
    }

    public void SeleccionarPokemon(Pokemon pokemon)
    {
        if (ListaPokemons.Count < 6)
        {
            ListaPokemons.Add(pokemon);
            Console.WriteLine($"{Nombre} ha seleccionado a {pokemon.Nombre}");
        }
        else
        {
            Console.WriteLine($"{Nombre} ya tiene 6 Pokémon seleccionados.");
        }
    }

    public void VerPokemons()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes Pokémon:");
        foreach (var pokemon in ListaPokemons)
        {
            Console.WriteLine($"{pokemon.Nombre} (HP: {pokemon.Vida})");
        }
    }

    public void CambiarPokemon(int indiceActual, int indiceNuevo)
    {
        if (indiceNuevo >= 0 && indiceNuevo < ListaPokemons.Count)
        {
            Console.WriteLine($"{Nombre} ha cambiado a {ListaPokemons[indiceActual].Nombre} por {ListaPokemons[indiceNuevo].Nombre}");
        }
        else
        {
            Console.WriteLine("El índice del Pokémon a cambiar no es válido.");
        }
    }
}