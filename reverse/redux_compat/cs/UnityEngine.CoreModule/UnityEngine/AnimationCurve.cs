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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Math/AnimationCurve.bindings.h")]
	[RequiredByNativeCode]
	public class AnimationCurve : IEquatable<UnityEngine.AnimationCurve> // TypeDefIndex: 7477
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.ParticleSystemModule" })]
		internal IntPtr m_Ptr; // 0x10
		private bool m_RequiresNativeCleanup; // 0x18
	
		// Properties
		public Keyframe[] keys { [FreeFunction("AnimationCurveBindings::GetKeysArray", HasExplicitThis = true, IsThreadSafe = true)] get; [FreeFunction("AnimationCurveBindings::SetKeysWithSpan", HasExplicitThis = true, IsThreadSafe = true)] set; } // 0x0000000182177AA0-0x0000000182177BB0 0x0000000182177CA0-0x0000000182177D60
		public Keyframe this[int index] { get => default; } // 0x00000001821779A0-0x0000000182177A50 
		public int length { [NativeMethod("GetKeyCount", IsThreadSafe = true)] get; } // 0x0000000182177BF0-0x0000000182177C50 
		public WrapMode preWrapMode { [NativeMethod("SetPreInfinity", IsThreadSafe = true)] set; } // 0x0000000182177E40-0x0000000182177EA0
		public WrapMode postWrapMode { [NativeMethod("SetPostInfinity", IsThreadSafe = true)] set; } // 0x0000000182177DA0-0x0000000182177E00
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7478
		{
			// Methods
			public static AnimationCurve ConvertToManaged(IntPtr ptr); // 0x000000018217A5B0-0x000000018217A610
			public static IntPtr ConvertToNative(AnimationCurve animationCurve); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public AnimationCurve(params Keyframe[] keys); // 0x0000000182177900-0x00000001821779A0
		[RequiredByNativeCode]
		public AnimationCurve(); // 0x0000000182177840-0x00000001821778C0
		[VisibleToOtherModules(new string[1] {"UnityEngine.ParticleSystemModule" })]
		internal AnimationCurve(IntPtr ptr, bool ownMemory); // 0x00000001821778C0-0x0000000182177900
	
		// Methods
		[FreeFunction("AnimationCurveBindings::Internal_Destroy", IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr ptr); // 0x00000001821772D0-0x0000000182177310
		[FreeFunction("AnimationCurveBindings::Internal_Create", IsThreadSafe = true)]
		private static IntPtr Internal_Create(Keyframe[] keys); // 0x0000000182177250-0x00000001821772D0
		[FreeFunction("AnimationCurveBindings::Internal_Equals", HasExplicitThis = true, IsThreadSafe = true)]
		private bool Internal_Equals(IntPtr other); // 0x0000000182177360-0x00000001821773C0
		[FreeFunction("AnimationCurveBindings::Internal_CopyFrom", HasExplicitThis = true, IsThreadSafe = true)]
		private void Internal_CopyFrom(IntPtr other); // 0x00000001821771B0-0x0000000182177210
		~AnimationCurve(); // 0x0000000182176F40-0x0000000182176FE0
		[NativeMethod(IsThreadSafe = true)]
		public float Evaluate(float time); // 0x0000000182176ED0-0x0000000182176F40
		[FreeFunction("AnimationCurveBindings::AddKeySmoothTangents", HasExplicitThis = true, IsThreadSafe = true)]
		public int AddKey(float time, float value); // 0x0000000182176A90-0x0000000182176B10
		public int AddKey(Keyframe key); // 0x0000000182176A10-0x0000000182176A90
		[NativeMethod("AddKey", IsThreadSafe = true)]
		private int AddKey_Internal(Keyframe key); // 0x00000001821769B0-0x0000000182176A10
		[FreeFunction("AnimationCurveBindings::MoveKey", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		public int MoveKey(int index, Keyframe key); // 0x0000000182177670-0x00000001821776E0
		[FreeFunction("AnimationCurveBindings::ClearKeys", HasExplicitThis = true, IsThreadSafe = true)]
		public void ClearKeys(); // 0x0000000182176B50-0x0000000182176BB0
		[FreeFunction("AnimationCurveBindings::RemoveKey", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		public void RemoveKey(int index); // 0x0000000182177720-0x0000000182177780
		[FreeFunction("AnimationCurveBindings::GetKey", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		private Keyframe GetKey(int index); // 0x00000001821770D0-0x0000000182177160
		[FreeFunction("AnimationCurveBindings::GetHashCode", HasExplicitThis = true, IsThreadSafe = true)]
		public override int GetHashCode(); // 0x0000000182177020-0x0000000182177080
		[FreeFunction("AnimationCurveBindings::SmoothTangents", HasExplicitThis = true, IsThreadSafe = true, ThrowsException = true)]
		public void SmoothTangents(int index, float weight); // 0x00000001821777D0-0x0000000182177840
		public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd); // 0x00000001821773C0-0x0000000182177620
		public override bool Equals(object o); // 0x0000000182176CF0-0x0000000182176E80
		public bool Equals(AnimationCurve other); // 0x0000000182176C20-0x0000000182176CF0
		public void CopyFrom(AnimationCurve other); // 0x0000000182176BB0-0x0000000182176C20
		private static IntPtr Internal_Create_Injected(ref ManagedSpanWrapper keys); // 0x0000000182177210-0x0000000182177250
		private static bool Internal_Equals_Injected(IntPtr _unity_self, IntPtr other); // 0x0000000182177310-0x0000000182177360
		private static void Internal_CopyFrom_Injected(IntPtr _unity_self, IntPtr other); // 0x0000000182177160-0x00000001821771B0
		private static float Evaluate_Injected(IntPtr _unity_self, float time); // 0x0000000182176E80-0x0000000182176ED0
		private static void get_keys_Injected(IntPtr _unity_self, ); // 0x0000000182177A50-0x0000000182177AA0
		private static void set_keys_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x0000000182177C50-0x0000000182177CA0
		private static int AddKey_Injected(IntPtr _unity_self, float time, float value); // 0x0000000182176900-0x0000000182176960
		private static int AddKey_Internal_Injected(IntPtr _unity_self, in Keyframe key); // 0x0000000182176960-0x00000001821769B0
		private static int MoveKey_Injected(IntPtr _unity_self, int index, in Keyframe key); // 0x0000000182177620-0x0000000182177670
		private static void ClearKeys_Injected(IntPtr _unity_self); // 0x0000000182176B10-0x0000000182176B50
		private static void RemoveKey_Injected(IntPtr _unity_self, int index); // 0x00000001821776E0-0x0000000182177720
		private static int get_length_Injected(IntPtr _unity_self); // 0x0000000182177BB0-0x0000000182177BF0
		private static void GetKey_Injected(IntPtr _unity_self, int index, ); // 0x0000000182177080-0x00000001821770D0
		private static int GetHashCode_Injected(IntPtr _unity_self); // 0x0000000182176FE0-0x0000000182177020
		private static void SmoothTangents_Injected(IntPtr _unity_self, int index, float weight); // 0x0000000182177780-0x00000001821777D0
		private static void set_preWrapMode_Injected(IntPtr _unity_self, WrapMode value); // 0x0000000182177E00-0x0000000182177E40
		private static void set_postWrapMode_Injected(IntPtr _unity_self, WrapMode value); // 0x0000000182177D60-0x0000000182177DA0
	}
}
