
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player {
    private static uint STARTING_MONEY = 2000;
    private static uint COUNTER = 0;
    public string Name { get; set; }
    public string Password { get; set; }
    public uint Coins { get; set; }
    public List<Card> Cards { get; set; }

    public Player() {
        Name = "Random_player"+COUNTER++;
        Password = "pwd123";
        Coins = STARTING_MONEY;
        Cards = new List<Card>();
    }

    public Player(string name, string password) {
        Name = name;
        Password = password;
        Coins = STARTING_MONEY;
        Cards = new List<Card>();
    }

    public override string ToString() {
        //TODO if(Vannak kartyai) akkor azt is
        //if (Cards != null) return "Player: " + Name + " " + Password + " " + Coins+" "+;
        /*else*/ return "Player: " + Name + " " + Password + " " + Coins;
    }

    public void AddCardsToHand(List<Card> cards)
    {
        Cards.AddRange(cards);
    }

    public void Turn() {
        // TODO implement here
    }

}