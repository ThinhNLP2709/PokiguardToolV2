namespace Unity.VisualScripting;

public interface ISet : ICollection<T>, IEnumerable<T>, IEnumerable
{

	public bool Add(T item) { }

	public void ExceptWith(IEnumerable<T> other) { }

	public void IntersectWith(IEnumerable<T> other) { }

	public bool IsProperSubsetOf(IEnumerable<T> other) { }

	public bool IsProperSupersetOf(IEnumerable<T> other) { }

	public bool IsSubsetOf(IEnumerable<T> other) { }

	public bool IsSupersetOf(IEnumerable<T> other) { }

	public bool Overlaps(IEnumerable<T> other) { }

	public bool SetEquals(IEnumerable<T> other) { }

	public void SymmetricExceptWith(IEnumerable<T> other) { }

	public void UnionWith(IEnumerable<T> other) { }

}

