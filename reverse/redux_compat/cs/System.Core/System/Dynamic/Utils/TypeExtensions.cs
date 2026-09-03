/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic.Utils
{
	internal static class TypeExtensions // TypeDefIndex: 12592
	{
		// Fields
		private static readonly CacheDict<MethodBase, ParameterInfo[]> s_paramInfoCache; // 0x00
	
		// Constructors
		static TypeExtensions(); // 0x0000000181809AE0-0x0000000181809B70
	
		// Extension methods
		public static MethodInfo GetAnyStaticMethodValidated(this Type type, string name, Type[] types); // 0x0000000181809620-0x00000001818096D0
		private static bool MatchesArgumentTypes(this MethodInfo mi, Type[] argTypes); // 0x00000001818098B0-0x0000000181809AE0
		public static Type GetReturnType(this MethodBase mi); // 0x00000001818097F0-0x0000000181809880
		public static TypeCode GetTypeCode(this Type type); // 0x0000000181809880-0x00000001818098B0
		internal static ParameterInfo[] GetParametersCached(this MethodBase method); // 0x00000001818096D0-0x00000001818097F0
	}
}
