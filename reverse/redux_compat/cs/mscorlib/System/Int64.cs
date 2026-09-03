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
	public struct Int64 : IComparable, IConvertible, IFormattable, IComparable<long>, IEquatable<long>, ISpanFormattable // TypeDefIndex: 2288
	{
		// Fields
		private readonly long m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x00000001815FD920-0x00000001815FD9E0
		public int CompareTo(long value); // 0x00000001815FD9E0-0x00000001815FDA00
		public override bool Equals(object obj); // 0x00000001815FDA00-0x00000001815FDA50
		[NonVersionable]
		public bool Equals(long obj); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public override int GetHashCode(); // 0x00000001815FDA50-0x00000001815FDA60
		public override string ToString(); // 0x00000001815FE100-0x00000001815FE170
		public string ToString(IFormatProvider provider); // 0x00000001815FE170-0x00000001815FE1F0
		public string ToString(string format); // 0x00000001815FE2A0-0x00000001815FE340
		public string ToString(string format, IFormatProvider provider); // 0x00000001815FE1F0-0x00000001815FE2A0
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001815FE340-0x00000001815FE3F0
		public static long Parse(string s, IFormatProvider provider); // 0x00000001815FDB40-0x00000001815FDC00
		public static long Parse(string s, NumberStyles style, IFormatProvider provider); // 0x00000001815FDA70-0x00000001815FDB40
		public static bool TryParse(string s, out long result); // 0x00000001815FE3F0-0x00000001815FE560
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out long result); // 0x00000001815FE560-0x00000001815FE640
		public TypeCode GetTypeCode(); // 0x00000001815FDA60-0x00000001815FDA70
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815FDC00-0x00000001815FDC50
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001815FDCA0-0x00000001815FDCF0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001815FDEE0-0x00000001815FDF30
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001815FDC50-0x00000001815FDCA0
		short IConvertible.ToInt16(IFormatProvider provider); // 0x00000001815FDE40-0x00000001815FDE90
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001815FE010-0x00000001815FE060
		int IConvertible.ToInt32(IFormatProvider provider); // 0x00000001815FDE90-0x00000001815FDEE0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x00000001815FE060-0x00000001815FE0B0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001808BADD0-0x00000001808BADE0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001815FE0B0-0x00000001815FE100
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001815FDF30-0x00000001815FDF80
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001815FDDF0-0x00000001815FDE40
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001815FDD80-0x00000001815FDDF0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001815FDCF0-0x00000001815FDD80
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001815FDF80-0x00000001815FE010
	}
}
