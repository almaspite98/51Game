
using System;

public class Controller {
    
    private static string REPLAY_FILE = @"replay.txt";



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