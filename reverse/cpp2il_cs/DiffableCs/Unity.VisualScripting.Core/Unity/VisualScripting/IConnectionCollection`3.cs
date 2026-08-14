namespace Unity.VisualScripting;

[DefaultMember("Item")]
public interface IConnectionCollection : ICollection<TConnection>, IEnumerable<TConnection>, IEnumerable
{

	public IEnumerable<TConnection> Item
	{
		 get { } //Length: 0
	}

	public IEnumerable<TConnection> Item
	{
		 get { } //Length: 0
	}

	public IEnumerable<TConnection> get_Item(TSource source) { }

	public IEnumerable<TConnection> get_Item(TDestination destination) { }

	public IEnumerable<TConnection> WithDestination(TDestination destination) { }

	public IEnumerable<TConnection> WithSource(TSource source) { }

}

