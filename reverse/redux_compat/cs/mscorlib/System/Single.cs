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
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct Single : IComparable, IConvertible, IFormattable, IComparable<float>, IEquatable<float>, ISpanFormattable // TypeDefIndex: 2333
	{
		// Fields
		private readonly float m_value; // 0x00
	
		// Methods
		[NonVersionable]
		public static bool IsFinite(float f); // 0x000000018161AF50-0x000000018161AF70
		[NonVersionable]
		public static bool IsInfinity(float f); // 0x000000018161AF70-0x000000018161AF90
		[NonVersionable]
		public static bool IsNaN(float f); // 0x000000018161AF90-0x000000018161AFB0
		[NonVersionable]
		public static bool IsNegative(float f); // 0x000000018161AFD0-0x000000018161AFE0
		[NonVersionable]
		public static bool IsNegativeInfinity(float f); // 0x000000018161AFB0-0x000000018161AFD0
		[NonVersionable]
		public static bool IsPositiveInfinity(float f); // 0x000000018161AFE0-0x000000018161B000
		public int CompareTo(object value); // 0x000000018161AD80-0x000000018161AE70
		public int CompareTo(float value); // 0x000000018161AD40-0x000000018161AD80
		public override bool Equals(object obj); // 0x000000018161AEA0-0x000000018161AF20
		public bool Equals(float obj); // 0x000000018161AE70-0x000000018161AEA0
		public override int GetHashCode(); // 0x000000018161AF20-0x000000018161AF40
		public override string ToString(); // 0x000000018161B860-0x000000018161B8D0
		public string ToString(IFormatProvider provider); // 0x000000018161B7E0-0x000000018161B860
		public string ToString(string format); // 0x000000018161B760-0x000000018161B7E0
		public string ToString(string format, IFormatProvider provider); // 0x000000018161B8D0-0x000000018161B960
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x000000018161B960-0x000000018161BA20
		public static float Parse(string s, IFormatProvider provider); // 0x000000018161B0C0-0x000000018161B170
		public static float Parse(string s, NumberStyles style, IFormatProvider provider); // 0x000000018161B000-0x000000018161B0C0
		public static bool TryParse(string s, out float result); // 0x000000018161BC00-0x000000018161BC80
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out float result); // 0x000000018161BC80-0x000000018161BD20
		private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info, out float result); // 0x000000018161BA20-0x000000018161BC00
		public TypeCode GetTypeCode(); // 0x000000018161AF40-0x000000018161AF50
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x000000018161B170-0x000000018161B1D0
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018161B230-0x000000018161B2C0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x000000018161B550-0x000000018161B5B0
		byte IConvertible.ToByte(IFormatProvider provider); // 0x000000018161B1D0-0x000000018161B230
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018161B430-0x000000018161B490
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018161B640-0x000000018161B6A0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x000000018161B490-0x000000018161B4F0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x000000018161B6A0-0x000000018161B700
		long IConvertible.ToInt64(IFormatProvider provider); // 0x000000018161B4F0-0x000000018161B550
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x000000018161B700-0x000000018161B760
		float IConvertible.ToSingle(IFormatProvider provider); // 0x000000018035C780-0x000000018035C790
		double IConvertible.ToDouble(IFormatProvider provider); // 0x000000018161B3D0-0x000000018161B430
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x000000018161B350-0x000000018161B3D0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x000000018161B2C0-0x000000018161B350
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x000000018161B5B0-0x000000018161B640
	}
}
