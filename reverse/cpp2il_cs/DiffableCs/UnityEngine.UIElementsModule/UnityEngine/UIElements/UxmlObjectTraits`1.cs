namespace UnityEngine.UIElements;

[Obsolete("UxmlObjectTraits<T> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
internal abstract class UxmlObjectTraits : BaseUxmlTraits
{

	protected UxmlObjectTraits`1() { }

	public override void Init(ref T obj, IUxmlAttributes bag, CreationContext cc) { }

}

