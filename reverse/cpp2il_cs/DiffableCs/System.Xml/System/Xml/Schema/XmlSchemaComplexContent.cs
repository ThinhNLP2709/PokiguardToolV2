namespace System.Xml.Schema;

public class XmlSchemaComplexContent : XmlSchemaContentModel
{
	private XmlSchemaContent content; //Field offset: 0x50
	private bool isMixed; //Field offset: 0x58
	private bool hasMixedAttribute; //Field offset: 0x59

	[XmlElement("restriction", typeof(XmlSchemaComplexContentRestriction))]
	[XmlElement("extension", typeof(XmlSchemaComplexContentExtension))]
	public virtual XmlSchemaContent Content
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	[XmlIgnore]
	internal bool HasMixedAttribute
	{
		internal get { } //Length: 5
	}

	[XmlAttribute("mixed")]
	public bool IsMixed
	{
		 get { } //Length: 5
		 set { } //Length: 8
	}

	public XmlSchemaComplexContent() { }

	public virtual XmlSchemaContent get_Content() { }

	internal bool get_HasMixedAttribute() { }

	public bool get_IsMixed() { }

	public virtual void set_Content(XmlSchemaContent value) { }

	public void set_IsMixed(bool value) { }

}

