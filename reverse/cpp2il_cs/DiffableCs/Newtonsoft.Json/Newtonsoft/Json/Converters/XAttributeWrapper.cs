namespace Newtonsoft.Json.Converters;

[Nullable(0)]
[NullableContext(2)]
internal class XAttributeWrapper : XObjectWrapper
{

	[Nullable(1)]
	private XAttribute Attribute
	{
		[NullableContext(1)]
		private get { } //Length: 107
	}

	public virtual string LocalName
	{
		 get { } //Length: 122
	}

	public virtual string NamespaceUri
	{
		 get { } //Length: 124
	}

	public virtual IXmlNode ParentNode
	{
		 get { } //Length: 164
	}

	public virtual string Value
	{
		 get { } //Length: 113
		 set { } //Length: 161
	}

	[NullableContext(1)]
	public XAttributeWrapper(XAttribute attribute) { }

	[NullableContext(1)]
	private XAttribute get_Attribute() { }

	public virtual string get_LocalName() { }

	public virtual string get_NamespaceUri() { }

	public virtual IXmlNode get_ParentNode() { }

	public virtual string get_Value() { }

	public virtual void set_Value(string value) { }

}

