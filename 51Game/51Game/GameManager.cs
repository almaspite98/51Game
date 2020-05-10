using System;
using System.Collections.Generic;

public class GameManager {
    private static uint POINTS = 51;
    private static uint DEALER_INDEX = 1;
    private static string deckFilePath = @"cards.txt";
    private static string LOG_FILE = @"log.txt";
    public static List<string> replayString = new List<string>();
    public static List<string> stateString = new List<string>();
    private static uint bet;
    private static string name;
    public List<Player> Players { get; set; }
    public Deck Deck { get; set; }
    public Pile Pile { get; set; }
    public int Version { get; set; }

    public GameManager() {
        Deck=new Deck(deckFilePath);
        Players = new List<Player>();
        
    }

    public void WelcomeWallText()
    {
        Console.WriteLine("Mi legyen a Játékos neved?");
        Console.Write("Player Name: ");
        name = Console.ReadLine();
        Console.WriteLine("Legyen tétje a játéknak?");
        Console.Write("hasStake (true/false): ");
        Boolean hasStake = Boolean.Parse(Console.ReadLine());
        if (hasStake)
        {
            Console.WriteLine("És mennyi legyen a tét?");
            Console.Write("Stake (0-2000): ");
            bet = uint.Parse(Console.ReadLine());
        }
    }

    public void NewGameSreen()
    {
        
        Console.WriteLine("Melyik verziót szeretnéd játszani?");
        Console.Write("Version (1 or 2): ");
        Version = int.Parse(Console.ReadLine());
        //int.Parse(Console.ReadLine());
        RealPlayer realPlayer = new RealPlayer(name, bet);
        Players.Add(realPlayer); //TODO oszto forgatása: változó?

        Start();
        Play();
    }
    private void AddBotPlayer(int numOfCards) {
        Player player1 = new Player("",bet);
        Players.Add(player1);
        player1.AddCardsToHand(Deck.DrawCards(numOfCards));
    }

    private void Start() {
        for (int i = 0; i < 4; i++) // 3 bottal feltöltjük a játékot
        {
            if (i == 0)
            {
                if (DEALER_INDEX % 4 == 0) Players[0].AddCardsToHand(Deck.DrawCards(7));
                else Players[0].AddCardsToHand(Deck.DrawCards(8));
            }
            else
            {
                if (DEALER_INDEX % 4 == i) AddBotPlayer(7); //osztó csak 7 lapot kap
                else AddBotPlayer(8);
            }
            Console.WriteLine(Players[i]);
            replayString.Add(Players[i].ToString());
        }
        
        Pile = new Pile();
        Pile.AddCard(Deck.DrawCard());
        //Console.WriteLine("Size of deck should be zero: " + Deck.Cards.Count);
    }

    private void Play() {
        int i = 0;
        while(Pile.Value < POINTS)
        {
            int valueOfCard = Players[i % 4].Turn(Pile.Value, Version);
            if (valueOfCard == -100)
            {
                Console.WriteLine(Players[i % 4].Name + " fealadta a játékot");
                Console.ReadKey();
                return;
                //Environment.Exit(0);
            }
            Pile.Value+= valueOfCard;
            Console.WriteLine("Value of pile: "+ Pile.Value);

            if (i % 4 == 0)
            {
                Console.WriteLine("El akarod menteni az aktuális állást? ");
                bool b = bool.Parse(Console.ReadLine());
                if (b)
                {
                    string roundString = Players[i % 4] + " " + Pile.Value;
                    Console.WriteLine(roundString);
                    replayString.Add(roundString);
                    Console.WriteLine("És milyen néven? ");
                    string s = Console.ReadLine();
                    GameManager.stateString.Add(s);
                    GameManager.stateString.Add(roundString);
                    Helper.Log(GameManager.replayString, 0, LOG_FILE);
                }
            }
            
            i++;
        }
        if (Pile.Value == POINTS && Version == 2) Console.WriteLine(Players[(i-1) % 4] + " " + Pile.Value + " ponttal nyert!");
        else Console.WriteLine(Players[(i-1) % 4] + " " + Pile.Value + " ponttal veszített!");

    }

}