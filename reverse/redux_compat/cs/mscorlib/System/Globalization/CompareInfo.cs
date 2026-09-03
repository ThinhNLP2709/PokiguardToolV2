/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	public class CompareInfo : IDeserializationCallback // TypeDefIndex: 3390
	{
		// Fields
		private const CompareOptions ValidIndexMaskOffFlags = CompareOptions.None | CompareOptions.OrdinalIgnoreCase | CompareOptions.StringSort | CompareOptions.Ordinal; // Metadata: 0x0064EDEF
		private const CompareOptions ValidCompareMaskOffFlags = CompareOptions.None | CompareOptions.OrdinalIgnoreCase | CompareOptions.Ordinal; // Metadata: 0x0064EDF0
		private const CompareOptions ValidHashCodeOfStringMaskOffFlags = CompareOptions.None | CompareOptions.OrdinalIgnoreCase | CompareOptions.StringSort | CompareOptions.Ordinal; // Metadata: 0x0064EDF5
		private const CompareOptions ValidSortkeyCtorMaskOffFlags = CompareOptions.None | CompareOptions.OrdinalIgnoreCase | CompareOptions.Ordinal; // Metadata: 0x0064EDF6
		internal static readonly CompareInfo Invariant; // 0x00
		[OptionalField(VersionAdded = 2)]
		private string m_name; // 0x10
		[NonSerialized]
		private string _sortName; // 0x18
		[OptionalField(VersionAdded = 3)]
		private SortVersion m_SortVersion; // 0x20
		private int culture; // 0x28
		[NonSerialized]
		private ISimpleCollator collator; // 0x30
		private static Dictionary<string, ISimpleCollator> collators; // 0x08
		private static bool managedCollation; // 0x10
		private static bool managedCollationChecked; // 0x11
	
		// Properties
		public virtual string Name { get; } // 0x0000000181547570-0x00000001815475F0 
		private static bool UseManagedCollation { get; } // 0x00000001815475F0-0x0000000181547730 
	
		// Constructors
		internal CompareInfo(CultureInfo culture); // 0x0000000181547520-0x0000000181547570
		static CompareInfo(); // 0x0000000181547460-0x00000001815474F0
		internal CompareInfo(); // 0x00000001815474F0-0x0000000181547520
	
		// Methods
		internal static int InvariantIndexOf(string source, string value, int startIndex, int count, bool ignoreCase); // 0x00000001815464D0-0x00000001815465B0
		internal static int InvariantIndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, bool ignoreCase); // 0x0000000181546400-0x00000001815464D0
		internal static int InvariantLastIndexOf(string source, string value, int startIndex, int count, bool ignoreCase); // 0x00000001815465B0-0x00000001815466A0
		private static unsafe int InvariantFindString(char* source, int sourceCount, char* value, int valueCount, bool ignoreCase, bool start); // 0x00000001815460C0-0x0000000181546400
		private static char InvariantToUpper(char c); // 0x00000001815466A0-0x00000001815466C0
		private SortKey InvariantCreateSortKey(string source, CompareOptions options); // 0x0000000181545E10-0x00000001815460C0
		public static CompareInfo GetCompareInfo(string name); // 0x0000000181544960-0x0000000181544A00
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx); // 0x0000000181547240-0x0000000181547260
		void IDeserializationCallback.OnDeserialization(object sender); // 0x0000000181547230-0x0000000181547240
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x0000000181547230-0x0000000181547240
		private void OnDeserialized(); // 0x0000000181547190-0x0000000181547230
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx); // 0x0000000181547260-0x00000001815472E0
		public virtual int Compare(string string1, string string2); // 0x0000000181543D10-0x0000000181543D40
		public virtual int Compare(string string1, string string2, CompareOptions options); // 0x0000000181543580-0x0000000181543800
		internal int Compare(ReadOnlySpan<char> string1, string string2, CompareOptions options); // 0x0000000181543D40-0x00000001815440B0
		internal int CompareOptionIgnoreCase(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2); // 0x0000000181542C40-0x0000000181542E60
		public virtual int Compare(string string1, int offset1, int length1, string string2, int offset2, int length2, CompareOptions options); // 0x0000000181543800-0x0000000181543D10
		internal static int CompareOrdinalIgnoreCase(string strA, int indexA, int lengthA, string strB, int indexB, int lengthB); // 0x0000000181543140-0x00000001815432B0
		internal static int CompareOrdinalIgnoreCase(ReadOnlySpan<char> strA, ReadOnlySpan<char> strB); // 0x0000000181542E60-0x0000000181543140
		public virtual bool IsPrefix(string source, string prefix, CompareOptions options); // 0x00000001815466C0-0x0000000181546950
		public virtual bool IsSuffix(string source, string suffix, CompareOptions options); // 0x0000000181546950-0x0000000181546B20
		internal bool IsSuffix(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options); // 0x0000000181544530-0x00000001815445B0
		public virtual int IndexOf(string source, char value, CompareOptions options); // 0x0000000181545D50-0x0000000181545DE0
		public virtual int IndexOf(string source, string value, CompareOptions options); // 0x0000000181545650-0x00000001815456E0
		public virtual int IndexOf(string source, char value, int startIndex, int count, CompareOptions options); // 0x00000001815456E0-0x00000001815459E0
		public virtual int IndexOf(string source, string value, int startIndex, int count, CompareOptions options); // 0x00000001815459E0-0x0000000181545D50
		internal int IndexOfOrdinal(ReadOnlySpan<char> source, ReadOnlySpan<char> value, bool ignoreCase); // 0x0000000181545350-0x00000001815453F0
		internal int IndexOf(ReadOnlySpan<char> source, ReadOnlySpan<char> value, CompareOptions options); // 0x00000001815455B0-0x0000000181545650
		internal int IndexOfOrdinal(string source, string value, int startIndex, int count, bool ignoreCase); // 0x00000001815453F0-0x00000001815455B0
		public virtual int LastIndexOf(string source, string value, int startIndex, int count, CompareOptions options); // 0x0000000181546CE0-0x0000000181547190
		internal int LastIndexOfOrdinal(string source, string value, int startIndex, int count, bool ignoreCase); // 0x0000000181546BA0-0x0000000181546CE0
		public virtual SortKey GetSortKey(string source, CompareOptions options); // 0x0000000181545140-0x0000000181545210
		public override bool Equals(object value); // 0x00000001815445B0-0x0000000181544670
		public override int GetHashCode(); // 0x0000000181544D60-0x0000000181544DA0
		internal static int GetIgnoreCaseHash(string source); // 0x0000000181544DA0-0x0000000181545140
		internal int GetHashCodeOfString(string source, CompareOptions options); // 0x0000000181544A40-0x0000000181544C50
		public virtual int GetHashCode(string source, CompareOptions options); // 0x0000000181544C50-0x0000000181544D60
		public override string ToString(); // 0x0000000181547400-0x0000000181547460
		private ISimpleCollator GetCollator(); // 0x0000000181544670-0x0000000181544960
		private SortKey CreateSortKeyCore(string source, CompareOptions options); // 0x00000001815440B0-0x0000000181544200
		private int internal_index_switch(string s1, int sindex, int count, string s2, CompareOptions opt, bool first); // 0x0000000181547C50-0x0000000181547E30
		private int internal_compare_switch(string str1, int offset1, int length1, string str2, int offset2, int length2, CompareOptions options); // 0x00000001815478E0-0x0000000181547AD0
		private int internal_compare_managed(string str1, int offset1, int length1, string str2, int offset2, int length2, CompareOptions options); // 0x00000001815477F0-0x00000001815478E0
		private int internal_index_managed(string s1, int sindex, int count, string s2, CompareOptions opt, bool first); // 0x0000000181547BA0-0x0000000181547C50
		private static unsafe int internal_compare_icall(char* str1, int length1, char* str2, int length2, CompareOptions options); // 0x0000000181547730-0x0000000181547740
		private static int internal_compare(string str1, int offset1, int length1, string str2, int offset2, int length2, CompareOptions options); // 0x0000000181547740-0x00000001815477F0
		private static unsafe int internal_index_icall(char* source, int sindex, int count, char* value, int value_length, bool first); // 0x0000000181547AD0-0x0000000181547AE0
		private static int internal_index(string source, int sindex, int count, string value, bool first); // 0x0000000181547AE0-0x0000000181547BA0
		private void InitSort(CultureInfo culture); // 0x0000000181545DE0-0x0000000181545E10
		private static unsafe int CompareStringOrdinalIgnoreCase(char* pString1, int length1, char* pString2, int length2); // 0x00000001815432B0-0x0000000181543400
		internal static int IndexOfOrdinalCore(string source, string value, int startIndex, int count, bool ignoreCase); // 0x0000000181545310-0x0000000181545350
		internal static int LastIndexOfOrdinalCore(string source, string value, int startIndex, int count, bool ignoreCase); // 0x0000000181546B60-0x0000000181546BA0
		private int LastIndexOfCore(string source, string target, int startIndex, int count, CompareOptions options); // 0x0000000181546B20-0x0000000181546B60
		private unsafe int IndexOfCore(string source, string target, int startIndex, int count, CompareOptions options, int* matchLengthPtr); // 0x0000000181545210-0x0000000181545260
		private unsafe int IndexOfCore(ReadOnlySpan<char> source, ReadOnlySpan<char> target, CompareOptions options, int* matchLengthPtr); // 0x0000000181545260-0x0000000181545310
		private int IndexOfOrdinalCore(ReadOnlySpan<char> source, ReadOnlySpan<char> value, bool ignoreCase); // 0x0000000181545350-0x00000001815453F0
		private int CompareString(ReadOnlySpan<char> string1, string string2, CompareOptions options); // 0x0000000181543500-0x0000000181543580
		private int CompareString(ReadOnlySpan<char> string1, ReadOnlySpan<char> string2, CompareOptions options); // 0x0000000181543400-0x0000000181543500
		private SortKey CreateSortKey(string source, CompareOptions options); // 0x0000000181544200-0x0000000181544410
		private bool StartsWith(string source, string prefix, CompareOptions options); // 0x00000001815472E0-0x0000000181547400
		private bool EndsWith(string source, string suffix, CompareOptions options); // 0x0000000181544410-0x0000000181544530
		private bool EndsWith(ReadOnlySpan<char> source, ReadOnlySpan<char> suffix, CompareOptions options); // 0x0000000181544530-0x00000001815445B0
		internal int GetHashCodeOfStringCore(string source, CompareOptions options); // 0x0000000181544A00-0x0000000181544A40
	}
}
