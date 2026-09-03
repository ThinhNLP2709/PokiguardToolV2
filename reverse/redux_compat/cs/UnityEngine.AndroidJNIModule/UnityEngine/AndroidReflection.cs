/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine
{
	internal class AndroidReflection // TypeDefIndex: 14776
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly GlobalJavaObjectRef s_ReflectionHelperClass; // 0x00
		private static readonly IntPtr s_ReflectionHelperGetConstructorID; // 0x08
		private static readonly IntPtr s_ReflectionHelperGetMethodID; // 0x10
		private static readonly IntPtr s_ReflectionHelperGetFieldID; // 0x18
		private static readonly IntPtr s_ReflectionHelperGetFieldSignature; // 0x20
		private static readonly IntPtr s_ReflectionHelperNewProxyInstance; // 0x28
		private static readonly IntPtr s_ReflectionHelperCeateInvocationError; // 0x30
		private static readonly IntPtr s_FieldGetDeclaringClass; // 0x38
	
		// Constructors
		static AndroidReflection(); // 0x0000000182150AE0-0x0000000182150DC0
	
		// Methods
		public static bool IsPrimitive(Type t); // 0x000000018171CC60-0x000000018171CC80
		public static bool IsAssignableFrom(Type t, Type from); // 0x0000000182150990-0x00000001821509C0
		private static IntPtr GetStaticMethodID(string clazz, string methodName, string signature); // 0x00000001821508C0-0x0000000182150990
		private static IntPtr GetMethodID(string clazz, string methodName, string signature); // 0x00000001821505E0-0x00000001821506B0
		public static IntPtr GetConstructorMember(IntPtr jclass, string signature); // 0x0000000182150430-0x00000001821505E0
		public static IntPtr GetMethodMember(IntPtr jclass, string methodName, string signature, bool isStatic); // 0x00000001821506B0-0x00000001821508C0
		public static IntPtr NewProxyInstance(IntPtr player, IntPtr delegateHandle, IntPtr interfaze); // 0x00000001821509C0-0x0000000182150AE0
		internal static IntPtr CreateInvocationError(Exception ex, bool methodNotFound); // 0x0000000182150300-0x0000000182150430
	}
}
