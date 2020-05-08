
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Player {
    private static uint STARTING_MONEY = 2000;
    private string name;
    private string password;
    private uint coins;
    private List<Card> cards;

    public Player() {
        name = "Random_player";
        password = "pwd123";
        coins = STARTING_MONEY;
    }

    public Player(string name, string password)
    {
        this.name = name;
        this.password = password;
        coins = STARTING_MONEY;
    }

    public void Turn() {
        // TODO implement here
    }

}