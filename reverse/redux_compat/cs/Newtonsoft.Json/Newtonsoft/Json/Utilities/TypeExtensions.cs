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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class TypeExtensions // TypeDefIndex: 10189
	{
		// Extension methods
		public static MethodInfo Method(this Delegate d); // 0x000000018171CD10-0x000000018171CD30
		public static MemberTypes MemberType(this MemberInfo memberInfo); // 0x000000018171CCE0-0x000000018171CD10
		public static bool ContainsGenericParameters(this Type type); // 0x000000018171C880-0x000000018171C8B0
		public static bool IsInterface(this Type type); // 0x000000018171CC40-0x000000018171CC60
		public static bool IsGenericType(this Type type); // 0x000000018171CC10-0x000000018171CC40
		public static bool IsGenericTypeDefinition(this Type type); // 0x000000018171CBE0-0x000000018171CC10
		public static Type BaseType(this Type type); // 0x000000018171C850-0x000000018171C880
		public static Assembly Assembly(this Type type); // 0x000000018171C660-0x000000018171C690
		public static bool IsEnum(this Type type); // 0x000000018171CBB0-0x000000018171CBE0
		public static bool IsClass(this Type type); // 0x000000018171CB90-0x000000018171CBB0
		public static bool IsSealed(this Type type); // 0x000000018171CC80-0x000000018171CCA0
		public static bool IsAbstract(this Type type); // 0x000000018171CB70-0x000000018171CB90
		public static bool IsVisible(this Type type); // 0x000000018171CCC0-0x000000018171CCE0
		public static bool IsValueType(this Type type); // 0x000000018171CCA0-0x000000018171CCC0
		public static bool IsPrimitive(this Type type); // 0x000000018171CC60-0x000000018171CC80
		public static bool AssignableToTypeName(this Type type, string fullTypeName, bool searchInterfaces, [Nullable(2)] [NotNullWhen(true)] out Type match); // 0x000000018171C6B0-0x000000018171C850
		public static bool AssignableToTypeName(this Type type, string fullTypeName, bool searchInterfaces); // 0x000000018171C690-0x000000018171C6B0
		public static bool ImplementInterface(this Type type, Type interfaceType); // 0x000000018171C8B0-0x000000018171CB70
	}
}
