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
	internal struct MonoMethodInfo // TypeDefIndex: 3352
	{
		// Fields
		private Type parent; // 0x00
		private Type ret; // 0x08
		internal MethodAttributes attrs; // 0x10
		internal MethodImplAttributes iattrs; // 0x14
		private CallingConventions callconv; // 0x18
	
		// Methods
		private static void get_method_info(IntPtr handle, out MonoMethodInfo info); // 0x000000018152DC50-0x000000018152DC60
		private static int get_method_attributes(IntPtr handle); // 0x000000018152DA70-0x000000018152DA80
		internal static MonoMethodInfo GetMethodInfo(IntPtr handle); // 0x000000018152DB10-0x000000018152DB40
		internal static Type GetDeclaringType(IntPtr handle); // 0x000000018152DAB0-0x000000018152DAE0
		internal static Type GetReturnType(IntPtr handle); // 0x000000018152DC20-0x000000018152DC50
		internal static MethodAttributes GetAttributes(IntPtr handle); // 0x000000018152DA70-0x000000018152DA80
		internal static CallingConventions GetCallingConvention(IntPtr handle); // 0x000000018152DA80-0x000000018152DAB0
		internal static MethodImplAttributes GetMethodImplementationFlags(IntPtr handle); // 0x000000018152DAE0-0x000000018152DB10
		private static ParameterInfo[] get_parameter_info(IntPtr handle, MemberInfo member); // 0x000000018152DB40-0x000000018152DB50
		internal static ParameterInfo[] GetParametersInfo(IntPtr handle, MemberInfo member); // 0x000000018152DB40-0x000000018152DB50
		private static MarshalAsAttribute get_retval_marshal(IntPtr handle); // 0x00000001814CAEE0-0x00000001814CAEF0
		internal static ParameterInfo GetReturnParameterInfo(RuntimeMethodInfo method); // 0x000000018152DB50-0x000000018152DC20
	}
}
