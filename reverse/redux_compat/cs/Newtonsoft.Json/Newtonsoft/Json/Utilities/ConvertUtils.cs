/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class ConvertUtils // TypeDefIndex: 10105
	{
		// Fields
		private static readonly Dictionary<Type, PrimitiveTypeCode> TypeCodeMap; // 0x00
		private static readonly TypeInformation[] PrimitiveTypeCodes; // 0x08
		[Nullable(new byte[7] {1, 0, 1, 1, 2, 2, 2 })]
		private static readonly ThreadSafeStore<StructMultiKey<Type, Type>, Func<object, object>> CastConverters; // 0x10
	
		// Nested types
		[NullableContext(0)]
		internal enum ConvertResult // TypeDefIndex: 10106
		{
			Success = 0,
			CannotConvertNull = 1,
			NotInstantiableType = 2,
			NoValidConversion = 3
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 10107
		{
			// Fields
			[Nullable(new byte[3] {0, 2, 2 })]
			public MethodCall<object, object> call; // 0x10
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(2)]
			internal object _CreateCastConverter_b__0(object o); // 0x00000001816FB600-0x00000001816FB6D0
		}
	
		// Constructors
		static ConvertUtils(); // 0x00000001816E83B0-0x00000001816E9560
	
		// Methods
		public static PrimitiveTypeCode GetTypeCode(Type t); // 0x00000001816E6CC0-0x00000001816E6D20
		public static PrimitiveTypeCode GetTypeCode(Type t, out bool isEnum); // 0x00000001816E6D20-0x00000001816E6F60
		public static TypeInformation GetTypeInformation(IConvertible convertable); // 0x00000001816E6F60-0x00000001816E7000
		public static bool IsConvertible(Type t); // 0x00000001816E7330-0x00000001816E73A0
		public static TimeSpan ParseTimeSpan(string input); // 0x00000001816E74B0-0x00000001816E7530
		[NullableContext(2)]
		private static Func<object, object> CreateCastConverter([Nullable(new byte[3] {0, 1, 1 })] StructMultiKey<Type, Type> t); // 0x00000001816E5C50-0x00000001816E5ED0
		internal static BigInteger ToBigInteger(object value); // 0x00000001816E7530-0x00000001816E7930
		public static object FromBigInteger(BigInteger i, Type targetType); // 0x00000001816E6900-0x00000001816E6CC0
		public static object Convert(object initialValue, CultureInfo culture, Type targetType); // 0x00000001816E59B0-0x00000001816E5C50
		private static bool TryConvert([Nullable(2)] object initialValue, CultureInfo culture, Type targetType, [Nullable(2)] out object value); // 0x00000001816E8240-0x00000001816E82F0
		private static ConvertResult TryConvertInternal([Nullable(2)] object initialValue, CultureInfo culture, Type targetType, [Nullable(2)] out object value); // 0x00000001816E7980-0x00000001816E8240
		public static object ConvertOrCast([Nullable(2)] object initialValue, CultureInfo culture, Type targetType); // 0x00000001816E5860-0x00000001816E59B0
		private static object EnsureTypeAssignable([Nullable(2)] object value, Type initialType, Type targetType); // 0x00000001816E66D0-0x00000001816E6900
		public static bool VersionTryParse(string input, [Nullable(2)] [NotNullWhen(true)] out Version result); // 0x00000001816E83A0-0x00000001816E83B0
		public static bool IsInteger(object value); // 0x00000001816E73A0-0x00000001816E74B0
		public static ParseResult Int32TryParse(char[] chars, int start, int length, out int value); // 0x00000001816E7000-0x00000001816E71A0
		public static ParseResult Int64TryParse(char[] chars, int start, int length, out long value); // 0x00000001816E71A0-0x00000001816E7330
		public static ParseResult DecimalTryParse(char[] chars, int start, int length, out decimal value); // 0x00000001816E5ED0-0x00000001816E66D0
		public static bool TryConvertGuid(string s, out Guid g); // 0x00000001816E7930-0x00000001816E7980
		public static bool TryHexTextToInt(char[] text, int start, int end, out int value); // 0x00000001816E82F0-0x00000001816E83A0
	}
}
