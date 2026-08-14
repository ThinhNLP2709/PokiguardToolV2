namespace UnityEngine.TextCore.LowLevel;

[UsedByNativeCode]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.TextCoreTextEngineModule"})]
internal struct MarkToMarkAdjustmentRecord
{
	[NativeName("baseMarkGlyphID")]
	[SerializeField]
	private uint m_BaseMarkGlyphID; //Field offset: 0x0
	[NativeName("baseMarkAnchor")]
	[SerializeField]
	private GlyphAnchorPoint m_BaseMarkGlyphAnchorPoint; //Field offset: 0x4
	[NativeName("combiningMarkGlyphID")]
	[SerializeField]
	private uint m_CombiningMarkGlyphID; //Field offset: 0xC
	[NativeName("combiningMarkPositionAdjustment")]
	[SerializeField]
	private MarkPositionAdjustment m_CombiningMarkPositionAdjustment; //Field offset: 0x10

	public GlyphAnchorPoint baseMarkGlyphAnchorPoint
	{
		 get { } //Length: 19
		 set { } //Length: 5
	}

	public uint baseMarkGlyphID
	{
		 get { } //Length: 5
		 set { } //Length: 3
	}

	public uint combiningMarkGlyphID
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public MarkPositionAdjustment combiningMarkPositionAdjustment
	{
		 get { } //Length: 19
		 set { } //Length: 5
	}

	public GlyphAnchorPoint get_baseMarkGlyphAnchorPoint() { }

	public uint get_baseMarkGlyphID() { }

	public uint get_combiningMarkGlyphID() { }

	public MarkPositionAdjustment get_combiningMarkPositionAdjustment() { }

	public void set_baseMarkGlyphAnchorPoint(GlyphAnchorPoint value) { }

	public void set_baseMarkGlyphID(uint value) { }

	public void set_combiningMarkGlyphID(uint value) { }

	public void set_combiningMarkPositionAdjustment(MarkPositionAdjustment value) { }

}

