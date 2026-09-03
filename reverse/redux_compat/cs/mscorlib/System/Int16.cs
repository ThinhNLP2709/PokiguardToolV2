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
	public struct Int16 : IComparable, IConvertible, IFormattable, IComparable<short>, IEquatable<short>, ISpanFormattable // TypeDefIndex: 2286
	{
		// Fields
		private readonly short m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x00000001815FBA40-0x00000001815FBAF0
		public int CompareTo(short value); // 0x00000001815FBAF0-0x00000001815FBB00
		public override bool Equals(object obj); // 0x00000001815FBB00-0x00000001815FBB60
		[NonVersionable]
		public bool Equals(short obj); // 0x0000000181560960-0x0000000181560970
		public override int GetHashCode(); // 0x00000001815FBB60-0x00000001815FBB70
		public override string ToString(); // 0x00000001815FC500-0x00000001815FC570
		public string ToString(IFormatProvider provider); // 0x00000001815FC480-0x00000001815FC500
		public string ToString(string format, IFormatProvider provider); // 0x00000001815FC320-0x00000001815FC480
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001815FC570-0x00000001815FC690
		public static short Parse(string s, IFormatProvider provider); // 0x00000001815FBB70-0x00000001815FBBF0
		public static short Parse(string s, NumberStyles style, IFormatProvider provider); // 0x00000001815FBBF0-0x00000001815FBC90
		private static short Parse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info); // 0x00000001815FBC90-0x00000001815FBE20
		public static bool TryParse(string s, out short result); // 0x00000001815FC760-0x00000001815FC8E0
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out short result); // 0x00000001815FC8E0-0x00000001815FC980
		private static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, NumberFormatInfo info, out short result); // 0x00000001815FC690-0x00000001815FC760
		public TypeCode GetTypeCode(); // 0x0000000180A2FB20-0x0000000180A2FB30
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815FBE20-0x00000001815FBE70
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001815FBEC0-0x00000001815FBF10
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001815FC100-0x00000001815FC150
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001815FBE70-0x00000001815FBEC0
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018123AD30-0x000000018123AD40
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001815FC230-0x00000001815FC280
		int IConvertible.ToInt32(IFormatProvider provider); // 0x00000001815FC060-0x00000001815FC0B0
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x00000001815FC280-0x00000001815FC2D0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001815FC0B0-0x00000001815FC100
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001815FC2D0-0x00000001815FC320
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001815FC150-0x00000001815FC1A0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001815FC010-0x00000001815FC060
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001815FBFA0-0x00000001815FC010
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001815FBF10-0x00000001815FBFA0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001815FC1A0-0x00000001815FC230
	}
}
