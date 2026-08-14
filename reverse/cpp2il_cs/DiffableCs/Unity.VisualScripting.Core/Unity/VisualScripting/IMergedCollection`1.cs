namespace Unity.VisualScripting;

public interface IMergedCollection : ICollection<T>, IEnumerable<T>, IEnumerable
{

	public bool Includes() { }

	public bool Includes(Type elementType) { }

}

