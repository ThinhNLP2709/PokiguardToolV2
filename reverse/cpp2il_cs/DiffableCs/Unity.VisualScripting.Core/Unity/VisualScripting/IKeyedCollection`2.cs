namespace Unity.VisualScripting;

[DefaultMember("Item")]
public interface IKeyedCollection : ICollection<TItem>, IEnumerable<TItem>, IEnumerable
{

	public TItem Item
	{
		 get { } //Length: 0
	}

	public TItem Item
	{
		 get { } //Length: 0
	}

	public bool Contains(TKey key) { }

	public TItem get_Item(TKey key) { }

	public TItem get_Item(int index) { }

	public bool Remove(TKey key) { }

	public bool TryGetValue(TKey key, out TItem value) { }

}

