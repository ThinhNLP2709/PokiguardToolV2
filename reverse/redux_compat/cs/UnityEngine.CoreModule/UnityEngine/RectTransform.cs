/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("UI::RectTransform", PersistentTypeId = 224)]
	[NativeHeader("Runtime/Transform/RectTransform.h")]
	[UIModuleHelpURL("class-RectTransform")]
	public sealed class RectTransform : Transform // TypeDefIndex: 7849
	{
		// Fields
		[CompilerGenerated]
		private static ReapplyDrivenProperties reapplyDrivenProperties; // 0x00
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		public Rect rect { get; } // 0x000000018220F4A0-0x000000018220F550 
		public Vector2 anchorMin { get; set; } // 0x000000018220EB50-0x000000018220EBF0 0x000000018220F920-0x000000018220F9C0
		public Vector2 anchorMax { get; set; } // 0x000000018220EA60-0x000000018220EB00 0x000000018220F830-0x000000018220F8D0
		public Vector2 anchoredPosition { get; set; } // 0x000000018220ED60-0x000000018220EE00 0x000000018220FB70-0x000000018220FC10
		public Vector2 sizeDelta { get; set; } // 0x000000018220F670-0x000000018220F710 0x0000000182210910-0x00000001822109B0
		public Vector2 pivot { get; set; } // 0x000000018220F3B0-0x000000018220F450 0x0000000182210730-0x00000001822107D0
		public Vector3 anchoredPosition3D { get; set; } // 0x000000018220EBF0-0x000000018220ED10 0x000000018220F9C0-0x000000018220FB20
		public Vector2 offsetMin { get; set; } // 0x000000018220F1A0-0x000000018220F360 0x0000000182210260-0x00000001822106E0
		public Vector2 offsetMax { get; set; } // 0x000000018220EFC0-0x000000018220F1A0 0x000000018220FE00-0x0000000182210260
		public Object drivenByObject { get; internal set; } // 0x000000018220EE40-0x000000018220EEF0 0x000000018220FC60-0x000000018220FD20
		internal DrivenTransformProperties drivenProperties { get; set; } // 0x000000018220EF30-0x000000018220EFC0 0x000000018220FD60-0x000000018220FE00
		public bool sendChildDimensionsChange { get; set; } // 0x000000018220F590-0x000000018220F620 0x0000000182210820-0x00000001822108C0
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event ReapplyDrivenProperties reapplyDrivenProperties {
			add; // 0x000000018220E940-0x000000018220EA10
			remove; // 0x000000018220F710-0x000000018220F7E0
		}
	
		// Nested types
		public enum Edge // TypeDefIndex: 7850
		{
			Left = 0,
			Right = 1,
			Top = 2,
			Bottom = 3
		}
	
		public enum Axis // TypeDefIndex: 7851
		{
			Horizontal = 0,
			Vertical = 1
		}
	
		public enum FitResult // TypeDefIndex: 7852
		{
			Success = 0,
			AlreadyInside = 1,
			FailLargerThanTarget = 2,
			FailNotCoplanar = 3,
			FailZRotationMismatch = 4,
			FailInvalidSizeTarget = 5
		}
	
		public delegate void ReapplyDrivenProperties(RectTransform driven); // TypeDefIndex: 7853; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public RectTransform(); // 0x00000001802E7A70-0x00000001802E7BC0
		static RectTransform(); // 0x000000018220E7A0-0x000000018220E940
	
		// Methods
		[NativeMethod("UpdateIfTransformDispatchIsDirty")]
		public void ForceUpdateRectTransforms(); // 0x000000018220A2D0-0x000000018220A360
		public void GetLocalCorners(Vector3[] fourCornersArray); // 0x000000018220A3D0-0x000000018220A590
		public void GetLocalCorners(Span<Vector3> fourCorners); // 0x000000018220A590-0x000000018220A750
		public void GetWorldCorners(Vector3[] fourCornersArray); // 0x000000018220AE00-0x000000018220B2A0
		public void GetWorldCorners(Span<Vector3> fourCorners); // 0x000000018220B2A0-0x000000018220B8B0
		public Rect GetWorldRect(); // 0x000000018220B8B0-0x000000018220BA10
		public bool Contains(RectTransform other); // 0x000000018220A030-0x000000018220A130
		public float GetLocalTop(); // 0x000000018220A820-0x000000018220A890
		public float GetLocalBottom(); // 0x000000018220A360-0x000000018220A3D0
		public float GetLocalLeft(); // 0x000000018220A750-0x000000018220A7B0
		public float GetLocalRight(); // 0x000000018220A7B0-0x000000018220A820
		public void SetLocalTop(float value, bool preserveSize = true /* Metadata: 0x0069D7C2 */); // 0x000000018220D950-0x000000018220DE00
		public void SetLocalBottom(float value, bool preserveSize = true /* Metadata: 0x0069D7C3 */); // 0x000000018220C940-0x000000018220CE80
		public void SetLocalLeft(float value, bool preserveSize = true /* Metadata: 0x0069D7C4 */); // 0x000000018220CE80-0x000000018220D420
		public void SetLocalRight(float value, bool preserveSize = true /* Metadata: 0x0069D7C5 */); // 0x000000018220D420-0x000000018220D950
		public void SetAnchors(Vector2 position); // 0x000000018220C050-0x000000018220C170
		public void SetPivotAndAnchors(Vector2 position); // 0x000000018220DE00-0x000000018220DF90
		public void SetInsetAndSizeFromParentEdge(Edge edge, float inset, float size); // 0x000000018220C170-0x000000018220C940
		public void SetSizeWithCurrentAnchors(Axis axis, float size); // 0x000000018220E040-0x000000018220E470
		[NativeMethod("SetPivotWithCounterAdjust")]
		private void Internal_SetPivotWithCounterAdjust(Vector2 newPivot, bool adjustChildren); // 0x000000018220BCB0-0x000000018220BD60
		public void SetPivotWithCounterAdjust(Vector2 newPivot, bool adjustChildren = false /* Metadata: 0x0069D7C6 */); // 0x000000018220DF90-0x000000018220E040
		[RequiredByNativeCode]
		internal static void SendReapplyDrivenProperties(RectTransform driven); // 0x000000018220BFE0-0x000000018220C050
		internal Rect GetRectInParentSpace(); // 0x000000018220AA60-0x000000018220AE00
		private Vector2 GetParentSize(); // 0x000000018220A890-0x000000018220AA60
		public bool IsCoplanarWith(RectTransform target); // 0x000000018220BE90-0x000000018220BFE0
		[NativeMethod("IsCoplanarWith")]
		private bool Internal_IsCoplanarWith(RectTransform target); // 0x000000018220BB90-0x000000018220BC50
		public FitResult FitInsideCoplanarRectTransform(RectTransform target, bool allowShrink = false /* Metadata: 0x0069D7C7 */); // 0x000000018220A130-0x000000018220A290
		[NativeMethod("FitInsideCoplanarRectTransform")]
		private FitResult Internal_FitInsideCoplanarRectTransform(RectTransform target, bool allowShrink); // 0x000000018220BA70-0x000000018220BB40
		public FitResult TryFitInsideCoplanarRectTransform(RectTransform target, bool allowShrink = false /* Metadata: 0x0069D7C8 */); // 0x000000018220E470-0x000000018220E5D0
		[NativeMethod("TryFitInsideCoplanarRectTransform")]
		private FitResult Internal_TryFitInsideCoplanarRectTransform(RectTransform target, bool allowShrink); // 0x000000018220BDC0-0x000000018220BE90
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018220E5D0-0x000000018220E7A0
		private static void get_rect_Injected(IntPtr _unity_self, ); // 0x000000018220F450-0x000000018220F4A0
		private static void get_anchorMin_Injected(IntPtr _unity_self, ); // 0x000000018220EB00-0x000000018220EB50
		private static void set_anchorMin_Injected(IntPtr _unity_self, in Vector2 value); // 0x000000018220F8D0-0x000000018220F920
		private static void get_anchorMax_Injected(IntPtr _unity_self, ); // 0x000000018220EA10-0x000000018220EA60
		private static void set_anchorMax_Injected(IntPtr _unity_self, in Vector2 value); // 0x000000018220F7E0-0x000000018220F830
		private static void get_anchoredPosition_Injected(IntPtr _unity_self, ); // 0x000000018220ED10-0x000000018220ED60
		private static void set_anchoredPosition_Injected(IntPtr _unity_self, in Vector2 value); // 0x000000018220FB20-0x000000018220FB70
		private static void get_sizeDelta_Injected(IntPtr _unity_self, ); // 0x000000018220F620-0x000000018220F670
		private static void set_sizeDelta_Injected(IntPtr _unity_self, in Vector2 value); // 0x00000001822108C0-0x0000000182210910
		private static void get_pivot_Injected(IntPtr _unity_self, ); // 0x000000018220F360-0x000000018220F3B0
		private static void set_pivot_Injected(IntPtr _unity_self, in Vector2 value); // 0x00000001822106E0-0x0000000182210730
		private static IntPtr get_drivenByObject_Injected(IntPtr _unity_self); // 0x000000018220EE00-0x000000018220EE40
		private static void set_drivenByObject_Injected(IntPtr _unity_self, IntPtr value); // 0x000000018220FC10-0x000000018220FC60
		private static DrivenTransformProperties get_drivenProperties_Injected(IntPtr _unity_self); // 0x000000018220EEF0-0x000000018220EF30
		private static void set_drivenProperties_Injected(IntPtr _unity_self, DrivenTransformProperties value); // 0x000000018220FD20-0x000000018220FD60
		private static bool get_sendChildDimensionsChange_Injected(IntPtr _unity_self); // 0x000000018220F550-0x000000018220F590
		private static void set_sendChildDimensionsChange_Injected(IntPtr _unity_self, bool value); // 0x00000001822107D0-0x0000000182210820
		private static void ForceUpdateRectTransforms_Injected(IntPtr _unity_self); // 0x000000018220A290-0x000000018220A2D0
		private static void Internal_SetPivotWithCounterAdjust_Injected(IntPtr _unity_self, in Vector2 newPivot, bool adjustChildren); // 0x000000018220BC50-0x000000018220BCB0
		private static bool Internal_IsCoplanarWith_Injected(IntPtr _unity_self, IntPtr target); // 0x000000018220BB40-0x000000018220BB90
		private static FitResult Internal_FitInsideCoplanarRectTransform_Injected(IntPtr _unity_self, IntPtr target, bool allowShrink); // 0x000000018220BA10-0x000000018220BA70
		private static FitResult Internal_TryFitInsideCoplanarRectTransform_Injected(IntPtr _unity_self, IntPtr target, bool allowShrink); // 0x000000018220BD60-0x000000018220BDC0
	}
}
