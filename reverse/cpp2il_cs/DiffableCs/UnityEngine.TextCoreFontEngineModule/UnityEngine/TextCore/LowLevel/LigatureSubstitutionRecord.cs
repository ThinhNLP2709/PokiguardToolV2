namespace UnityEngine.TextCore.LowLevel;

[UsedByNativeCode]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.TextCoreTextEngineModule", "UnityEditor.TextCoreTextEngineModule"})]
internal struct LigatureSubstitutionRecord : IEquatable<LigatureSubstitutionRecord>
{
	[NativeName("componentGlyphs")]
	[SerializeField]
	private UInt32[] m_ComponentGlyphIDs; //Field offset: 0x0
	[NativeName("ligatureGlyph")]
	[SerializeField]
	private uint m_LigatureGlyphID; //Field offset: 0x8

	public UInt32[] componentGlyphIDs
	{
		 get { } //Length: 6
		 set { } //Length: 8
	}

	public uint ligatureGlyphID
	{
		 get { } //Length: 6
		 set { } //Length: 4
	}

	public override bool Equals(LigatureSubstitutionRecord other) { }

	public virtual bool Equals(object obj) { }

	public UInt32[] get_componentGlyphIDs() { }

	public uint get_ligatureGlyphID() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(LigatureSubstitutionRecord lhs, LigatureSubstitutionRecord rhs) { }

	public void set_componentGlyphIDs(UInt32[] value) { }

	public void set_ligatureGlyphID(uint value) { }

}

