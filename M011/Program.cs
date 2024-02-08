namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generische Datentypen (Generic)
		//Geben die Möglichkeit, Typagnostische Klassen und Methoden zu definieren, bei denen bei Objekterstellung/Verwendung der Benutzer einen fixen Typen angeben muss
		//Der Platzhalter T wird dann überall innerhalb der Klasse/Methode durch den gegebenen Typen ausgetauscht

		//List: Funktioniert wie Array, aber ist beliebig groß
		List<int> ints = new List<int>(); //List von int
		ints.Add(1); //T wird durch int ersetzt
		ints.Contains(1); //Auch hier wird T durch int ersetzt

		Console.WriteLine(ints[0]); //Index genau wie bei Array

		foreach (int i in ints) //Schleife wie bei Array
		{
            Console.WriteLine(i);
        }

		Console.WriteLine(ints.Count); //Count == Length

		List<string> strings = new List<string>();
		strings.Add("ABC"); //Hier wird T durch string ersetzt

		/////////////////////////////////////////////////////////////////////////

		//Dictionary: Liste von Schlüssel-Wert Paaren
		//Benötigt zwei Generics (Key und Value)
		//WICHTIG: Jeder Schlüssel muss eindeutig sein

		Dictionary<string, int> einwohnerzahlen = new(); //Target-Typed new: Ergänzt den Typen des Objekts von der linken Seite
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //System.ArgumentException: 'An item with the same key has already been added. Key: Paris'

		Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary angreifen mit [] wobei der Index sich an den generischen Datentyp des Schlüssels anpasst

		if (!einwohnerzahlen.ContainsKey("Paris")) //Prüft, ob ein Schlüssel existiert
			einwohnerzahlen.Add("Paris", 2_160_000);

        Console.WriteLine(einwohnerzahlen.Keys); //Gibt eine Liste nur mit den Schlüsseln zurück
        Console.WriteLine(einwohnerzahlen.Values); //Gibt eine Liste nur mit den Werten zurück

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var: Der Typ ergibt sich aus dem Objekt
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
		}

		for (int i = 0; i < einwohnerzahlen.Count; i++)
		{
			Console.WriteLine(einwohnerzahlen.ElementAt(i));
        }
	}
}
