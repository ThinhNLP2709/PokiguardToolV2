namespace TMPro;

public struct MarkToBaseAdjustmentRecord
{
	[SerializeField]
	private uint m_BaseGlyphID; //Field offset: 0x0
	[SerializeField]
	private GlyphAnchorPoint m_BaseGlyphAnchorPoint; //Field offset: 0x4
	[SerializeField]
	private uint m_MarkGlyphID; //Field offset: 0xC
	[SerializeField]
	private MarkPositionAdjustment m_MarkPositionAdjustment; //Field offset: 0x10

	public GlyphAnchorPoint baseGlyphAnchorPoint
	{
		 get { } //Length: 19
		 set { } //Length: 5
	}

	public uint baseGlyphID
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public uint markGlyphID
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public MarkPositionAdjustment markPositionAdjustment
	{
		 get { } //Length: 19
		 set { } //Length: 5
	}

	public GlyphAnchorPoint get_baseGlyphAnchorPoint() { }

	public uint get_baseGlyphID() { }

	public uint get_markGlyphID() { }

	public MarkPositionAdjustment get_markPositionAdjustment() { }

	public void set_baseGlyphAnchorPoint(GlyphAnchorPoint value) { }

	public void set_baseGlyphID(uint value) { }

	public void set_markGlyphID(uint value) { }

	public void set_markPositionAdjustment(MarkPositionAdjustment value) { }

}

