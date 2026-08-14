namespace UnityEngine.UIElements;

public struct CreationContext : IEquatable<CreationContext>
{
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	public struct AttributeOverrideRange
	{
		internal readonly VisualTreeAsset sourceAsset; //Field offset: 0x0
		internal readonly List<AttributeOverride> attributeOverrides; //Field offset: 0x8

		public AttributeOverrideRange(VisualTreeAsset sourceAsset, List<AttributeOverride> attributeOverrides) { }

	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	public struct SerializedDataOverrideRange
	{
		internal readonly VisualTreeAsset sourceAsset; //Field offset: 0x0
		internal readonly int templateId; //Field offset: 0x8
		internal readonly List<UxmlSerializedDataOverride> attributeOverrides; //Field offset: 0x10

	}

	public static readonly CreationContext Default; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <target>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private List<Int32> <veaIdsPath>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualTreeAsset <visualTreeAsset>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Dictionary<String, VisualElement> <slotInsertionPoints>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private List<AttributeOverrideRange> <attributeOverrides>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private List<SerializedDataOverrideRange> <serializedDataOverrides>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private List<String> <namesPath>k__BackingField; //Field offset: 0x30

	internal List<AttributeOverrideRange> attributeOverrides
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal bool hasOverrides
	{
		internal get { } //Length: 152
	}

	internal List<String> namesPath
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal List<SerializedDataOverrideRange> serializedDataOverrides
	{
		[CompilerGenerated]
		[IsReadOnly]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private Dictionary<String, VisualElement> slotInsertionPoints
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private VisualElement target
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 8
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<Int32> veaIdsPath
	{
		[CompilerGenerated]
		[IsReadOnly]
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private VisualTreeAsset visualTreeAsset
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private static CreationContext() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal CreationContext(Dictionary<String, VisualElement> slotInsertionPoints, List<AttributeOverrideRange> attributeOverrides, List<SerializedDataOverrideRange> serializedDataOverrides, VisualTreeAsset vta, VisualElement target, List<Int32> veaIdsPath, List<String> namesPath) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal CreationContext(Dictionary<String, VisualElement> slotInsertionPoints, List<AttributeOverrideRange> attributeOverrides, VisualTreeAsset vta, VisualElement target) { }

	internal CreationContext(Dictionary<String, VisualElement> slotInsertionPoints, VisualTreeAsset vta, VisualElement target) { }

	internal CreationContext(Dictionary<String, VisualElement> slotInsertionPoints, List<AttributeOverrideRange> attributeOverrides) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal CreationContext(VisualTreeAsset vta) { }

	public override bool Equals(CreationContext other) { }

	public virtual bool Equals(object obj) { }

	[CompilerGenerated]
	[IsReadOnly]
	internal List<AttributeOverrideRange> get_attributeOverrides() { }

	internal bool get_hasOverrides() { }

	[CompilerGenerated]
	[IsReadOnly]
	internal List<String> get_namesPath() { }

	[CompilerGenerated]
	[IsReadOnly]
	internal List<SerializedDataOverrideRange> get_serializedDataOverrides() { }

	[CompilerGenerated]
	[IsReadOnly]
	public Dictionary<String, VisualElement> get_slotInsertionPoints() { }

	[CompilerGenerated]
	[IsReadOnly]
	public VisualElement get_target() { }

	[CompilerGenerated]
	[IsReadOnly]
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal List<Int32> get_veaIdsPath() { }

	[CompilerGenerated]
	[IsReadOnly]
	public VisualTreeAsset get_visualTreeAsset() { }

	public virtual int GetHashCode() { }

	[CompilerGenerated]
	private void set_attributeOverrides(List<AttributeOverrideRange> value) { }

	[CompilerGenerated]
	private void set_namesPath(List<String> value) { }

	[CompilerGenerated]
	private void set_serializedDataOverrides(List<SerializedDataOverrideRange> value) { }

	[CompilerGenerated]
	private void set_slotInsertionPoints(Dictionary<String, VisualElement> value) { }

	[CompilerGenerated]
	private void set_target(VisualElement value) { }

	[CompilerGenerated]
	private void set_veaIdsPath(List<Int32> value) { }

	[CompilerGenerated]
	private void set_visualTreeAsset(VisualTreeAsset value) { }

}

