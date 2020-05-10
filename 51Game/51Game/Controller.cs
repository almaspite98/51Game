


using System;

public class Controller {
    private static GameManager gm;

    private static void Method()
    {
        //int.Parse(Console.ReadLine());
        string val;
        Console.Write("Enter Integer: ");
        val = Console.ReadLine();

        int a = Convert.ToInt32(val);
        Console.WriteLine("Your input: {0}", a);
    }

    static int Main(string[] args)
    {
        gm = new GameManager();
        gm.Start();
        gm.Play();

        Method();
        //init accountListFileName
        //String FilePath;
        //FilePath = Server.MapPath("/MyWebSite");

        
        return 0;
    }
}