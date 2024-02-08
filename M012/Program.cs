using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region IEnumerable
		//Basis für alle Listentypen in C#
		//Dieses Interface wird benötigt um foreach auf ein Objekt anwenden zu können und Linq

		//IEnumerable ist nur eine Anleitung
		Enumerable.Range(0, 20); //Anleitung zur Erstellung einer Liste von 0-19
		Enumerable.Range(0, 1_000_000_000); //1ms, hier werden noch keine Werte erstellt
		Enumerable.Range(0, 1_000_000_000).ToList(); //Ausführung der Anleitung -> 5s, Endergebnis sind konkrete Werte

		Enumerable.Range(0, 1_000_000_000).Where(e => e % 2 == 0); //1ms -> Anleitung

		List<int> ints = [1, 2, 3, 4, 5, 6, 7, 8, 9];
		//ints.AddRange(Enumerable.Range(0, 1_000_000_000)); //Anleitung weitergeben und AddRange selbst die Ausführung überlassen
		//ints.AddRange(Enumerable.Range(0, 1_000_000_000).ToList()); //Doppelte Durchgänge (ToList() + AddRange())
		#endregion

		#region Einfaches Linq
		//Linq: Collections einfach verarbeiten
		ints.Average();
		ints.Sum();
		ints.Min();
		ints.Max();

		ints.First(); //Gibt das erste Element zurück, oder eine Exception wenn kein Element gefunden wird
		ints.FirstOrDefault(); //Gibt das erste Element zurück, oder den Standardwert des Datentypen (0, null, false) wenn kein Element gefunden wird

		ints.Last();
		ints.LastOrDefault();

        //Console.WriteLine(ints.First(e => e % 50 == 0)); //Finde die erste Zahl, die durch 50 teilbar ist
        Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //Finde die erste Zahl, die durch 50 teilbar ist
		#endregion

		#region Linq mit Objektliste
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Finde alle Fahrzeuge die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV > 200);

		//Finde alle VWs die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV > 200 && e.Marke == FahrzeugMarke.VW);

		//Alle Fahrzeuge nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //WICHTIG: Nicht die originale Liste wird hier verändert
		fahrzeuge.OrderByDescending(e => e.Marke);

		//Alle Fahrzeuge nach Marke und danach Geschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		List<Fahrzeug> sorted = fahrzeuge.OrderBy(e => e.Marke).ToList(); //Sortierung in einer neuen Liste speichern

		//Fahren alle unsere Fahrzeuge mindestens 200km/h?
		if (fahrzeuge.All(e => e.MaxV > 200))
		{
            Console.WriteLine("...");
        }

		//Fährt mindestens eines unserer Fahrzeuge mindestens 200km/h?
		if (fahrzeuge.Any(e => e.MaxV > 200))
		{
			Console.WriteLine("...");
		}

		//Wieviele BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW); //4

		//Wieviele BMWs und VWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW || e.Marke == FahrzeugMarke.VW);

		//Min vs. MinBy
		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit

		//Die Durchschnittsgeschwindigkeit aller Audis
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.Audi)
			.Average(e => e.MaxV);

		//Select
		//Transformiert eine Liste in eine neue Form
		//Zwei Anwendungsfälle

		//1. Fall: Einzelnes Feld aus der Liste entnehmen (80%):

		//Liste mit allen Marken haben
		fahrzeuge.Select(e => e.Marke); //Schleife über die Liste, entnehmen aus jedem Element die Marke und schreiben diese in die neue Liste

		//Die Durchschnittsgeschwindigkeit
		fahrzeuge.Select(e => e.MaxV).Average();
		fahrzeuge.Average(e => e.MaxV);

		//2. Fall: Liste umwandeln (20%)

		//Wir haben einen Ordner mit Dateien, wir wollen jetzt aus den Pfaden nur die Dateinamen ohne Endung entnehmen
		string[] files = Directory.GetFiles(@"C:\Windows");
		List<string> dateinamen = new();
		foreach (string s in files)
			dateinamen.Add(Path.GetFileNameWithoutExtension(s));

		//Mit Select
		List<string> namen = Directory.GetFiles(@"C:\Windows")
			.Select(e => Path.GetFileNameWithoutExtension(e))
			.ToList();

		dateinamen.SequenceEqual(namen); //true

		//GroupBy
		//Gruppiert die Elemente der Liste nach einem Kriterium
		fahrzeuge.GroupBy(e => e.Marke); //Erzeugt für jede Marke eine Gruppe, und fügt alle Elemente ihrer entsprechenden Gruppe hinzu

		//Konvertierung zu Dictionary oder Lookup
		var lookup = fahrzeuge
			.GroupBy(e => e.Marke)
			.ToLookup(e => e.Key);
		Console.WriteLine(lookup[FahrzeugMarke.Audi]); //Alle Audis herausholen

		fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.Count()); //Hier kann auch noch das Ergebnis verändert werden

		fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.ToList()); //Effektiv ein Lookup
		#endregion

		#region Erweiterungsmethoden
		//Erweiterungsmethoden
		//An beliebige Typen in C# Methoden anhängen
		int zahl = 4287;
		zahl.Quersumme();

        Console.WriteLine(327958.Quersumme());

		//Eigene Linq Funktion
		//Liste randomizen
		fahrzeuge.Shuffle();
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }