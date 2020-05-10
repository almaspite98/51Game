
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Dobó pakli megvalósításáért felelõs osztály
/// Az összértéke a legfontosabb változója
/// </summary>
public class Pile {
    public int Value { get; set; }
    public List<Card> Cards { get; set; }

    public Pile() {
        Cards = new List<Card>();
    }

    /// <summary>
    /// @param Card c
    /// </summary>
    public void AddCard(Card c) {
        Cards.Add(c);
    }

}