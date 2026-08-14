namespace System.Xml.Schema;

public class XmlSchemaSimpleType : XmlSchemaType
{
	private XmlSchemaSimpleTypeContent content; //Field offset: 0x98

	[XmlElement("restriction", typeof(XmlSchemaSimpleTypeRestriction))]
	[XmlElement("list", typeof(XmlSchemaSimpleTypeList))]
	[XmlElement("union", typeof(XmlSchemaSimpleTypeUnion))]
	public XmlSchemaSimpleTypeContent Content
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public XmlSchemaSimpleType() { }

	internal virtual XmlSchemaObject Clone() { }

	public XmlSchemaSimpleTypeContent get_Content() { }

	public void set_Content(XmlSchemaSimpleTypeContent value) { }

}

