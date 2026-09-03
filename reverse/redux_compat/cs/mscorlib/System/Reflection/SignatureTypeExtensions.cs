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

namespace System.Reflection
{
	internal static class SignatureTypeExtensions // TypeDefIndex: 3325
	{
		// Extension methods
		public static bool MatchesParameterTypeExactly(this Type pattern, ParameterInfo parameter); // 0x000000018153CA50-0x000000018153CB20
		internal static bool MatchesExactly(this SignatureType pattern, Type actual); // 0x000000018153C670-0x000000018153CA50
		internal static Type TryResolveAgainstGenericMethod(this SignatureType signatureType, MethodInfo genericMethod); // 0x000000018153CC10-0x000000018153CC50
		private static Type TryResolve(this SignatureType signatureType, Type[] genericMethodParameters); // 0x000000018153CC50-0x000000018153D0A0
		private static Type TryMakeArrayType(this Type type); // 0x000000018153CB50-0x000000018153CB80
		private static Type TryMakeArrayType(this Type type, int rank); // 0x000000018153CB20-0x000000018153CB50
		private static Type TryMakeByRefType(this Type type); // 0x000000018153CB80-0x000000018153CBB0
		private static Type TryMakePointerType(this Type type); // 0x000000018153CBE0-0x000000018153CC10
		private static Type TryMakeGenericType(this Type type, Type[] instantiation); // 0x000000018153CBB0-0x000000018153CBE0
	}
}
