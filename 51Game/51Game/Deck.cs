
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// 
/// </summary>
public class Deck {
    public List<Card> Cards { get; set; }

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

    public Card DrawCard() {
        int i = new Random().Next(0, Cards.Count);
        Card c = Cards[i];
        Cards.Remove(c);
        return c;
    }

    public List<Card> DrawCards(int db) {
        List<Card> cards = Cards.GetRange(0, db);
        Cards.RemoveRange(0, db);
        return cards;
    }

}