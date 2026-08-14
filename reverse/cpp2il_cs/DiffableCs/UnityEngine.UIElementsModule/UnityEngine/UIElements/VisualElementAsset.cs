namespace UnityEngine.UIElements;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
internal class VisualElementAsset : UxmlAsset, ISerializationCallbackReceiver
{
	[SerializeField]
	private string m_Name; //Field offset: 0x48
	[SerializeField]
	private int m_RuleIndex; //Field offset: 0x50
	[SerializeField]
	private string m_Text; //Field offset: 0x58
	[SerializeField]
	private PickingMode m_PickingMode; //Field offset: 0x60
	[SerializeField]
	private String[] m_Classes; //Field offset: 0x68
	[SerializeField]
	private List<String> m_StylesheetPaths; //Field offset: 0x70
	[SerializeField]
	private List<StyleSheet> m_Stylesheets; //Field offset: 0x78
	[SerializeReference]
	internal UxmlSerializedData m_SerializedData; //Field offset: 0x80
	[SerializeField]
	private bool m_SkipClone; //Field offset: 0x88

	public String[] classes
	{
		 get { } //Length: 7
	}

	public bool hasStylesheetPaths
	{
		 get { } //Length: 9
	}

	public bool hasStylesheets
	{
		 get { } //Length: 9
	}

	public int ruleIndex
	{
		 get { } //Length: 6
	}

	public UxmlSerializedData serializedData
	{
		 get { } //Length: 8
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool skipClone
	{
		internal get { } //Length: 8
	}

	public List<String> stylesheetPaths
	{
		 get { } //Length: 123
	}

	public List<StyleSheet> stylesheets
	{
		 get { } //Length: 123
	}

	public String[] get_classes() { }

	public bool get_hasStylesheetPaths() { }

	public bool get_hasStylesheets() { }

	public int get_ruleIndex() { }

	public UxmlSerializedData get_serializedData() { }

	internal bool get_skipClone() { }

	public List<String> get_stylesheetPaths() { }

	public List<StyleSheet> get_stylesheets() { }

	private static bool IdsPathMatchesAttributeOverrideIdsPath(List<Int32> idsPath, List<Int32> attributeOverrideIdsPath, int templateId) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal override VisualElement Instantiate(CreationContext cc) { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

}

