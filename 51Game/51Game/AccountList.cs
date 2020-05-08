
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AccountList {

    private List<Player> players;

    public AccountList(string accountListFileName)
    {
        //beolvasás a fájlból az accountokat és adataikat
    }
    

    /// <summary>
    /// @param string name 
    /// @param string password
    /// </summary>
    public void Login(string name, string password) {
        players.Add(new Player(name, password));
    }

}