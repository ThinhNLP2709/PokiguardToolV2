namespace Unity.VisualScripting;

public class GuidCollection : KeyedCollection<Guid, T>, IKeyedCollection<Guid, T>, ICollection<T>, IEnumerable<T>, IEnumerable
{

	public GuidCollection`1() { }

	protected virtual Guid GetKeyForItem(T item) { }

	protected virtual void InsertItem(int index, T item) { }

	protected virtual void SetItem(int index, T item) { }

	public override bool TryGetValue(Guid key, out T value) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.Guid,T>.Contains(Guid key) { }

	private override T Unity.VisualScripting.IKeyedCollection<System.Guid,T>.get_Item(Guid key) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.Guid,T>.Remove(Guid key) { }

}

