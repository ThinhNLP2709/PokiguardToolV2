/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[Obsolete("Font feature tables and OTL feature tags are obsolete. OpenType layout is now handled natively by Advanced Text Generator (ATG).", false)]
	public class FontFeatureTable // TypeDefIndex: 12643
	{
		// Fields
		[SerializeField]
		internal List<MultipleSubstitutionRecord> m_MultipleSubstitutionRecords; // 0x10
		[SerializeField]
		internal List<LigatureSubstitutionRecord> m_LigatureSubstitutionRecords; // 0x18
		[SerializeField]
		private List<GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords; // 0x20
		[SerializeField]
		internal List<MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecords; // 0x28
		[SerializeField]
		internal List<MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecords; // 0x30
		internal Dictionary<uint, List<LigatureSubstitutionRecord>> m_LigatureSubstitutionRecordLookup; // 0x38
		internal Dictionary<uint, GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookup; // 0x40
		internal Dictionary<uint, MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecordLookup; // 0x48
		internal Dictionary<uint, MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecordLookup; // 0x50
	
		// Properties
		internal List<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal List<MarkToBaseAdjustmentRecord> MarkToBaseAdjustmentRecords { get; } // 0x000000018033D240-0x000000018033D250 
		internal List<MarkToMarkAdjustmentRecord> MarkToMarkAdjustmentRecords { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12644
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<GlyphPairAdjustmentRecord, uint> __9__24_0; // 0x08
			public static Func<GlyphPairAdjustmentRecord, uint> __9__24_1; // 0x10
			public static Func<MarkToBaseAdjustmentRecord, uint> __9__25_0; // 0x18
			public static Func<MarkToBaseAdjustmentRecord, uint> __9__25_1; // 0x20
			public static Func<MarkToMarkAdjustmentRecord, uint> __9__26_0; // 0x28
			public static Func<MarkToMarkAdjustmentRecord, uint> __9__26_1; // 0x30
	
			// Constructors
			static __c(); // 0x0000000182312FD0-0x0000000182313040
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortGlyphPairAdjustmentRecords_b__24_0(GlyphPairAdjustmentRecord s); // 0x0000000182095990-0x00000001820959A0
			internal uint _SortGlyphPairAdjustmentRecords_b__24_1(GlyphPairAdjustmentRecord s); // 0x00000001820959A0-0x00000001820959B0
			internal uint _SortMarkToBaseAdjustmentRecords_b__25_0(MarkToBaseAdjustmentRecord s); // 0x0000000180E6B260-0x0000000180E6B270
			internal uint _SortMarkToBaseAdjustmentRecords_b__25_1(MarkToBaseAdjustmentRecord s); // 0x000000018132C100-0x000000018132C110
			internal uint _SortMarkToMarkAdjustmentRecords_b__26_0(MarkToMarkAdjustmentRecord s); // 0x0000000180E6B260-0x0000000180E6B270
			internal uint _SortMarkToMarkAdjustmentRecords_b__26_1(MarkToMarkAdjustmentRecord s); // 0x000000018132C100-0x000000018132C110
		}
	
		// Constructors
		internal FontFeatureTable(); // 0x00000001823034F0-0x0000000182303760
	
		// Methods
		public void SortGlyphPairAdjustmentRecords(); // 0x0000000182302F50-0x0000000182303130
		public void SortMarkToBaseAdjustmentRecords(); // 0x0000000182303130-0x0000000182303310
		public void SortMarkToMarkAdjustmentRecords(); // 0x0000000182303310-0x00000001823034F0
	}
}
