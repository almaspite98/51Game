
/// <summary>
/// Kártya osztály megvalósításáért felel: Van neve és értéke egy kártyának
/// </summary>
public class Card {
    public string Name { get; set; }
    public int Value { get; set; }
    public int Weight { get; set; }

    public Card(string name, int value,int weight) {
        this.Name = name;
        this.Value = value;
    }

    public override string ToString() {
        return Name + " " + Value ; }
}