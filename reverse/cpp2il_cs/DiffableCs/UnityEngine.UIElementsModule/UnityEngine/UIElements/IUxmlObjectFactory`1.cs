namespace UnityEngine.UIElements;

[Obsolete("IUxmlObjectFactory<out T> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
internal interface IUxmlObjectFactory : IBaseUxmlObjectFactory, IBaseUxmlFactory
{

	public T CreateObject(IUxmlAttributes bag, CreationContext cc) { }

}

