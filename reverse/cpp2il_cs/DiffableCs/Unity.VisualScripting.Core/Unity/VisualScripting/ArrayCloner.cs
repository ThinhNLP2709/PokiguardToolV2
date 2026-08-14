namespace Unity.VisualScripting;

public sealed class ArrayCloner : Cloner<Array>
{

	public ArrayCloner() { }

	public virtual Array ConstructClone(Type type, Array original) { }

	public virtual void FillClone(Type type, ref Array clone, Array original, CloningContext context) { }

	public virtual bool Handles(Type type) { }

}

