namespace UnityEngine.UIElements;

[Obsolete("UxmlStyleFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
public class UxmlStyleFactory : UxmlFactory<VisualElement, UxmlStyleTraits>
{

	public virtual string uxmlName
	{
		 get { } //Length: 44
	}

	public virtual string uxmlQualifiedName
	{
		 get { } //Length: 120
	}

	public UxmlStyleFactory() { }

	public virtual VisualElement Create(IUxmlAttributes bag, CreationContext cc) { }

	public virtual string get_uxmlName() { }

	public virtual string get_uxmlQualifiedName() { }

}

