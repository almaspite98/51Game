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
    /// Oszt� szerep�t v�logatni kell 
    /// </summary>
    private static uint DEALER_INDEX = 1;
    /// <summary>
    /// K�rty�k el�r�si �tvonala
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
    /// Dob� pakli 
    /// </summary>
    public Pile Pile { get; set; }
    /// <summary>
    /// J�t�k verzi�ja
    /// </summary>
    public int version;

    public GameManager()
    {
        Deck = new Deck(deckFilePath);
        Players = new List<Player>();
    }

    /// <summary>
    /// A legels� j�t�k eset�n ez a met�dus veszi fel a J�t�kos alapadatait
    /// </summary>
    public void WelcomeWallText()
    {
        Console.Write("Mi legyen a J�t�kos neved? (string, max hossz: 16): ");
        name = Console.ReadLine();
        if (name.Length > 16)
        {
            name = name.Substring(0, 16);
        }
        Console.Write("Legyen t�tje a j�t�knak? (true/false): ");
        bool hasStake = false;
        while (!bool.TryParse(Console.ReadLine(), out hasStake))
        {
            Console.Write("Nincs ilyen v�lasz!\nLegyen t�tje a j�t�knak? (true/false): ");
        }
        if (hasStake)
        {
            Console.Write("Mennyi legyen a t�t? (0-2000): ");
            while (!uint.TryParse(Console.ReadLine(), out bet))
            {
                Console.Write("Nincs ilyen v�lasz!\nMennyi legyen a t�t? (0-2000): ");
            }
        }
    }

    /// <summary>
    /// Minden tov�bbi j�t�k ind�t�sakor lehet verzi�t v�ltoztatni.
    /// Ez a met�dus ind�tja el a v�ltoz�k inicializ�l�s�t (Start) �s a j�t�kmenetet (Play)
    /// </summary>
    public void NewGameSreen()
    {

        Console.Write("Melyik verzi�t szeretn�d j�tszani? (1 vagy 2): ");
        while (!int.TryParse(Console.ReadLine(), out version))
        {
            Console.Write("Nincs ilyen v�lasz!\nMelyik verzi�t szeretn�d j�tszani? (1 vagy 2): ");
        }
        RealPlayer realPlayer = new RealPlayer(name, bet);
        Players.Add(realPlayer); 

        Start();
        Play();
    }

    /// <summary>
    /// Bot j�t�kos hozz�ad�sa a j�t�khoz
    /// </summary>
    /// <param name="numOfCards"> Amennyi k�rtya kell a kez�be </param>
    private void AddBotPlayer(int numOfCards)
    {
        Player player1 = new Player("", bet);
        Players.Add(player1);
        player1.AddCardsToHand(Deck.DrawCards(numOfCards));
    }

    /// <summary>
    /// V�ltoz�k felt�lt�s�rt felel
    /// </summary>
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
        }

        Pile = new Pile();
        Pile.AddCard(Deck.DrawCard());
    }

    /// <summary>
    /// Egy meccs levezet�s��rt felel�s f�ggv�ny
    /// K�r�nk�nt J�t�kosok k�rty�kat j�tszanak ki, aminek az �rt�k�vel n� a dob� pakli
    /// Majd 51 ut�n gy�ztest/vesztest hirdet
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
                Console.WriteLine(Players[i % 4].Name + " fealadta a j�t�kot");
                Console.ReadKey();
                return;
            }
            Pile.Value += valueOfCard;
            replayString.Add("Value of pile: " + Pile.Value);
            Console.WriteLine("Value of pile: " + Pile.Value);
            i++;
        }
        if (Pile.Value == POINTS && version == 2) Console.WriteLine(Players[(i - 1) % 4] + " " + Pile.Value + " ponttal nyert!");
        else Console.WriteLine(Players[(i - 1) % 4] + " " + Pile.Value + " ponttal vesz�tett!");

    }

}