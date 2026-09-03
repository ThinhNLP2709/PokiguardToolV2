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
	[CLSCompliant(false)]
	[IsReadOnly]
	public struct SByte : IComparable, IConvertible, IFormattable, IComparable<sbyte>, IEquatable<sbyte>, ISpanFormattable // TypeDefIndex: 2331
	{
		// Fields
		private readonly sbyte m_value; // 0x00
	
		// Methods
		public int CompareTo(object obj); // 0x0000000181619F10-0x0000000181619FC0
		public int CompareTo(sbyte value); // 0x0000000181619F00-0x0000000181619F10
		public override bool Equals(object obj); // 0x0000000181619FC0-0x000000018161A020
		[NonVersionable]
		public bool Equals(sbyte obj); // 0x000000018155E1F0-0x000000018155E200
		public override int GetHashCode(); // 0x000000018161A020-0x000000018161A030
		public override string ToString(); // 0x000000018161A960-0x000000018161A9D0
		public string ToString(IFormatProvider provider); // 0x000000018161A8E0-0x000000018161A960
		public string ToString(string format, IFormatProvider provider); // 0x000000018161A780-0x000000018161A8E0
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x000000018161A9D0-0x000000018161AAF0
		[CLSCompliant(false)]
		public static sbyte Parse(string s, IFormatProvider provider); // 0x000000018161A030-0x000000018161A0A0
		[CLSCompliant(false)]
		public static sbyte Parse(string s, NumberStyles style, IFormatProvider provider); // 0x000000018161A230-0x000000018161A2C0
		private static sbyte Parse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info); // 0x000000018161A0A0-0x000000018161A230
		[CLSCompliant(false)]
		public static bool TryParse(string s, out sbyte result); // 0x000000018161AAF0-0x000000018161ABD0
		[CLSCompliant(false)]
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out sbyte result); // 0x000000018161ACA0-0x000000018161AD40
		private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info, out sbyte result); // 0x000000018161ABD0-0x000000018161ACA0
		public TypeCode GetTypeCode(); // 0x0000000180A32630-0x0000000180A32640
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x000000018161A2C0-0x000000018161A310
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018161A360-0x000000018161A3B0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x0000000180333490-0x00000001803334A0
		byte IConvertible.ToByte(IFormatProvider provider); // 0x000000018161A310-0x000000018161A360
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018161A500-0x000000018161A550
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018161A690-0x000000018161A6E0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x000000018161A550-0x000000018161A560
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x000000018161A6E0-0x000000018161A730
		long IConvertible.ToInt64(IFormatProvider provider); // 0x000000018161A560-0x000000018161A5B0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x000000018161A730-0x000000018161A780
		float IConvertible.ToSingle(IFormatProvider provider); // 0x000000018161A5B0-0x000000018161A600
		double IConvertible.ToDouble(IFormatProvider provider); // 0x000000018161A4B0-0x000000018161A500
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x000000018161A440-0x000000018161A4B0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x000000018161A3B0-0x000000018161A440
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x000000018161A600-0x000000018161A690
	}
}
