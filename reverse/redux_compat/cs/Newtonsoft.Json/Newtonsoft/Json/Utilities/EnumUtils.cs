/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class EnumUtils // TypeDefIndex: 10138
	{
		// Fields
		private const char EnumSeparatorChar = ','; // Metadata: 0x006A095C
		private const string EnumSeparatorString = ", "; // Metadata: 0x006A095E
		[Nullable(new byte[5] {1, 0, 1, 2, 1 })]
		private static readonly ThreadSafeStore<StructMultiKey<Type, NamingStrategy>, EnumInfo> ValuesAndNamesPerEnum; // 0x00
		private static CamelCaseNamingStrategy _camelCaseNamingStrategy; // 0x08
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10139
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<EnumMemberAttribute, string> __9__3_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001816FB6D0-0x00000001816FB740
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal string _InitializeValuesAndNames_b__3_0(EnumMemberAttribute a); // 0x000000018052BA80-0x000000018052BAA0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__4<T> // TypeDefIndex: 10140
			where T : struct
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__4<T> __9;
			[Nullable(0)]
			public static Func<ulong, bool> __9__4_0;
	
			// Constructors
			static __c__4();
			public __c__4();
	
			// Methods
			internal bool _GetFlagsValues_b__4_0(ulong v);
		}
	
		// Constructors
		static EnumUtils(); // 0x00000001816EF4A0-0x00000001816EF5C0
	
		// Methods
		private static EnumInfo InitializeValuesAndNames([Nullable(new byte[3] {0, 1, 2 })] StructMultiKey<Type, NamingStrategy> key); // 0x00000001816EDE80-0x00000001816EE3D0
		[NullableContext(0)]
		public static IList<T> GetFlagsValues<T>(T value)
			where T : struct;
		public static bool TryToString(Type enumType, object value, bool camelCase, [Nullable(2)] [NotNullWhen(true)] out string name); // 0x00000001816EF2C0-0x00000001816EF4A0
		public static bool TryToString(Type enumType, object value, [Nullable(2)] NamingStrategy namingStrategy, [Nullable(2)] [NotNullWhen(true)] out string name); // 0x00000001816EF140-0x00000001816EF2C0
		private static string InternalFlagsFormat(EnumInfo entry, ulong result); // 0x00000001816EE3D0-0x00000001816EE570
		public static EnumInfo GetEnumValuesAndNames(Type enumType); // 0x00000001816EDDD0-0x00000001816EDE80
		private static ulong ToUInt64(object value); // 0x00000001816EEE50-0x00000001816EF140
		public static object ParseEnum(Type enumType, [Nullable(2)] NamingStrategy namingStrategy, string value, bool disallowNumber); // 0x00000001816EE630-0x00000001816EEE50
		private static int? MatchName(string value, string[] enumNames, string[] resolvedNames, int valueIndex, int valueSubstringLength, StringComparison comparison); // 0x00000001816EE570-0x00000001816EE630
		private static int? FindIndexByName(string[] enumNames, string value, int valueIndex, int valueSubstringLength, StringComparison comparison); // 0x00000001816EDD00-0x00000001816EDDD0
	}
}
