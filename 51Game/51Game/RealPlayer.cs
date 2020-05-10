
using System;

public class RealPlayer : Player {
    public RealPlayer(string name, uint money) : base(name, money)
    {
    }

    public override int Turn(int valueOfPile,int version)
    {
        //play a card
        Console.WriteLine("Melyik lapod szeretnéd kijátszani?");
        int c = 0;
        Card card;
        int i;
        Boolean invalidInput = true;
        do
        {
            Console.Write("Index of the card: ");
            i = int.Parse(Console.ReadLine());
            if (i == -1) return -100;
            if (0 <= i && i < Cards.Count) invalidInput = false;
            else Console.WriteLine("Ez egy érvénytelen index, kérlek adj meg másikat!");
            if (c >= 10)
            {
                card = Cards[0];
                Cards.RemoveAt(0);
                return card.Value;
            }
            c++;
        } while (invalidInput);
        card = Cards[i];
        Cards.RemoveAt(i);
        GameManager.replayString.Add("Value of card played: " + card.Value);
        return card.Value;//c.Value;

    }

}