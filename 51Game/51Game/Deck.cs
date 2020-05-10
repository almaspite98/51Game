
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Deck {
    public List<Card> Cards { get; set; }

    public Deck(string cardsFilePath)
    {
        Cards = new List<Card>();
        //beolvasás a fájlból az accountokat és adataikat
        string jsonString = File.ReadAllText(cardsFilePath);
        List<Card> oneSet= JsonConvert.DeserializeObject<List<Card>>(jsonString);
        //oneSet.ForEach(i => Console.WriteLine("{0}", i));
        Cards.AddRange(oneSet);
        Cards.AddRange(oneSet);
        Cards.AddRange(oneSet);
        Cards.AddRange(oneSet);
        Helper.Shuffle<Card>(Cards);
        //Console.WriteLine("Size of deck: "+Cards.Count);
        //Cards.ForEach(i => Console.WriteLine("{0}", i));

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