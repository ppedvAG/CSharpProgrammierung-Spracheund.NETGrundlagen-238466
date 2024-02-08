namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x) //this (in diesem Kontext): bestimmt den Typen, auf den sich diese Erweiterungsmethode bezieht
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e)); //½
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next());
	}
}
