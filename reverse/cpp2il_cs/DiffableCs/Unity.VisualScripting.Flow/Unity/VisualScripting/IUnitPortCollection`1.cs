namespace Unity.VisualScripting;

public interface IUnitPortCollection : IKeyedCollection<String, TPort>, ICollection<TPort>, IEnumerable<TPort>, IEnumerable
{

	public TPort Single() { }

}

