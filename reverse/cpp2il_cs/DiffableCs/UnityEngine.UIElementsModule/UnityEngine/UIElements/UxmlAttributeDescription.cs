namespace UnityEngine.UIElements;

public abstract class UxmlAttributeDescription
{
	internal enum Use
	{
		None = 0,
		Optional = 1,
		Prohibited = 2,
		Required = 3,
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <name>k__BackingField; //Field offset: 0x10
	private String[] m_ObsoleteNames; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <type>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <typeNamespace>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Use <use>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private UxmlTypeRestriction <restriction>k__BackingField; //Field offset: 0x38

	public string name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public IEnumerable<String> obsoleteNames
	{
		 set { } //Length: 120
	}

	public UxmlTypeRestriction restriction
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	protected private string type
	{
		[CompilerGenerated]
		private set { } //Length: 13
	}

	protected string typeNamespace
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public Use use
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	protected UxmlAttributeDescription() { }

	[CompilerGenerated]
	public string get_name() { }

	protected T GetValueFromBag(IUxmlAttributes bag, CreationContext cc, Func<String, T, T> converterFunc, T defaultValue) { }

	[CompilerGenerated]
	public void set_name(string value) { }

	public void set_obsoleteNames(IEnumerable<String> value) { }

	[CompilerGenerated]
	public void set_restriction(UxmlTypeRestriction value) { }

	[CompilerGenerated]
	protected private void set_type(string value) { }

	[CompilerGenerated]
	protected void set_typeNamespace(string value) { }

	[CompilerGenerated]
	public void set_use(Use value) { }

	internal bool TryFindValueInAttributeOverrides(string elementName, CreationContext cc, List<AttributeOverride> attributeOverrides, out string value) { }

	internal bool TryGetAttributeOverrideValueFromBagAsString(IUxmlAttributes bag, CreationContext cc, out string value, out VisualTreeAsset sourceAsset) { }

	protected bool TryGetValueFromBag(IUxmlAttributes bag, CreationContext cc, Func<String, T, T> converterFunc, T defaultValue, ref T value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool TryGetValueFromBagAsString(IUxmlAttributes bag, CreationContext cc, out string value) { }

	internal bool TryGetValueFromBagAsString(IUxmlAttributes bag, CreationContext cc, out string value, out VisualTreeAsset sourceAsset) { }

	internal bool ValidateName() { }

}

