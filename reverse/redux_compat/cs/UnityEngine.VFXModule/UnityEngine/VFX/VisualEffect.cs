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

// Image 57: UnityEngine.VFXModule.dll - Assembly: UnityEngine.VFXModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15667-15684

namespace UnityEngine.VFX
{
	[NativeClass("VisualEffect", PersistentTypeId = 2083052967)]
	[NativeHeader("Modules/VFX/Public/VisualEffect.h")]
	[NativeHeader("Modules/VFX/Public/ScriptBindings/VisualEffectBindings.h")]
	[RequireComponent(typeof(Transform))]
	public class VisualEffect : Behaviour // TypeDefIndex: 15683
	{
		// Fields
		private VFXEventAttribute m_cachedEventAttribute; // 0x18
		public Action<VFXOutputEventArgs> outputEventReceived; // 0x20
	
		// Properties
		public VisualEffectAsset visualEffectAsset { get; } // 0x00000001825D2EC0-0x00000001825D2FC0 
	
		// Methods
		public VFXEventAttribute CreateVFXEventAttribute(); // 0x00000001825D2B20-0x00000001825D2C80
		[RequiredByNativeCode]
		private static VFXEventAttribute InvokeGetCachedEventAttributeForOutputEvent_Internal(VisualEffect source); // 0x00000001825D2C80-0x00000001825D2E20
		[RequiredByNativeCode]
		private static void InvokeOutputEventReceived_Internal(VisualEffect source, int eventNameId); // 0x00000001825D2E20-0x00000001825D2E80
		private static IntPtr get_visualEffectAsset_Injected(IntPtr _unity_self); // 0x00000001825D2E80-0x00000001825D2EC0
	}
}
