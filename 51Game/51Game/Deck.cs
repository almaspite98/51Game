
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Deck {
    public List<Card> Cards { get; set; }

    public Deck(string cardsFilePath)
    {
        //beolvasás a fájlból az accountokat és adataikat
        string jsonString = File.ReadAllText(cardsFilePath);
        Cards = JsonConvert.DeserializeObject<List<Card>>(jsonString);
        Cards.ForEach(i => Debug.WriteLine("{0}", i));
        Cards.AddRange(Cards);
        Cards.AddRange(Cards);
        Cards.AddRange(Cards);
        Logger.Shuffle<Card>(Cards);
        Cards.ForEach(i => Debug.WriteLine("{0}", i));

    } 

    public Card DrawCard() {
        int i = new Random().Next(0, Cards.Count);
        Debug.WriteLine("Generált random szám: " + i);
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