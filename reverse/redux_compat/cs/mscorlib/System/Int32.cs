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
	public struct Int32 : IComparable, IConvertible, IFormattable, IComparable<int>, IEquatable<int>, ISpanFormattable // TypeDefIndex: 2287
	{
		// Fields
		private readonly int m_value; // 0x00
	
		// Methods
		public int CompareTo(object value); // 0x00000001815FC980-0x00000001815FCA40
		public int CompareTo(int value); // 0x00000001815FCA40-0x00000001815FCA60
		public override bool Equals(object obj); // 0x00000001815FCA60-0x00000001815FCAB0
		[NonVersionable]
		public bool Equals(int obj); // 0x00000001815FCAB0-0x00000001815FCAC0
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public override string ToString(); // 0x00000001815FD360-0x00000001815FD3D0
		public string ToString(string format); // 0x00000001815FD450-0x00000001815FD4F0
		public string ToString(IFormatProvider provider); // 0x00000001815FD3D0-0x00000001815FD450
		public string ToString(string format, IFormatProvider provider); // 0x00000001815FD4F0-0x00000001815FD5A0
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001815FD5A0-0x00000001815FD640
		public static int Parse(string s); // 0x00000001815FCAD0-0x00000001815FCB80
		public static int Parse(string s, NumberStyles style); // 0x00000001815FCDA0-0x00000001815FCE60
		public static int Parse(string s, IFormatProvider provider); // 0x00000001815FCCE0-0x00000001815FCDA0
		public static int Parse(string s, NumberStyles style, IFormatProvider provider); // 0x00000001815FCB80-0x00000001815FCC50
		public static int Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.None | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.Integer /* Metadata: 0x0064E491 */, IFormatProvider provider = null); // 0x00000001815FCC50-0x00000001815FCCE0
		public static bool TryParse(string s, out int result); // 0x00000001815FD7B0-0x00000001815FD920
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out int result); // 0x00000001815FD6E0-0x00000001815FD7B0
		public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out int result); // 0x00000001815FD640-0x00000001815FD6E0
		public TypeCode GetTypeCode(); // 0x00000001815FCAC0-0x00000001815FCAD0
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815FCE60-0x00000001815FCEB0
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001815FCF00-0x00000001815FCF50
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001815FD140-0x00000001815FD190
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001815FCEB0-0x00000001815FCF00
		short IConvertible.ToInt16(IFormatProvider provider); // 0x00000001815FD0A0-0x00000001815FD0F0
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001815FD270-0x00000001815FD2C0
		int IConvertible.ToInt32(IFormatProvider provider); // 0x0000000180732D10-0x0000000180732D20
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x00000001815FD2C0-0x00000001815FD310
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001815FD0F0-0x00000001815FD140
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001815FD310-0x00000001815FD360
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001815FD190-0x00000001815FD1E0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001815FD050-0x00000001815FD0A0
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001815FCFE0-0x00000001815FD050
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001815FCF50-0x00000001815FCFE0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001815FD1E0-0x00000001815FD270
	}
}
