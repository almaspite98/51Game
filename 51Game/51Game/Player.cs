
using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Player oszt�ly egy j�t�kost val�s�t meg
/// Botok k�rei�rt felel m�g
/// Ebb�l sz�rmazik le a RealPlayer
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
    /// A papam�terk�nt kapott Card list�t a j�t�kos kez�hez adja
    /// </summary>
    /// <param name="cards">Egy List ami Card-okat tartalmaz</param>
    public void AddCardsToHand(List<Card> cards)
    {
        Cards.AddRange(cards);
    }

    /// <summary>
    /// 30 pont alatt a bot rakhat b�rmit, csak ne 8 || 0 || -1-et
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
    /// 30 pont f�l�tt pedig igyekezzen min�l jobba megk�zel�teni az 51 pontot (vagy el�rni)
    /// </summary>
    /// <param name="valueOfPile"> Dob�pakli �rt�ke </param>
    /// <param name="version"> J�t�k verzi�ja </param>
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
        if (45 < valueOfPile + Cards[maxi].Value && valueOfPile + Cards[maxi].Value < POINTS_TO_LOSE) Console.WriteLine("Huhh ez k�zel volt...");
        if(valueOfPile + Cards[maxi].Value >= POINTS_TO_LOSE) Console.WriteLine("A csud�ba...");
        return Cards[maxi]; 
    }


    /// <summary>
    /// Virtu�lis f�ggv�ny (RealPlayer miatt)
    /// Egy j�t�kos egy k�r�nek az �sszefoglal� met�dusa : Egy lap kij�tsz�sa
    /// </summary>
    /// <param name="valueOfPile"> Dob� pakli �ssz�rt�ke </param>
    /// <param name="version"> J�t�k verzi�ja </param>
    /// <returns></returns>
    public virtual int Turn(int valueOfPile,int version)
    {
        Card c;
        if (valueOfPile <= TURNING_POINT) c = NotEndGameMove();
        else c = EndGameMove(valueOfPile,version);
        if (c == null) Console.WriteLine("Kifogytam a lapokb�l!");
        else
        {
            Cards.Remove(c);
            Console.WriteLine("Value of card played: " + c.Value);
            GameManager.replayString.Add("Value of card played: " + c.Value);
        }
        return c.Value;

    }

}