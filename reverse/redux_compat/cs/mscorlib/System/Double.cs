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
	public struct Double : IComparable, IConvertible, IFormattable, IComparable<double>, IEquatable<double>, ISpanFormattable // TypeDefIndex: 2236
	{
		// Fields
		private readonly double m_value; // 0x00
	
		// Methods
		[NonVersionable]
		public static bool IsFinite(double d); // 0x00000001815F6060-0x00000001815F6090
		[NonVersionable]
		public static bool IsInfinity(double d); // 0x00000001815F6090-0x00000001815F60C0
		[NonVersionable]
		public static bool IsNaN(double d); // 0x00000001815F60C0-0x00000001815F60F0
		[NonVersionable]
		public static bool IsNegative(double d); // 0x00000001815F6110-0x00000001815F6120
		[NonVersionable]
		public static bool IsNegativeInfinity(double d); // 0x00000001815F60F0-0x00000001815F6110
		[NonVersionable]
		public static bool IsPositiveInfinity(double d); // 0x00000001815F6120-0x00000001815F6140
		public int CompareTo(object value); // 0x00000001815F5E30-0x00000001815F5F30
		public int CompareTo(double value); // 0x00000001815F5F30-0x00000001815F5F90
		public override bool Equals(object obj); // 0x00000001815F5F90-0x00000001815F6020
		public bool Equals(double obj); // 0x00000001815F6020-0x00000001815F6060
		public override int GetHashCode(); // 0x0000000180C58C00-0x0000000180C58C30
		public override string ToString(); // 0x00000001815F6A80-0x00000001815F6AF0
		public string ToString(string format); // 0x00000001815F6A00-0x00000001815F6A80
		public string ToString(IFormatProvider provider); // 0x00000001815F6980-0x00000001815F6A00
		public string ToString(string format, IFormatProvider provider); // 0x00000001815F6AF0-0x00000001815F6B80
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001815F6B80-0x00000001815F6C40
		public static double Parse(string s); // 0x00000001815F62D0-0x00000001815F6380
		public static double Parse(string s, IFormatProvider provider); // 0x00000001815F6140-0x00000001815F6200
		public static double Parse(string s, NumberStyles style, IFormatProvider provider); // 0x00000001815F6200-0x00000001815F62D0
		public static bool TryParse(string s, out double result); // 0x00000001815F6CE0-0x00000001815F6D60
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out double result); // 0x00000001815F6C40-0x00000001815F6CE0
		private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info, out double result); // 0x00000001815F6D60-0x00000001815F6F40
		public TypeCode GetTypeCode(); // 0x0000000180A2FD00-0x0000000180A2FD10
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815F6380-0x00000001815F63E0
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001815F6440-0x00000001815F64D0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001815F6710-0x00000001815F6770
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001815F63E0-0x00000001815F6440
		short IConvertible.ToInt16(IFormatProvider provider); // 0x00000001815F65F0-0x00000001815F6650
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001815F6860-0x00000001815F68C0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x00000001815F6650-0x00000001815F66B0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x00000001815F68C0-0x00000001815F6920
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001815F66B0-0x00000001815F6710
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001815F6920-0x00000001815F6980
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001815F6770-0x00000001815F67D0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001815F65E0-0x00000001815F65F0
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001815F6560-0x00000001815F65E0
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001815F64D0-0x00000001815F6560
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001815F67D0-0x00000001815F6860
	}
}
