/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public sealed class String : IComparable, IEnumerable<char>, IComparable<string>, IEquatable<string>, IConvertible, ICloneable // TypeDefIndex: 2171
	{
		// Fields
		private const int StackallocIntBufferSizeLimit = 128; // Metadata: 0x0064E2AD
		private const int PROBABILISTICMAP_BLOCK_INDEX_MASK = 7; // Metadata: 0x0064E2AF
		private const int PROBABILISTICMAP_BLOCK_INDEX_SHIFT = 3; // Metadata: 0x0064E2B0
		private const int PROBABILISTICMAP_SIZE = 8; // Metadata: 0x0064E2B1
		[NonSerialized]
		private int _stringLength; // 0x10
		[NonSerialized]
		private char _firstChar; // 0x14
		public static readonly string Empty; // 0x00
	
		// Properties
		public int Length { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public char this[int index] { [Intrinsic] get => default; } // 0x000000018145ED40-0x000000018145ED90 
	
		// Nested types
		private enum TrimType // TypeDefIndex: 2172
		{
			Head = 0,
			Tail = 1,
			Both = 2
		}
	
		private struct ProbabilisticMap // TypeDefIndex: 2173
		{
		}
	
		// Constructors
		public String(char[] value); // 0x000000018145EC10-0x000000018145EC20
		public String(char[] value, int startIndex, int length); // 0x000000018145EC10-0x000000018145EC20
		[CLSCompliant(false)]
		public unsafe String(char* value); // 0x000000018145EC10-0x000000018145EC20
		[CLSCompliant(false)]
		public unsafe String(char* value, int startIndex, int length); // 0x000000018145EC10-0x000000018145EC20
		[CLSCompliant(false)]
		public unsafe String(sbyte* value, int startIndex, int length); // 0x000000018145EC10-0x000000018145EC20
		[CLSCompliant(false)]
		public unsafe String(sbyte* value, int startIndex, int length, Encoding enc); // 0x000000018145EC10-0x000000018145EC20
		public String(char c, int count); // 0x000000018145EC10-0x000000018145EC20
		public String(ReadOnlySpan<char> value); // 0x000000018145EC20-0x000000018145EC40
	
		// Methods
		private static bool EqualsHelper(string strA, string strB); // 0x00000001814573E0-0x0000000181457410
		private static int CompareOrdinalHelper(string strA, int indexA, int countA, string strB, int indexB, int countB); // 0x00000001814539C0-0x0000000181453A10
		private static int CompareOrdinalHelper(string strA, string strB); // 0x0000000181453850-0x00000001814539C0
		public static int Compare(string strA, string strB); // 0x0000000181453D20-0x0000000181453E00
		public static int Compare(string strA, string strB, bool ignoreCase); // 0x0000000181454400-0x0000000181454410
		public static int Compare(string strA, string strB, StringComparison comparisonType); // 0x0000000181454570-0x0000000181454900
		public static int Compare(string strA, string strB, CultureInfo culture, CompareOptions options); // 0x00000001814549C0-0x0000000181454A80
		public static int Compare(string strA, string strB, bool ignoreCase, CultureInfo culture); // 0x0000000181454900-0x00000001814549C0
		public static int Compare(string strA, int indexA, string strB, int indexB, int length); // 0x0000000181454A80-0x0000000181454BE0
		public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase); // 0x0000000181454410-0x0000000181454570
		public static int Compare(string strA, int indexA, string strB, int indexB, int length, StringComparison comparisonType); // 0x0000000181453F30-0x0000000181454400
		public static int CompareOrdinal(string strA, string strB); // 0x0000000181453CE0-0x0000000181453D20
		internal static int CompareOrdinal(ReadOnlySpan<char> strA, ReadOnlySpan<char> strB); // 0x0000000181453A10-0x0000000181453A80
		public static int CompareOrdinal(string strA, int indexA, string strB, int indexB, int length); // 0x0000000181453A80-0x0000000181453CE0
		public int CompareTo(object value); // 0x0000000181453E00-0x0000000181453F30
		public int CompareTo(string strB); // 0x0000000181453D20-0x0000000181453E00
		public bool EndsWith(string value); // 0x00000001814572E0-0x00000001814573E0
		public bool EndsWith(string value, StringComparison comparisonType); // 0x0000000181456FA0-0x00000001814572E0
		public override bool Equals(object obj); // 0x0000000181457450-0x00000001814574A0
		public bool Equals(string value); // 0x0000000181457AB0-0x0000000181457AE0
		public bool Equals(string value, StringComparison comparisonType); // 0x00000001814574A0-0x00000001814577A0
		public static bool Equals(string a, string b); // 0x0000000181457410-0x0000000181457450
		public static bool Equals(string a, string b, StringComparison comparisonType); // 0x00000001814577A0-0x0000000181457AB0
		public static bool operator ==(string a, string b); // 0x0000000181457410-0x0000000181457450
		public static bool operator !=(string a, string b); // 0x000000018145EF00-0x000000018145EF50
		public override int GetHashCode(); // 0x00000001814587D0-0x0000000181458820
		internal int GetLegacyNonRandomizedHashCode(); // 0x00000001814587D0-0x0000000181458820
		public bool StartsWith(string value); // 0x000000018145D9E0-0x000000018145DAF0
		public bool StartsWith(string value, StringComparison comparisonType); // 0x000000018145D680-0x000000018145D9E0
		internal static void CheckStringComparison(StringComparison comparisonType); // 0x0000000181453830-0x0000000181453850
		private static string Ctor(char[] value); // 0x0000000181456800-0x0000000181456880
		private static string Ctor(char[] value, int startIndex, int length); // 0x0000000181456D70-0x0000000181456FA0
		private static unsafe string Ctor(char* ptr); // 0x0000000181456610-0x0000000181456780
		private static unsafe string Ctor(char* ptr, int startIndex, int length); // 0x0000000181456B60-0x0000000181456D70
		private static unsafe string Ctor(sbyte* value, int startIndex, int length); // 0x0000000181456410-0x0000000181456610
		private static unsafe string CreateStringForSByteConstructor(byte* pb, int numBytes); // 0x0000000181455E90-0x0000000181455EF0
		private static unsafe string Ctor(sbyte* value, int startIndex, int length, Encoding enc); // 0x0000000181456960-0x0000000181456B60
		private static string Ctor(char c, int count); // 0x0000000181456880-0x0000000181456960
		private static string Ctor(ReadOnlySpan<char> value); // 0x0000000181456780-0x0000000181456800
		public static string Create<TState>(int length, TState state, SpanAction<char, TState> action);
		public static implicit operator ReadOnlySpan<char>(string value); // 0x000000018145EEC0-0x000000018145EF00
		public object Clone(); // 0x0000000180370C60-0x0000000180370C70
		public static string Copy(string str); // 0x0000000181455DC0-0x0000000181455E60
		public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count); // 0x0000000181455B70-0x0000000181455DC0
		public char[] ToCharArray(); // 0x000000018145E380-0x000000018145E450
		[NonVersionable]
		public static bool IsNullOrEmpty(string value); // 0x0000000181459C50-0x0000000181459C60
		public static bool IsNullOrWhiteSpace(string value); // 0x0000000181459C60-0x0000000181459D00
		internal ref char GetRawStringData(); // 0x0000000181458820-0x0000000181458830
		internal static unsafe string CreateStringFromEncoding(byte* bytes, int byteLength, Encoding encoding); // 0x0000000181455EF0-0x0000000181455FC0
		internal static string CreateFromChar(char c); // 0x0000000181455E60-0x0000000181455E90
		internal static unsafe void wstrcpy(char* dmem, char* smem, int charCount); // 0x00000001808576A0-0x00000001808576B0
		public override string ToString(); // 0x0000000180370C60-0x0000000180370C70
		public string ToString(IFormatProvider provider); // 0x0000000180370C60-0x0000000180370C70
		IEnumerator<char> IEnumerable<char>.GetEnumerator(); // 0x000000018145DCF0-0x000000018145DD50
		IEnumerator IEnumerable.GetEnumerator(); // 0x000000018145DD50-0x000000018145DDB0
		internal static unsafe int wcslen(char* ptr); // 0x000000018145EF50-0x000000018145F040
		public TypeCode GetTypeCode(); // 0x0000000181458830-0x0000000181458840
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x000000018145DDB0-0x000000018145DE10
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018145DE70-0x000000018145DED0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x000000018145E130-0x000000018145E190
		byte IConvertible.ToByte(IFormatProvider provider); // 0x000000018145DE10-0x000000018145DE70
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018145E010-0x000000018145E070
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018145E260-0x000000018145E2C0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x000000018145E070-0x000000018145E0D0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x000000018145E2C0-0x000000018145E320
		long IConvertible.ToInt64(IFormatProvider provider); // 0x000000018145E0D0-0x000000018145E130
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x000000018145E320-0x000000018145E380
		float IConvertible.ToSingle(IFormatProvider provider); // 0x000000018145E190-0x000000018145E1F0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x000000018145DFB0-0x000000018145E010
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x000000018145DF30-0x000000018145DFB0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x000000018145DED0-0x000000018145DF30
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x000000018145E1F0-0x000000018145E260
		public string Normalize(NormalizationForm normalizationForm); // 0x000000018145BB90-0x000000018145BBF0
		private static void FillStringChecked(string dest, int destPos, string src); // 0x0000000181457AF0-0x0000000181457B80
		public static string Concat(object arg0, object arg1, object arg2); // 0x0000000181455350-0x0000000181455420
		public static string Concat(IEnumerable<string> values); // 0x00000001814555A0-0x0000000181455940
		public static string Concat(string str0, string str1); // 0x0000000181455420-0x00000001814555A0
		public static string Concat(string str0, string str1, string str2); // 0x0000000181455130-0x0000000181455350
		public static string Concat(string str0, string str1, string str2, string str3); // 0x0000000181454BE0-0x0000000181454E70
		public static string Concat(params string[] values); // 0x0000000181454E70-0x0000000181455130
		public static string Format(string format, object arg0); // 0x00000001814583E0-0x0000000181458520
		public static string Format(string format, object arg0, object arg1); // 0x0000000181458690-0x00000001814587D0
		public static string Format(string format, object arg0, object arg1, object arg2); // 0x00000001814582A0-0x00000001814583E0
		public static string Format(string format, params object[] args); // 0x0000000181458100-0x00000001814582A0
		public static string Format(IFormatProvider provider, string format, object arg0); // 0x0000000181457CA0-0x0000000181457DF0
		public static string Format(IFormatProvider provider, string format, object arg0, object arg1); // 0x0000000181457FA0-0x0000000181458100
		public static string Format(IFormatProvider provider, string format, object arg0, object arg1, object arg2); // 0x0000000181458520-0x0000000181458690
		public static string Format(IFormatProvider provider, string format, params object[] args); // 0x0000000181457DF0-0x0000000181457FA0
		private static string FormatHelper(IFormatProvider provider, string format, ParamsArray args); // 0x0000000181457B80-0x0000000181457CA0
		public string Insert(int startIndex, string value); // 0x00000001814599B0-0x0000000181459B40
		public static string Join<T>(char separator, IEnumerable<T> values);
		public static string Join(string separator, params string[] value); // 0x000000018145A200-0x000000018145A2B0
		public static string Join<T>(string separator, IEnumerable<T> values);
		public static string Join(string separator, IEnumerable<string> values); // 0x000000018145A2B0-0x000000018145A660
		public static string Join(string separator, string[] value, int startIndex, int count); // 0x000000018145A660-0x000000018145A6B0
		private static unsafe string JoinCore<T>(char* separator, int separatorLength, IEnumerable<T> values);
		private static unsafe string JoinCore(char* separator, int separatorLength, string[] value, int startIndex, int count); // 0x0000000181459D00-0x000000018145A200
		public string PadLeft(int totalWidth, char paddingChar); // 0x000000018145BBF0-0x000000018145BCF0
		public string PadRight(int totalWidth, char paddingChar); // 0x000000018145BCF0-0x000000018145BDF0
		public string Remove(int startIndex, int count); // 0x000000018145BDF0-0x000000018145BFF0
		public string Remove(int startIndex); // 0x000000018145BFF0-0x000000018145C0D0
		public string Replace(char oldChar, char newChar); // 0x000000018145C390-0x000000018145C470
		public string Replace(string oldValue, string newValue); // 0x000000018145C470-0x000000018145C700
		private string ReplaceHelper(int oldValueLength, string newValue, ReadOnlySpan<int> indices); // 0x000000018145C0D0-0x000000018145C390
		public string[] Split(char separator, StringSplitOptions options = StringSplitOptions.None /* Metadata: 0x0064E2AC */); // 0x000000018145D5E0-0x000000018145D630
		public string[] Split(params char[] separator); // 0x000000018145D4E0-0x000000018145D530
		public string[] Split(char[] separator, int count); // 0x000000018145D530-0x000000018145D580
		public string[] Split(char[] separator, StringSplitOptions options); // 0x000000018145D580-0x000000018145D5E0
		private string[] SplitInternal(ReadOnlySpan<char> separators, int count, StringSplitOptions options); // 0x000000018145C720-0x000000018145CA10
		public string[] Split(string[] separator, StringSplitOptions options); // 0x000000018145D4B0-0x000000018145D4E0
		private string[] SplitInternal(string separator, string[] separators, int count, StringSplitOptions options); // 0x000000018145CBE0-0x000000018145CFD0
		private string[] SplitInternal(string separator, int count, StringSplitOptions options); // 0x000000018145CA10-0x000000018145CBE0
		private string[] SplitKeepEmptyEntries(ReadOnlySpan<int> sepList, ReadOnlySpan<int> lengthList, int defaultLength, int count); // 0x000000018145CFD0-0x000000018145D1E0
		private string[] SplitOmitEmptyEntries(ReadOnlySpan<int> sepList, ReadOnlySpan<int> lengthList, int defaultLength, int count); // 0x000000018145D1E0-0x000000018145D4B0
		private void MakeSeparatorList(ReadOnlySpan<char> separators, ref ValueListBuilder<int> sepListBuilder); // 0x000000018145B7C0-0x000000018145BB90
		private void MakeSeparatorList(string separator, ref ValueListBuilder<int> sepListBuilder); // 0x000000018145B330-0x000000018145B540
		private void MakeSeparatorList(string[] separators, ref ValueListBuilder<int> sepListBuilder, ref ValueListBuilder<int> lengthListBuilder); // 0x000000018145B540-0x000000018145B7C0
		public string Substring(int startIndex); // 0x000000018145DAF0-0x000000018145DB00
		public string Substring(int startIndex, int length); // 0x000000018145DB00-0x000000018145DCF0
		private string InternalSubString(int startIndex, int length); // 0x0000000181459BC0-0x0000000181459C30
		public string ToLower(); // 0x000000018145E4C0-0x000000018145E530
		public string ToLower(CultureInfo culture); // 0x000000018145E530-0x000000018145E5D0
		public string ToLowerInvariant(); // 0x000000018145E450-0x000000018145E4C0
		public string ToUpper(); // 0x000000018145E640-0x000000018145E6B0
		public string ToUpper(CultureInfo culture); // 0x000000018145E6B0-0x000000018145E750
		public string ToUpperInvariant(); // 0x000000018145E5D0-0x000000018145E640
		public string Trim(); // 0x000000018145EBD0-0x000000018145EBE0
		public string Trim(char trimChar); // 0x000000018145EBE0-0x000000018145EC10
		public string Trim(params char[] trimChars); // 0x000000018145EB70-0x000000018145EBD0
		public string TrimStart(); // 0x000000018145E9F0-0x000000018145EA00
		public string TrimStart(char trimChar); // 0x000000018145E970-0x000000018145E9A0
		public string TrimStart(params char[] trimChars); // 0x000000018145E9A0-0x000000018145E9F0
		public string TrimEnd(); // 0x000000018145E750-0x000000018145E760
		public string TrimEnd(char trimChar); // 0x000000018145E7C0-0x000000018145E7F0
		public string TrimEnd(params char[] trimChars); // 0x000000018145E760-0x000000018145E7C0
		private string TrimWhiteSpaceHelper(TrimType trimType); // 0x000000018145EA00-0x000000018145EB70
		private unsafe string TrimHelper(char* trimChars, int trimCharsLength, TrimType trimType); // 0x000000018145E7F0-0x000000018145E970
		private string CreateTrimmedString(int start, int end); // 0x00000001814563E0-0x0000000181456410
		public bool Contains(string value); // 0x0000000181455960-0x0000000181455B20
		public bool Contains(string value, StringComparison comparisonType); // 0x0000000181455B20-0x0000000181455B50
		public bool Contains(char value); // 0x0000000181455B50-0x0000000181455B70
		public bool Contains(char value, StringComparison comparisonType); // 0x0000000181455940-0x0000000181455960
		public int IndexOf(char value); // 0x00000001814597D0-0x00000001814597E0
		public int IndexOf(char value, int startIndex); // 0x0000000181459080-0x00000001814590A0
		public int IndexOf(char value, StringComparison comparisonType); // 0x00000001814590A0-0x0000000181459340
		public int IndexOf(char value, int startIndex, int count); // 0x00000001814597E0-0x00000001814598F0
		public int IndexOfAny(char[] anyOf); // 0x0000000181458BC0-0x0000000181458BE0
		public int IndexOfAny(char[] anyOf, int startIndex); // 0x0000000181458840-0x0000000181458860
		public int IndexOfAny(char[] anyOf, int startIndex, int count); // 0x0000000181458860-0x0000000181458BC0
		private int IndexOfAny(char value1, char value2, int startIndex, int count); // 0x0000000181458C30-0x0000000181458CA0
		private int IndexOfAny(char value1, char value2, char value3, int startIndex, int count); // 0x0000000181458BE0-0x0000000181458C30
		private int IndexOfCharArray(char[] anyOf, int startIndex, int count); // 0x0000000181458CA0-0x0000000181458DC0
		private static unsafe void InitializeProbabilisticMap(uint* charMap, ReadOnlySpan<char> anyOf); // 0x00000001814598F0-0x00000001814599B0
		private static bool ArrayContains(char searchChar, char[] anyOf); // 0x00000001814537E0-0x0000000181453830
		private static unsafe bool IsCharBitSet(uint* charMap, byte value); // 0x0000000181459C30-0x0000000181459C50
		private static unsafe void SetCharBit(uint* charMap, byte value); // 0x000000018145C700-0x000000018145C720
		public int IndexOf(string value); // 0x0000000181459790-0x00000001814597B0
		public int IndexOf(string value, int startIndex); // 0x00000001814597B0-0x00000001814597D0
		public int IndexOf(string value, StringComparison comparisonType); // 0x0000000181459370-0x00000001814593A0
		public int IndexOf(string value, int startIndex, StringComparison comparisonType); // 0x0000000181459340-0x0000000181459370
		public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType); // 0x00000001814593A0-0x0000000181459790
		public int LastIndexOf(char value); // 0x000000018145B1C0-0x000000018145B1D0
		public int LastIndexOf(char value, int startIndex); // 0x000000018145B170-0x000000018145B190
		public int LastIndexOf(char value, int startIndex, int count); // 0x000000018145B200-0x000000018145B330
		public int LastIndexOfAny(char[] anyOf); // 0x000000018145A6B0-0x000000018145A6E0
		public int LastIndexOfAny(char[] anyOf, int startIndex); // 0x000000018145A940-0x000000018145A960
		public int LastIndexOfAny(char[] anyOf, int startIndex, int count); // 0x000000018145A6E0-0x000000018145A940
		private int LastIndexOfCharArray(char[] anyOf, int startIndex, int count); // 0x000000018145A960-0x000000018145AA80
		public int LastIndexOf(string value); // 0x000000018145B1D0-0x000000018145B200
		public int LastIndexOf(string value, StringComparison comparisonType); // 0x000000018145B190-0x000000018145B1C0
		public int LastIndexOf(string value, int startIndex, StringComparison comparisonType); // 0x000000018145B140-0x000000018145B170
		public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType); // 0x000000018145AD20-0x000000018145B140
		internal int IndexOfUnchecked(string value, int startIndex, int count); // 0x0000000181458F90-0x0000000181459080
		internal int IndexOfUncheckedIgnoreCase(string value, int startIndex, int count); // 0x0000000181458DC0-0x0000000181458F90
		internal int LastIndexOfUnchecked(string value, int startIndex, int count); // 0x000000018145AC40-0x000000018145AD20
		internal int LastIndexOfUncheckedIgnoreCase(string value, int startIndex, int count); // 0x000000018145AA80-0x000000018145AC40
		internal bool StartsWithOrdinalUnchecked(string value); // 0x000000018145D630-0x000000018145D680
		internal static string FastAllocateString(int length); // 0x0000000181457AE0-0x0000000181457AF0
		private static string InternalIntern(string str); // 0x0000000181459BB0-0x0000000181459BC0
		private static unsafe void memset(byte* dest, int val, int len); // 0x000000018145EDD0-0x000000018145EEC0
		private static unsafe void memcpy(byte* dest, byte* src, int size); // 0x000000018145EDC0-0x000000018145EDD0
		internal static unsafe void bzero(byte* dest, int len); // 0x000000018145EC50-0x000000018145ED40
		internal static unsafe void bzero_aligned_1(byte* dest, int len); // 0x000000018071CA50-0x000000018071CA60
		internal static unsafe void bzero_aligned_2(byte* dest, int len); // 0x00000001812399C0-0x00000001812399D0
		internal static unsafe void bzero_aligned_4(byte* dest, int len); // 0x00000001812C86B0-0x00000001812C86C0
		internal static unsafe void bzero_aligned_8(byte* dest, int len); // 0x000000018145EC40-0x000000018145EC50
		internal static unsafe void memcpy_aligned_1(byte* dest, byte* src, int size); // 0x000000018145ED90-0x000000018145EDA0
		internal static unsafe void memcpy_aligned_2(byte* dest, byte* src, int size); // 0x000000018145EDA0-0x000000018145EDB0
		internal static unsafe void memcpy_aligned_4(byte* dest, byte* src, int size); // 0x000000018145EDB0-0x000000018145EDC0
		internal static unsafe void memcpy_aligned_8(byte* dest, byte* src, int size); // 0x0000000180D17CC0-0x0000000180D17CD0
		private unsafe string CreateString(sbyte* value, int startIndex, int length); // 0x0000000181456300-0x0000000181456320
		private unsafe string CreateString(char* value); // 0x0000000181456050-0x00000001814561B0
		private unsafe string CreateString(char* value, int startIndex, int length); // 0x00000001814561B0-0x00000001814561D0
		private string CreateString(char[] val, int startIndex, int length); // 0x0000000181456320-0x0000000181456340
		private string CreateString(char[] val); // 0x0000000181456340-0x00000001814563E0
		private string CreateString(char c, int count); // 0x0000000181456200-0x0000000181456300
		private unsafe string CreateString(sbyte* value, int startIndex, int length, Encoding enc); // 0x00000001814561D0-0x0000000181456200
		private string CreateString(ReadOnlySpan<char> value); // 0x0000000181455FC0-0x0000000181456050
		public static string Intern(string str); // 0x0000000181459B40-0x0000000181459BB0
	}
}
