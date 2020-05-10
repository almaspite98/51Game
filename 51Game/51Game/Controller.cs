
using System;

/// <summary>
/// Játékék indításáért felelõ osztály
/// </summary>
public class Controller {
    /// <summary>
    /// "újrajátszás" fájl
    /// </summary>
    private static string REPLAY_FILE = @"replay.txt";

    /// <summary>
    /// Játkokat indít a Main amíg a Játékos játszani szeretne
    /// Majd kiírajta a fáljba a meccset szövegesítve, és a konzolra is kiírja
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static int Main(string[] args)
    {
        Console.WriteLine("Üdvözlünk az 51 Game-ben!");
        GameManager gm;
        bool wannaPlay = true;
        bool firstRound = true;
        while (wannaPlay)
        {
            gm = new GameManager();
            if (firstRound)
            {
                gm.WelcomeWallText();
                firstRound = false;
            }
            gm.NewGameSreen();
            Console.WriteLine("Akarsz még játszani? ");
            Console.Write("Another Round(true/false) : ");
            while (!bool.TryParse(Console.ReadLine(), out wannaPlay))
            {
                Console.Write("Nincs ilyen válasz!\nAnother Round(true/false) : ");
            }
        }

        Helper.Log(GameManager.replayString, 0, REPLAY_FILE);
        Helper.ReadLog(REPLAY_FILE);
        Console.ReadKey();
        return 0;
    }
}