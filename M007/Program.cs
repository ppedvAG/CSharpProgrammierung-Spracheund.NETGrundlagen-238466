namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Person p = new Person();
		}
		GC.Collect();
		GC.WaitForPendingFinalizers();
		#endregion

		#region Static
		//Static: Global
		//Eine Funktion/Feld welches mit Static definiert ist, kann ohne Objekt aufgerufen werden
		Console.WriteLine(); //Kann immer und überall aufgerufen werden
							 //Console cc = new Console(); //Nicht möglich, weil static

		//Person.Sprechen("Hallo"); //Nicht möglich, weil Sprechen sich auf ein Objekt bezieht
		Person p2 = new Person();
		p2.Sprechen("Hallo"); //Nur mit Objekt möglich

        //Person soll einen Zähler bekommen, der die Anzahl der erstellten Personen zählt
        Console.WriteLine(Person.Zaehler);
		#endregion

		#region Datumswerte
		//2 Klassen
		//DateTime, TimeSpan
		DateTime dt = new DateTime(2020, 01, 01);

        //Wieviele Tage sind seit dt vergangen?
        Console.WriteLine(DateTime.Now - dt); //Ergebnis: TimeSpan

		if (dt < DateTime.Now)
		{
			//Ist das Datum in der Vergangenheit?
		}

		//Formatierung von Datumswerten
        Console.WriteLine(dt.ToLongDateString());
        Console.WriteLine(dt.ToShortDateString());
        Console.WriteLine(dt.ToString("yyyy.MM.dd")); //Eigene Datumsform
		#endregion

		#region Werte- und Referenztyp
		//class und struct

		//Referenztyp: class
		//Wird referenziert, wenn diese in eine Variable geschrieben wird
		//Wenn zwei Objekte verglichen werden, werden die Speicheradressen verglichen
		Person p3 = new Person(); //Hier wird das Objekt angelegt und ein Zeiger von p3 auf dieses Objekt gelegt
		Person p4 = p3; //Hier wird ein Zeiger von p4 auf das Objekt unter p3 gelegt
		p3.Alter = 50; //Hier werden beide Objekte verändert

		//Wertetyp: struct
		//Wird kopiert, wenn diese in eine Variable geschrieben wird
		//Wenn zwei Objekte verglichen werden, werden die Inhalte verglichen
		int x = 5;
		int y = x;
		x = 10;

        Console.WriteLine(p3 == p4);
        Console.WriteLine(p3.GetHashCode());
        Console.WriteLine(p4.GetHashCode());

        Console.WriteLine(x == y);

		Test(y); //y bleibt unverändert
		Test(ref y); //y wird hier verändert
		Test(p3);
		#endregion

		#region Null
		Person p5 = null; //Null, weil die Variable leer ist
		//p5.Sprechen("Hallo"); //Fehler, weil das Objekt null ist

		if (p5 != null)
			p5.Sprechen("Hallo");

		//int z = null; //structs können nicht null sein
		int? z = null; //Mit ? am Ende des Typens können structs nullable sein
		#endregion
	}

	static void Test(int x)
	{
		x = 100;
	}

	static void Test(ref int x)
	{
		x = 100;
	}

	static void Test(Person p)
	{
		p.Alter = 100;
	}
}
