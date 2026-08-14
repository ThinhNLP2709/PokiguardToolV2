namespace Unity.VisualScripting;

public class ReferenceEqualityComparer : IEqualityComparer<Object>
{
	public static readonly ReferenceEqualityComparer Instance; //Field offset: 0x0

	private static ReferenceEqualityComparer() { }

	private ReferenceEqualityComparer() { }

	public static int GetHashCode(object a) { }

	private override bool System.Collections.Generic.IEqualityComparer<System.Object>.Equals(object a, object b) { }

	private override int System.Collections.Generic.IEqualityComparer<System.Object>.GetHashCode(object a) { }

}

