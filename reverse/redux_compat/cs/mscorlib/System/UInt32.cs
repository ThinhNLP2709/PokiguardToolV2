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
	public struct UInt32 : IComparable, IConvertible, IFormattable, IComparable<uint>, IEquatable<uint>, ISpanFormattable // TypeDefIndex: 2361
	{
		// Fields
		private readonly uint m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x0000000181626CD0-0x0000000181626D90
		public int CompareTo(uint value); // 0x0000000181626D90-0x0000000181626DB0
		public override bool Equals(object obj); // 0x0000000181626DB0-0x0000000181626E00
		[NonVersionable]
		public bool Equals(uint obj); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public override string ToString(); // 0x0000000181627650-0x00000001816276C0
		public string ToString(IFormatProvider provider); // 0x00000001816275D0-0x0000000181627650
		public string ToString(string format, IFormatProvider provider); // 0x0000000181627520-0x00000001816275D0
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001816276C0-0x0000000181627760
		[CLSCompliant(false)]
		public static uint Parse(string s); // 0x0000000181626E10-0x0000000181626EB0
		[CLSCompliant(false)]
		public static uint Parse(string s, IFormatProvider provider); // 0x0000000181626EB0-0x0000000181626F60
		[CLSCompliant(false)]
		public static uint Parse(string s, NumberStyles style, IFormatProvider provider); // 0x0000000181626F60-0x0000000181627020
		[CLSCompliant(false)]
		public static bool TryParse(string s, out uint result); // 0x0000000181627830-0x00000001816278F0
		[CLSCompliant(false)]
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out uint result); // 0x0000000181627760-0x0000000181627830
		public TypeCode GetTypeCode(); // 0x0000000181626E00-0x0000000181626E10
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x0000000181627020-0x0000000181627070
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001816270C0-0x0000000181627110
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x0000000181627350-0x00000001816273A0
		byte IConvertible.ToByte(IFormatProvider provider); // 0x0000000181627070-0x00000001816270C0
		short IConvertible.ToInt16(IFormatProvider provider); // 0x0000000181627260-0x00000001816272B0
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x0000000181627480-0x00000001816274D0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x00000001816272B0-0x0000000181627300
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x0000000180732D10-0x0000000180732D20
		long IConvertible.ToInt64(IFormatProvider provider); // 0x0000000181627300-0x0000000181627350
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001816274D0-0x0000000181627520
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001816273A0-0x00000001816273F0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x0000000181627210-0x0000000181627260
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001816271A0-0x0000000181627210
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x0000000181627110-0x00000001816271A0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001816273F0-0x0000000181627480
	}
}
