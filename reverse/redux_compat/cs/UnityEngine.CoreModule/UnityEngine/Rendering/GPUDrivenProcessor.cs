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
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Camera/GPUDrivenProcessor.h")]
	[RequiredByNativeCode]
	internal class GPUDrivenProcessor // TypeDefIndex: 8377
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Properties
		public bool enablePartialRendering { set; } // 0x000000018225C360-0x000000018225C3C0
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 8378
		{
			// Methods
			public static IntPtr ConvertToNative(GPUDrivenProcessor obj); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public GPUDrivenProcessor(); // 0x000000018225C2D0-0x000000018225C310
	
		// Methods
		public void Dispose(); // 0x000000018225BC20-0x000000018225BC70
		private static IntPtr Internal_Create(); // 0x000000018225BE40-0x000000018225BE70
		private static void Internal_Destroy(IntPtr ptr); // 0x000000018225BE70-0x000000018225BEB0
		public void EnableGPUDrivenRenderingAndDispatchRendererData(ReadOnlySpan<EntityId> renderers, GPUDrivenRendererDataCallback callback); // 0x000000018225BCD0-0x000000018225BD80
		public void DisableGPUDrivenRendering(ReadOnlySpan<EntityId> renderers); // 0x000000018225BA50-0x000000018225BAF0
		public void DispatchLODGroupData(ReadOnlySpan<EntityId> lodGroups, bool transformOnly, GPUDrivenLODGroupDataCallback callback); // 0x000000018225BB60-0x000000018225BC20
		public static void RegisterMaterials(BatchRendererGroup brg, NativeArray<EntityId> materials, NativeArray<GPUDrivenMaterial> materialDatas); // 0x000000018225BFC0-0x000000018225C0C0
		[FreeFunction("GPUDrivenProcessor::RegisterMaterials", IsThreadSafe = true)]
		private static void RegisterMaterials(IntPtr brg, ReadOnlySpan<EntityId> materials, Span<GPUDrivenMaterial> materialDatas); // 0x000000018225BF10-0x000000018225BFC0
		public static void RegisterMeshes(BatchRendererGroup brg, NativeArray<EntityId> meshInstanceIDs, NativeArray<BatchMeshID> batchMeshIDs); // 0x000000018225C120-0x000000018225C220
		[FreeFunction("GPUDrivenProcessor::RegisterMeshes", IsThreadSafe = true)]
		private static void RegisterMeshes(IntPtr brg, ReadOnlySpan<EntityId> meshInstanceIDs, Span<BatchMeshID> batchMeshIDs); // 0x000000018225C220-0x000000018225C2D0
		[FreeFunction("GPUDrivenProcessor::FetchMeshDatas")]
		public static void FetchMeshDatas(ReadOnlySpan<EntityId> meshIDs, GPUDrivenFetchMeshesDataCallback callback); // 0x000000018225BDD0-0x000000018225BE40
		[FreeFunction("GPUDrivenProcessor::ClassifyMaterials")]
		public static int ClassifyMaterials(ReadOnlySpan<EntityId> materialIDs, Span<EntityId> unsupportedMaterialIDs, Span<EntityId> supportedMaterialIDs, Span<GPUDrivenMaterialData> supportedPackedMaterialDatas); // 0x000000018225B8D0-0x000000018225BA00
		private static void set_enablePartialRendering_Injected(IntPtr _unity_self, bool value); // 0x000000018225C310-0x000000018225C360
		private static void EnableGPUDrivenRenderingAndDispatchRendererData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper renderers, GPUDrivenRendererDataCallback callback); // 0x000000018225BC70-0x000000018225BCD0
		private static void DisableGPUDrivenRendering_Injected(IntPtr _unity_self, ref ManagedSpanWrapper renderers); // 0x000000018225BA00-0x000000018225BA50
		private static void DispatchLODGroupData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper lodGroups, bool transformOnly, GPUDrivenLODGroupDataCallback callback); // 0x000000018225BAF0-0x000000018225BB60
		private static void RegisterMaterials_Injected(IntPtr brg, ref ManagedSpanWrapper materials, ref ManagedSpanWrapper materialDatas); // 0x000000018225BEB0-0x000000018225BF10
		private static void RegisterMeshes_Injected(IntPtr brg, ref ManagedSpanWrapper meshInstanceIDs, ref ManagedSpanWrapper batchMeshIDs); // 0x000000018225C0C0-0x000000018225C120
		private static void FetchMeshDatas_Injected(ref ManagedSpanWrapper meshIDs, GPUDrivenFetchMeshesDataCallback callback); // 0x000000018225BD80-0x000000018225BDD0
		private static int ClassifyMaterials_Injected(ref ManagedSpanWrapper materialIDs, ref ManagedSpanWrapper unsupportedMaterialIDs, ref ManagedSpanWrapper supportedMaterialIDs, ref ManagedSpanWrapper supportedPackedMaterialDatas); // 0x000000018225B860-0x000000018225B8D0
	}
}
