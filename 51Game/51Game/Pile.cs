
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pile {
    private List<Card> cards;

    public Pile() {
        cards = new List<Card>();
    }

    /// <summary>
    /// @param Card c
    /// </summary>
    public void AddCard(Card c) {
        cards.Add(c);
    }

}