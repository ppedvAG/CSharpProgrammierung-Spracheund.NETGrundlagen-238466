using M013;

namespace M013_Tests;

[TestClass]
public class RechnerTests
{
	//View -> Test Explorer
	Rechner r;

	[TestInitialize]
	public void Setup()
	{
		r = new Rechner();
	}

	[TestCleanup]
	public void Cleanup()
	{
		r = null;
	}

	[TestMethod]
	[TestCategory("Addiere")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(4, 8);
		Assert.AreEqual(12, ergebnis); //Assert: Auswertungsklasse, hiermit kann das Ergebnis validiert werden
	}

	[TestMethod]
	[TestCategory("Dividiere")]
	public void TesteDividiere()
	{
		double ergebnis = r.Dividiere(4, 8);
		Assert.AreEqual(0.5, ergebnis); //Assert: Auswertungsklasse, hiermit kann das Ergebnis validiert werden
	}
}