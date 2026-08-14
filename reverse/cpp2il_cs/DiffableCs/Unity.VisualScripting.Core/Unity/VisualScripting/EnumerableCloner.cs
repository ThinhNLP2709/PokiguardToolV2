namespace Unity.VisualScripting;

public sealed class EnumerableCloner : Cloner<IEnumerable>
{
	private readonly Dictionary<Type, IOptimizedInvoker> addMethods; //Field offset: 0x10

	public EnumerableCloner() { }

	public virtual void FillClone(Type type, ref IEnumerable clone, IEnumerable original, CloningContext context) { }

	private IOptimizedInvoker GetAddMethod(Type type) { }

	public virtual bool Handles(Type type) { }

}

