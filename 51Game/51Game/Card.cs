
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Card {
    public string Name { get; set; }
    public uint Value { get; set; }

    public Card(string name, uint value)
    {
        this.Name = name;
        this.Value = value;
    }
}