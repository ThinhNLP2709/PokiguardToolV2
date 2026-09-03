/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class UIRUtility // TypeDefIndex: 4342
	{
		// Fields
		private static readonly ProfilerMarker k_ComputeTransformMatrixMarker; // 0x00
		public static readonly string k_DefaultShaderName; // 0x08
		public static readonly bool k_ProfilerSupported; // 0x10
		internal static readonly ExtraVertexChannels[] k_ExtrasChannelOrder; // 0x18
		[NoAutoStaticsCleanup]
		[ThreadStatic]
		private static int? s_ThreadIndex; // 0x80000000
	
		// Constructors
		static UIRUtility(); // 0x00000001824E2630-0x00000001824E2780
	
		// Methods
		public static bool ShapeWindingIsClockwise(int maskDepth, int stencilRef); // 0x00000001824E25B0-0x00000001824E2630
		public static int ExtrasStride(ExtraVertexChannels mask); // 0x00000001824E1EA0-0x00000001824E1F20
		private static int PopCount(uint v); // 0x00000001822BB110-0x00000001822BB150
		public static Rect Encapsulate(Rect a, Rect b); // 0x00000001824E1DE0-0x00000001824E1EA0
		public static Rect InflateByMargins(Rect r, PostProcessingMargins margins); // 0x00000001824E21F0-0x00000001824E2290
		private static void ComputeMatrixRelativeToAncestor(RenderData renderData, RenderData ancestor, out Matrix4x4 transform); // 0x00000001824E1890-0x00000001824E1980
		public static void ComputeMatrixRelativeToRenderTree(RenderData renderData, out Matrix4x4 transform); // 0x00000001824E1980-0x00000001824E1A60
		public static void GetVerticesTransformInfo(RenderData renderData, out Matrix4x4 transform); // 0x00000001824E2050-0x00000001824E21F0
		internal static void ComputeTransformMatrix(RenderData renderData, RenderData ancestor, out Matrix4x4 result); // 0x00000001824E1A60-0x00000001824E1D40
		public static bool RectHasArea(Rect rect); // 0x00000001824E24E0-0x00000001824E2550
		public static bool RectHasArea(RectInt rect); // 0x00000001824E2550-0x00000001824E25B0
		public static Rect CastToRect(RectInt rect); // 0x00000001824E17E0-0x00000001824E1890
		public static RectInt CastToRectInt(Rect rect); // 0x00000001824E1600-0x00000001824E17E0
		public static bool IsRoundRect(VisualElement ve); // 0x00000001824E2290-0x00000001824E2370
		public static bool IsVectorImageBackground(VisualElement ve); // 0x00000001824E2370-0x00000001824E24E0
		public static void Destroy(UnityEngine.Object obj); // 0x00000001824E1D40-0x00000001824E1DE0
		public static int GetPrevPow2(int n); // 0x00000001824E1F60-0x00000001824E1F80
		public static int GetNextPow2(int n); // 0x00000001824E1F40-0x00000001824E1F60
		public static int GetNextPow2Exp(int n); // 0x00000001824E1F20-0x00000001824E1F40
		public static int GetThreadIndex(); // 0x00000001824E1F80-0x00000001824E2050
	}
}
