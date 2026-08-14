namespace Unity.Properties.Internal;

internal interface IAttributes
{

	public List<Attribute> Attributes
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public void AddAttribute(Attribute attribute) { }

	public void AddAttributes(IEnumerable<Attribute> attributes) { }

	public AttributesScope CreateAttributesScope(IAttributes attributes) { }

	public List<Attribute> get_Attributes() { }

	public void set_Attributes(List<Attribute> value) { }

}

