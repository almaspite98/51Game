
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameManager {
    public static string deckFilePath = @"cards.txt";
    public List<Player> Players { get; set; }
    public Deck Deck { get; set; }
    public Pile Pile { get; set; }

    public GameManager() {
        Deck=new Deck(deckFilePath);
        Players = new List<Player>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0) AddPlayer(7); //osztó csak 7 lapot kap
            else AddPlayer(8);
        }
    }
    private void AddPlayer(int numOfCards) {
        Player player1 = new Player();
        Players.Add(player1);
        player1.AddCardsToHand(Deck.DrawCards(numOfCards));
    }

    public void Start() {
        //init shit here

    }

    public void Lose() {
        // TODO implement here
    }

}