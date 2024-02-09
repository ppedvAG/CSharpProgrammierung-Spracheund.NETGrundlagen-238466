namespace M013;

internal class Program
{
	/// <summary>
	/// 
	/// </summary>
	/// <exception cref="System.Exception"></exception>
	static void Main(string[] args)
	{
		//Alle Exceptions loggen
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception("Test");

		//Fehlerbehandlung
		//In einem Programm treten oftmals unvorhersehbare Fehler auf
		//z.B.: Verbindungsabbruch, API nicht erreichbar, ...
		//Bei einem Fehler stürzt das Programm ab, kann mit try-catch verhindert werden

		try //Code markieren -> Rechtsklick -> Surround with -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions Liste
			int zahl = int.Parse(eingabe); //3 mögliche Fehler

			if (zahl == 0)
				throw new TestException("Zahl darf nicht 0 sein"); //throw: Verursacht einen Fehler, lässt beim Benutzer das Programm abstürzen
		}
		catch (FormatException) //Wenn ein Fehler auftritt, wird dieser Codeblock ausgeführt
		{
            //Hier kann der Anwender selbst entscheiden, was die Fehlerbehandlung sein soll
            Console.WriteLine("Keine Zahl eingegeben");
        }
		catch (OverflowException e) //Exceptions kommen immer als Object zum Anwender
		{
            Console.WriteLine("Zahl zu klein/groß");
            Console.WriteLine(e.Message); //C# interne Nachricht
            Console.WriteLine(e.StackTrace); //Gibt den Call Stack zurück, wo die Exception aufgetreten ist
        }
		catch (Exception e) //Allgemeiner Exception Block
		{
            Console.WriteLine("Anderer Fehler");
            Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
        }
		finally //Stück Code, welches immer am Ende ausgeführt wird
		{
            Console.WriteLine("Parsen fertig");
        }
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		//Log schreiben
		File.WriteAllText("Log.txt", (e.ExceptionObject as Exception).StackTrace);
	}
}

public class TestException : Exception
{
	public TestException(string? message) : base(message) { }
}