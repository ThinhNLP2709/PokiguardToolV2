/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public class TMP_FontFeatureTable // TypeDefIndex: 11830
	{
		// Fields
		[SerializeField]
		internal List<MultipleSubstitutionRecord> m_MultipleSubstitutionRecords; // 0x10
		[SerializeField]
		internal List<LigatureSubstitutionRecord> m_LigatureSubstitutionRecords; // 0x18
		[SerializeField]
		internal List<GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords; // 0x20
		[SerializeField]
		internal List<MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecords; // 0x28
		[SerializeField]
		internal List<MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecords; // 0x30
		internal Dictionary<uint, List<LigatureSubstitutionRecord>> m_LigatureSubstitutionRecordLookup; // 0x38
		internal Dictionary<uint, GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookup; // 0x40
		internal Dictionary<uint, MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecordLookup; // 0x48
		internal Dictionary<uint, MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecordLookup; // 0x50
	
		// Properties
		public List<MultipleSubstitutionRecord> multipleSubstitutionRecords { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public List<LigatureSubstitutionRecord> ligatureRecords { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public List<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public List<MarkToBaseAdjustmentRecord> MarkToBaseAdjustmentRecords { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public List<MarkToMarkAdjustmentRecord> MarkToMarkAdjustmentRecords { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11831
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<GlyphPairAdjustmentRecord, uint> __9__25_0; // 0x08
			public static Func<GlyphPairAdjustmentRecord, uint> __9__25_1; // 0x10
			public static Func<MarkToBaseAdjustmentRecord, uint> __9__26_0; // 0x18
			public static Func<MarkToBaseAdjustmentRecord, uint> __9__26_1; // 0x20
			public static Func<MarkToMarkAdjustmentRecord, uint> __9__27_0; // 0x28
			public static Func<MarkToMarkAdjustmentRecord, uint> __9__27_1; // 0x30
	
			// Constructors
			static __c(); // 0x0000000182095AB0-0x0000000182095B20
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortGlyphPairAdjustmentRecords_b__25_0(GlyphPairAdjustmentRecord s); // 0x0000000182095990-0x00000001820959A0
			internal uint _SortGlyphPairAdjustmentRecords_b__25_1(GlyphPairAdjustmentRecord s); // 0x00000001820959A0-0x00000001820959B0
			internal uint _SortMarkToBaseAdjustmentRecords_b__26_0(MarkToBaseAdjustmentRecord s); // 0x0000000180E6B260-0x0000000180E6B270
			internal uint _SortMarkToBaseAdjustmentRecords_b__26_1(MarkToBaseAdjustmentRecord s); // 0x000000018132C100-0x000000018132C110
			internal uint _SortMarkToMarkAdjustmentRecords_b__27_0(MarkToMarkAdjustmentRecord s); // 0x0000000180E6B260-0x0000000180E6B270
			internal uint _SortMarkToMarkAdjustmentRecords_b__27_1(MarkToMarkAdjustmentRecord s); // 0x000000018132C100-0x000000018132C110
		}
	
		// Constructors
		public TMP_FontFeatureTable(); // 0x0000000182084620-0x0000000182084890
	
		// Methods
		public void SortGlyphPairAdjustmentRecords(); // 0x0000000182084080-0x0000000182084260
		public void SortMarkToBaseAdjustmentRecords(); // 0x0000000182084260-0x0000000182084440
		public void SortMarkToMarkAdjustmentRecords(); // 0x0000000182084440-0x0000000182084620
	}
}
