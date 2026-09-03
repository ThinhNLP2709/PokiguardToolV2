/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	[ComVisible(true)]
	public static class FormatterServices // TypeDefIndex: 3030
	{
		// Fields
		internal static ConcurrentDictionary<MemberHolder, MemberInfo[]> m_MemberInfoTable; // 0x00
		private static bool unsafeTypeForwardersIsEnabled; // 0x08
		private static bool unsafeTypeForwardersIsEnabledInitialized; // 0x09
		private static readonly Type[] advancedTypes; // 0x10
		private static Binder s_binder; // 0x18
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 3031
		{
			// Fields
			public Type type; // 0x10
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal MemberInfo[] _GetSerializableMembers_b__0(MemberHolder _); // 0x00000001814ED040-0x00000001814ED0E0
		}
	
		// Constructors
		static FormatterServices(); // 0x00000001814DD250-0x00000001814DD410
	
		// Methods
		private static MemberInfo[] GetSerializableMembers(RuntimeType type); // 0x00000001814DBD90-0x00000001814DBF50
		private static bool CheckSerializable(RuntimeType type); // 0x00000001814DACC0-0x00000001814DACF0
		private static MemberInfo[] InternalGetSerializableMembers(RuntimeType type); // 0x00000001814DC470-0x00000001814DCB70
		private static bool GetParentTypes(RuntimeType parentType, out RuntimeType[] parentTypes, out int parentTypeCount); // 0x00000001814DB920-0x00000001814DBD90
		public static MemberInfo[] GetSerializableMembers(Type type, StreamingContext context); // 0x00000001814DBF50-0x00000001814DC200
		public static object GetUninitializedObject(Type type); // 0x00000001814DC2B0-0x00000001814DC470
		private static object nativeGetUninitializedObject(RuntimeType type); // 0x00000001814CE6A0-0x00000001814CE6B0
		private static bool GetEnableUnsafeTypeForwarders(); // 0x00000001802E7840-0x00000001802E7850
		internal static bool UnsafeTypeForwardersIsEnabled(); // 0x00000001814DD1B0-0x00000001814DD250
		internal static void SerializationSetValue(MemberInfo fi, object target, object value); // 0x00000001814DCF80-0x00000001814DD1B0
		public static object PopulateObjectMembers(object obj, MemberInfo[] members, object[] data); // 0x00000001814DCBE0-0x00000001814DCF80
		public static object[] GetObjectData(object obj, MemberInfo[] members); // 0x00000001814DB4E0-0x00000001814DB920
		public static Type GetTypeFromAssembly(Assembly assem, string name); // 0x00000001814DC200-0x00000001814DC2B0
		internal static Assembly LoadAssemblyFromString(string assemblyName); // 0x00000001814DCBD0-0x00000001814DCBE0
		internal static Assembly LoadAssemblyFromStringNoThrow(string assemblyName); // 0x00000001814DCB70-0x00000001814DCBD0
		internal static string GetClrAssemblyName(Type type, out bool hasTypeForwardedFrom); // 0x00000001814DACF0-0x00000001814DAE70
		internal static string GetClrTypeFullName(Type type); // 0x00000001814DB460-0x00000001814DB4E0
		private static string GetClrTypeFullNameForArray(Type type); // 0x00000001814DAE70-0x00000001814DB080
		private static string GetClrTypeFullNameForNonArrayTypes(Type type); // 0x00000001814DB080-0x00000001814DB460
	}
}
