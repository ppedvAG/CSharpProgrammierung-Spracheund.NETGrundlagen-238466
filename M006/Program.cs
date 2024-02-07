using M006.Data;

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		Person p = new Person(); //new Person(): Legt ein neues Person Objekt an
		p.SetVorname("Max"); //Dieses konkrete Objekt hat den Vornamen
        Console.WriteLine(p.GetVorname());
		//Console.WriteLine(p.vorname); //Nicht möglich, weil private

		//Properties werden wie normale Variablen angesprochen
		p.Nachname = "Mustermann";
        Console.WriteLine(p.Nachname);

		p.Sprechen("Hallo");

		Person p2 = new Person("Max", "Mustermann");
		Person p3 = new Person("Max", "Mustermann", 30);
		
		//Assozation von Objekten
		//Verwendung von Objekten in anderen Objekten
		Person trainer = new Person("Lukas", "Kern", 25);
		Person mh = new Person("", "", 27);
		Person mc = new Person("", "", 27);
		Person vl = new Person("", "", 31);
		Kurs k = new Kurs("C# Grundkurs", 4, 2000, trainer, mh, mc, vl);

		//Namespaces
		//Organisationseinheiten mit denen Typen in bestimmte Kategorien eingeordnet werden können
		//z.B. M006 -> Wurzelnamespace, sollte wenig Klassen enthalten
		//M006.Data -> Enthält die Datenklassen, Person und Kurs
		//Namespaces sollten generell mit ihrem entsprechenden Ordner zusammenhängen
		
		//using
		//Wird verwendet, um Typen zu importieren/aus anderen Namespaces zu verwenden

		//Beispiele für Namespaces
		//System: int, double, Console, ...
		//System.IO: File, Directory, Path, ...
		//System.Net: Netzwerke, Http, Mail, DNS, ...
    }
}
