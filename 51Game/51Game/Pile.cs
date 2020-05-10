
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Dob� pakli megval�s�t�s��rt felel�s oszt�ly
/// Az �ssz�rt�ke a legfontosabb v�ltoz�ja
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