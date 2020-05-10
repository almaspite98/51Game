using System;
using System.Collections.Generic;

public class GameManager
{
    private static uint POINTS = 51;
    private static uint DEALER_INDEX = 1;
    private static string deckFilePath = @"cards.txt";
    public static List<string> replayString = new List<string>();
    private static uint bet;
    private static string name;
    public List<Player> Players { get; set; }
    public Deck Deck { get; set; }
    public Pile Pile { get; set; }
    public int version;

    public GameManager()
    {
        Deck = new Deck(deckFilePath);
        Players = new List<Player>();

    }

    public void WelcomeWallText()
    {
        Console.Write("Mi legyen a Játékos neved? (string, max hossz: 16): ");
        name = Console.ReadLine();
        if (name.Length > 16)
        {
            name = name.Substring(0, 16);
        }
        Console.Write("Legyen tétje a játéknak? (true/false): ");
        bool hasStake = false;
        while (!bool.TryParse(Console.ReadLine(), out hasStake))
        {
            Console.Write("Nincs ilyen válasz!\nLegyen tétje a játéknak? (true/false): ");
        }
        if (hasStake)
        {
            Console.Write("Mennyi legyen a tét? (0-2000): ");
            while (!uint.TryParse(Console.ReadLine(), out bet))
            {
                Console.Write("Nincs ilyen válasz!\nMennyi legyen a tét? (0-2000): ");
            }
        }
    }

    public void NewGameSreen()
    {

        Console.Write("Melyik verziót szeretnéd játszani? (1 vagy 2): ");
        while (!int.TryParse(Console.ReadLine(), out version))
        {
            Console.Write("Nincs ilyen válasz!\nMelyik verziót szeretnéd játszani? (1 vagy 2): ");
        }
        //int.Parse(Console.ReadLine());
        RealPlayer realPlayer = new RealPlayer(name, bet);
        Players.Add(realPlayer); //TODO oszto forgatása: változó?

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
            int valueOfCard = Players[i % 4].Turn(Pile.Value, version);
            if (valueOfCard == -100)
            {
                Console.WriteLine(Players[i % 4].Name + " fealadta a játékot");
                Console.ReadKey();
                return;
            }
            Pile.Value += valueOfCard;
            replayString.Add("Value of pile: " + Pile.Value);
            Console.WriteLine("Value of pile: " + Pile.Value);
            i++;
        }
        if (Pile.Value == POINTS && version == 2) Console.WriteLine(Players[(i - 1) % 4] + " " + Pile.Value + " ponttal nyert!");
        else Console.WriteLine(Players[(i - 1) % 4] + " " + Pile.Value + " ponttal veszített!");

    }

}