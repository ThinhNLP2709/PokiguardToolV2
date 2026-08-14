namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class UxmlAsset : IUxmlAttributes
{
	public const string NullNodeType = "null"; //Field offset: 0x0
	[SerializeField]
	private string m_FullTypeName; //Field offset: 0x10
	[SerializeField]
	private UxmlNamespaceDefinition m_XmlNamespace; //Field offset: 0x18
	[SerializeField]
	private int m_Id; //Field offset: 0x28
	[SerializeField]
	private int m_OrderInDocument; //Field offset: 0x2C
	[SerializeField]
	private int m_ParentId; //Field offset: 0x30
	[SerializeField]
	private List<UxmlNamespaceDefinition> m_NamespaceDefinitions; //Field offset: 0x38
	[SerializeField]
	protected List<String> m_Properties; //Field offset: 0x40

	public string fullTypeName
	{
		 get { } //Length: 5
	}

	public int id
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public int orderInDocument
	{
		 get { } //Length: 4
	}

	public int parentId
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public UxmlAsset(string fullTypeName, UxmlNamespaceDefinition xmlNamespace = null) { }

	public string get_fullTypeName() { }

	public int get_id() { }

	public int get_orderInDocument() { }

	public int get_parentId() { }

	public void RemoveAttribute(string attributeName) { }

	public void set_id(int value) { }

	public void set_parentId(int value) { }

	public void SetAttribute(string name, string value) { }

	private void SetOrAddProperty(string propertyName, string propertyValue) { }

	public virtual string ToString() { }

	public override bool TryGetAttributeValue(string propertyName, out string value) { }

}

