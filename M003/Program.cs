#region Arrays
//Array: Variable, die mehrere Werte halten kann
int[] zahlen;
zahlen = new int[10]; //Neues Array mit Größe 10 erstellen
zahlen[3] = 10; //Mit [] auf eine bestimmte Stelle greifen
Console.WriteLine(zahlen[3]);

//Direkte Initialisierung
int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Länge 5, Index 0-4
int[] zahlenDirekt2 = new[] { 1, 2, 3, 4, 5 }; //Länge 5, Index 0-4
int[] zahlenDirekt3 = { 1, 2, 3, 4, 5 }; //Länge 5, Index 0-4
int[] zahlenDirekt4 = [1, 2, 3, 4, 5]; //Neu mit C# 12

Console.WriteLine(zahlen.Length); //10
Console.WriteLine(zahlen.Contains(10)); //Hat dieses Array 10 enthalten? true

//Mehrdimensionale Arrays
int[,] zweiD = new int[3, 3]; //3x3 Array/Matrix
zweiD[0, 2] = 5;

int[,,] dreiD; //Anzahl Kommas bestimmt die extra Dimensionen (hier 3)

Console.WriteLine(zweiD.GetLength(0)); //Erste Dimension
Console.WriteLine(zweiD.GetLength(1)); //Zweite Dimension
Console.WriteLine(zweiD.Rank); //Anzahl Dimensionen (2)
#endregion

#region Bedingungen
int zahl1 = 7;
int zahl2 = 4;

if (zahl1 == zahl2)
    Console.WriteLine("Z1 und Z2 sind gleich");
else
    Console.WriteLine("Z1 und Z2 sind ungleich");

//Ternary Operator (?-Operator): If's einzeilig machen
Console.WriteLine(zahl1 == zahl2 ? "Z1 und Z2 sind gleich" : "Z1 und Z2 sind ungleich");
//zahl1 == zahl2 ? Console.WriteLine("Z1 und Z2 sind gleich") : Console.WriteLine("Z1 und Z2 sind ungleich"); //Funktioniert nicht, weil der ? Operator immer ein Ergebnis zurückgeben muss

string str = zahl1 == zahl2 ? "Z1 und Z2 sind gleich" : "Z1 und Z2 sind ungleich";
#endregion