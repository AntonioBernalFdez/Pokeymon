using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonMapArea2 : MonoBehaviour
{
    [SerializeField] List<Pokemon> wildPokemons;

    //After a random encounter with a wild pokemon the function gets a random pokemon of the list of each grass area.
    public Pokemon GetRandomWildPokemon()

    {
        var pokemon = wildPokemons[Random.Range(0, wildPokemons.Count)];
        pokemon.InitPokemon();
        return pokemon;
    }
}
