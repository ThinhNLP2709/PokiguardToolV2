namespace Unity.VisualScripting;

public class ReferenceEqualityComparer : IEqualityComparer<T>
{
	public static readonly ReferenceEqualityComparer<T> Instance; //Field offset: 0x0

	private static ReferenceEqualityComparer`1() { }

	private ReferenceEqualityComparer`1() { }

	public static int GetHashCode(T a) { }

	private override bool System.Collections.Generic.IEqualityComparer<T>.Equals(T a, T b) { }

	private override int System.Collections.Generic.IEqualityComparer<T>.GetHashCode(T a) { }

}

