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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	public static class CustomAttributeExtensions // TypeDefIndex: 3336
	{
		// Extension methods
		public static Attribute GetCustomAttribute(this Assembly element, Type attributeType); // 0x00000001815264B0-0x00000001815264C0
		public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType); // 0x00000001815264C0-0x00000001815264D0
		public static T GetCustomAttribute<T>(this Assembly element)
			where T : Attribute;
		public static T GetCustomAttribute<T>(this MemberInfo element)
			where T : Attribute;
		public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, bool inherit); // 0x00000001815264D0-0x00000001815264E0
		public static T GetCustomAttribute<T>(this MemberInfo element, bool inherit)
			where T : Attribute;
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element); // 0x00000001815264F0-0x0000000181526500
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType); // 0x0000000181526500-0x0000000181526510
		public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element)
			where T : Attribute;
		public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType, bool inherit); // 0x00000001815264E0-0x00000001815264F0
		public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element, bool inherit)
			where T : Attribute;
		public static bool IsDefined(this MemberInfo element, Type attributeType); // 0x0000000181526510-0x0000000181526520
	}
}
