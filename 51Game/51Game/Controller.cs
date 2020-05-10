
using System;

public class Controller {
    private static string LOG_FILE = @"log.txt";
    private static string REPLAY_FILE = @"replay.txt";



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
        Helper.Log(GameManager.replayString, 0, LOG_FILE);
        
        


        //init accountListFileName
        //String FilePath;
        //FilePath = Server.MapPath("/MyWebSite");

        
        return 0;
    }
}