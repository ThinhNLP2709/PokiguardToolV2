/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExtensionOfNativeClass]
	[NativeClass(null)]
	[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
	[RequiredByNativeCode]
	public class ScriptableObject : Object // TypeDefIndex: 7766
	{
		// Constructors
		public ScriptableObject(); // 0x00000001821F9790-0x00000001821F9800
	
		// Methods
		public static ScriptableObject CreateInstance(Type type); // 0x00000001821F9630-0x00000001821F9690
		public static T CreateInstance<T>()
			where T : ScriptableObject;
		[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
		private static void CreateScriptableObject([Writable] ScriptableObject self); // 0x00000001821F9750-0x00000001821F9790
		[NativeMethod(Name = "Scripting::CreateScriptableObjectWithType", IsFreeFunction = true, ThrowsException = true)]
		internal static ScriptableObject CreateScriptableObjectInstanceFromType(Type type, bool applyDefaultsAndReset); // 0x00000001821F96E0-0x00000001821F9750
		private static IntPtr CreateScriptableObjectInstanceFromType_Injected(Type type, bool applyDefaultsAndReset); // 0x00000001821F9690-0x00000001821F96E0
	}
}
