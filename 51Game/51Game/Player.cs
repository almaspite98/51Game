
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Player
{
    private static uint STARTING_MONEY = 2000;
    private static int TURNING_POINT = 30;
    private static uint POINTS_TO_LOSE = 51;
    private static uint COUNTER = 0;
    public string Name { get; set; }
    public uint Coins { get; set; }
    public List<Card> Cards { get; set; }

    public Player()
    {
        Name = "Random_player" + COUNTER++;
        Coins = STARTING_MONEY;
        Cards = new List<Card>();
    }

    public Player(string name)
    {
        Name = name;
        Coins = STARTING_MONEY;
        Cards = new List<Card>();
    }

    public override string ToString()
    {
        //TODO if(Vannak kartyai) akkor azt is
        string cardsString = "{";
        Cards.ForEach(i =>
        {
            cardsString += i;
            cardsString += " ; ";
        });
        cardsString += "}";
        if (Cards != null) return "Player: " + Name + " " + Coins + " " + cardsString;
        else return "Player: " + Name + " " + Coins;
    }

    public void AddCardsToHand(List<Card> cards)
    {
        Cards.AddRange(cards);
    }

    private Card NotEndGameMove()
    {
        foreach(Card c in Cards){
            if (c.Value != 8 && (c.Value != 0 || c.Value != -1)) return c;
        }
        return Cards[new Random().Next(0, Cards.Count)]; //might be null!
    }

    private Card EndGameMove(int valueOfPile,int version) //max kiv�laszt�s
    {
        int maxi = 0;
        for(int i = 0; i < Cards.Count; i++)
        {
            if (version==2 && valueOfPile + Cards[i].Value == POINTS_TO_LOSE)
            {
                Debug.WriteLine("Ezaz! Nyertem!");
                return Cards[i];
            }
            if (valueOfPile+Cards[i].Value < POINTS_TO_LOSE && Cards[i].Value > Cards[maxi].Value)
            {
                maxi = i;
            }
        }
        if (45 < valueOfPile + Cards[maxi].Value && valueOfPile + Cards[maxi].Value < POINTS_TO_LOSE) Debug.WriteLine("Huhh ez k�zel volt...");
        if(valueOfPile + Cards[maxi].Value >= POINTS_TO_LOSE) Debug.WriteLine("A csud�ba...");
        return Cards[maxi]; //might be null!
    }

    public virtual int Turn(int valueOfPile)
    {
        // TODO implement here
        //play a card
        Card c;
        if (valueOfPile <= TURNING_POINT) c = NotEndGameMove();
        else c = EndGameMove(valueOfPile,1);
        if (c == null) Debug.WriteLine("Kifogytam a lapokb�l!");
        else
        {
            Cards.Remove(c);
            Debug.WriteLine("Value of card played: " + c.Value);
        }
        return c.Value;

    }

}