using System;
using System.Collections.Generic;

/// <summary>
/// Ez az oszt�ly felel az�rt, hogy egy meccset lemenedzseljen
/// </summary>
public class GameManager
{
    /// <summary>
    /// Az a pont mennyis�g amit el�rve vesztes/nyersz (verzi�t�l f�gg�en)
    /// </summary>
    private static uint POINTS = 51;
    /// <summary>
    /// Oszt� szerep�t v�ltogatni kell 
    /// </summary>
    private static uint DEALER_INDEX = 1;
    /// <summary>
    /// k�rtya pakli el�r�si �tvonala
    /// </summary>
    private static string deckFilePath = @"cards.txt";
    /// <summary>
    /// Az "�jraj�tsz�s" sz�veg�t ebben a v�ltoz�ban t�rolom soronk�nt
    /// </summary>
    public static List<string> replayString = new List<string>();
    /// <summary>
    /// z�log �rt�ke
    /// </summary>
    private static uint bet;
    /// <summary>
    /// j�t�kos neve
    /// </summary>
    private static string name;
    /// <summary>
    /// j�t�kosok az adott meccsben
    /// </summary>
    public List<Player> Players { get; set; }
    /// <summary>
    /// Pakli amib�l osztunk
    /// </summary>
    public Deck Deck { get; set; }
    /// <summary>
    /// Dob� pakli (�ssz�rt�k sz�m�t)
    /// </summary>
    public Pile Pile { get; set; }
    /// <summary>
    /// J�t�k verzi�ja
    /// </summary>
    public int Version { get; set; }

    public GameManager()
    {
        Deck = new Deck(deckFilePath);
        Players = new List<Player>();

    }

    public void WelcomeWallText()
    {
        Console.Write("Mi legyen a J�t�kos neved? (string): ");
        name = Console.ReadLine();
        Console.Write("Legyen t�tje a j�t�knak? (true/false): ");
        bool hasStake = bool.Parse(Console.ReadLine());
        if (hasStake)
        {
            Console.Write("�s mennyi legyen a t�t? (0-2000): ");
            bet = uint.Parse(Console.ReadLine());
        }
    }

    public void NewGameSreen()
    {

        Console.Write("Melyik verzi�t szeretn�d j�tszani? (1 vagy 2): ");
        Version = int.Parse(Console.ReadLine());
        //int.Parse(Console.ReadLine());
        RealPlayer realPlayer = new RealPlayer(name, bet);
        Players.Add(realPlayer); //TODO oszto forgat�sa: v�ltoz�?

        Start();
        Play();
    }
    private void AddBotPlayer(int numOfCards)
    {
        Player player1 = new Player("", bet);
        Players.Add(player1);
        player1.AddCardsToHand(Deck.DrawCards(numOfCards));
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++) // 3 bottal felt�ltj�k a j�t�kot
        {
            if (i == 0)
            {
                if (DEALER_INDEX % 4 == 0) Players[0].AddCardsToHand(Deck.DrawCards(7));
                else Players[0].AddCardsToHand(Deck.DrawCards(8));
            }
            else
            {
                if (DEALER_INDEX % 4 == i) AddBotPlayer(7); //oszt� csak 7 lapot kap
                else AddBotPlayer(8);
            }
            //Console.WriteLine(Players[i]);
            //replayString.Add(Players[i].ToString());
        }

        Pile = new Pile();
        Pile.AddCard(Deck.DrawCard());
        //Console.WriteLine("Size of deck should be zero: " + Deck.Cards.Count);
    }

    private void Play()
    {
        int i = 0;
        while (Pile.Value < POINTS)
        {
            replayString.Add(Players[i % 4].ToString());
            if (i % 4 == 0)
            {
                Console.WriteLine();
                Console.WriteLine(Players[0]);
            }
            int valueOfCard = Players[i % 4].Turn(Pile.Value, Version);
            if (valueOfCard == -100)
            {
                Console.WriteLine(Players[i % 4].Name + " fealadta a j�t�kot");
                Console.ReadKey();
                return;
            }
            Pile.Value += valueOfCard;
            replayString.Add("Value of pile: " + Pile.Value);
            Console.WriteLine("Value of pile: " + Pile.Value);
            i++;
        }
        if (Pile.Value == POINTS && Version == 2) Console.WriteLine(Players[(i - 1) % 4] + " " + Pile.Value + " ponttal nyert!");
        else Console.WriteLine(Players[(i - 1) % 4] + " " + Pile.Value + " ponttal vesz�tett!");

    }

}