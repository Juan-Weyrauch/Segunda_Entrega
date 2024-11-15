using Library.Interfaces;
using System.Collections.Generic;

namespace Library.Classes;

/// <summary>
/// Class Player, holds the players info
/// This information is:
///     - Name
///     - A list of pokemons (team)
///     - A list of items (potions)
/// </summary>
public class Player : IPlayer
{
    // Static fields for singleton instances
    private static Player _player1;
    private static Player _player2;

    /// <summary>
    /// Property to access Player1 singleton instance
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static Player Player1
    {
        get
        {
            if (_player1 == null)
            {
                throw new System.InvalidOperationException("Player1 has not been initialized.");
            }

            return _player1;
        }
    }

    
    /// <summary>
    /// Property to access Player2 singleton instance
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static Player Player2
    {
        get
        {
            if (_player2 == null)
            {
                throw new System.InvalidOperationException("Player2 has not been initialized.");
            }

            return _player2;
        }
    }

    // Public properties
    /// <summary>
    /// The Name of the player
    /// </summary>
    public string Name { get; private set; }
    
    
    /// <summary>
    /// A list containing all the players Pokémon
    /// </summary>
    public List<IPokemon> Pokemons { get; private set; }
    
    
    /// <summary>
    /// A list containing all potions of the player
    /// </summary>
    public List<IPotions> Potions { get; private set; }
    
    
    
    /// <summary>
    /// The Pokémon that the player has selected
    /// </summary>
    public IPokemon SelectedPokemon { get; private set; }
    
    /// <summary>
    /// Sets the turn of the player.
    /// This is used for enabling the user to use special attacks, which can only be used once every 2 turns.
    /// The logic is:
    ///     - If the user selects a special attack, it starts a counter that increments the 'Turn' variable
    ///     - After that, we always check this variable, whenever it's 0 the user can 
    /// </summary>
    public int Turn { get; private set; } //private set beacause we use 'SetTurn' method. (Which is public)

    // Private constructor
    private Player(string name, List<IPokemon> pokemons, IPokemon selectedPokemon)
    {
        Name = name;
        Pokemons = pokemons;
        Potions = new List<IPotions>
        {
            new RevivePotion(),
            new TotalCure(), new TotalCure(),
            new SuperPotion(), new SuperPotion(), new SuperPotion(), new SuperPotion()
        };
        SelectedPokemon = selectedPokemon;
        Turn = 0;
    }

    
    /// <summary>
    /// Static method to initialize Player1
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pokemons"></param>
    /// <param name="selectedPokemon"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void InitializePlayer1(string name, List<IPokemon> pokemons, IPokemon selectedPokemon)
    {
        if (_player1 == null)
        {
            _player1 = new Player(name, pokemons, selectedPokemon);
        }
        else
        {
            throw new System.InvalidOperationException("Player1 has already been initialized.");
        }
    }
    
    /// <summary>
    /// Static method to initialize Player2
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pokemons"></param>
    /// <param name="selectedPokemon"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void InitializePlayer2(string name, List<IPokemon> pokemons, IPokemon selectedPokemon)
    {
        if (_player2 == null)
        {
            _player2 = new Player(name, pokemons, selectedPokemon);
        }
        else
        {
            throw new System.InvalidOperationException("Player2 has already been initialized.");
        }
    }

    /// <summary>
    /// Lets the PLAYER change ITS Pokémon.
    /// </summary>
    /// <param name="selectedPokemon"></param>
    public void SwitchPokemon(IPokemon selectedPokemon)
    {
        SelectedPokemon = selectedPokemon;
    }

    public void UseItem(int itemChoice)
    {
     //On the works...
    }
    
}