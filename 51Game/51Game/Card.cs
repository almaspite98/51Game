/// <summary>
/// K�rtya oszt�ly egy magyar k�rtya reprezent�l�s��rt felel
/// Neve �s �rt�ke van egy Card-nak
/// </summary>
public class Card {
    public string Name { get; set; }
    public int Value { get; set; }

    public Card(string name, int value) {
        this.Name = name;
        this.Value = value;
    }

    /// <summary>
    /// Ki�rat�sn�l a nevet �s az �r�tket l�tjuk
    /// </summary>
    /// <returns></returns>
    public override string ToString() {
        return Name + " " + Value ; }
}