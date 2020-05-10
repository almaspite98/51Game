
using System;

/// <summary>
/// Ez az oszt�ly felel az�rt, hogy J�t�kokat ind�tson
/// J�t�kok v�g�n pedig a "�jraj�tsza" ny�ltlapokkal a meccset
/// </summary>
public class Controller {
    
    /// <summary>
    /// Ez az "�jraj�tsz�s" f�jl �tvonal�t
    /// </summary>
    private static string REPLAY_FILE = @"replay.txt";


    /// <summary>
    /// A logika itt van megval�s�tva, am�g akar j�tszani a J�t�kos, addig �jabb GameManagereket id�t el
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static int Main(string[] args)
    {
        Console.WriteLine("�dv�zl�nk az 51 Game-ben!");
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
            Console.WriteLine("Akarsz m�g j�tszani? ");
            Console.Write("Another Round(true/false) : ");
            wannaPlay = bool.Parse(Console.ReadLine());
        }

        Helper.Log(GameManager.replayString, 0, REPLAY_FILE);
        Helper.ReadLog(REPLAY_FILE);
        Console.ReadKey();
        return 0;
    }
}