
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AccountList {

    private List<Player> players;

    public AccountList(string accountListFileName)
    {
        //beolvas�s a f�jlb�l az accountokat �s adataikat
    }
    

    /// <summary>
    /// @param string name 
    /// @param string password
    /// </summary>
    public void Login(string name, string password) {
        players.Add(new Player(name, password));
    }

}