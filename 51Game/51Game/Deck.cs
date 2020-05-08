
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Deck {
    private List<Card> cards;

    public Deck(List<Card> cards)
    {
        this.cards = cards;
    }

    public Card DrawCard() {
        int i = new Random().Next(0, cards.Count);
        Console.WriteLine("Generált random szám: " + i);
        Card c = cards[i];
        cards.Remove(c);
        return c;
    }

}