/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal static class BackdropFilterHelper // TypeDefIndex: 5024
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly MaterialPropertyBlock s_PropertyBlock; // 0x00
		[CompilerGenerated]
		[TupleElementNames(new string[2] {"texture", "isTopOrigin" })]
		private static Func<ValueTuple<RenderTexture, bool>> _editorWindowBackdropSource_k__BackingField; // 0x08
		private static readonly int s_ColorMatrixId; // 0x10
		private static readonly int s_ColorOffsetId; // 0x14
		private static readonly int s_ColorInvertId; // 0x18
		[NoAutoStaticsCleanup]
		private static Material s_NormalizeMaterial; // 0x20
		[NoAutoStaticsCleanup]
		private static bool s_CustomFilterWarningLogged; // 0x28
	
		// Properties
		[TupleElementNames(new string[2] {"texture", "isTopOrigin" })]
		private static Func<ValueTuple<RenderTexture, bool>> editorWindowBackdropSource { [CompilerGenerated] get; } // 0x00000001823EF6F0-0x00000001823EF740 
		private static Material normalizeMaterial { get; } // 0x00000001823EF740-0x00000001823EF960 
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass16_0 // TypeDefIndex: 5025
		{
			// Fields
			public Matrix4x4 worldTransform; // 0x00
			public Rect worldBound; // 0x40
			public float invWidth; // 0x50
			public float invHeight; // 0x54
		}
	
		// Constructors
		static BackdropFilterHelper(); // 0x00000001823EF5F0-0x00000001823EF6F0
	
		// Methods
		private static RenderTextureReadWrite GetColorSpace(); // 0x00000001802E7860-0x00000001802E7870
		public static void AllocBackdropFilterTextureId(RenderTreeManager renderTreeManager, RenderData owner); // 0x00000001823ECF90-0x00000001823ED020
		public static void ReleaseBackdropFilterResources(RenderTreeManager renderTreeManager, RenderData owner); // 0x00000001823EF0A0-0x00000001823EF1B0
		public static void UpdateBackdropFilterUVCorners(VisualElement ve, RenderData owner); // 0x00000001823EF290-0x00000001823EF5F0
		private static void ComputeBackdropFilterUVCorners(VisualElement ve, Rect worldBound, RenderData owner); // 0x00000001823ED7D0-0x00000001823EDA70
		public static void GenerateBackdropFilterTexture(DrawParams drawParams, VisualElement ve, float pixelsPerPoint, RenderData owner); // 0x00000001823EDA70-0x00000001823EEF80
		private static bool ClampCapture(ref RectInt captureRect, RectInt bounds); // 0x00000001823ED620-0x00000001823ED7D0
		private static void BlitToTarget(RenderTexture source, RenderTexture target, RectInt destRect); // 0x00000001823ED2F0-0x00000001823ED460
		private static RenderTexture CaptureBackdrop(Texture source, RectInt region, RenderTextureReadWrite colorSpace); // 0x00000001823ED460-0x00000001823ED620
		private static RenderTexture ApplyBackdropFilters(RenderTexture source, VisualElement ve, float pixelsPerPoint, RenderTextureReadWrite colorSpace, bool readsGamma); // 0x00000001823ED020-0x00000001823ED2F0
		private static bool HasCustomFilter(ReadOnlySpan<UnmanagedFilterFunction> filters); // 0x00000001823EEF80-0x00000001823EF0A0
		[CompilerGenerated]
		internal static Vector2 _ComputeBackdropFilterUVCorners_g__CornerUV_16_0(float localX, float localY, ref __c__DisplayClass16_0 param_00007d41); // 0x00000001823EF1B0-0x00000001823EF290
	}
}
