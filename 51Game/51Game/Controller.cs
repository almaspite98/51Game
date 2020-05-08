
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Controller {
    private static GameManager gm;
    private static AccountList accountList;
    private static string accountListFileName;

    static int Main(string[] args)
    {
        gm = new GameManager();
        //init accountListFileName
        accountList = new AccountList(accountListFileName);
        return 0;
    }
}