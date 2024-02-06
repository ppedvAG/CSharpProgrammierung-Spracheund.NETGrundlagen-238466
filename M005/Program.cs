namespace M005;

internal class Program
{
	static void Main(string[] args)
	{
		int x = Addiere(4, 5);
		PrintAddiere(5, 6);

		//Methodenüberladung: Ermöglicht, mehrere Funktionen mit demselben Namen anzulegen
		Console.WriteLine(); //1 of 18, 18 verschiedene CW Funktionen

		Addiere(1, 2); //1 of 2 ausgewählt
		Addiere(1, 2, 3); //2 of 2 ausgewählt

		//params: Beliebige Anzahl von Parametern, muss als Array angegeben werden
		Summiere(3, 4);
		Summiere(2, 3, 4, 5, 6);
		Summiere(4);
		Summiere(); //Achtung: Keine Parameter sind auch beliebig viele Parameter

		//Optionale Parameter: Parameter mit einer Vorbelegung, der vom Benutzer (falls gefordert) überschrieben werden kann
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6, false); //Standardbelegung kann angepasst werden
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6);
		AddiereOderSubtrahiere(5, 6);

		//Konfiguration von Methoden
		PrintPerson(alter: 20); //Nur die Parameter angeben die auch wirklich interessant sind
		PrintPerson(nachname: "Mustermann", adresse: "Zuhause");

		//out-Parameter: Ermöglicht, die Rückgabe von mehreren Werten statt nur einem
		int diff;
		int summe = AddiereUndSubtrahiere(4, 5, out diff); //Hier wird der out Parameter mit der diff Variable verbunden
        Console.WriteLine($"Summe: {summe}, Differenz: {diff}");

		//int.Parse("degj"); //Absturz
		int p = 22;
		bool hatFunktioniert = int.TryParse("123e", out p); //Wenn parsen nicht funktioniert hat, ist p = 0
		if (hatFunktioniert)
		{
            Console.WriteLine($"Ergebnis: {p}");
        }
		else
		{
            Console.WriteLine("Parsen hat nicht funktioniert");
        }

		int.TryParse("123", out int a); //out Variable in der Funktion selbst definieren

		//Tupel: Ermöglicht das gruppieren von zwei Werten in einen Typen
		(int, int) zahlen = AddiereUndSubtrahiere(5, 6);
        Console.WriteLine(zahlen.Item1);
        Console.WriteLine(zahlen.Item2);
    }

	/// <summary>
	/// Diese Funktion addiert zwei ganze Zahlen zusammen und gibt diese Summe zurück.
	/// </summary>
	/// <param name="x">Die erste Zahl</param>
	/// <param name="y">Die zweite Zahl</param>
	/// <returns>Die Summe von x und y</returns>
	static int Addiere(int x, int y)
	{
		return x + y;
	}

	/// <summary>
	/// Kein Rückgabewert
	/// </summary>
	static void PrintAddiere(int x, int y)
	{
        Console.WriteLine(x + y);
    }

	static int Addiere(int x, int y, int z)
	{
		return x + y + z;
	}

	static int Summiere(params int[] x)
	{
		return x.Sum();
	}

	static int AddiereOderSubtrahiere(int x, int y, bool add = true)
	{
		if (add)
			return x + y;
		else
			return x - y;
	}

	static void PrintPerson(string vorname = "", string nachname = "", int alter = 0, string adresse = "") //20 Parameter
	{
		return; //Beendet die Funktion
        Console.WriteLine(); //Unreachable code detected
    }

	static int AddiereUndSubtrahiere(int x, int y, out int diff) //Zwei Rückgabewerte
	{
		diff = x - y;
		return x + y;
	}

	static (int, int) AddiereUndSubtrahiere(int x, int y)
	{
		return (x + y, x - y);
	}
}