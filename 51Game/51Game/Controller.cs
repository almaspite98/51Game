
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Controller {
    private static GameManager gm;
    private static AccountList accountList;
    private static string accountListFileName = @"accounts.txt";

    static int Main(string[] args)
    {
        gm = new GameManager();
        //init accountListFileName
        //String FilePath;
        //FilePath = Server.MapPath("/MyWebSite");

        accountList = new AccountList(accountListFileName);
        Console.WriteLine("Hello world");
        return 0;
    }
}