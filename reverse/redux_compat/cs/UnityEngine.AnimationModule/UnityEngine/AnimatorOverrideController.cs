/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine
{
	[HelpURL("AnimatorOverrideController")]
	[NativeClass("AnimatorOverrideController", PersistentTypeId = 221)]
	[NativeHeader("Modules/Animation/AnimatorOverrideController.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
	[UsedByNativeCode]
	public class AnimatorOverrideController : RuntimeAnimatorController // TypeDefIndex: 14739
	{
		// Fields
		internal OnOverrideControllerDirtyCallback OnOverrideControllerDirty; // 0x18
	
		// Properties
		public RuntimeAnimatorController runtimeAnimatorController { [NativeMethod("GetAnimatorController")] get; } // 0x0000000182158AB0-0x0000000182158B40 
		public AnimationClip this[AnimationClip clip] { set {} } // 0x0000000182158B40-0x0000000182158BE0
	
		// Nested types
		internal delegate void OnOverrideControllerDirtyCallback(); // TypeDefIndex: 14740; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		public AnimatorOverrideController(RuntimeAnimatorController controller); // 0x00000001821589D0-0x0000000182158A70
	
		// Methods
		[FreeFunction("AnimationBindings::CreateAnimatorOverrideController")]
		private static void Internal_Create([Writable] AnimatorOverrideController self, RuntimeAnimatorController controller); // 0x0000000182158820-0x0000000182158870
		private void SetClip(AnimationClip originalClip, AnimationClip overrideClip, bool notify); // 0x0000000182158920-0x00000001821589D0
		[NativeConditional("UNITY_EDITOR")]
		[RequiredByNativeCode]
		internal static void OnInvalidateOverrideController(AnimatorOverrideController controller); // 0x0000000182158870-0x00000001821588B0
		private static void Internal_Create_Injected([Writable] AnimatorOverrideController self, IntPtr controller); // 0x00000001821587D0-0x0000000182158820
		private static IntPtr get_runtimeAnimatorController_Injected(IntPtr _unity_self); // 0x0000000182158A70-0x0000000182158AB0
		private static void SetClip_Injected(IntPtr _unity_self, IntPtr originalClip, IntPtr overrideClip, bool notify); // 0x00000001821588B0-0x0000000182158920
	}
}
