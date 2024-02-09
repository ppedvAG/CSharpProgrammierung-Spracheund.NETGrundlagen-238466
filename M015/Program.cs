using CsvHelper;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		//Dateimanagement
		//Directory, File, Path

		string folderPath = "M015";
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//StreamWriter: Wrapper für einen Stream
		//Stream: Pipe für Bytes auf z.B. Files oder Webschnittstellen
		StreamWriter writer = new StreamWriter(filePath);
		writer.WriteLine("Test1");
		writer.WriteLine("Test2");
		writer.WriteLine("Test3"); //Hier wird nur ein Buffer beschrieben
		writer.Flush(); //Texte in die Datei schreiben
		writer.Close();

		//using-Block: Ermöglicht das automatische schließen von Streams/externen Resourcen
		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
			//sw2.Flush(); //Nicht notwendig, da Dispose() automatisch Flush() mitinbezieht
		} //.Dispose()

		//using-Statement: Stream wird am Ende der Methode geschlossen
		using StreamReader reader = new StreamReader(filePath);
		string content = reader.ReadToEnd();
        Console.WriteLine(content);

		List<string> lines = [];
		while (!reader.EndOfStream)
			lines.Add(reader.ReadLine());

		reader.Close();

		//Schnelle Methoden
		File.WriteAllText(filePath, content);
		File.WriteAllLines(filePath, lines);

		string s = File.ReadAllText(filePath);
		string[] strings = File.ReadAllLines(filePath);

		//NuGet-Pakete
		//Externe Pakete installieren
		//z.B. DB Connectoren, Logger, ...
		//Tools -> NuGet-Package Manager -> Manage Packages

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

		//System.Text.Json
		//string json = JsonSerializer.Serialize(fahrzeuge);
		//File.WriteAllText("Fahrzeuge.txt", json);

		//string readJson = File.ReadAllText("Fahrzeuge.txt");
		//Fahrzeug[] fzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson);

		//Newtonsoft.Json
		string json = JsonConvert.SerializeObject(fahrzeuge);
		File.WriteAllText("Fahrzeuge.txt", json);

		string readJson = File.ReadAllText("Fahrzeuge.txt");
		Fahrzeug[] fzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson);

		//XML
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new("Fahrzeuge.xml"))
		{
			xml.Serialize(sw, fahrzeuge);
		}

		using (StreamReader sr = new("Fahrzeuge.xml"))
		{
			List<Fahrzeug> readFzg = xml.Deserialize(sr) as List<Fahrzeug>;
		}

		//CSV
		using (StreamWriter sw = new("Fahrzeuge.csv"))
		{
			CsvWriter csvW = new CsvWriter(sw, CultureInfo.CurrentCulture); //CultureInfo: Tausendertrennzeichen, Kommazeichen, ...
																			//new CultureInfo("de-DE"), "en-US"
			csvW.WriteRecords(fahrzeuge);
		}

		using (StreamReader sr = new("Fahrzeuge.csv"))
		{
			CsvReader csvW = new CsvReader(sr, CultureInfo.CurrentCulture); //CultureInfo: Tausendertrennzeichen, Kommazeichen, ...
																			//new CultureInfo("de-DE"), "en-US"
			csvW.GetRecords<Fahrzeug>().ToList();
		}
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

    public Fahrzeug()
    {
		
    }
}

public enum FahrzeugMarke { Audi, BMW, VW }