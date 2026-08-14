namespace UnityEngine.UIElements;

internal class UITKTextHandle : TextHandle
{
	internal static readonly float k_MinPadding; //Field offset: 0x0
	private ATGTextEventHandler m_ATGTextEventHandler; //Field offset: 0xA8
	private List<ValueTuple`3<Int32, TagType, String>> m_Links; //Field offset: 0xB0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Vector2 <MeasuredSizes>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Vector2 <RoundedSizes>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Vector2 <ATGMeasuredSizes>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Vector2 <ATGRoundedSizes>k__BackingField; //Field offset: 0xD0
	internal TextEventHandler m_TextEventHandler; //Field offset: 0xD8
	protected TextElement m_TextElement; //Field offset: 0xE0
	private bool wasAdvancedTextEnabledForElement; //Field offset: 0xE8

	public Vector2 ATGMeasuredSizes
	{
		[CompilerGenerated]
		 get { } //Length: 25
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public Vector2 ATGRoundedSizes
	{
		[CompilerGenerated]
		 get { } //Length: 25
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public virtual bool IsPlaceholder
	{
		 get { } //Length: 62
	}

	private List<ValueTuple`3<Int32, TagType, String>> Links
	{
		private get { } //Length: 132
	}

	public Vector2 MeasuredSizes
	{
		[CompilerGenerated]
		 get { } //Length: 25
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public Vector2 RoundedSizes
	{
		[CompilerGenerated]
		 get { } //Length: 25
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private static UITKTextHandle() { }

	public UITKTextHandle(TextElement te) { }

	public virtual void AddTextInfoToPermanentCache() { }

	internal ValueTuple<TagType, String> ATGFindIntersectingLink(Vector2 point) { }

	public void ComputeNativeTextSize(in RenderedText textToMeasure, float width, float height) { }

	public void ComputeSettingsAndUpdate() { }

	public Vector2 ComputeTextSize(in RenderedText textToMeasure, float width, float height) { }

	internal bool ConvertUssToNativeTextGenerationSettings() { }

	internal override bool ConvertUssToTextGenerationSettings() { }

	[CompilerGenerated]
	public Vector2 get_ATGMeasuredSizes() { }

	[CompilerGenerated]
	public Vector2 get_ATGRoundedSizes() { }

	public virtual bool get_IsPlaceholder() { }

	private List<ValueTuple`3<Int32, TagType, String>> get_Links() { }

	[CompilerGenerated]
	public Vector2 get_MeasuredSizes() { }

	[CompilerGenerated]
	public Vector2 get_RoundedSizes() { }

	private TextOverflowMode GetTextOverflowMode() { }

	internal float GetVertexPadding(FontAsset fontAsset) { }

	public void HandleATag() { }

	public void HandleLinkAndATagCallbacks() { }

	public void HandleLinkTag() { }

	private ValueTuple<Boolean, Boolean> hasLinkAndHyperlink() { }

	internal virtual bool IsAdvancedTextEnabledForElement() { }

	[CompilerGenerated]
	public void set_ATGMeasuredSizes(Vector2 value) { }

	[CompilerGenerated]
	public void set_ATGRoundedSizes(Vector2 value) { }

	[CompilerGenerated]
	public void set_MeasuredSizes(Vector2 value) { }

	[CompilerGenerated]
	public void set_RoundedSizes(Vector2 value) { }

	internal bool TextLibraryCanElide() { }

	private void UpdateATGTextEventHandler(NativeTextGenerationSettings setting) { }

	public void UpdateMesh() { }

	public NativeTextInfo UpdateNative(ref bool success) { }

}

