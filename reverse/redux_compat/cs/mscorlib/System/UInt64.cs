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
	public struct UInt64 : IComparable, IConvertible, IFormattable, IComparable<ulong>, IEquatable<ulong>, ISpanFormattable // TypeDefIndex: 2362
	{
		// Fields
		private readonly ulong m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x0000000181627910-0x00000001816279D0
		public int CompareTo(ulong value); // 0x00000001816278F0-0x0000000181627910
		public override bool Equals(object obj); // 0x00000001816279D0-0x0000000181627A20
		[NonVersionable]
		public bool Equals(ulong obj); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public override int GetHashCode(); // 0x0000000181627A20-0x0000000181627A30
		public override string ToString(); // 0x0000000181628270-0x00000001816282E0
		public string ToString(IFormatProvider provider); // 0x00000001816281F0-0x0000000181628270
		public string ToString(string format); // 0x00000001816280A0-0x0000000181628140
		public string ToString(string format, IFormatProvider provider); // 0x0000000181628140-0x00000001816281F0
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001816282E0-0x0000000181628390
		[CLSCompliant(false)]
		public static ulong Parse(string s, IFormatProvider provider); // 0x0000000181627A30-0x0000000181627AE0
		[CLSCompliant(false)]
		public static ulong Parse(string s, NumberStyles style, IFormatProvider provider); // 0x0000000181627AE0-0x0000000181627BA0
		[CLSCompliant(false)]
		public static bool TryParse(string s, out ulong result); // 0x0000000181628470-0x0000000181628530
		[CLSCompliant(false)]
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ulong result); // 0x0000000181628390-0x0000000181628470
		public TypeCode GetTypeCode(); // 0x0000000180740840-0x0000000180740850
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x0000000181627BA0-0x0000000181627BF0
		char IConvertible.ToChar(IFormatProvider provider); // 0x0000000181627C40-0x0000000181627C90
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x0000000181627ED0-0x0000000181627F20
		byte IConvertible.ToByte(IFormatProvider provider); // 0x0000000181627BF0-0x0000000181627C40
		short IConvertible.ToInt16(IFormatProvider provider); // 0x0000000181627DE0-0x0000000181627E30
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x0000000181628000-0x0000000181628050
		int IConvertible.ToInt32(IFormatProvider provider); // 0x0000000181627E30-0x0000000181627E80
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x0000000181628050-0x00000001816280A0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x0000000181627E80-0x0000000181627ED0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001808BADD0-0x00000001808BADE0
		float IConvertible.ToSingle(IFormatProvider provider); // 0x0000000181627F20-0x0000000181627F70
		double IConvertible.ToDouble(IFormatProvider provider); // 0x0000000181627D90-0x0000000181627DE0
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x0000000181627D20-0x0000000181627D90
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x0000000181627C90-0x0000000181627D20
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x0000000181627F70-0x0000000181628000
	}
}
