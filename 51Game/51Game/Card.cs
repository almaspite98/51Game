/// <summary>
/// Kártya osztály egy magyar kártya reprezentálásáért felel
/// Neve és értéke van egy Card-nak
/// </summary>
public class Card {
    public string Name { get; set; }
    public int Value { get; set; }

    public Card(string name, int value) {
        this.Name = name;
        this.Value = value;
    }

    /// <summary>
    /// Kiíratásnál a nevet és az érétket látjuk
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
        return Name + " " + Value ; }
}