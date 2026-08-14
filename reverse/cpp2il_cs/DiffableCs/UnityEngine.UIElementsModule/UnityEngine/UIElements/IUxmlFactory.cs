namespace UnityEngine.UIElements;

[Obsolete("IUxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
public interface IUxmlFactory : IBaseUxmlFactory
{

	public VisualElement Create(IUxmlAttributes bag, CreationContext cc) { }

}

