/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine
{
	[NativeClass("AnimationClip", PersistentTypeId = 74)]
	[NativeHeader("Modules/Animation/AnimationClip.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationClip.bindings.h")]
	public sealed class AnimationClip : Motion // TypeDefIndex: 14724
	{
		// Properties
		[NativeProperty("Length", false, TargetType.Function)]
		public float length { get; } // 0x00000001821569B0-0x0000000182156A10 
		[NativeProperty("StartTime", false, TargetType.Function)]
		internal float startTime { get; } // 0x0000000182156B10-0x0000000182156B70 
		[NativeProperty("StopTime", false, TargetType.Function)]
		internal float stopTime { get; } // 0x0000000182156BB0-0x0000000182156C10 
		[NativeProperty("SampleRate", false, TargetType.Function)]
		public float frameRate { get; set; } // 0x00000001821564B0-0x0000000182156510 0x0000000182156D00-0x0000000182156D70
		[NativeProperty("WrapMode", false, TargetType.Function)]
		public WrapMode wrapMode { get; set; } // 0x0000000182156C50-0x0000000182156CB0 0x0000000182156F10-0x0000000182156F70
		[NativeProperty("Bounds", false, TargetType.Function)]
		public Bounds localBounds { get; set; } // 0x0000000182156A60-0x0000000182156AD0 0x0000000182156E70-0x0000000182156ED0
		public bool legacy { [NativeMethod("IsLegacy")] get; [NativeMethod("SetLegacy")] set; } // 0x0000000182156910-0x0000000182156970 0x0000000182156DC0-0x0000000182156E20
		public bool humanMotion { [NativeMethod("IsHumanMotion")] get; } // 0x0000000182156870-0x00000001821568D0 
		public bool empty { [NativeMethod("IsEmpty")] get; } // 0x0000000182156410-0x0000000182156470 
		public bool hasGenericRootTransform { [NativeMethod("HasGenericRootTransform")] get; } // 0x0000000182156550-0x00000001821565B0 
		public bool hasMotionFloatCurves { [NativeMethod("HasMotionFloatCurves")] get; } // 0x0000000182156690-0x00000001821566F0 
		public bool hasMotionCurves { [NativeMethod("HasMotionCurves")] get; } // 0x00000001821565F0-0x0000000182156650 
		public bool hasRootCurves { [NativeMethod("HasRootCurves")] get; } // 0x0000000182156730-0x0000000182156790 
		internal bool hasRootMotion { [FreeFunction(Name = "AnimationClipBindings::Internal_GetHasRootMotion", HasExplicitThis = true)] get; } // 0x00000001821567D0-0x0000000182156830 
		public AnimationEvent[] events { get; set; } // 0x0000000182155BC0-0x0000000182155C20 0x0000000182156300-0x0000000182156360
	
		// Constructors
		public AnimationClip(); // 0x0000000182156360-0x00000001821563D0
	
		// Methods
		[FreeFunction("AnimationClipBindings::Internal_CreateAnimationClip")]
		private static void Internal_CreateAnimationClip([Writable] AnimationClip self); // 0x0000000182155C20-0x0000000182155C60
		public void SampleAnimation(GameObject go, float time); // 0x0000000182155DE0-0x0000000182155F20
		[FreeFunction]
		[NativeHeader("Modules/Animation/AnimationUtility.h")]
		internal static void SampleAnimation([NotNull] GameObject go, [NotNull] AnimationClip clip, float inTime, WrapMode wrapMode); // 0x0000000182155CD0-0x0000000182155DE0
		[FreeFunction("AnimationClipBindings::Internal_SetCurve", HasExplicitThis = true)]
		public void SetCurve([NotNull] string relativePath, [NotNull] Type type, [NotNull] string propertyName, AnimationCurve curve); // 0x0000000182155F90-0x00000001821562B0
		public void EnsureQuaternionContinuity(); // 0x0000000182155B20-0x0000000182155B80
		public void ClearCurves(); // 0x0000000182155A80-0x0000000182155AE0
		public void AddEvent(AnimationEvent evt); // 0x0000000182155960-0x0000000182155A40
		[FreeFunction(Name = "AnimationClipBindings::AddEventInternal", HasExplicitThis = true)]
		private void AddEventInternal([NotNull] AnimationEvent evt); // 0x00000001821558C0-0x0000000182155960
		[FreeFunction(Name = "AnimationClipBindings::SetEventsInternal", HasExplicitThis = true)]
		private void SetEventsInternal(AnimationEvent[] events); // 0x0000000182156300-0x0000000182156360
		[FreeFunction(Name = "AnimationClipBindings::GetEventsInternal", HasExplicitThis = true)]
		private AnimationEvent[] GetEventsInternal(); // 0x0000000182155BC0-0x0000000182155C20
		private static void SampleAnimation_Injected(IntPtr go, IntPtr clip, float inTime, WrapMode wrapMode); // 0x0000000182155C60-0x0000000182155CD0
		private static float get_length_Injected(IntPtr _unity_self); // 0x0000000182156970-0x00000001821569B0
		private static float get_startTime_Injected(IntPtr _unity_self); // 0x0000000182156AD0-0x0000000182156B10
		private static float get_stopTime_Injected(IntPtr _unity_self); // 0x0000000182156B70-0x0000000182156BB0
		private static float get_frameRate_Injected(IntPtr _unity_self); // 0x0000000182156470-0x00000001821564B0
		private static void set_frameRate_Injected(IntPtr _unity_self, float value); // 0x0000000182156CB0-0x0000000182156D00
		private static void SetCurve_Injected(IntPtr _unity_self, ref ManagedSpanWrapper relativePath, Type type, ref ManagedSpanWrapper propertyName, IntPtr curve); // 0x0000000182155F20-0x0000000182155F90
		private static void EnsureQuaternionContinuity_Injected(IntPtr _unity_self); // 0x0000000182155AE0-0x0000000182155B20
		private static void ClearCurves_Injected(IntPtr _unity_self); // 0x0000000182155A40-0x0000000182155A80
		private static WrapMode get_wrapMode_Injected(IntPtr _unity_self); // 0x0000000182156C10-0x0000000182156C50
		private static void set_wrapMode_Injected(IntPtr _unity_self, WrapMode value); // 0x0000000182156ED0-0x0000000182156F10
		private static void get_localBounds_Injected(IntPtr _unity_self, ); // 0x0000000182156A10-0x0000000182156A60
		private static void set_localBounds_Injected(IntPtr _unity_self, in Bounds value); // 0x0000000182156E20-0x0000000182156E70
		private static bool get_legacy_Injected(IntPtr _unity_self); // 0x00000001821568D0-0x0000000182156910
		private static void set_legacy_Injected(IntPtr _unity_self, bool value); // 0x0000000182156D70-0x0000000182156DC0
		private static bool get_humanMotion_Injected(IntPtr _unity_self); // 0x0000000182156830-0x0000000182156870
		private static bool get_empty_Injected(IntPtr _unity_self); // 0x00000001821563D0-0x0000000182156410
		private static bool get_hasGenericRootTransform_Injected(IntPtr _unity_self); // 0x0000000182156510-0x0000000182156550
		private static bool get_hasMotionFloatCurves_Injected(IntPtr _unity_self); // 0x0000000182156650-0x0000000182156690
		private static bool get_hasMotionCurves_Injected(IntPtr _unity_self); // 0x00000001821565B0-0x00000001821565F0
		private static bool get_hasRootCurves_Injected(IntPtr _unity_self); // 0x00000001821566F0-0x0000000182156730
		private static bool get_hasRootMotion_Injected(IntPtr _unity_self); // 0x0000000182156790-0x00000001821567D0
		private static void AddEventInternal_Injected(IntPtr _unity_self, AnimationEvent evt); // 0x0000000182155870-0x00000001821558C0
		private static void SetEventsInternal_Injected(IntPtr _unity_self, AnimationEvent[] events); // 0x00000001821562B0-0x0000000182156300
		private static AnimationEvent[] GetEventsInternal_Injected(IntPtr _unity_self); // 0x0000000182155B80-0x0000000182155BC0
	}
}
