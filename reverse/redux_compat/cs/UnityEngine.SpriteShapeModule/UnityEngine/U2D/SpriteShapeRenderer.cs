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
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 66: UnityEngine.SpriteShapeModule.dll - Assembly: UnityEngine.SpriteShapeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15818-15827

namespace UnityEngine.U2D
{
	[MovedFrom("UnityEngine.Experimental.U2D")]
	[NativeClass("SpriteShapeRenderer", PersistentTypeId = 1971053207)]
	[NativeHeader("Modules/SpriteShape/Public/SpriteShapeRenderer.h")]
	public class SpriteShapeRenderer : Renderer // TypeDefIndex: 15824
	{
		// Constructors
		public SpriteShapeRenderer(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		public void Prepare(JobHandle handle, SpriteShapeParameters shapeParams, Sprite[] sprites); // 0x00000001822E7810-0x00000001822E7890
		private NativeArray<T> GetNativeDataArray<T>(SpriteShapeDataType dataType)
			where T : struct;
		private NativeSlice<T> GetChannelDataArray<T>(SpriteShapeDataType dataType, VertexAttribute channel)
			where T : struct;
		private void SetSegmentCount(int geomCount); // 0x00000001822E7B20-0x00000001822E7B80
		private void SetMeshDataCount(int vertexCount, int indexCount); // 0x00000001822E7A70-0x00000001822E7AE0
		private void SetMeshChannelInfo(int vertexCount, int indexCount, int hotChannelMask); // 0x00000001822E79A0-0x00000001822E7A20
		private SpriteChannelInfo GetDataInfo(SpriteShapeDataType arrayType); // 0x00000001822E7680-0x00000001822E7700
		private SpriteChannelInfo GetChannelInfo(VertexAttribute channel); // 0x00000001822E7310-0x00000001822E7390
		public void SetLocalAABB(Bounds bounds); // 0x00000001822E78E0-0x00000001822E7940
		public NativeArray<Bounds> GetBounds(); // 0x00000001822E7290-0x00000001822E72C0
		public NativeArray<SpriteShapeSegment> GetSegments(int dataSize); // 0x00000001822E7700-0x00000001822E77A0
		public void GetChannels(int dataSize, out NativeArray<ushort> indices, out NativeSlice<Vector3> vertices, out NativeSlice<Vector2> texcoords); // 0x00000001822E7500-0x00000001822E7630
		public void GetChannels(int dataSize, out NativeArray<ushort> indices, out NativeSlice<Vector3> vertices, out NativeSlice<Vector2> texcoords, out NativeSlice<Vector4> tangents); // 0x00000001822E7390-0x00000001822E7500
		private static void Prepare_Injected(IntPtr _unity_self, in JobHandle handle, in SpriteShapeParameters shapeParams, Sprite[] sprites); // 0x00000001822E77A0-0x00000001822E7810
		private static void SetSegmentCount_Injected(IntPtr _unity_self, int geomCount); // 0x00000001822E7AE0-0x00000001822E7B20
		private static void SetMeshDataCount_Injected(IntPtr _unity_self, int vertexCount, int indexCount); // 0x00000001822E7A20-0x00000001822E7A70
		private static void SetMeshChannelInfo_Injected(IntPtr _unity_self, int vertexCount, int indexCount, int hotChannelMask); // 0x00000001822E7940-0x00000001822E79A0
		private static void GetDataInfo_Injected(IntPtr _unity_self, SpriteShapeDataType arrayType, ); // 0x00000001822E7630-0x00000001822E7680
		private static void GetChannelInfo_Injected(IntPtr _unity_self, VertexAttribute channel, ); // 0x00000001822E72C0-0x00000001822E7310
		private static void SetLocalAABB_Injected(IntPtr _unity_self, in Bounds bounds); // 0x00000001822E7890-0x00000001822E78E0
	}
}
