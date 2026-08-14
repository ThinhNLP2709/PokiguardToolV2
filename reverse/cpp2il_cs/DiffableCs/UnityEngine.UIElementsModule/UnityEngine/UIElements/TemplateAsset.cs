namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class TemplateAsset : VisualElementAsset
{
	internal struct AttributeOverride
	{
		public string m_ElementName; //Field offset: 0x0
		public String[] m_NamesPath; //Field offset: 0x8
		public string m_AttributeName; //Field offset: 0x10
		public string m_Value; //Field offset: 0x18

		public bool NamesPathMatchesElementNamesPath(IList<String> elementNamesPath) { }

	}

	internal struct UxmlSerializedDataOverride
	{
		public int m_ElementId; //Field offset: 0x0
		public List<Int32> m_ElementIdsPath; //Field offset: 0x8
		[SerializeReference]
		public UxmlSerializedData m_SerializedData; //Field offset: 0x10

	}

	[SerializeField]
	private string m_TemplateAlias; //Field offset: 0x90
	[SerializeField]
	private List<AttributeOverride> m_AttributeOverrides; //Field offset: 0x98
	[SerializeField]
	private List<UxmlSerializedDataOverride> m_SerializedDataOverride; //Field offset: 0xA0
	[SerializeField]
	private List<SlotUsageEntry> m_SlotUsages; //Field offset: 0xA8

	public List<AttributeOverride> attributeOverrides
	{
		 get { } //Length: 8
	}

	internal List<SlotUsageEntry> slotUsages
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 10
	}

	public List<AttributeOverride> get_attributeOverrides() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<SlotUsageEntry> get_slotUsages() { }

}

