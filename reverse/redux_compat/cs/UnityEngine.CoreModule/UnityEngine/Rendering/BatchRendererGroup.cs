/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Math/Matrix4x4.h")]
	[NativeHeader("Runtime/Camera/BatchRendererGroup.h")]
	[RequiredByNativeCode]
	public class BatchRendererGroup : IDisposable // TypeDefIndex: 8362
	{
		// Fields
		private IntPtr m_GroupHandle; // 0x10
		private OnPerformCulling m_PerformCulling; // 0x18
		private OnFinishedCulling m_FinishedCulling; // 0x20
	
		// Properties
		internal IntPtr Handle { get; } // 0x0000000180377550-0x0000000180377560 
		public static BatchBufferTarget BufferTarget { get; } // 0x00000001822559E0-0x0000000182255A10 
	
		// Nested types
		public delegate JobHandle OnPerformCulling(BatchRendererGroup rendererGroup, BatchCullingContext cullingContext, BatchCullingOutput cullingOutput, IntPtr userContext); // TypeDefIndex: 8363; 0x000000018225E160-0x000000018225E260
	
		public delegate void OnFinishedCulling(IntPtr customCullingResult); // TypeDefIndex: 8364; 0x00000001804A78A0-0x00000001804A78B0
	
		internal static class BindingsMarshaller // TypeDefIndex: 8365
		{
			// Methods
			public static IntPtr ConvertToNative(BatchRendererGroup batchRendererGroup); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public BatchRendererGroup(BatchRendererGroupCreateInfo info); // 0x00000001822560E0-0x0000000182256170
	
		// Methods
		public void Dispose(); // 0x0000000182255990-0x00000001822559E0
		private BatchID AddDrawCommandBatch(IntPtr values, int count, GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize); // 0x0000000182255860-0x0000000182255900
		public BatchID AddBatch(NativeArray<MetadataValue> batchMetadata, GraphicsBufferHandle buffer); // 0x0000000182255740-0x00000001822557F0
		private void RemoveDrawCommandBatch(BatchID batchID); // 0x0000000182255F20-0x0000000182255F80
		public void RemoveBatch(BatchID batchID); // 0x0000000182255E70-0x0000000182255ED0
		public void UnregisterMaterial(BatchMaterialID material); // 0x0000000182255FD0-0x0000000182256030
		public void UnregisterMesh(BatchMeshID mesh); // 0x0000000182256080-0x00000001822560E0
		private static BatchBufferTarget GetBufferTarget(); // 0x00000001822559E0-0x0000000182255A10
		private static unsafe IntPtr Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] BatchRendererGroup group, void* userContext); // 0x0000000182255900-0x0000000182255950
		private static void Destroy(IntPtr groupHandle); // 0x0000000182255950-0x0000000182255990
		[RequiredByNativeCode]
		private static void InvokeOnPerformCulling(BatchRendererGroup group, ref BatchRendererCullingOutput context, ref LODParameters lodParameters, IntPtr userContext); // 0x0000000182255A70-0x0000000182255DD0
		[RequiredByNativeCode]
		private static void InvokeOnFinishedCulling(BatchRendererGroup group, IntPtr customCullingResult); // 0x0000000182255A10-0x0000000182255A70
		[FreeFunction("BatchRendererGroup::OcclusionTestAABB", IsThreadSafe = true)]
		internal static bool OcclusionTestAABB(IntPtr occlusionBuffer, Bounds aabb); // 0x0000000182255E20-0x0000000182255E70
		private static void AddDrawCommandBatch_Injected(IntPtr _unity_self, IntPtr values, int count, in GraphicsBufferHandle buffer, uint bufferOffset, uint windowSize, ); // 0x00000001822557F0-0x0000000182255860
		private static void RemoveDrawCommandBatch_Injected(IntPtr _unity_self, in BatchID batchID); // 0x0000000182255ED0-0x0000000182255F20
		private static void UnregisterMaterial_Injected(IntPtr _unity_self, in BatchMaterialID material); // 0x0000000182255F80-0x0000000182255FD0
		private static void UnregisterMesh_Injected(IntPtr _unity_self, in BatchMeshID mesh); // 0x0000000182256030-0x0000000182256080
		private static bool OcclusionTestAABB_Injected(IntPtr occlusionBuffer, in Bounds aabb); // 0x0000000182255DD0-0x0000000182255E20
	}
}
