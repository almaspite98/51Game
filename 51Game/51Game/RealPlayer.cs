
using System;

/// <summary>
/// Valódi Játékos megvalósításáért felelõs osztály
/// Játékos tud szabadon dönteni, hogy egy körben melyik kártyát játsza ki
/// </summary>
public class RealPlayer : Player {
    public RealPlayer(string name, uint money) : base(name, money)
    {
    }
    /// <summary>
    /// Ez egy override-ja a Player turn metódsának
    /// Játékos tud szabadon dönteni, hogy egy körben melyik kártyát játsza ki
    /// </summary>
    /// <param name="valueOfPile"> Dobópakli összértéke </param>
    /// <param name="version"> Játék verziója </param>
    /// <returns></returns>
    public override int Turn(int valueOfPile,int version)
    {
        //play a card
        Console.WriteLine("Melyik lapod szeretnéd kijátszani?");
        int c = 0;
        Card card;
        int PlayedCardIndex = 0;
        Boolean invalidInput = true;
        do
        {
            Console.Write("Index of the card: ");
            while (!int.TryParse(Console.ReadLine(), out PlayedCardIndex))
            {
                Console.Write("Nincs ilyen válasz!\nIndex of the card: ");
            }
            if (PlayedCardIndex == -1) return -100;
            if (0 <= PlayedCardIndex && PlayedCardIndex < Cards.Count) invalidInput = false;
            else Console.WriteLine("Ez egy érvénytelen index, kérlek adj meg másikat!");
            if (c >= 10)
            {
                card = Cards[0];
                Cards.RemoveAt(0);
                return card.Value;
            }
            c++;
        } while (invalidInput);
        card = Cards[PlayedCardIndex];
        Cards.RemoveAt(PlayedCardIndex);
        GameManager.replayString.Add("Value of card played: " + card.Value);
        return card.Value;//c.Value;

    }

}