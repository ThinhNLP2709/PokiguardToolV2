namespace Unity.VisualScripting;

public sealed class AotDictionary : OrderedDictionary
{

	public AotDictionary() { }

	public AotDictionary(IEqualityComparer comparer) { }

	public AotDictionary(int capacity) { }

	public AotDictionary(int capacity, IEqualityComparer comparer) { }

	[Preserve]
	public static void AotStubs() { }

}

