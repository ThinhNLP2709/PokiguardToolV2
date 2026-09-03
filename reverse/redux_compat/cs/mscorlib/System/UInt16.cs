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
	public struct UInt16 : IComparable, IConvertible, IFormattable, IComparable<ushort>, IEquatable<ushort>, ISpanFormattable // TypeDefIndex: 2360
	{
		// Fields
		private readonly ushort m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x0000000181625FC0-0x0000000181626070
		public int CompareTo(ushort value); // 0x0000000181560720-0x0000000181560730
		public override bool Equals(object obj); // 0x0000000181626070-0x00000001816260D0
		[NonVersionable]
		public bool Equals(ushort obj); // 0x0000000181560960-0x0000000181560970
		public override int GetHashCode(); // 0x000000018123AD30-0x000000018123AD40
		public override string ToString(); // 0x0000000181626800-0x0000000181626870
		public string ToString(IFormatProvider provider); // 0x0000000181626920-0x00000001816269A0
		public string ToString(string format, IFormatProvider provider); // 0x0000000181626870-0x0000000181626920
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001816269A0-0x0000000181626A50
		[CLSCompliant(false)]
		public static ushort Parse(string s, IFormatProvider provider); // 0x00000001816260D0-0x0000000181626140
		[CLSCompliant(false)]
		public static ushort Parse(string s, NumberStyles style, IFormatProvider provider); // 0x0000000181626140-0x00000001816261D0
		private static ushort Parse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info); // 0x00000001816261D0-0x0000000181626300
		[CLSCompliant(false)]
		public static bool TryParse(string s, out ushort result); // 0x0000000181626A50-0x0000000181626B30
		[CLSCompliant(false)]
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ushort result); // 0x0000000181626B30-0x0000000181626C20
		private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info, out ushort result); // 0x0000000181626C20-0x0000000181626CD0
		public TypeCode GetTypeCode(); // 0x0000000180740830-0x0000000180740840
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x0000000181626300-0x0000000181626350
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001816263A0-0x00000001816263F0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x0000000181626630-0x0000000181626680
		byte IConvertible.ToByte(IFormatProvider provider); // 0x0000000181626350-0x00000001816263A0
		short IConvertible.ToInt16(IFormatProvider provider); // 0x0000000181626540-0x0000000181626590
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018123AD30-0x000000018123AD40
		int IConvertible.ToInt32(IFormatProvider provider); // 0x0000000181626590-0x00000001816265E0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x0000000181626760-0x00000001816267B0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001816265E0-0x0000000181626630
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001816267B0-0x0000000181626800
		float IConvertible.ToSingle(IFormatProvider provider); // 0x0000000181626680-0x00000001816266D0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001816264F0-0x0000000181626540
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x0000000181626480-0x00000001816264F0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001816263F0-0x0000000181626480
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001816266D0-0x0000000181626760
	}
}
