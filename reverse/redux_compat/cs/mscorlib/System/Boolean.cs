/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
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
	public struct Boolean : IComparable, IConvertible, IComparable<bool>, IEquatable<bool> // TypeDefIndex: 2222
	{
		// Fields
		private readonly bool m_value; // 0x00
		public static readonly string TrueString; // 0x00
		public static readonly string FalseString; // 0x08
	
		// Constructors
		static Boolean(); // 0x000000018155EFD0-0x000000018155F070
	
		// Methods
		public override int GetHashCode(); // 0x000000018155E200-0x000000018155E210
		public override string ToString(); // 0x000000018155E980-0x000000018155E9D0
		public string ToString(IFormatProvider provider); // 0x000000018155E9D0-0x000000018155EA30
		public override bool Equals(object obj); // 0x000000018155E190-0x000000018155E1F0
		[NonVersionable]
		public bool Equals(bool obj); // 0x000000018155E1F0-0x000000018155E200
		public int CompareTo(object obj); // 0x000000018155E0D0-0x000000018155E190
		public int CompareTo(bool value); // 0x000000018155E0B0-0x000000018155E0D0
		public static bool Parse(string value); // 0x000000018155E2B0-0x000000018155E3D0
		public static bool Parse(ReadOnlySpan<char> value); // 0x000000018155E210-0x000000018155E2B0
		public static bool TryParse(string value, out bool result); // 0x000000018155EF50-0x000000018155EFD0
		public static bool TryParse(ReadOnlySpan<char> value, out bool result); // 0x000000018155EC50-0x000000018155EF50
		private static ReadOnlySpan<char> TrimWhiteSpaceAndNull(ReadOnlySpan<char> value); // 0x000000018155EA30-0x000000018155EC50
		public TypeCode GetTypeCode(); // 0x000000018071E4A0-0x000000018071E4B0
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x000000018155E3D0-0x000000018155E3E0
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018155E430-0x000000018155E4C0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x000000018155E750-0x000000018155E7A0
		byte IConvertible.ToByte(IFormatProvider provider); // 0x000000018155E3E0-0x000000018155E430
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018155E660-0x000000018155E6B0
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018155E890-0x000000018155E8E0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x000000018155E6B0-0x000000018155E700
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x000000018155E8E0-0x000000018155E930
		long IConvertible.ToInt64(IFormatProvider provider); // 0x000000018155E700-0x000000018155E750
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x000000018155E930-0x000000018155E980
		float IConvertible.ToSingle(IFormatProvider provider); // 0x000000018155E7A0-0x000000018155E800
		double IConvertible.ToDouble(IFormatProvider provider); // 0x000000018155E600-0x000000018155E660
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x000000018155E550-0x000000018155E600
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x000000018155E4C0-0x000000018155E550
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x000000018155E800-0x000000018155E890
	}
}
