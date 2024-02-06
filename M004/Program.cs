using System.Net;
#region Schleifen
int a = 0;
int b = 10;
while (a < b)
{
    Console.WriteLine($"while: {a}");
	a++;
}

a = 0;
do //do-while: Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
{
	Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b);

//while (true)
//{
//	//Endlosschleife
//}

a = 0;

while (true) //do-while mit while(true) dargestellt
{
	Console.WriteLine($"while true: {a}");
	a++;

	if (a == 5)
	{
		continue; //continue: Springe zum Schleifenkopf zurück (überspringe den Code danach)
	}

	if (a >= b)
		break; //break: Beende die Schleife
}

for (int i = 0; i < 10; i++) //for + Tab
{
    Console.WriteLine($"for: {i}");
}

for (int i = 10 - 1; i >= 0; i--) //forr + Tab
{
    Console.WriteLine($"forr: {i}");
}

for (int i = 0, j = 1; i < 32; i++, j *= 2)
{
    Console.WriteLine($"2^{i} = {j}");
}

int[] zahlen = [1, 2, 3, 4, 5];
//for (int i = 0; i <= zahlen.Length; i++) //Achtung: Index kann daneben greifen
//{
//	Console.WriteLine(zahlen[i]);
//}

foreach (int i in zahlen)
{
    Console.WriteLine($"foreach: {i}");
}
#endregion

#region Enum
//Enum: Eigener Datentyp mit einer Liste von Konstanten
//Verwendungszweck: Ermöglicht, das Erzwingen von einem fixen Zustand bei z.B. einer Eingabe
//Muss in einem Codefile immer ganz unten definiert werden
string sTag = "Di";
if (sTag == "DI")
{

}

Wochentag tag = Wochentag.Di;

if (tag == Wochentag.Di)
{

}

//Jeder Enumzustand hat immer eine Zahl dahinter, beginnend mit 0
Console.WriteLine(tag); //Di
Console.WriteLine((int) tag); //Die Zahl hinter dem Enumwert: 1
Console.WriteLine((Wochentag) 1); //Der Enumwert hinter der Zahl: Di

//Statische Enum Methoden
Enum.GetValues<Wochentag>(); //Enum.GetValues<Enumtyp>(): Gibt alle Enumwerte des gegebenen Enums in einem Array zurück

foreach (Wochentag wt in Enum.GetValues<Wochentag>())
{
    Console.WriteLine(wt);
}

foreach (HttpStatusCode code in Enum.GetValues<HttpStatusCode>())
{
	Console.WriteLine(code);
}
#endregion

#region Switch
//Switch: Vereinfachung von if-else Konstrukten
if (tag == Wochentag.Mo)
    Console.WriteLine("Wochenanfang");
else if (tag == Wochentag.Di || tag == Wochentag.Mi || tag == Wochentag.Do || tag == Wochentag.Fr)
    Console.WriteLine("Unter der Woche");
else if (tag == Wochentag.Sa || tag == Wochentag.So)
    Console.WriteLine("Wochenende");
else
    Console.WriteLine("Fehler");

switch (tag)
{
	case Wochentag.Mo:
        Console.WriteLine("Wochenanfang");
        break;
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
        Console.WriteLine("Unter der Woche");
        break;
	case Wochentag.Sa:
	case Wochentag.So:
        Console.WriteLine("Wochenende");
        break;
	default:
        Console.WriteLine("Fehler");
        break;
}

int x = 0;
switch (x)
{
	case 0:
        Console.WriteLine("Die Zahl ist 0");
		break;
	case 1:
		Console.WriteLine("Die Zahl ist 1");
		break;
	case 2:
		Console.WriteLine("Die Zahl ist 2");
		break;
}

switch (tag) //Switch mit boolescher Logik
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
		Console.WriteLine("Wochentag");
		break;
	case Wochentag.Sa or Wochentag.So:
        Console.WriteLine("Wochenende");
		break;
}
#endregion

enum Wochentag
{
	//Enumwerten können auch dediziert Werte zugewiesen werden
	Mo = 1, Di, Mi, Do = 10, Fr, Sa, So
}