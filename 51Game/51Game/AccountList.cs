
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class AccountList {

    public List<Player> Players { get; set; }

    public AccountList(string accountListFilePath)
    {
        //beolvasás a fájlból az accountokat és adataikat
        string jsonString = File.ReadAllText(accountListFilePath);
        Players=JsonConvert.DeserializeObject<List<Player>>(jsonString);
        Players.ForEach(i => Debug.WriteLine("{0}", i));
    }
    
    /*private void ScanAccountsFromFile(string accountListFileName)
    {
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(accountListFileName))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.WriteLine(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.WriteLine("The file could not be read:");
            Debug.WriteLine(e.Message);
        }
    }*/

    /// <summary>
    /// @param string name 
    /// @param string password
    /// </summary>
    public void Login(string name, string password) {
        Players.Add(new Player(name, password));
    }

}