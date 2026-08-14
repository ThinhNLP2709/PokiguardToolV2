namespace TMPro;

public class TMP_FontFeatureTable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<GlyphPairAdjustmentRecord, UInt32> <>9__25_0; //Field offset: 0x8
		public static Func<GlyphPairAdjustmentRecord, UInt32> <>9__25_1; //Field offset: 0x10
		public static Func<MarkToBaseAdjustmentRecord, UInt32> <>9__26_0; //Field offset: 0x18
		public static Func<MarkToBaseAdjustmentRecord, UInt32> <>9__26_1; //Field offset: 0x20
		public static Func<MarkToMarkAdjustmentRecord, UInt32> <>9__27_0; //Field offset: 0x28
		public static Func<MarkToMarkAdjustmentRecord, UInt32> <>9__27_1; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal uint <SortGlyphPairAdjustmentRecords>b__25_0(GlyphPairAdjustmentRecord s) { }

		internal uint <SortGlyphPairAdjustmentRecords>b__25_1(GlyphPairAdjustmentRecord s) { }

		internal uint <SortMarkToBaseAdjustmentRecords>b__26_0(MarkToBaseAdjustmentRecord s) { }

		internal uint <SortMarkToBaseAdjustmentRecords>b__26_1(MarkToBaseAdjustmentRecord s) { }

		internal uint <SortMarkToMarkAdjustmentRecords>b__27_0(MarkToMarkAdjustmentRecord s) { }

		internal uint <SortMarkToMarkAdjustmentRecords>b__27_1(MarkToMarkAdjustmentRecord s) { }

	}

	[SerializeField]
	internal List<MultipleSubstitutionRecord> m_MultipleSubstitutionRecords; //Field offset: 0x10
	[SerializeField]
	internal List<LigatureSubstitutionRecord> m_LigatureSubstitutionRecords; //Field offset: 0x18
	[SerializeField]
	internal List<GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords; //Field offset: 0x20
	[SerializeField]
	internal List<MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecords; //Field offset: 0x28
	[SerializeField]
	internal List<MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecords; //Field offset: 0x30
	internal Dictionary<UInt32, List`1<LigatureSubstitutionRecord>> m_LigatureSubstitutionRecordLookup; //Field offset: 0x38
	internal Dictionary<UInt32, GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookup; //Field offset: 0x40
	internal Dictionary<UInt32, MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecordLookup; //Field offset: 0x48
	internal Dictionary<UInt32, MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecordLookup; //Field offset: 0x50

	public List<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public List<LigatureSubstitutionRecord> ligatureRecords
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public List<MarkToBaseAdjustmentRecord> MarkToBaseAdjustmentRecords
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public List<MarkToMarkAdjustmentRecord> MarkToMarkAdjustmentRecords
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public List<MultipleSubstitutionRecord> multipleSubstitutionRecords
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public TMP_FontFeatureTable() { }

	public List<GlyphPairAdjustmentRecord> get_glyphPairAdjustmentRecords() { }

	public List<LigatureSubstitutionRecord> get_ligatureRecords() { }

	public List<MarkToBaseAdjustmentRecord> get_MarkToBaseAdjustmentRecords() { }

	public List<MarkToMarkAdjustmentRecord> get_MarkToMarkAdjustmentRecords() { }

	public List<MultipleSubstitutionRecord> get_multipleSubstitutionRecords() { }

	public void set_glyphPairAdjustmentRecords(List<GlyphPairAdjustmentRecord> value) { }

	public void set_ligatureRecords(List<LigatureSubstitutionRecord> value) { }

	public void set_MarkToBaseAdjustmentRecords(List<MarkToBaseAdjustmentRecord> value) { }

	public void set_MarkToMarkAdjustmentRecords(List<MarkToMarkAdjustmentRecord> value) { }

	public void set_multipleSubstitutionRecords(List<MultipleSubstitutionRecord> value) { }

	public void SortGlyphPairAdjustmentRecords() { }

	public void SortMarkToBaseAdjustmentRecords() { }

	public void SortMarkToMarkAdjustmentRecords() { }

}

