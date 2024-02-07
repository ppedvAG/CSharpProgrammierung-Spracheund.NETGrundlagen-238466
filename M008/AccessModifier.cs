namespace M008;

public class AccessModifier
{
	public string Name { get; set; } //Kann überall gesehen (auch außerhalb vom Projekt)

	internal int Alter { get; set; } //Kann überall gesehen (aber nur innerhalb vom Projekt)

	private string Adresse { get; set; } //Kann nur innerhalb dieser Klasse gesehen werden


	protected string Haarfarbe { get; set; } //Kann nur innerhalb dieser Klasse gesehen werden aber auch in Unterklassen (auch außerhalb vom Projekt)

	protected internal string Lieblingfarbe { get; set; } //Kann überall gesehen (aber nur innerhalb vom Projekt), und in Unterklassen außerhalb vom Projekt

	protected private bool Verheiratet { get; set; } //Kann nur innerhalb dieser Klasse gesehen werden aber auch in Unterklassen (nur innerhalb vom Projekt)
}