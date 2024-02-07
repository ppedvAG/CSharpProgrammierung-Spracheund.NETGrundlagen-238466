using System.Net.Http.Headers;

namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		//Polymorphismus
		//-> Typkompatibilität, welche Typen sind mit welchen anderen Typen kompatibel

		//Eine Unterklasse ist immer mit ihrer direkten Oberklasse kompatibel
		//Eine Unterklasse kann mit einer indirekten Oberklasse kompatibel sein

		//Quiz
		//int und double
		int i = 32894;
		double d = i;
		i = (int) d;

		//int und bool
		//int x = 1;
		//bool b = (bool) x;
		//bool b = true;
		//x = (int) b;

		//char und int
		char c = 'A';
		int b = c;
		b = c; //Jeder char hat immer eine Zahl dahinter -> Char Code

		//string und char
		//string s = "A";
		//char t = (char) s;
		//char t = 'A';
		//s = (string) t;

		//Was ist ein String?
		//Text = Liste von chars (char[])
		//char = int
		//string = int[]
		int[] zahlen = [44, 55, 66, 77, 88];
        Console.WriteLine(new string(zahlen.Select(e => (char) e).ToArray()));

		//Lebewesen und Mensch
		Lebewesen lw = new Mensch(11, "");
		Mensch m = (Mensch) lw; //Kann kompatibel sein, muss aber nicht (Typvergleich)

		//lw = new Lebewesen(1);
		//m = (Mensch) lw; //Hier nicht möglich, wegen new Lebewesen()

		//Mensch und Hund
		//Hund h = new Mensch(1, "Max"); //Nicht direkt kompatibel
		//Lebewesen l = new Mensch(1, "Max");
		//Hund h = (Hund) l; //Indirekt möglich, wird aber eine Fehlermeldung geben

		//object: Die Oberklasse von allen Klassen in C#
		//object ist mit allen Objekten kompatibel
		object o = 123;
		o = false;
		o = new Hund(1);
		o = "Hallo";

        #region	Typen
        //Typen
        //Es gibt zwei Optionen um ein Typ Objekt zu erhalten
        //GetType(), typeof(...)

        //GetType(): Gibt über einen Variablennamen den Typen des unterliegenden Objekts zurück
        Console.WriteLine(o.GetType()); //Fullname: System.String
        Console.WriteLine(o.GetType().Name); //String

		//typeof(...): Gibt über einen Klassennamen den Typen hinter der Klasse zurück
		Type lt = typeof(Lebewesen);
		#endregion

		#region Exakter Typvergleich
		Lebewesen l = new Mensch(1, "");
		//Ist hier ein Mensch oder ein Hund dahinter?
		if (l.GetType() == typeof(Mensch))
		{
			//true
		}

		if (l.GetType() == typeof(Hund))
		{
			//false
		}

		if (l.GetType() == typeof(Lebewesen))
		{
			//false, weil hier exakt die Typen verglichen werden
		}
		#endregion

		#region Vererbungshiearchietypvergleich
		if (l is Mensch)
		{
			//Mensch m = l;
			//true
		}

		if (l is Lebewesen)
		{
			//Lebewesen lw = l;
			//true
		}

		if (l is object)
		{
			//object o = l;
			//true
		}
		#endregion

		#region Anwendungsbeispiel
		//Ich möchte Menschen, Hunde und Katzen gruppieren in eine Liste
		Lebewesen[] zoo = new Lebewesen[5];
		zoo[0] = new Mensch(1, "Max");
		zoo[1] = new Hund(3);
		zoo[2] = new Katze(8);
		zoo[3] = new Mensch(1, "Max");
		zoo[4] = new Hund(3);

		//Über Polymorphismus wissen wir jetzt, das jedes Objekt in diesem Array die bewegen Methode haben muss
		foreach (Lebewesen tier in zoo)
		{
			//tier.Bewegen(10);
			tier.Bewegen2(10);

			//Tiere die sprechen können zum sprechen bringen
			if (tier is Mensch) //Hier wird sprechen nur bei Menschen aufgerufen
			{
				Mensch mensch = tier as Mensch;
				mensch.Sprechen("Hallo");
			}
		}

		Test(123);
		Test("Hallo");
		Test(new Mensch(1, "Max"));
		#endregion
	}

	/// <summary>
	/// Über den Parameter object kann hier alles übergeben werden
	/// </summary>
	public static void Test(object o)
	{

	}

	public static object Test()
	{
		return 123;
		return "Hallo";
		return new Mensch(1, "Max");
	}
}

/// <summary>
/// abstract: Definiert, das eine Klasse nur eine Strukturklasse ist
/// "Kein Lebewesen auf der Welt wird nur als Lebewesen bezeichnet, jedes Lebewesen hat eine spezifische Bezeichnung"
/// 
/// Diese Klasse kann nicht mehr instanziert werden (kein Objekt erzeugen)
/// Innerhalb einer Abstrakten Klasse können abstrakte Methoden/Properties ohne Body definiert werden (keine Implementation)
/// Diese Methoden/Properties müssen dann in den Unterklassen ausimplementiert werden
/// </summary>
public abstract class Lebewesen
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

	public abstract void Bewegen2(int distanz);
}

public class Mensch : Lebewesen
{
	public string Name { get; set; }

	public Mensch(int alter, string name) : base(alter) => Name = name;

	/// <summary>
	/// Hier muss jetzt diese Abstrakte Methode implementiert werden
	/// </summary>
	/// <param name="distanz"></param>
	public override void Bewegen2(int distanz)
	{
		Console.WriteLine($"Der Mensch bewegt sich um {distanz}m.");
	}

	public void Sprechen(string text) => Console.WriteLine(text);
}

public class Hund : Lebewesen
{
	public Hund(int alter) : base(alter) { }

	public override void Bewegen2(int distanz)
	{
        Console.WriteLine($"Der Hund bewegt sich {distanz}m");
    }
}

public class Katze : Lebewesen
{
	public Katze(int alter) : base(alter)
	{
	}

	public override void Bewegen2(int distanz)
	{
		Console.WriteLine($"Die Katze bewegt sich {distanz}m");
	}
}