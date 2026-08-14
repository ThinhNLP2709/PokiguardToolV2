namespace Unity.VisualScripting;

public sealed class ListCloner : Cloner<IList>
{

	public ListCloner() { }

	public virtual void FillClone(Type type, ref IList clone, IList original, CloningContext context) { }

	public virtual bool Handles(Type type) { }

}

