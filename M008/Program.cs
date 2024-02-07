namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(20, "Max");
		m.Alter = 30; //Alter wird von Lebewesen vererbt
		m.Bewegen(10); //Bewegen wird auch vererbt

		Hund h = new Hund(2);
		h.Alter = 2;
		h.Bewegen(20);

		//virtual, override
		m.Bewegen2(30); //Hier wird die Basisimplementation ausgeführt, weil keine Überschreibung angegeben ist
		h.Bewegen2(30);

		//Nach Überschreibung
		m.Bewegen2(30); //Neuer Code
	}
}

/// <summary>
/// Vererbung: Klassenhierarchien herstellen
/// Felder, Properties, Funktionen werden nach unten vererbt
/// Konstruktoren müssen verkettet werden
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; }

	public Lebewesen(int alter)
	{
		Alter = alter;
	}

	public void Bewegen(int distanz)
	{
        Console.WriteLine($"Das Lebewesen bewegt sich um {distanz}m.");
    }

	/// <summary>
	/// virtual: Ermöglicht, die Überschriebung dieser Methode in den Unterklassen -> eine spezifische Implementation pro Klasse
	/// Hier kann eine Basisimplementation gegeben werden
	/// In den Unterklassen kann override für die Überschreibung verwendet werden
	/// </summary>
	public virtual void Bewegen2(int distanz)
	{
		Console.WriteLine($"Das Lebewesen bewegt sich um {distanz}m.");
	}
}

public class Mensch : Lebewesen //Mit : <Klasse> eine Vererbung herstellen
{
	public string Name { get; set; }

	/// <summary>
	/// Um hier ein Feld hinzuzufügen kann es einfach dazu geschrieben werden
	/// </summary>
	public Mensch(int alter, string name) : base(alter) //Mit base muss hier in die Oberklasse verkettet werden
	{
		Name = name;
	}

	/// <summary>
	/// override + Abstand -> Methode auswählen -> Enter
	/// </summary>
	public override void Bewegen2(int distanz)
	{
		//base.Bewegen2(distanz); //base.: Nimm die Implementation von der Oberklasse
		Console.WriteLine($"Der Mensch bewegt sich um {distanz}m.");
	}
}

public class Hund : Lebewesen //"Hund ist ein Lebewesen"
{
	public Hund(int alter) : base(alter)
	{
	}
}