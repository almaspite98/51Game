
using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Player osztály egy játékost valósít meg
/// Botok köreiért felel még
/// Ebbõl származik le a RealPlayer
/// </summary>
public class Player
{
    private static uint STARTING_MONEY = 2000;
    private static int TURNING_POINT = 30;
    private static uint POINTS_TO_LOSE = 51;
    private static uint COUNTER = 0;
    public string Name { get; set; }
    public uint Coins { get; set; }
    public List<Card> Cards { get; set; }

    public Player(uint money)
    {
        Name = "Random_player" + COUNTER++;
        Coins = money;
        Cards = new List<Card>();
    }

    public Player(string name,uint money)
    {
        if(name.Length==0) Name = "Random_player" + COUNTER++;
        else Name = name;
        Coins = money;
        Cards = new List<Card>();
    }

    public override string ToString()
    {
        int j = 0;
        string cardsString = "{";
        Cards.ForEach(i =>
        {
            cardsString += j+": ";
            cardsString += i;
            cardsString += " ; ";
            j++;
        });
        cardsString += "}";
        if (Cards != null) return "Player: " + Name + " " + Coins + " " + cardsString;
        else return "Player: " + Name + " " + Coins;
    }

    /// <summary>
    /// A papaméterként kapott Card listát a játékos kezéhez adja
    /// </summary>
    /// <param name="cards">Egy List ami Card-okat tartalmaz</param>
    public void AddCardsToHand(List<Card> cards)
    {
        Cards.AddRange(cards);
    }

    /// <summary>
    /// 30 pont alatt a bot rakhat bármit, csak ne 8 || 0 || -1-et
    /// </summary>
    /// <returns></returns>
    private Card NotEndGameMove()
    {
        foreach(Card c in Cards){
            if (c.Value != 8 && (c.Value != 0 || c.Value != -1)) return c;
        }
        return Cards[new Random().Next(0, Cards.Count)]; 
    }


    /// <summary>
    /// 30 pont fölött pedig igyekezzen minél jobba megközelíteni az 51 pontot (vagy elérni)
    /// </summary>
    /// <param name="valueOfPile"> Dobópakli értéke </param>
    /// <param name="version"> Játék verziója </param>
    /// <returns></returns>
    private Card EndGameMove(int valueOfPile,int version) 
    {
        int maxi = 0;
        for(int i = 0; i < Cards.Count; i++)
        {
            if (version==2 && valueOfPile + Cards[i].Value == POINTS_TO_LOSE)
            {
                Console.WriteLine("Ezaz! Nyertem!");
                return Cards[i];
            }
            if (valueOfPile+Cards[i].Value < POINTS_TO_LOSE && Cards[i].Value > Cards[maxi].Value)
            {
                maxi = i;
            }
        }
        if (45 < valueOfPile + Cards[maxi].Value && valueOfPile + Cards[maxi].Value < POINTS_TO_LOSE) Console.WriteLine("Huhh ez közel volt...");
        if(valueOfPile + Cards[maxi].Value >= POINTS_TO_LOSE) Console.WriteLine("A csudába...");
        return Cards[maxi]; 
    }


    /// <summary>
    /// Virtuális függvény (RealPlayer miatt)
    /// Egy játékos egy körének az összefoglaló metódusa : Egy lap kijátszása
    /// </summary>
    /// <param name="valueOfPile"> Dobó pakli összértéke </param>
    /// <param name="version"> Játék verziója </param>
    /// <returns></returns>
    public virtual int Turn(int valueOfPile,int version)
    {
        Card c;
        if (valueOfPile <= TURNING_POINT) c = NotEndGameMove();
        else c = EndGameMove(valueOfPile,version);
        if (c == null) Console.WriteLine("Kifogytam a lapokból!");
        else
        {
            Cards.Remove(c);
            Console.WriteLine("Value of card played: " + c.Value);
            GameManager.replayString.Add("Value of card played: " + c.Value);
        }
        return c.Value;

    }

}