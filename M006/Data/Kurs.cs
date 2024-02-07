namespace M006.Data;

internal class Kurs
{
    //Properties: Preis, Dauer, Titel, Teilnehmer, Trainer
    //Funktionen: TeilnehmerHinzufügen

    public string Titel { get; set; }

    public int DauerInTagen { get; set; }

    public int Preis { get; set; }

    public Person[] Teilnehmer { get; private set; }

    public Person Trainer { get; set; }

    public Kurs(string titel, int dauerInTagen, int preis, Person trainer, params Person[] teilnehmer)
    {
        Titel = titel;
        DauerInTagen = dauerInTagen;
        Preis = preis;
        Teilnehmer = teilnehmer;
        Trainer = trainer;
    }

    public void AddTeilnehmer(Person p)
    {
        Teilnehmer = Teilnehmer.Append(p).ToArray();
    }
}
