namespace UnityEngine.UIElements;

[Obsolete("UxmlObjectFactory<TCreatedType, TTraits> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
internal class UxmlObjectFactory : BaseUxmlFactory<TCreatedType, TTraits>, IUxmlObjectFactory<TCreatedType>, IBaseUxmlObjectFactory, IBaseUxmlFactory
{

	public UxmlObjectFactory`2() { }

	public override TCreatedType CreateObject(IUxmlAttributes bag, CreationContext cc) { }

}

