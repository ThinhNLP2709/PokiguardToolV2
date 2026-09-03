/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
	[NativeHeader("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
	public struct CullingResults : IEquatable<CullingResults> // TypeDefIndex: 8406
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.VFXModule" })]
		internal IntPtr ptr; // 0x00
		private unsafe CullingAllocationInfo* m_AllocationInfo; // 0x08
	
		// Properties
		public NativeArray<VisibleLight> visibleLights { get; } // 0x00000001822596C0-0x0000000182259710 
		public NativeArray<VisibleReflectionProbe> visibleReflectionProbes { get; } // 0x0000000182259710-0x0000000182259760 
	
		// Methods
		[FreeFunction("GetLightIndexMapSize")]
		private static int GetLightIndexMapSize(IntPtr cullingResultsPtr); // 0x0000000182259460-0x00000001822594A0
		[FreeFunction("FillLightIndexMapScriptable")]
		private static void FillLightIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize); // 0x00000001822593E0-0x0000000182259440
		[FreeFunction("SetLightIndexMapScriptable")]
		private static void SetLightIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize); // 0x0000000182259660-0x00000001822596C0
		[FreeFunction("ScriptableRenderPipeline_Bindings::GetShadowCasterBounds")]
		private static bool GetShadowCasterBounds(IntPtr cullingResultsPtr, int lightIndex, out Bounds bounds); // 0x00000001822595B0-0x0000000182259600
		[FreeFunction("ScriptableRenderPipeline_Bindings::ComputeSpotShadowMatricesAndCullingPrimitives")]
		private static bool ComputeSpotShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x0000000182259200-0x0000000182259260
		[FreeFunction("ScriptableRenderPipeline_Bindings::ComputePointShadowMatricesAndCullingPrimitives")]
		private static bool ComputePointShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x00000001822591A0-0x0000000182259200
		[FreeFunction("ScriptableRenderPipeline_Bindings::ComputeDirectionalShadowMatricesAndCullingPrimitives")]
		private static bool ComputeDirectionalShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x0000000182259080-0x0000000182259140
		private unsafe NativeArray<T> GetNativeArray<T>(void* dataPointer, int length)
			where T : struct;
		public NativeArray<int> GetLightIndexMap(Allocator allocator); // 0x00000001822594A0-0x0000000182259560
		public void SetLightIndexMap(NativeArray<int> lightIndexMap); // 0x0000000182259600-0x0000000182259660
		public bool GetShadowCasterBounds(int lightIndex, out Bounds outBounds); // 0x0000000182259560-0x00000001822595B0
		public bool ComputeSpotShadowMatricesAndCullingPrimitives(int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x0000000182259260-0x00000001822592C0
		public bool ComputePointShadowMatricesAndCullingPrimitives(int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x0000000182259140-0x00000001822591A0
		public bool ComputeDirectionalShadowMatricesAndCullingPrimitives(int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x0000000182258FB0-0x0000000182259080
		public bool Equals(CullingResults other); // 0x0000000182259380-0x00000001822593E0
		public override bool Equals(object obj); // 0x00000001822592C0-0x0000000182259380
		public override int GetHashCode(); // 0x0000000182259440-0x0000000182259460
		public static bool operator ==(CullingResults left, CullingResults right); // 0x0000000182259760-0x00000001822597C0
		private static bool ComputeDirectionalShadowMatricesAndCullingPrimitives_Injected(IntPtr cullingResultsPtr, int activeLightIndex, int splitIndex, int splitCount, in Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData); // 0x0000000182258F40-0x0000000182258FB0
	}
}
