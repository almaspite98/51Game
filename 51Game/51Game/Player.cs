
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player {
    private static uint STARTING_MONEY = 2000;

    public string Name { get; set; }
    public string Password { get; set; }
    public uint Coins { get; set; }
    private List<Card> cards;

    public Player() {
        Name = "Random_player";
        Password = "pwd123";
        Coins = STARTING_MONEY;
    }

    public Player(string name, string password)
    {
        Name = name;
        Password = password;
        Coins = STARTING_MONEY;
    }

    public void Turn() {
        // TODO implement here
    }

}