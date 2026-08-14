namespace TMPro;

public struct LigatureSubstitutionRecord
{
	[SerializeField]
	private UInt32[] m_ComponentGlyphIDs; //Field offset: 0x0
	[SerializeField]
	private uint m_LigatureGlyphID; //Field offset: 0x8

	public UInt32[] componentGlyphIDs
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public uint ligatureGlyphID
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public UInt32[] get_componentGlyphIDs() { }

	public uint get_ligatureGlyphID() { }

	public static bool op_Equality(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs) { }

	public static bool op_Inequality(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs) { }

	public void set_componentGlyphIDs(UInt32[] value) { }

	public void set_ligatureGlyphID(uint value) { }

}

