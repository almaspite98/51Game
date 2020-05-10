
using System;

/// <summary>
/// Val�di J�t�kos megval�s�t�s��rt felel�s oszt�ly
/// J�t�kos tud szabadon d�nteni, hogy egy k�rben melyik k�rty�t j�tsza ki
/// </summary>
public class RealPlayer : Player {
    public RealPlayer(string name, uint money) : base(name, money)
    {
    }
    /// <summary>
    /// Ez egy override-ja a Player turn met�ds�nak
    /// J�t�kos tud szabadon d�nteni, hogy egy k�rben melyik k�rty�t j�tsza ki
    /// </summary>
    /// <param name="valueOfPile"> Dob�pakli �ssz�rt�ke </param>
    /// <param name="version"> J�t�k verzi�ja </param>
    /// <returns></returns>
    public override int Turn(int valueOfPile,int version)
    {
        //play a card
        Console.WriteLine("Melyik lapod szeretn�d kij�tszani?");
        int c = 0;
        Card card;
        int PlayedCardIndex = 0;
        Boolean invalidInput = true;
        do
        {
            Console.Write("Index of the card: ");
            while (!int.TryParse(Console.ReadLine(), out PlayedCardIndex))
            {
                Console.Write("Nincs ilyen v�lasz!\nIndex of the card: ");
            }
            if (PlayedCardIndex == -1) return -100;
            if (0 <= PlayedCardIndex && PlayedCardIndex < Cards.Count) invalidInput = false;
            else Console.WriteLine("Ez egy �rv�nytelen index, k�rlek adj meg m�sikat!");
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