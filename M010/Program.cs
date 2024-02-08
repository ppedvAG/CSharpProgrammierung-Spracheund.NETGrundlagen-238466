using System.Runtime.InteropServices;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Smartphone s = new Smartphone();
		s.Aufladen(59);

		ElektroAuto eAuto = new ElektroAuto();
		eAuto.Aufladen(49);

		//Variable des Interfaces anlegen
		IAufladbar aufladbar = s;
		aufladbar = eAuto; //Auch EAuto kann hier zugewiesen werden

		//IEnumerable
		//Basis von allen Listen in C#
		IEnumerable<int> x = new int[10];
		IEnumerable<int> y = new List<int>();
		IEnumerable<int> z = new Queue<int>();

		ListeVerarbeiten(x); //Passt nicht zusammen obwohl es oben zusammen passt (Zeile 21)
		ListeVerarbeiten(y);
		ListeVerarbeiten(z);

		//Prüfen, ob ein Objekt ein bestimmtes Interface hat
		if (s is IAufladbar)
		{

		}
	}

	public static void Test(IAufladbar aufladbar) //Kann nur Smartphones und EAutos empfangen
	{

	}

	public static void Test(object aufladbar) //Kann alles empfangen
	{

	}

	public static void ListeVerarbeiten(int[] x) { }

	public static void ListeVerarbeiten(IEnumerable<int> x) { } //Kann beliebige Listen empfangen
}

public class Elektrogeraet { }

public class Mixer : Elektrogeraet { }

public class Smartphone : Elektrogeraet, IAufladbar
{
	public int Akkustand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public bool WirdGeladen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public string Akkuzustand()
	{
		throw new NotImplementedException();
	}

	public void Aufladen(int Akkustand)
	{

	}

	public void DauerBisVoll()
	{
		throw new NotImplementedException();
	}
}

public class ElektroAuto : IAufladbar
{
	public int Akkustand { get; set; }

	public bool WirdGeladen { get; set; }

	public string Akkuzustand()
	{
		return $"Der Akkustand beträgt {Akkustand}%, der Akku wird {(WirdGeladen ? "geladen" : "nicht geladen")}.";
	}

	public void Aufladen(int Akkustand)
	{
		int neuerAkku = this.Akkustand + Akkustand;
		if (neuerAkku >= 0 && neuerAkku <= 100)
			this.Akkustand = neuerAkku;
	}

	public void DauerBisVoll()
	{
		if (WirdGeladen)
            Console.WriteLine("...");
    }
}

/// <summary>
/// Interface: Ermöglicht Polymorphismus zwischen Klassen die sonst keine Gemeinsamkeiten haben
/// Vererbung einer Klasse ist eine "strenge" Vererbung (Es kann immer nur eine Oberklasse geben)
/// Vererbung eines Interface ist eine "lockere" Vererbung (Es kann beliebig viele Interfaces geben)
/// Interface funktioniert wie eine Abstrakte Klasse (Member werden erzwungen, kann nicht instanziert werden, Methoden ohne Body, ...)
/// </summary>
public interface IAufladbar
{
	int Akkustand { get; set; }

	bool WirdGeladen { get; set; }

	void Aufladen(int Akkustand);

	string Akkuzustand();

	void DauerBisVoll();
}