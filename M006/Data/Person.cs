namespace M006.Data;

/// <summary>
/// Klasse: Bauplan für Objekte, hier werden Member definiert die dann im fertigen Objekt enthalten sein werden
/// Member: Variablen, Eigenschaften/Properties, Funktionen, Konstruktoren
/// Aus einer Klasse können beliebig viele Objekte erzeugt werden
/// WICHTIG: Eine Klasse enthält keine konkreten Werte
/// </summary>
public class Person
{
    //Felder: Vorname, Nachname, Alter, Augenfarbe, Größe, Gewicht, ...
    //Funktionen: Essen, Gehen, Sprechen, ...

    #region Variable
    //private: Kann von außen nicht angegriffen werden (nur innerhalb der Klammern der Klasse)
    private string vorname;

    /// <summary>
    /// Gibt dem Benutzer die Möglichkeit, auf den Vornamen zuzugreifen
    /// </summary>
    public string GetVorname()
    {
        return vorname;
    }

    /// <summary>
    /// Ermöglicht dem Benutzer, einen neuen Vornamen einzutragen
    /// Hier können Überprüfungen gemacht werden, bevor der neue Vorname eingetragen wird
    /// z.B.: Keine Zahlen, Längenüberprüfung
    /// Warum Set-Methode? Damit der Benutzer nicht einfach beliebige in das unterliegende Feld (vorname) eintragen kann
    /// </summary>
    public void SetVorname(string vorname)
    {
        if (vorname.Length >= 3 && vorname.Length <= 15 && vorname.All(char.IsLetter))
        {
            //this: Greife nach oben
            //vorname = vorname; //Hier ist nicht klar, ob der Parameter oder das private Feld gemeint ist
            this.vorname = vorname;
        }
        else
        {
            Console.WriteLine("Vorname muss vollständig aus Buchstaben bestehen und muss zwischen 3 und 15 Zeichen haben");
        }
    }
    #endregion

    #region Properties
    private string nachname;

    /// <summary>
    /// Property: Vereinfacht Get-/Set-Methoden, mit einem eigenen Aufbau
    /// Zwei Accessoren: get { ... }, set { ... }
    /// Können wie normale Variablen verwendet werden
    /// </summary>
    public string Nachname
    {
        get
        {
            return nachname;
        }
        set
        {
            //Parameter: value
            //value ist hier das gleiche wie vorname bei SetVorname (Parameter)
            if (value.Length >= 3 && value.Length <= 15 && value.All(char.IsLetter))
            {
                nachname = value;
            }
            else
            {
                Console.WriteLine("Nachname muss vollständig aus Buchstaben bestehen und muss zwischen 3 und 15 Zeichen haben");
            }
        }
    }

    //Vereinfachung von Properties
    //Expression Bodies: Einzeiler mit => darstellen
    public string Nachname2
    {
        get => nachname;
        set
        {
            if (value.Length >= 3 && value.Length <= 15 && value.All(char.IsLetter))
                nachname = value;
            else
                Console.WriteLine("Nachname muss vollständig aus Buchstaben bestehen und muss zwischen 3 und 15 Zeichen haben");
        }
    }

    //Drei verschiedene Arten von Properties
    //Full Property: private Feld + Get/Set
    //Auto Property: Wie normale Variable, aber mit { get; set; } am Ende
    //Get-Only Property

    /// <summary>
    /// Auto Property
    /// Hier können noch Access Modifier (private) auf die Accessoren angewandt werden
    /// </summary>
    public int Alter { get; set; }

    public int Gehalt { get; private set; } //Von außen nicht veränderbar

    /// <summary>
    /// Get-Only Property
    /// Kann nicht gesetzt werden
    /// Wird generell für Berechnungen verwendet
    /// </summary>
    public string VollerName
    {
        get
        {
            return vorname + " " + nachname;
        }
    }

    public string VollerName2
    {
        get => vorname + " " + nachname;
    }

    public string VollerName3 => vorname + " " + nachname;
    #endregion

    #region Funktionen
    /// <summary>
    /// Jedes Person Objekt wird die Methode sprechen haben und kann diese auch ausführen
    /// Hier wird bei VollerName der Name des konkreten Objekts eingesetzt
    /// </summary>
    public void Sprechen(string text)
    {
        Console.WriteLine($"{VollerName} sagt: {text}");
    }
    #endregion

    #region Konstruktor
    public Person()
    {
        Console.WriteLine("Person wurde erstellt");
    }

    /// <summary>
    /// Konstruktor: Code der bei Erstellung des Objekts (bei new) ausgeführt wird
    /// Hier werden Standardwerte für das konkrete Objekt verlangt
    /// Der Standardkonstruktor wird mit einem eigenen Konstruktor gelöscht
    /// </summary>
    public Person(string vorname, string nachname) : this()
    {
        this.vorname = vorname;
        this.nachname = nachname;
    }

    /// <summary>
    /// Konstruktoren verketten: Ermöglicht, mehrere Konstruktoren zu verbinden -> wenn einer aufgerufen wird, wird der andere auch aufgerufen
    /// Benötigt : this(Parameter1, Parameter2, ...)
    /// </summary>
    public Person(string vorname, string nachname, int alter)
        : this(vorname, nachname) //Hier wird der Konstruktor darüber angebunden
                                  //: this() //Hier wird der leere Konstruktor angebunden
    {
        Alter = alter;
    }

    public Person(string vorname, string nachname, int alter, int gehalt)
        : this(vorname, nachname, alter)
    {
        Gehalt = gehalt;
    }
    #endregion
}