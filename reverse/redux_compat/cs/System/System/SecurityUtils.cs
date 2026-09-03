/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System
{
	internal static class SecurityUtils // TypeDefIndex: 8656
	{
		// Methods
		private static void DemandReflectionAccess(Type type); // 0x00000001802E76C0-0x00000001802E76D0
		private static void DemandGrantSet(Assembly assembly); // 0x00000001802E76C0-0x00000001802E76D0
		private static bool HasReflectionPermission(Type type); // 0x0000000181B55260-0x0000000181B55280
		internal static object SecureCreateInstance(Type type); // 0x0000000181B55670-0x0000000181B55730
		internal static object SecureCreateInstance(Type type, object[] args, bool allowNonPublic); // 0x0000000181B55730-0x0000000181B55830
		internal static object SecureCreateInstance(Type type, object[] args); // 0x0000000181B55830-0x0000000181B558F0
		internal static object SecureConstructorInvoke(Type type, Type[] argTypes, object[] args, bool allowNonPublic); // 0x0000000181B55390-0x0000000181B55500
		internal static object SecureConstructorInvoke(Type type, Type[] argTypes, object[] args, bool allowNonPublic, BindingFlags extraFlags); // 0x0000000181B55500-0x0000000181B55670
		private static bool GenericArgumentsAreVisible(MethodInfo method); // 0x0000000181B551B0-0x0000000181B55260
		internal static object MethodInfoInvoke(MethodInfo method, object target, object[] args); // 0x0000000181B55280-0x0000000181B55390
	}
}
