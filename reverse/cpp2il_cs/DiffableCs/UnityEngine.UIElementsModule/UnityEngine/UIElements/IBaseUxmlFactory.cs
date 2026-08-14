namespace UnityEngine.UIElements;

[Obsolete("IUxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", False)]
public interface IBaseUxmlFactory
{

	public string uxmlQualifiedName
	{
		 get { } //Length: 0
	}

	public Type uxmlType
	{
		 get { } //Length: 0
	}

	public bool AcceptsAttributeBag(IUxmlAttributes bag, CreationContext cc) { }

	public string get_uxmlQualifiedName() { }

	public Type get_uxmlType() { }

}

