using System;
using System.Collections.Generic;

/// <summary>
/// Ez az osztály felel azért, hogy egy meccset lemenedzseljen
/// </summary>
public class GameManager
{
    /// <summary>
    /// Az a pont mennyiség amit elérve vesztes/nyersz (verziótól függõen)
    /// </summary>
    private static uint POINTS = 51;
    /// <summary>
    /// Osztó szerepét válogatni kell 
    /// </summary>
    private static uint DEALER_INDEX = 1;
    /// <summary>
    /// Kártyák elérési útvonala
    /// </summary>
    private static string deckFilePath = @"cards.txt";
    /// <summary>
    /// Az "újrajátszás" szövegét ebben a változóban tárolom soronként
    /// </summary>
    public static List<string> replayString = new List<string>();
    /// <summary>
    /// zálog értéke
    /// </summary>
    private static uint bet;
    /// <summary>
    /// játékos neve
    /// </summary>
    private static string name;
    /// <summary>
    /// játékosok az adott meccsben
    /// </summary>
    public List<Player> Players { get; set; }
    /// <summary>
    /// Pakli amibõl osztunk
    /// </summary>
    public Deck Deck { get; set; }
    /// <summary>
    /// Dobó pakli 
    /// </summary>
    public Pile Pile { get; set; }
    /// <summary>
    /// Játék verziója
    /// </summary>
    public int version;

    public GameManager()
    {
        Deck = new Deck(deckFilePath);
        Players = new List<Player>();
    }

    /// <summary>
    /// A legelsõ játék esetén ez a metódus veszi fel a Játékos alapadatait
    /// </summary>
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

    /// <summary>
    /// Minden további játék indításakor lehet verziót változtatni.
    /// Ez a metódus indítja el a változók inicializálását (Start) és a játékmenetet (Play)
    /// </summary>
    public void NewGameSreen()
    {

        Console.Write("Melyik verziót szeretnéd játszani? (1 vagy 2): ");
        while (!int.TryParse(Console.ReadLine(), out version))
        {
            Console.Write("Nincs ilyen válasz!\nMelyik verziót szeretnéd játszani? (1 vagy 2): ");
        }
        RealPlayer realPlayer = new RealPlayer(name, bet);
        Players.Add(realPlayer); 

        Start();
        Play();
    }

    /// <summary>
    /// Bot játékos hozzáadása a játékhoz
    /// </summary>
    /// <param name="numOfCards"> Amennyi kártya kell a kezébe </param>
    private void AddBotPlayer(int numOfCards)
    {
        Player player1 = new Player("", bet);
        Players.Add(player1);
        player1.AddCardsToHand(Deck.DrawCards(numOfCards));
    }

    /// <summary>
    /// Változók feltöltésért felel
    /// </summary>
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
        }

        Pile = new Pile();
        Pile.AddCard(Deck.DrawCard());
    }

    /// <summary>
    /// Egy meccs levezetéséért felelõs függvény
    /// Körönként Játékosok kártyákat játszanak ki, aminek az értékével nõ a dobó pakli
    /// Majd 51 után gyõztest/vesztest hirdet
    /// </summary>
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