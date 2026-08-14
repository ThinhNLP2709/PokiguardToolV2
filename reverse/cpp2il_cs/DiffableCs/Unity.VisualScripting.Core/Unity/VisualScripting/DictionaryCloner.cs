namespace Unity.VisualScripting;

public sealed class DictionaryCloner : Cloner<IDictionary>
{

	public DictionaryCloner() { }

	public virtual void FillClone(Type type, ref IDictionary clone, IDictionary original, CloningContext context) { }

	public virtual bool Handles(Type type) { }

}

