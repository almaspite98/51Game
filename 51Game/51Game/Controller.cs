
using System;

/// <summary>
/// Ez az osztály felel azért, hogy Játékokat indítson
/// Játékok végén pedig a "újrajátsza" nyíltlapokkal a meccset
/// </summary>
public class Controller {
    
    /// <summary>
    /// Ez az "újrajátszás" fájl útvonalát
    /// </summary>
    private static string REPLAY_FILE = @"replay.txt";


    /// <summary>
    /// A logika itt van megvalósítva, amíg akar játszani a Játékos, addig újabb GameManagereket idít el
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
            wannaPlay = bool.Parse(Console.ReadLine());
        }

        Helper.Log(GameManager.replayString, 0, REPLAY_FILE);
        Helper.ReadLog(REPLAY_FILE);
        Console.ReadKey();
        return 0;
    }
}