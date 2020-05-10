
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

/// <summary>
/// Pakli�rt felel�s oszt�ly
/// </summary>
public class Deck {
    /// <summary>
    /// Egy pakli k�rty�kb�l �ll
    /// </summary>
    public List<Card> Cards { get; set; }

    /// <summary>
    /// Egy magyar pakliban 8*4 k�rtya van
    /// Egy szettet egy JSON f�jlb�l kovert�lva olvasok be, �s leduplik�lom
    /// Majd megkeverem
    /// </summary>
    /// <param name="cardsFilePath"></param>
    public Deck(string cardsFilePath)
    {
        Cards = new List<Card>();
        string jsonString = File.ReadAllText(cardsFilePath);
        List<Card> oneSet= JsonConvert.DeserializeObject<List<Card>>(jsonString);
        Cards.AddRange(oneSet);
        Cards.AddRange(oneSet);
        Cards.AddRange(oneSet);
        Cards.AddRange(oneSet);
        Helper.Shuffle<Card>(Cards);

    } 

    /// <summary>
    /// Egy k�rtya h�z�sa
    /// </summary>
    /// <returns></returns>
    public Card DrawCard() {
        int i = new Random().Next(0, Cards.Count);
        Card c = Cards[i];
        Cards.Remove(c);
        return c;
    }

    /// <summary>
    /// db darab k�rtya h�z�sa
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    public List<Card> DrawCards(int db) {
        List<Card> cards = Cards.GetRange(0, db);
        Cards.RemoveRange(0, db);
        return cards;
    }

}