namespace Unity.VisualScripting;

public class NonNullableHashSet : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private readonly HashSet<T> set; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 46
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public NonNullableHashSet`1() { }

	public NonNullableHashSet`1(IEqualityComparer<T> comparer) { }

	public NonNullableHashSet`1(IEnumerable<T> collection) { }

	public NonNullableHashSet`1(IEnumerable<T> collection, IEqualityComparer<T> comparer) { }

	public override bool Add(T item) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public override void ExceptWith(IEnumerable<T> other) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override IEnumerator<T> GetEnumerator() { }

	public override void IntersectWith(IEnumerable<T> other) { }

	public override bool IsProperSubsetOf(IEnumerable<T> other) { }

	public override bool IsProperSupersetOf(IEnumerable<T> other) { }

	public override bool IsSubsetOf(IEnumerable<T> other) { }

	public override bool IsSupersetOf(IEnumerable<T> other) { }

	public override bool Overlaps(IEnumerable<T> other) { }

	public override bool Remove(T item) { }

	public override bool SetEquals(IEnumerable<T> other) { }

	public override void SymmetricExceptWith(IEnumerable<T> other) { }

	private override void System.Collections.Generic.ICollection<T>.Add(T item) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override void UnionWith(IEnumerable<T> other) { }

}

