/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public class KerningTable // TypeDefIndex: 11823
	{
		// Fields
		public List<KerningPair> kerningPairs; // 0x10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 11824
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<KerningPair, uint> __9__7_0; // 0x08
			public static Func<KerningPair, uint> __9__7_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182095B20-0x0000000182095C60
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal uint _SortKerningPairs_b__7_0(KerningPair s); // 0x000000018030F200-0x000000018030F220
			internal uint _SortKerningPairs_b__7_1(KerningPair s); // 0x00000001820959B0-0x00000001820959D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass3_0 // TypeDefIndex: 11825
		{
			// Fields
			public uint first; // 0x10
			public uint second; // 0x14
	
			// Constructors
			public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddKerningPair_b__0(KerningPair item); // 0x00000001820959D0-0x0000000182095A00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 11826
		{
			// Fields
			public uint first; // 0x10
			public uint second; // 0x14
	
			// Constructors
			public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _AddGlyphPairAdjustmentRecord_b__0(KerningPair item); // 0x00000001820959D0-0x0000000182095A00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass5_0 // TypeDefIndex: 11827
		{
			// Fields
			public int left; // 0x10
			public int right; // 0x14
	
			// Constructors
			public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveKerningPair_b__0(KerningPair item); // 0x0000000182095A00-0x0000000182095A40
		}
	
		// Constructors
		public KerningTable(); // 0x0000000182082F70-0x0000000182082FF0
	
		// Methods
		public void AddKerningPair(); // 0x0000000182082AC0-0x0000000182082C80
		public int AddKerningPair(uint first, uint second, float offset); // 0x0000000182082920-0x0000000182082AC0
		public int AddGlyphPairAdjustmentRecord(uint first, GlyphValueRecord_Legacy firstAdjustments, uint second, GlyphValueRecord_Legacy secondAdjustments); // 0x0000000182082770-0x0000000182082920
		public void RemoveKerningPair(int left, int right); // 0x0000000182082C80-0x0000000182082D70
		public void RemoveKerningPair(int index); // 0x0000000182082D70-0x0000000182082D90
		public void SortKerningPairs(); // 0x0000000182082D90-0x0000000182082F70
	}
}
