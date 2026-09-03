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
	internal class MSCompatUnicodeTable // TypeDefIndex: 2109
	{
		// Fields
		public static int MaxExpansionLength; // 0x00
		private static readonly unsafe byte* ignorableFlags; // 0x08
		private static readonly unsafe byte* categories; // 0x10
		private static readonly unsafe byte* level1; // 0x18
		private static readonly unsafe byte* level2; // 0x20
		private static readonly unsafe byte* level3; // 0x28
		private static unsafe byte* cjkCHScategory; // 0x30
		private static unsafe byte* cjkCHTcategory; // 0x38
		private static unsafe byte* cjkJAcategory; // 0x40
		private static unsafe byte* cjkKOcategory; // 0x48
		private static unsafe byte* cjkCHSlv1; // 0x50
		private static unsafe byte* cjkCHTlv1; // 0x58
		private static unsafe byte* cjkJAlv1; // 0x60
		private static unsafe byte* cjkKOlv1; // 0x68
		private static unsafe byte* cjkKOlv2; // 0x70
		private static readonly char[] tailoringArr; // 0x78
		private static readonly TailoringInfo[] tailoringInfos; // 0x80
		private static object forLock; // 0x88
		public static readonly bool isReady; // 0x90
	
		// Properties
		public static bool IsReady { get; } // 0x0000000181432320-0x0000000181432380 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2110
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<Level2Map> __9__17_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018143D950-0x000000018143D9C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _BuildTailoringTables_b__17_0(Level2Map a, Level2Map b); // 0x000000018143D920-0x000000018143D950
		}
	
		// Constructors
		static MSCompatUnicodeTable(); // 0x0000000181431D20-0x0000000181432320
	
		// Methods
		public static TailoringInfo GetTailoringInfo(int lcid); // 0x0000000181431190-0x00000001814312D0
		public static void BuildTailoringTables(CultureInfo culture, TailoringInfo t, ref Contraction[] contractions, ref Level2Map[] diacriticals); // 0x0000000181430390-0x0000000181430A50
		private static unsafe void SetCJKReferences(string name, ref CodePointIndexer cjkIndexer, ref byte* catTable, ref byte* lv1Table, ref CodePointIndexer lv2Indexer, ref byte* lv2Table); // 0x0000000181431870-0x0000000181431B40
		public static byte Category(int cp); // 0x0000000181430A50-0x0000000181430B00
		public static byte Level1(int cp); // 0x0000000181431660-0x0000000181431710
		public static byte Level2(int cp); // 0x0000000181431710-0x00000001814317C0
		public static byte Level3(int cp); // 0x00000001814317C0-0x0000000181431870
		public static bool IsIgnorable(int cp, byte flag); // 0x00000001814313D0-0x00000001814314F0
		public static bool IsIgnorableNonSpacing(int cp); // 0x0000000181431380-0x00000001814313D0
		public static int ToKanaTypeInsensitive(int i); // 0x0000000181431B40-0x0000000181431B60
		public static int ToWidthCompat(int i); // 0x0000000181431B60-0x0000000181431CE0
		public static bool HasSpecialWeight(char c); // 0x00000001814312D0-0x0000000181431340
		public static bool IsHalfWidthKana(char c); // 0x0000000181431340-0x0000000181431360
		public static bool IsHiragana(char c); // 0x0000000181431360-0x0000000181431380
		public static bool IsJapaneseSmallLetter(char c); // 0x00000001814314F0-0x0000000181431660
		private static IntPtr GetResource(string name); // 0x00000001814310D0-0x0000000181431190
		private static unsafe uint UInt32FromBytePtr(byte* raw, uint idx); // 0x0000000181431CE0-0x0000000181431D20
		public static unsafe void FillCJK(string culture, ref CodePointIndexer cjkIndexer, ref byte* catTable, ref byte* lv1Table, ref CodePointIndexer lv2Indexer, ref byte* lv2Table); // 0x0000000181430F50-0x00000001814310D0
		private static unsafe void FillCJKCore(string culture, ref CodePointIndexer cjkIndexer, ref byte* catTable, ref byte* lv1Table, ref CodePointIndexer cjkLv2Indexer, ref byte* lv2Table); // 0x0000000181430B00-0x0000000181430F50
	}
}
