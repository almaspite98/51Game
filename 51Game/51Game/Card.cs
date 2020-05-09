
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Card {
    public string Name { get; set; }
    public int Value { get; set; }

    public Card(string name, int value) {
        this.Name = name;
        this.Value = value;
    }

    public override string ToString() {
        return "Card: " + Name + " " + Value ; }
}