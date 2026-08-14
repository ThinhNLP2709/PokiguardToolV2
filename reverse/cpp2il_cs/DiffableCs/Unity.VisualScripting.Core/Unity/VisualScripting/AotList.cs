namespace Unity.VisualScripting;

public sealed class AotList : ArrayList
{

	public AotList() { }

	public AotList(int capacity) { }

	public AotList(ICollection c) { }

	[Preserve]
	public static void AotStubs() { }

}

