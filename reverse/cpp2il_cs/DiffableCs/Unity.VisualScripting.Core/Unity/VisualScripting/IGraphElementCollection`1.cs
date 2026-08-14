namespace Unity.VisualScripting;

public interface IGraphElementCollection : IKeyedCollection<Guid, T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged<T>
{

}

