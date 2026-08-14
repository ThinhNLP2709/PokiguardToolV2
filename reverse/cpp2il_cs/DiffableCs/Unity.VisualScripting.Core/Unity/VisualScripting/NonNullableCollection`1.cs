namespace Unity.VisualScripting;

public abstract class NonNullableCollection : Collection<T>
{

	protected NonNullableCollection`1() { }

	public void AddRange(IEnumerable<T> collection) { }

	protected virtual void InsertItem(int index, T item) { }

	protected virtual void SetItem(int index, T item) { }

}

