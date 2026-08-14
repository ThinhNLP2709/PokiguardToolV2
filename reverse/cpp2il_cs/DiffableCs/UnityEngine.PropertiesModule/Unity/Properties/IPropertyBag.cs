namespace Unity.Properties;

public interface IPropertyBag
{

	public void Accept(ITypeVisitor visitor) { }

	public void Accept(IPropertyBagVisitor visitor, ref object container) { }

}

