while (true)
{
	double z1 = ZahlEingabe("Gib die erste Zahl ein: ");
	double z2 = ZahlEingabe("Gib die zweite Zahl ein: ");
	Rechenoperation op = RechenoperationEingabe();

	Berechne(z1, z2, op);

	Console.WriteLine("Enter drücken zum wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}

double Berechne(double x, double y, Rechenoperation op)
{
	switch (op)
	{
		case Rechenoperation.Add:
            Console.WriteLine($"{x} + {y} = {x + y}");
			return x + y;
		case Rechenoperation.Sub:
			Console.WriteLine($"{x} - {y} = {x - y}");
			return x - y;
		case Rechenoperation.Mult:
			Console.WriteLine($"{x} * {y} = {x * y}");
			return x * y;
		case Rechenoperation.Div:
			if (y == 0)
				return double.NaN;
			Console.WriteLine($"{x} / {y} = {x / y}");
			return x / y;
		default:
            Console.WriteLine("Fehlerhafte Rechenoperation");
			return double.NaN;
    }
}

double ZahlEingabe(string text)
{
	while (true)
	{
        Console.Write(text);
		string eingabe = Console.ReadLine();
		bool b = double.TryParse(eingabe, out double z);
		if (b)
			return z;
        //Console.WriteLine("Keine Zahl eingegeben");
    }
}

Rechenoperation RechenoperationEingabe()
{
	while (true)
	{
        Console.WriteLine("Gib eine Rechenoperation ein: ");
        foreach (Rechenoperation op in Enum.GetValues<Rechenoperation>())
            Console.WriteLine($"{(int) op}: {op}");

		Rechenoperation operation = (Rechenoperation) ZahlEingabe("Gib eine Rechenoperation ein: ");
		if (Enum.IsDefined(operation))
		{
			return operation;
		}
        Console.WriteLine("Ungültige Rechenoperation");
    }
}

enum Rechenoperation
{
	Add = 1, Sub, Mult, Div
}