/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Globalization.Unicode
{
	internal class SimpleCollator : ISimpleCollator // TypeDefIndex: 2113
	{
		// Fields
		private static SimpleCollator invariant; // 0x00
		private readonly TextInfo textInfo; // 0x10
		private readonly CodePointIndexer cjkIndexer; // 0x18
		private readonly Contraction[] contractions; // 0x20
		private readonly Level2Map[] level2Maps; // 0x28
		private readonly byte[] unsafeFlags; // 0x30
		private readonly unsafe byte* cjkCatTable; // 0x38
		private readonly unsafe byte* cjkLv1Table; // 0x40
		private readonly unsafe byte* cjkLv2Table; // 0x48
		private readonly CodePointIndexer cjkLv2Indexer; // 0x50
		private readonly int lcid; // 0x58
		private readonly bool frenchSort; // 0x5C
	
		// Nested types
		internal struct Context // TypeDefIndex: 2114
		{
			// Fields
			public readonly CompareOptions Option; // 0x00
			public readonly unsafe byte* NeverMatchFlags; // 0x08
			public readonly unsafe byte* AlwaysMatchFlags; // 0x10
			public unsafe byte* Buffer1; // 0x18
			public unsafe byte* Buffer2; // 0x20
			public int PrevCode; // 0x28
			public unsafe byte* PrevSortKey; // 0x30
	
			// Constructors
			public unsafe Context(CompareOptions opt, byte* alwaysMatchFlags, byte* neverMatchFlags, byte* buffer1, byte* buffer2, byte* prev1); // 0x000000018142E110-0x000000018142E140
		}
	
		private struct PreviousInfo // TypeDefIndex: 2115
		{
			// Fields
			public int Code; // 0x00
			public unsafe byte* SortKey; // 0x08
	
			// Constructors
			public unsafe PreviousInfo(bool dummy); // 0x0000000181432E70-0x0000000181432E80
		}
	
		private struct Escape // TypeDefIndex: 2116
		{
			// Fields
			public string Source; // 0x00
			public int Index; // 0x08
			public int Start; // 0x0C
			public int End; // 0x10
			public int Optional; // 0x14
		}
	
		private enum ExtenderType // TypeDefIndex: 2117
		{
			None = 0,
			Simple = 1,
			Voiced = 2,
			Conditional = 3,
			Buggy = 4
		}
	
		// Constructors
		public SimpleCollator(CultureInfo culture); // 0x0000000181439AE0-0x0000000181439F80
		static SimpleCollator(); // 0x0000000181439A40-0x0000000181439AE0
	
		// Methods
		private unsafe void SetCJKTable(CultureInfo culture, ref CodePointIndexer cjkIndexer, ref byte* catTable, ref byte* lv1Table, ref CodePointIndexer lv2Indexer, ref byte* lv2Table); // 0x00000001814398B0-0x0000000181439A10
		private static CultureInfo GetNeutralCulture(CultureInfo info); // 0x0000000181436410-0x00000001814364B0
		private byte Category(int cp); // 0x0000000181434180-0x0000000181434220
		private byte Level1(int cp); // 0x00000001814385D0-0x0000000181438670
		private byte Level2(int cp, ExtenderType ext); // 0x0000000181438670-0x0000000181438800
		private static bool IsHalfKana(int cp, CompareOptions opt); // 0x0000000181437760-0x00000001814377E0
		private Contraction GetContraction(string s, int start, int end); // 0x0000000181436270-0x0000000181436350
		private Contraction GetContraction(string s, int start, int end, Contraction[] clist); // 0x0000000181436130-0x0000000181436270
		private Contraction GetTailContraction(string s, int start, int end); // 0x0000000181436CA0-0x0000000181436D80
		private Contraction GetTailContraction(string s, int start, int end, Contraction[] clist); // 0x0000000181436AA0-0x0000000181436CA0
		private int FilterOptions(int i, CompareOptions opt); // 0x0000000181435E70-0x0000000181436130
		private ExtenderType GetExtenderType(int i); // 0x0000000181436350-0x0000000181436410
		private static byte ToDashTypeValue(ExtenderType ext, CompareOptions opt); // 0x0000000181439A20-0x0000000181439A40
		private int FilterExtender(int i, ExtenderType ext, CompareOptions opt); // 0x0000000181435C70-0x0000000181435E70
		private static bool IsIgnorable(int i, CompareOptions opt); // 0x00000001814377E0-0x0000000181437870
		private bool IsSafe(int i); // 0x0000000181437A30-0x0000000181437AA0
		public SortKey GetSortKey(string s, CompareOptions options); // 0x00000001814369B0-0x0000000181436AA0
		public SortKey GetSortKey(string s, int start, int length, CompareOptions options); // 0x00000001814364B0-0x00000001814365B0
		private void GetSortKey(string s, int start, int end, SortKeyBuffer buf, CompareOptions opt); // 0x00000001814365B0-0x00000001814369B0
		private void FillSortKeyRaw(int i, ExtenderType ext, SortKeyBuffer buf, CompareOptions opt); // 0x0000000181435680-0x0000000181435BA0
		private void FillSurrogateSortKeyRaw(int i, SortKeyBuffer buf); // 0x0000000181435BA0-0x0000000181435C70
		int ISimpleCollator.Compare(string s1, int idx1, int len1, string s2, int idx2, int len2, CompareOptions options); // 0x0000000181439A10-0x0000000181439A20
		internal int Compare(string s1, int idx1, int len1, string s2, int idx2, int len2, CompareOptions options); // 0x0000000181435580-0x0000000181435680
		private unsafe void ClearBuffer(byte* buffer, int size); // 0x0000000181434220-0x0000000181434240
		private int CompareInternal(string s1, int idx1, int len1, string s2, int idx2, int len2, out bool targetConsumed, out bool sourceConsumed, bool skipHeadingExtenders, bool immediateBreakup, ref Context ctx); // 0x0000000181434260-0x0000000181435580
		private int CompareFlagPair(bool b1, bool b2); // 0x0000000181434240-0x0000000181434260
		public bool IsPrefix(string src, string target, CompareOptions opt); // 0x00000001814378F0-0x0000000181437930
		public bool IsPrefix(string s, string target, int start, int length, CompareOptions opt); // 0x0000000181437930-0x0000000181437A30
		private bool IsPrefix(string s, string target, int start, int length, bool skipHeadingExtenders, ref Context ctx); // 0x0000000181437870-0x00000001814378F0
		public bool IsSuffix(string src, string target, CompareOptions opt); // 0x0000000181437B60-0x0000000181437C20
		public bool IsSuffix(string s, string target, int start, int length, CompareOptions opt); // 0x0000000181437AA0-0x0000000181437B60
		private int QuickIndexOf(string s, string target, int start, int length, out bool testWasUnable); // 0x0000000181439770-0x00000001814398B0
		public int IndexOf(string s, string target, int start, int length, CompareOptions opt); // 0x0000000181437490-0x0000000181437760
		private int IndexOfOrdinal(string s, string target, int start, int length); // 0x0000000181436D80-0x0000000181436E40
		private int IndexOfOrdinal(string s, char target, int start, int length); // 0x0000000181436E40-0x0000000181436EC0
		private unsafe int IndexOfSortKey(string s, int start, int length, byte* sortkey, char target, int ti, bool noLv4, ref Context ctx); // 0x0000000181436EC0-0x0000000181436F80
		private unsafe int IndexOf(string s, string target, int start, int length, byte* targetSortKey, ref Context ctx); // 0x0000000181436F80-0x0000000181437490
		public int LastIndexOf(string s, string target, int start, int length, CompareOptions opt); // 0x0000000181438420-0x00000001814385D0
		private int LastIndexOfOrdinal(string s, string target, int start, int length); // 0x0000000181437C20-0x0000000181437D70
		private unsafe int LastIndexOfSortKey(string s, int start, int orgStart, int length, byte* sortkey, int ti, bool noLv4, ref Context ctx); // 0x0000000181437D70-0x0000000181437E40
		private unsafe int LastIndexOf(string s, string target, int start, int length, byte* targetSortKey, ref Context ctx); // 0x0000000181437E40-0x0000000181438420
		private unsafe bool MatchesForward(string s, ref int idx, int end, int ti, byte* sortkey, bool noLv4, ref Context ctx); // 0x00000001814393D0-0x00000001814395C0
		private unsafe bool MatchesForwardCore(string s, ref int idx, int end, int ti, byte* sortkey, bool noLv4, ExtenderType ext, ref Contraction ct, ref Context ctx); // 0x0000000181438FF0-0x00000001814393D0
		private unsafe bool MatchesPrimitive(CompareOptions opt, byte* source, int si, ExtenderType ext, byte* target, int ti, bool noLv4); // 0x00000001814395C0-0x0000000181439770
		private unsafe bool MatchesBackward(string s, ref int idx, int end, int orgStart, int ti, byte* sortkey, bool noLv4, ref Context ctx); // 0x0000000181438E00-0x0000000181438FF0
		private unsafe bool MatchesBackwardCore(string s, ref int idx, int end, int orgStart, int ti, byte* sortkey, bool noLv4, ExtenderType ext, ref Contraction ct, ref Context ctx); // 0x0000000181438800-0x0000000181438E00
	}
}
