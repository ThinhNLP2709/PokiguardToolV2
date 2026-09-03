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
	public struct Byte : IComparable, IConvertible, IFormattable, IComparable<byte>, IEquatable<byte>, ISpanFormattable // TypeDefIndex: 2223
	{
		// Fields
		private readonly byte m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x000000018155F080-0x000000018155F130
		public int CompareTo(byte value); // 0x000000018155F070-0x000000018155F080
		public override bool Equals(object obj); // 0x000000018155F130-0x000000018155F190
		[NonVersionable]
		public bool Equals(byte obj); // 0x000000018155E1F0-0x000000018155E200
		public override int GetHashCode(); // 0x0000000180333490-0x00000001803334A0
		public static byte Parse(string s, IFormatProvider provider); // 0x000000018155F360-0x000000018155F3E0
		public static byte Parse(string s, NumberStyles style, IFormatProvider provider); // 0x000000018155F2C0-0x000000018155F360
		private static byte Parse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info); // 0x000000018155F190-0x000000018155F2C0
		public static bool TryParse(string s, out byte result); // 0x000000018155FDE0-0x000000018155FEC0
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out byte result); // 0x000000018155FCF0-0x000000018155FDE0
		private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info, out byte result); // 0x000000018155FC40-0x000000018155FCF0
		public override string ToString(); // 0x000000018155FB20-0x000000018155FB90
		public string ToString(string format); // 0x000000018155FA80-0x000000018155FB20
		public string ToString(IFormatProvider provider); // 0x000000018155F950-0x000000018155F9D0
		public string ToString(string format, IFormatProvider provider); // 0x000000018155F9D0-0x000000018155FA80
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x000000018155FB90-0x000000018155FC40
		public TypeCode GetTypeCode(); // 0x0000000180A32610-0x0000000180A32620
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x000000018155F3E0-0x000000018155F430
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018155F430-0x000000018155F480
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x000000018155F6F0-0x000000018155F780
		byte IConvertible.ToByte(IFormatProvider provider); // 0x0000000180333490-0x00000001803334A0
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018155F600-0x000000018155F650
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018155F860-0x000000018155F8B0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x000000018155F650-0x000000018155F6A0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x000000018155F8B0-0x000000018155F900
		long IConvertible.ToInt64(IFormatProvider provider); // 0x000000018155F6A0-0x000000018155F6F0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x000000018155F900-0x000000018155F950
		float IConvertible.ToSingle(IFormatProvider provider); // 0x000000018155F780-0x000000018155F7D0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x000000018155F5B0-0x000000018155F600
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x000000018155F510-0x000000018155F5B0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x000000018155F480-0x000000018155F510
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x000000018155F7D0-0x000000018155F860
	}
}
