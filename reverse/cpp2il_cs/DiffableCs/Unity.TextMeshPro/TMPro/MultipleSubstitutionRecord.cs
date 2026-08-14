namespace TMPro;

public struct MultipleSubstitutionRecord
{
	[SerializeField]
	private uint m_TargetGlyphID; //Field offset: 0x0
	[SerializeField]
	private UInt32[] m_SubstituteGlyphIDs; //Field offset: 0x8

	public UInt32[] substituteGlyphIDs
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public uint targetGlyphID
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public UInt32[] get_substituteGlyphIDs() { }

	public uint get_targetGlyphID() { }

	public void set_substituteGlyphIDs(UInt32[] value) { }

	public void set_targetGlyphID(uint value) { }

}

