using System.Collections.Generic;
using System.Diagnostics;

public class GameManager {
    private static uint POINTS_TO_LOSE = 51;
    public static string deckFilePath = @"cards.txt";
    public List<Player> Players { get; set; }
    public Deck Deck { get; set; }
    public Pile Pile { get; set; }

    public GameManager() {
        Deck=new Deck(deckFilePath);
        Players = new List<Player>();
        
    }
    private void AddPlayer(int numOfCards) {
        Player player1 = new Player();
        Players.Add(player1);
        player1.AddCardsToHand(Deck.DrawCards(numOfCards));
        Debug.WriteLine(player1);
    }

    public void Start() {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0) AddPlayer(7); //osztó csak 7 lapot kap
            else AddPlayer(8);
        }
        Pile = new Pile();
        Pile.AddCard(Deck.DrawCard());
        Debug.WriteLine("Size of deck should be zero: " + Deck.Cards.Count);
    }

    public void Play() {
        int i = 0;
        while(Pile.Value < POINTS_TO_LOSE)
        {
            Pile.Value+=Players[i % 4].Turn(Pile.Value);
            Debug.WriteLine(Players[i % 4] + " " + Pile.Value);
            if (Pile.Value >= POINTS_TO_LOSE) Debug.WriteLine(Players[i%4]+" "+Pile.Value+" ponttal veszített!");
            i++;
        }
    }

    public void Lose() {
        // TODO implement here
    }

}