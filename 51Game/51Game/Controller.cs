
using System;

/// <summary>
/// J�t�k�k ind�t�s��rt felel� oszt�ly
/// </summary>
public class Controller {
    /// <summary>
    /// "�jraj�tsz�s" f�jl
    /// </summary>
    private static string REPLAY_FILE = @"replay.txt";

    /// <summary>
    /// J�tkokat ind�t a Main am�g a J�t�kos j�tszani szeretne
    /// Majd ki�rajta a f�ljba a meccset sz�veges�tve, �s a konzolra is ki�rja
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
            while (!bool.TryParse(Console.ReadLine(), out wannaPlay))
            {
                Console.Write("Nincs ilyen v�lasz!\nAnother Round(true/false) : ");
            }
        }

        Helper.Log(GameManager.replayString, 0, REPLAY_FILE);
        Helper.ReadLog(REPLAY_FILE);
        Console.ReadKey();
        return 0;
    }
}