namespace Unity.VisualScripting.FullSerializer.Internal;

public class fsCyclicReferenceManager
{
	private class ObjectReferenceEqualityComparator : IEqualityComparer<Object>
	{
		public static readonly IEqualityComparer<Object> Instance; //Field offset: 0x0

		private static ObjectReferenceEqualityComparator() { }

		public ObjectReferenceEqualityComparator() { }

		private override bool System.Collections.Generic.IEqualityComparer<System.Object>.Equals(object x, object y) { }

		private override int System.Collections.Generic.IEqualityComparer<System.Object>.GetHashCode(object obj) { }

	}

	private Dictionary<Object, Int32> _objectIds; //Field offset: 0x10
	private int _nextId; //Field offset: 0x18
	private Dictionary<Int32, Object> _marked; //Field offset: 0x20
	private int _depth; //Field offset: 0x28

	public fsCyclicReferenceManager() { }

	public void AddReferenceWithId(int id, object reference) { }

	public void Enter() { }

	public bool Exit() { }

	public int GetReferenceId(object item) { }

	public object GetReferenceObject(int id) { }

	public bool IsReference(object item) { }

	public void MarkSerialized(object item) { }

}

