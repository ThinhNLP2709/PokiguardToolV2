namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Bindings/AccessibilityNodeData.bindings.h")]
[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
[NativeType(CodegenOptions::Custom (1), "MonoAccessibilityNodeData")]
[RequiredByNativeCode]
internal struct AccessibilityNodeData
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <id>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <isActive>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <label>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <value>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <hint>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AccessibilityRole <role>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <allowsDirectInteraction>k__BackingField; //Field offset: 0x22
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private AccessibilityState <state>k__BackingField; //Field offset: 0x24
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Rect <frame>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <parentId>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Int32[] <childIds>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly bool <isFocused>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private SystemLanguage <language>k__BackingField; //Field offset: 0x4C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <implementsSelected>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <implementsDismissed>k__BackingField; //Field offset: 0x51

	public bool allowsDirectInteraction
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public Int32[] childIds
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public Rect frame
	{
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public string hint
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public int id
	{
		[CompilerGenerated]
		 set { } //Length: 3
	}

	public bool implementsDismissed
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool implementsSelected
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool isActive
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public string label
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	internal SystemLanguage language
	{
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public int parentId
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public AccessibilityRole role
	{
		[CompilerGenerated]
		 set { } //Length: 5
	}

	public AccessibilityState state
	{
		[CompilerGenerated]
		 set { } //Length: 5
	}

	public string value
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[CompilerGenerated]
	public void set_allowsDirectInteraction(bool value) { }

	[CompilerGenerated]
	public void set_childIds(Int32[] value) { }

	[CompilerGenerated]
	public void set_frame(Rect value) { }

	[CompilerGenerated]
	public void set_hint(string value) { }

	[CompilerGenerated]
	public void set_id(int value) { }

	[CompilerGenerated]
	public void set_implementsDismissed(bool value) { }

	[CompilerGenerated]
	public void set_implementsSelected(bool value) { }

	[CompilerGenerated]
	public void set_isActive(bool value) { }

	[CompilerGenerated]
	public void set_label(string value) { }

	[CompilerGenerated]
	internal void set_language(SystemLanguage value) { }

	[CompilerGenerated]
	public void set_parentId(int value) { }

	[CompilerGenerated]
	public void set_role(AccessibilityRole value) { }

	[CompilerGenerated]
	public void set_state(AccessibilityState value) { }

	[CompilerGenerated]
	public void set_value(string value) { }

}

