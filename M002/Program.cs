#region Variablen
//Aufbau:
//Datentyp Name;
int zahl;
zahl = 10;

Console.WriteLine(zahl); //cw + Tab

//Datentypen
//Wichtig: int, double, string, bool

//Ganze Zahlen:
//byte, short, int, long
byte b = 32;
short s = 3825;
long l = 832579813274;

//Kommazahlen:
//float, double, decimal
double d = 382957.21759327;
float f = 219874214.32185712984f;
decimal m = 83297593287.3158731957m;

//Texttypen:
//char, string
string str = "Das ist ein Text"; //Doppelte Hochkomma
char c = 'A'; //Einzelne Hochkomma

//Boolean
bool T = true;
bool F = false;
#endregion

#region Strings
//Strings verbinden
//Mit +
string kombination = "Die Zahl ist " + zahl + ", der Text ist: " + str + ", True: " + T;
Console.WriteLine(kombination);

//String Interpolation ($-String): Code in einen String einbauen
string interpolation = $"Die Zahl ist {zahl}, der Text ist: {str}, True: {T}";
Console.WriteLine(interpolation);

//Escape-Sequenzen: Untippbare Zeichen in einen String einbauen
//Zeilenumbruch: \n
//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
string umbruch = "Test\nTest";

string e = "\" \\ \t";

//Verbatim-String (@-String): String der Escape-Sequenzen ignoriert
string pfad = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Text.Encoding.Extensions.dll";
string pfad2 = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.1\\System.Text.Encoding.Extensions.dll";
#endregion

#region Eingabe
//string eingabe = Console.ReadLine(); //Hält das Programm auf, bis eine Eingabe kommt + Enter
//Console.WriteLine($"Du hast {eingabe} eingegeben");

//ConsoleKeyInfo info = Console.ReadKey();
//Console.WriteLine($"Du hast {info.Key} gedrückt. Diese Taste hat den Character {info.KeyChar}");

//Console.ReadKey(true); //Sorgt dafür, das der eingebene Character nicht in der Konsole ausgegeben wird

Console.Write("Ausgabe ohne Zeilenumbruch");
#endregion

#region Konvertierungen
//string -> anderer Typ: Parse
//anderer Typ -> string: ToString()
//anderer Typ -> anderer Typ: Typecast

string zahlEingabe = "2384";
//Console.WriteLine(zahlEingabe * 2); //Texte können nicht multipliziert werden -> Konvertierung
int zahlEingabeKonvertiert = int.Parse(zahlEingabe); //Parse: Text zu Zahl umwandeln
Console.WriteLine(zahlEingabeKonvertiert * 2);

double x = 947.813857321;
//int y = x; //Nicht möglich, da double Kommastellen hat
int y = (int) x; //Hier über einen Cast eine explizite Umwandlung erzwingen
Console.WriteLine(y); //Hier werden die Kommastellen abgeschnitten

double a = 219874193741324.32857983257;
int g = (int) a; //Hier wird der "Maximalwert" von int genommen
Console.WriteLine(g);
//1 1111111 11111111 11111111 11111111
//Das erste Bit ist für das Vorzeichen verantwortlich
//double ist größer als int -> 31 mal die 1 + Vorzeichen auch 1 -> -2147483648

int u = 32975325;
double k = u; //int zu double ist immer möglich, da alle ints in double passen (int: 2^31, double: 5*10^324)
Console.WriteLine(k);
#endregion

#region Arithmetik
int zahl1 = 7;
int zahl2 = 4;

Console.WriteLine(zahl1 + zahl2); //Hier wird nur die Summe berechnet, ohne die Variablen zu verändern
zahl1 += zahl2; //Hier wird die rechte Variable auf die linke aufsummiert

Console.WriteLine(zahl1 % zahl2);
zahl1 %= zahl2;

zahl1++;
zahl1--;

//Rundungsfunktionen
Math.Ceiling(4.5); //Aufrunden
Math.Floor(4.5); //Abrunden
Math.Round(4.5); //Rundet auf oder ab, bei .5 zur nächsten geraden Zahl
Math.Round(4.5); //4
Math.Round(5.5); //6

double gerundet = Math.Round(329508.325879321, 2); //Hier kann auch die Anzahl der Kommastellen mitgegeben werden
Console.WriteLine(gerundet);

//Divisionseigenheiten
Console.WriteLine(8 / 5); //Int-Division: Ergebnis ganze Zahl (1)
Console.WriteLine(8 / 5d); //Double-Division erzwingen mit Konvertierung (1.6)
Console.WriteLine(8 / 5.0);
Console.WriteLine(8d / 5);
Console.WriteLine(zahl1 / (double) zahl2); //Bei einer Division mit 2 Variablen kann eine der beiden Variablen zu einem Double konvertiert werden
Console.WriteLine((double) zahl1 / zahl2);
#endregion