namespace UnityEngine.UIElements;

[Obsolete("UxmlFactory<TCreatedType, TTraits> is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
public class UxmlFactory : BaseUxmlFactory<TCreatedType, TTraits>, IUxmlFactory, IBaseUxmlFactory
{

	public UxmlFactory`2() { }

	public override VisualElement Create(IUxmlAttributes bag, CreationContext cc) { }

}

