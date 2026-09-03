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
	[NativeClass("Behaviour", PersistentTypeId = 8)]
	[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
	[UsedByNativeCode]
	public class Behaviour : Component // TypeDefIndex: 7733
	{
		// Properties
		[NativeProperty]
		[RequiredByNativeCode]
		public bool enabled { get; set; } // 0x00000001821E45F0-0x00000001821E4650 0x00000001821E4740-0x00000001821E47A0
		[NativeProperty]
		public bool isActiveAndEnabled { [NativeMethod("IsAddedToManager")] get; } // 0x00000001821E4690-0x00000001821E46F0 
	
		// Constructors
		public Behaviour(); // 0x00000001821E4560-0x00000001821E45B0
	
		// Methods
		private static bool get_enabled_Injected(IntPtr _unity_self); // 0x00000001821E45B0-0x00000001821E45F0
		private static void set_enabled_Injected(IntPtr _unity_self, bool value); // 0x00000001821E46F0-0x00000001821E4740
		private static bool get_isActiveAndEnabled_Injected(IntPtr _unity_self); // 0x00000001821E4650-0x00000001821E4690
	}
}
