/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class Enum : IComparable, IFormattable, IConvertible // TypeDefIndex: 2421
	{
		// Fields
		private static readonly char[] enumSeperatorCharArray; // 0x00
		private const string enumSeperator = ", "; // Metadata: 0x0064E5F6
	
		// Nested types
		private enum ParseFailureKind // TypeDefIndex: 2422
		{
			None = 0,
			Argument = 1,
			ArgumentNull = 2,
			ArgumentWithParameter = 3,
			UnhandledException = 4
		}
	
		private struct EnumResult // TypeDefIndex: 2423
		{
			// Fields
			internal object parsedEnum; // 0x00
			internal bool canThrow; // 0x08
			internal ParseFailureKind m_failure; // 0x0C
			internal string m_failureMessageID; // 0x10
			internal string m_failureParameter; // 0x18
			internal object m_failureMessageFormatArgument; // 0x20
			internal Exception m_innerException; // 0x28
	
			// Methods
			internal void Init(bool canMethodThrow); // 0x0000000181635280-0x00000001816352D0
			internal void SetFailure(Exception unhandledException); // 0x00000001816352D0-0x00000001816352F0
			internal void SetFailure(ParseFailureKind failure, string failureParameter); // 0x00000001816352F0-0x0000000181635340
			internal void SetFailure(ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument); // 0x0000000181635340-0x00000001816353B0
			internal Exception GetEnumParseException(); // 0x00000001816350A0-0x0000000181635280
		}
	
		private class ValuesAndNames // TypeDefIndex: 2424
		{
			// Fields
			public ulong[] Values; // 0x10
			public string[] Names; // 0x18
	
			// Constructors
			public ValuesAndNames(ulong[] values, string[] names); // 0x0000000180CB0730-0x0000000180CB0780
		}
	
		// Constructors
		protected Enum(); // 0x00000001802F4070-0x00000001802F4080
		static Enum(); // 0x0000000181639D20-0x0000000181639DA0
	
		// Methods
		private static ValuesAndNames GetCachedValuesAndNames(RuntimeType enumType, bool getNames); // 0x0000000181635C40-0x0000000181635DC0
		private static string InternalFormattedHexString(object value); // 0x00000001816368F0-0x0000000181636D60
		private static string InternalFormat(RuntimeType eT, object value); // 0x0000000181636780-0x00000001816368F0
		private static string InternalFlagsFormat(RuntimeType eT, object value); // 0x0000000181636580-0x0000000181636780
		internal static ulong ToUInt64(object value); // 0x00000001816393D0-0x0000000181639520
		private static int InternalCompareTo(object o1, object o2); // 0x0000000181636570-0x0000000181636580
		internal static RuntimeType InternalGetUnderlyingType(RuntimeType enumType); // 0x0000000181636DA0-0x0000000181636DB0
		private static bool GetEnumValuesAndNames(RuntimeType enumType, out ulong[] values, out string[] names); // 0x0000000181635DC0-0x0000000181635DD0
		private static object InternalBoxEnum(RuntimeType enumType, long value); // 0x0000000181636560-0x0000000181636570
		public static bool TryParse<TEnum>(string value, out ref TEnum result)
			where TEnum : struct;
		public static bool TryParse<TEnum>(string value, bool ignoreCase, out ref TEnum result)
			where TEnum : struct;
		[ComVisible(true)]
		public static object Parse(Type enumType, string value); // 0x0000000181636F80-0x0000000181637060
		[ComVisible(true)]
		public static object Parse(Type enumType, string value, bool ignoreCase); // 0x0000000181636EB0-0x0000000181636F80
		private static bool TryParseEnum(Type enumType, string value, bool ignoreCase, ref EnumResult parseResult); // 0x0000000181639520-0x0000000181639B90
		[ComVisible(true)]
		public static Type GetUnderlyingType(Type enumType); // 0x0000000181636270-0x0000000181636310
		[ComVisible(true)]
		public static Array GetValues(Type enumType); // 0x0000000181636320-0x00000001816363C0
		internal static ulong[] InternalGetValues(RuntimeType enumType); // 0x0000000181636DB0-0x0000000181636DF0
		[ComVisible(true)]
		public static string GetName(Type enumType, object value); // 0x0000000181635DE0-0x0000000181635E90
		[ComVisible(true)]
		public static string[] GetNames(Type enumType); // 0x0000000181635E90-0x0000000181635F30
		internal static string[] InternalGetNames(RuntimeType enumType); // 0x0000000181636D60-0x0000000181636DA0
		[ComVisible(true)]
		public static object ToObject(Type enumType, object value); // 0x0000000181638870-0x0000000181638CD0
		[ComVisible(true)]
		public static bool IsDefined(Type enumType, object value); // 0x0000000181636E00-0x0000000181636EB0
		[ComVisible(true)]
		public static string Format(Type enumType, object value, string format); // 0x00000001816355B0-0x0000000181635C40
		private object get_value(); // 0x0000000181636310-0x0000000181636320
		internal object GetValue(); // 0x0000000181636310-0x0000000181636320
		private bool InternalHasFlag(Enum flags); // 0x0000000181636DF0-0x0000000181636E00
		private int get_hashcode(); // 0x0000000181635DD0-0x0000000181635DE0
		public override bool Equals(object obj); // 0x00000001816355A0-0x00000001816355B0
		public override int GetHashCode(); // 0x0000000181635DD0-0x0000000181635DE0
		public override string ToString(); // 0x00000001816390E0-0x0000000181639170
		[Obsolete("The provider argument is not used. Please use ToString(String).")]
		public string ToString(string format, IFormatProvider provider); // 0x00000001816390D0-0x00000001816390E0
		public int CompareTo(object target); // 0x00000001816353B0-0x00000001816355A0
		public string ToString(string format); // 0x0000000181639170-0x00000001816393D0
		[Obsolete("The provider argument is not used. Please use ToString().")]
		public string ToString(IFormatProvider provider); // 0x00000001815A1B20-0x00000001815A1B40
		public bool HasFlag(Enum flag); // 0x00000001816363C0-0x0000000181636560
		public TypeCode GetTypeCode(); // 0x0000000181635F30-0x0000000181636270
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x0000000181637060-0x00000001816370E0
		char IConvertible.ToChar(IFormatProvider provider); // 0x0000000181637160-0x00000001816371E0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x0000000181637580-0x0000000181637600
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001816370E0-0x0000000181637160
		short IConvertible.ToInt16(IFormatProvider provider); // 0x0000000181637400-0x0000000181637480
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001816376F0-0x0000000181637770
		int IConvertible.ToInt32(IFormatProvider provider); // 0x0000000181637480-0x0000000181637500
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x0000000181637770-0x00000001816377F0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x0000000181637500-0x0000000181637580
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001816377F0-0x0000000181637870
		float IConvertible.ToSingle(IFormatProvider provider); // 0x0000000181637600-0x0000000181637680
		double IConvertible.ToDouble(IFormatProvider provider); // 0x0000000181637380-0x0000000181637400
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001816372E0-0x0000000181637380
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001816371E0-0x00000001816372E0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x0000000181637680-0x00000001816376F0
		[CLSCompliant(false)]
		[ComVisible(true)]
		public static object ToObject(Type enumType, sbyte value); // 0x0000000181638ED0-0x00000001816390D0
		[ComVisible(true)]
		public static object ToObject(Type enumType, short value); // 0x0000000181637870-0x0000000181637A70
		[ComVisible(true)]
		public static object ToObject(Type enumType, int value); // 0x0000000181637C70-0x0000000181637E70
		[ComVisible(true)]
		public static object ToObject(Type enumType, byte value); // 0x0000000181638270-0x0000000181638470
		[CLSCompliant(false)]
		[ComVisible(true)]
		public static object ToObject(Type enumType, ushort value); // 0x0000000181638470-0x0000000181638670
		[CLSCompliant(false)]
		[ComVisible(true)]
		public static object ToObject(Type enumType, uint value); // 0x0000000181638670-0x0000000181638870
		[ComVisible(true)]
		public static object ToObject(Type enumType, long value); // 0x0000000181637E70-0x0000000181638070
		[CLSCompliant(false)]
		[ComVisible(true)]
		public static object ToObject(Type enumType, ulong value); // 0x0000000181638CD0-0x0000000181638ED0
		private static object ToObject(Type enumType, char value); // 0x0000000181638070-0x0000000181638270
		private static object ToObject(Type enumType, bool value); // 0x0000000181637A70-0x0000000181637C70
		public static bool TryParse(Type enumType, string value, bool ignoreCase, out object result); // 0x0000000181639C60-0x0000000181639D20
		public static bool TryParse(Type enumType, string value, out object result); // 0x0000000181639B90-0x0000000181639C60
	}
}
