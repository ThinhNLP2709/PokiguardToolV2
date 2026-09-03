/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("Mesh", PersistentTypeId = 43)]
	[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
	[RequiredByNativeCode]
	public sealed class Mesh : Object // TypeDefIndex: 7625
	{
		// Properties
		public IndexFormat indexFormat { get; set; } // 0x00000001821BA830-0x00000001821BA890 0x00000001821BAE60-0x00000001821BAEC0
		public GraphicsBuffer.Target vertexBufferTarget { get; [FreeFunction(Name = "MeshScripting::SetVertexBufferTarget", HasExplicitThis = true, ThrowsException = true)] set; } // 0x00000001821BAB20-0x00000001821BAB80 0x00000001821BB220-0x00000001821BB280
		public GraphicsBuffer.Target indexBufferTarget { get; [FreeFunction(Name = "MeshScripting::SetIndexBufferTarget", HasExplicitThis = true, ThrowsException = true)] set; } // 0x00000001821BA790-0x00000001821BA7F0 0x00000001821BADC0-0x00000001821BAE20
		internal bool canAccess { [NativeMethod("CanAccessFromScript")] get; } // 0x00000001821BA6A0-0x00000001821BA700 
		public int vertexCount { [NativeMethod("GetVertexCount")] get; } // 0x00000001821BABC0-0x00000001821BAC20 
		public int subMeshCount { [NativeMethod(Name = "GetSubMeshCount")] get; [FreeFunction(Name = "MeshScripting::SetSubMeshCount", HasExplicitThis = true)] set; } // 0x00000001821BA910-0x00000001821BA970 0x00000001821BAF60-0x00000001821BAFC0
		public Bounds bounds { get; set; } // 0x00000001821BA5F0-0x00000001821BA660 0x00000001821BACB0-0x00000001821BAD10
		public Vector3[] vertices { get; set; } // 0x00000001821BAC20-0x00000001821BAC60 0x00000001821BB280-0x00000001821BB2E0
		public Vector3[] normals { get; set; } // 0x00000001821BA890-0x00000001821BA8D0 0x00000001821BAEC0-0x00000001821BAF20
		public Vector4[] tangents { set; } // 0x00000001821BAFC0-0x00000001821BB020
		public Vector2[] uv { get; set; } // 0x00000001821BAAA0-0x00000001821BAAE0 0x00000001821BB180-0x00000001821BB1E0
		public Vector2[] uv2 { get; set; } // 0x00000001821BAA60-0x00000001821BAAA0 0x00000001821BB120-0x00000001821BB180
		public Color32[] colors32 { get; set; } // 0x00000001821BA700-0x00000001821BA750 0x00000001821BAD10-0x00000001821BAD80
		public int lodCount { get; } // 0x00000001821B67C0-0x00000001821B6820 
		public int[] triangles { get; set; } // 0x00000001821BA970-0x00000001821BAA60 0x00000001821BB020-0x00000001821BB120
	
		// Nested types
		[Serializable]
		[UsedByNativeCode]
		public struct LodSelectionCurve // TypeDefIndex: 7626
		{
			// Fields
			[SerializeField]
			private float m_LodSlope; // 0x00
			[SerializeField]
			private float m_LodBias; // 0x04
	
			// Properties
			public float lodSlope { get; } // 0x000000018035C780-0x000000018035C790 
			public float lodBias { get; } // 0x000000018035C790-0x000000018035C7A0 
		}
	
		[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
		[StaticAccessor("MeshDataBindings", StaticAccessorType.DoubleColon)]
		public struct MeshData // TypeDefIndex: 7627
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal IntPtr m_Ptr; // 0x00
	
			// Properties
			public int vertexCount { get; } // 0x00000001821B5140-0x00000001821B5180 
			public int vertexBufferCount { get; } // 0x00000001821B5100-0x00000001821B5140 
			public IndexFormat indexFormat { get; } // 0x00000001821B5040-0x00000001821B5080 
			public int subMeshCount { get; set; } // 0x00000001821B50C0-0x00000001821B5100 0x00000001821B5180-0x00000001821B51C0
			public int lodCount { get; } // 0x00000001821B5080-0x00000001821B50C0 
	
			// Methods
			[NativeMethod(IsThreadSafe = true)]
			private static bool HasVertexAttribute(IntPtr self, VertexAttribute attr); // 0x00000001821B4C10-0x00000001821B4C50
			[NativeMethod(IsThreadSafe = true)]
			private static int GetVertexCount(IntPtr self); // 0x00000001821B4AE0-0x00000001821B4B20
			[NativeMethod(IsThreadSafe = true)]
			private static int GetVertexBufferCount(IntPtr self); // 0x00000001821B4AA0-0x00000001821B4AE0
			[NativeMethod(IsThreadSafe = true)]
			private static IntPtr GetVertexDataPtr(IntPtr self, int stream); // 0x00000001821B4B20-0x00000001821B4B60
			[NativeMethod(IsThreadSafe = true)]
			private static ulong GetVertexDataSize(IntPtr self, int stream); // 0x00000001821B4B60-0x00000001821B4BA0
			[NativeMethod(IsThreadSafe = true)]
			private static void CopyAttributeIntoPtr(IntPtr self, VertexAttribute attr, VertexAttributeFormat format, int dim, IntPtr dst); // 0x00000001821B4080-0x00000001821B40E0
			[NativeMethod(IsThreadSafe = true)]
			private static void CopyIndicesIntoPtr(IntPtr self, int submesh, int meshLod, bool applyBaseVertex, int dstStride, IntPtr dst); // 0x00000001821B40E0-0x00000001821B4150
			[NativeMethod(IsThreadSafe = true)]
			private static IndexFormat GetIndexFormat(IntPtr self); // 0x00000001821B4290-0x00000001821B42D0
			[NativeMethod(IsThreadSafe = true)]
			private static int GetIndexCount(IntPtr self, int submesh, int meshlod); // 0x00000001821B41C0-0x00000001821B4210
			[NativeMethod(IsThreadSafe = true)]
			private static IntPtr GetIndexDataPtr(IntPtr self); // 0x00000001821B4210-0x00000001821B4250
			[NativeMethod(IsThreadSafe = true)]
			private static ulong GetIndexDataSize(IntPtr self); // 0x00000001821B4250-0x00000001821B4290
			[NativeMethod(IsThreadSafe = true)]
			private static int GetSubMeshCount(IntPtr self); // 0x00000001821B46A0-0x00000001821B46E0
			[NativeMethod(IsThreadSafe = true)]
			private static int GetLodCount(IntPtr self); // 0x00000001821B45F0-0x00000001821B4630
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			private static SubMeshDescriptor GetSubMesh(IntPtr self, int index); // 0x00000001821B4730-0x00000001821B47A0
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			private static void SetVertexBufferParamsFromArray(IntPtr self, int vertexCount, params VertexAttributeDescriptor[] attributes); // 0x00000001821B4F00-0x00000001821B4FA0
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			private static void SetIndexBufferParamsImpl(IntPtr self, int indexCount, IndexFormat indexFormat); // 0x00000001821B4C90-0x00000001821B4CE0
			[NativeMethod(IsThreadSafe = true)]
			private static void SetSubMeshCount(IntPtr self, int count); // 0x00000001821B4D30-0x00000001821B4D70
			[NativeMethod(IsThreadSafe = true, ThrowsException = true)]
			private static void SetSubMeshImpl(IntPtr self, int index, SubMeshDescriptor desc, MeshUpdateFlags flags); // 0x00000001821B4DD0-0x00000001821B4E30
			public bool HasVertexAttribute(VertexAttribute attr); // 0x00000001821B4C50-0x00000001821B4C90
			public void GetVertices(NativeArray<Vector3> outVertices); // 0x00000001821B4BA0-0x00000001821B4C10
			public void GetNormals(NativeArray<Vector3> outNormals); // 0x00000001821B4630-0x00000001821B46A0
			public void GetTangents(NativeArray<Vector4> outTangents); // 0x00000001821B4830-0x00000001821B48A0
			public void GetColors(NativeArray<Color32> outColors); // 0x00000001821B4150-0x00000001821B41C0
			public void GetUVs(int channel, NativeArray<Vector2> outUVs); // 0x00000001821B48A0-0x00000001821B49A0
			public void GetUVs(int channel, NativeArray<Vector4> outUVs); // 0x00000001821B49A0-0x00000001821B4AA0
			public NativeArray<T> GetVertexData<T>([DefaultValue("0")] int stream = 0 /* Metadata: 0x0069D3D5 */)
				where T : struct;
			private void CopyAttributeInto<T>(NativeArray<T> buffer, VertexAttribute channel, VertexAttributeFormat format, int dim)
				where T : struct;
			public void SetVertexBufferParams(int vertexCount, params VertexAttributeDescriptor[] attributes); // 0x00000001821B4FA0-0x00000001821B5040
			public void SetIndexBufferParams(int indexCount, IndexFormat format); // 0x00000001821B4CE0-0x00000001821B4D30
			public void GetIndices(NativeArray<ushort> outIndices, int submesh, [DefaultValue("true")] bool applyBaseVertex = true /* Metadata: 0x0069D3D6 */); // 0x00000001821B45C0-0x00000001821B45F0
			public void GetIndices(NativeArray<ushort> outIndices, int submesh, int meshlod, [DefaultValue("true")] bool applyBaseVertex = true /* Metadata: 0x0069D3D7 */); // 0x00000001821B42D0-0x00000001821B45C0
			public NativeArray<T> GetIndexData<T>()
				where T : struct;
			public SubMeshDescriptor GetSubMesh(int index); // 0x00000001821B47A0-0x00000001821B4830
			public void SetSubMesh(int index, SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3D8 */); // 0x00000001821B4E30-0x00000001821B4EB0
			private static void GetSubMesh_Injected(IntPtr self, int index, ); // 0x00000001821B46E0-0x00000001821B4730
			private static void SetVertexBufferParamsFromArray_Injected(IntPtr self, int vertexCount, params ref ManagedSpanWrapper attributes); // 0x00000001821B4EB0-0x00000001821B4F00
			private static void SetSubMeshImpl_Injected(IntPtr self, int index, in SubMeshDescriptor desc, MeshUpdateFlags flags); // 0x00000001821B4D70-0x00000001821B4DD0
		}
	
		[NativeContainer]
		[NativeContainerSupportsMinMaxWriteRestriction]
		[StaticAccessor("MeshDataArrayBindings", StaticAccessorType.DoubleColon)]
		public struct MeshDataArray : IDisposable // TypeDefIndex: 7628
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe IntPtr* m_Ptrs; // 0x00
			internal int m_Length; // 0x08
	
			// Properties
			public int Length { get; } // 0x0000000180732D20-0x0000000180732D30 
			public MeshData this[int index] { get => default; } // 0x0000000180B1C370-0x0000000180B1C380 
	
			// Constructors
			internal unsafe MeshDataArray(Mesh mesh, bool checkReadWrite = true /* Metadata: 0x0069D3D9 */, bool createAsCopy = false /* Metadata: 0x0069D3DA */); // 0x00000001821B3CB0-0x00000001821B3F90
			internal unsafe MeshDataArray(int meshesCount); // 0x00000001821B3F90-0x00000001821B4080
	
			// Methods
			private static unsafe void AcquireReadOnlyMeshData([NotNull] Mesh mesh, IntPtr* datas); // 0x00000001821B3870-0x00000001821B3910
			private static unsafe void AcquireMeshDataCopy([NotNull] Mesh mesh, IntPtr* datas); // 0x00000001821B3780-0x00000001821B3820
			private static unsafe void ReleaseMeshDatas(IntPtr* datas, int count); // 0x00000001821B3C70-0x00000001821B3CB0
			private static unsafe void CreateNewMeshDatas(IntPtr* datas, int count); // 0x00000001821B3BA0-0x00000001821B3BE0
			[NativeMethod(ThrowsException = true)]
			private static void ApplyToMeshImpl([NotNull] Mesh mesh, IntPtr data, MeshUpdateFlags flags); // 0x00000001821B3AF0-0x00000001821B3BA0
			public void Dispose(); // 0x00000001821B3BE0-0x00000001821B3C70
			internal void ApplyToMeshAndDispose(Mesh mesh, MeshUpdateFlags flags); // 0x00000001821B3910-0x00000001821B3A90
			private static unsafe void AcquireReadOnlyMeshData_Injected(IntPtr mesh, IntPtr* datas); // 0x00000001821B3820-0x00000001821B3870
			private static unsafe void AcquireMeshDataCopy_Injected(IntPtr mesh, IntPtr* datas); // 0x00000001821B3730-0x00000001821B3780
			private static void ApplyToMeshImpl_Injected(IntPtr mesh, IntPtr data, MeshUpdateFlags flags); // 0x00000001821B3A90-0x00000001821B3AF0
		}
	
		// Constructors
		[RequiredByNativeCode]
		public Mesh(); // 0x00000001821BA530-0x00000001821BA5A0
	
		// Methods
		[FreeFunction("MeshScripting::CreateMesh")]
		private static void Internal_Create([Writable] Mesh mono); // 0x00000001821B79B0-0x00000001821B79F0
		[FreeFunction(Name = "MeshScripting::SetIndexBufferParams", HasExplicitThis = true, ThrowsException = true)]
		public void SetIndexBufferParams(int indexCount, IndexFormat format); // 0x00000001821B8400-0x00000001821B8470
		[FreeFunction(Name = "MeshScripting::InternalSetIndexBufferData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetIndexBufferData(IntPtr data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags); // 0x00000001821B7850-0x00000001821B78D0
		[FreeFunction(Name = "MeshScripting::SetVertexBufferParamsFromArray", HasExplicitThis = true, ThrowsException = true)]
		private void SetVertexBufferParamsFromArray(int vertexCount, params VertexAttributeDescriptor[] attributes); // 0x00000001821BA190-0x00000001821BA250
		[FreeFunction(Name = "MeshScripting::InternalSetVertexBufferData", HasExplicitThis = true)]
		private void InternalSetVertexBufferData(int stream, IntPtr data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags); // 0x00000001821B7930-0x00000001821B79B0
		[FreeFunction(Name = "MeshScripting::GetIndexCount", HasExplicitThis = true)]
		private uint GetIndexCountImpl(int submesh, int meshlod); // 0x00000001821B60E0-0x00000001821B6150
		[FreeFunction(Name = "MeshScripting::GetTriangles", HasExplicitThis = true)]
		private int[] GetTrianglesImpl(int submesh, bool applyBaseVertex, int meshlod); // 0x00000001821B6B10-0x00000001821B6C80
		[FreeFunction(Name = "MeshScripting::GetIndices", HasExplicitThis = true)]
		private int[] GetIndicesImpl(int submesh, bool applyBaseVertex, int meshlod); // 0x00000001821B62C0-0x00000001821B6430
		[FreeFunction(Name = "SetMeshIndicesFromScript", HasExplicitThis = true, ThrowsException = true)]
		private void SetIndicesImpl(int submesh, MeshTopology topology, IndexFormat indicesFormat, Span<byte> indices, int arrayStart, int arraySize, bool calculateBounds, int baseVertex, int meshlod); // 0x00000001821B84E0-0x00000001821B85F0
		[FreeFunction(Name = "MeshScripting::PrintErrorCantAccessChannel", HasExplicitThis = true)]
		private void PrintErrorCantAccessChannel(VertexAttribute ch); // 0x00000001821B7B70-0x00000001821B7BD0
		[FreeFunction(Name = "MeshScripting::HasChannel", HasExplicitThis = true)]
		public bool HasVertexAttribute(VertexAttribute attr); // 0x00000001821B7780-0x00000001821B77E0
		[FreeFunction(Name = "MeshScripting::GetChannelDimension", HasExplicitThis = true)]
		public int GetVertexAttributeDimension(VertexAttribute attr); // 0x00000001821B7230-0x00000001821B7290
		[FreeFunction(Name = "MeshScripting::GetChannelFormat", HasExplicitThis = true)]
		public VertexAttributeFormat GetVertexAttributeFormat(VertexAttribute attr); // 0x00000001821B72D0-0x00000001821B7330
		[FreeFunction(Name = "MeshScripting::GetChannelStream", HasExplicitThis = true)]
		public int GetVertexAttributeStream(VertexAttribute attr); // 0x00000001821B7410-0x00000001821B7470
		[FreeFunction(Name = "MeshScripting::GetChannelOffset", HasExplicitThis = true)]
		public int GetVertexAttributeOffset(VertexAttribute attr); // 0x00000001821B7370-0x00000001821B73D0
		[FreeFunction(Name = "SetMeshComponentFromSpanFromScript", HasExplicitThis = true)]
		private void SetArrayForChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, Span<byte> values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags); // 0x00000001821B7F80-0x00000001821B8080
		[FreeFunction(Name = "SetMeshComponentFromNativeArrayFromScript", HasExplicitThis = true)]
		private void SetNativeArrayForChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, IntPtr values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags); // 0x00000001821B9030-0x00000001821B90B0
		[FreeFunction(Name = "AllocExtractMeshComponentFromScript", HasExplicitThis = true)]
		private Array GetAllocArrayFromChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim); // 0x00000001821B5DF0-0x00000001821B5E70
		[FreeFunction(Name = "MeshScripting::GetVertexBufferStride", HasExplicitThis = true)]
		public int GetVertexBufferStride(int stream); // 0x00000001821B75A0-0x00000001821B7600
		[FreeFunction(Name = "MeshScripting::GetVertexBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		private GraphicsBuffer GetVertexBufferImpl(int index); // 0x00000001821B74B0-0x00000001821B7560
		[FreeFunction(Name = "MeshScripting::GetIndexBufferPtr", HasExplicitThis = true, ThrowsException = true)]
		private GraphicsBuffer GetIndexBufferImpl(); // 0x00000001821B5EB0-0x00000001821B5F60
		[FreeFunction("MeshScripting::SetSubMesh", HasExplicitThis = true, ThrowsException = true)]
		public void SetSubMesh(int index, SubMeshDescriptor desc, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3BD */); // 0x00000001821B9A30-0x00000001821B9AB0
		[FreeFunction("MeshScripting::GetSubMesh", HasExplicitThis = true, ThrowsException = true)]
		public SubMeshDescriptor GetSubMesh(int index); // 0x00000001821B6870-0x00000001821B68F0
		[FreeFunction("MeshScripting::GetLodCount", HasExplicitThis = true)]
		private int GetLodCount(); // 0x00000001821B67C0-0x00000001821B6820
		[NativeMethod("Clear")]
		private void ClearImpl(bool keepVertexLayout); // 0x00000001821B5C20-0x00000001821B5C80
		[NativeMethod("RecalculateBounds")]
		private void RecalculateBoundsImpl(MeshUpdateFlags flags); // 0x00000001821B7C90-0x00000001821B7CF0
		[NativeMethod("MarkDynamic")]
		private void MarkDynamicImpl(); // 0x00000001821B7A30-0x00000001821B7A90
		[NativeMethod("UploadMeshData")]
		private void UploadMeshDataImpl(bool markNoLongerReadable); // 0x00000001821BA420-0x00000001821BA480
		[FreeFunction(Name = "MeshScripting::GetPrimitiveType", HasExplicitThis = true)]
		private MeshTopology GetTopologyImpl(int submesh); // 0x00000001821B6930-0x00000001821B6990
		internal static VertexAttribute GetUVChannel(int uvIndex); // 0x00000001821B7170-0x00000001821B71F0
		internal static int DefaultDimensionForChannel(VertexAttribute channel); // 0x00000001821B5CE0-0x00000001821B5D90
		private T[] GetAllocArrayFromChannel<T>(VertexAttribute channel, VertexAttributeFormat format, int dim);
		private T[] GetAllocArrayFromChannel<T>(VertexAttribute channel)
			where T : struct;
		private void SetSizedArrayForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, Span<byte> values, int valuesArrayLength, int valuesStart, int valuesCount, MeshUpdateFlags flags); // 0x00000001821B9230-0x00000001821B9640
		private void SetSizedNativeArrayForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, IntPtr values, int valuesArrayLength, int valuesStart, int valuesCount, MeshUpdateFlags flags); // 0x00000001821B9640-0x00000001821B99D0
		private void SetArrayForChannel<T>(VertexAttribute channel, VertexAttributeFormat format, int dim, T[] values, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3BE */)
			where T : struct;
		private void SetArrayForChannel<T>(VertexAttribute channel, T[] values, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3BF */)
			where T : struct;
		private void SetListForChannel<T>(VertexAttribute channel, VertexAttributeFormat format, int dim, List<T> values, int start, int length, MeshUpdateFlags flags)
			where T : struct;
		private void SetListForChannel<T>(VertexAttribute channel, List<T> values, int start, int length, MeshUpdateFlags flags)
			where T : struct;
		public void SetVertices(List<Vector3> inVertices); // 0x00000001821BA350-0x00000001821BA3D0
		[ExcludeFromDocs]
		public void SetVertices(List<Vector3> inVertices, int start, int length); // 0x00000001821BA2D0-0x00000001821BA350
		public void SetVertices(List<Vector3> inVertices, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821BA250-0x00000001821BA2D0
		public void SetVertices<T>(NativeArray<T> inVertices)
			where T : struct;
		[ExcludeFromDocs]
		public void SetVertices<T>(NativeArray<T> inVertices, int start, int length)
			where T : struct;
		public void SetVertices<T>(NativeArray<T> inVertices, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
			where T : struct;
		public void SetNormals(List<Vector3> inNormals); // 0x00000001821B91B0-0x00000001821B9230
		[ExcludeFromDocs]
		public void SetNormals(List<Vector3> inNormals, int start, int length); // 0x00000001821B9130-0x00000001821B91B0
		public void SetNormals(List<Vector3> inNormals, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B90B0-0x00000001821B9130
		public void SetNormals<T>(NativeArray<T> inNormals)
			where T : struct;
		[ExcludeFromDocs]
		public void SetNormals<T>(NativeArray<T> inNormals, int start, int length)
			where T : struct;
		public void SetNormals<T>(NativeArray<T> inNormals, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
			where T : struct;
		public void SetTangents(List<Vector4> inTangents); // 0x00000001821B9AB0-0x00000001821B9B30
		[ExcludeFromDocs]
		public void SetTangents(List<Vector4> inTangents, int start, int length); // 0x00000001821B9BB0-0x00000001821B9C30
		public void SetTangents(List<Vector4> inTangents, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B9B30-0x00000001821B9BB0
		public void SetColors(List<Color> inColors); // 0x00000001821B8330-0x00000001821B83B0
		[ExcludeFromDocs]
		public void SetColors(List<Color> inColors, int start, int length); // 0x00000001821B8110-0x00000001821B8190
		public void SetColors(List<Color> inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B8220-0x00000001821B82A0
		public void SetColors(List<Color32> inColors); // 0x00000001821B8190-0x00000001821B8220
		[ExcludeFromDocs]
		public void SetColors(List<Color32> inColors, int start, int length); // 0x00000001821B82A0-0x00000001821B8330
		public void SetColors(List<Color32> inColors, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B8080-0x00000001821B8110
		private void SetUvsImpl<T>(int uvIndex, int dim, List<T> uvs, int start, int length, MeshUpdateFlags flags)
			where T : struct;
		public void SetUVs(int channel, List<Vector2> uvs); // 0x00000001821B9D50-0x00000001821B9DE0
		public void SetUVs(int channel, List<Vector4> uvs); // 0x00000001821B9F00-0x00000001821B9F90
		[ExcludeFromDocs]
		public void SetUVs(int channel, List<Vector2> uvs, int start, int length); // 0x00000001821B9E70-0x00000001821B9F00
		public void SetUVs(int channel, List<Vector2> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821BA020-0x00000001821BA0B0
		[ExcludeFromDocs]
		public void SetUVs(int channel, List<Vector4> uvs, int start, int length); // 0x00000001821B9DE0-0x00000001821B9E70
		public void SetUVs(int channel, List<Vector4> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B9C30-0x00000001821B9CC0
		private void SetUvsImpl<T>(int uvIndex, int dim, T[] uvs, int arrayStart, int arraySize, MeshUpdateFlags flags)
			where T : struct;
		public void SetUVs(int channel, Vector4[] uvs); // 0x00000001821BA0B0-0x00000001821BA140
		[ExcludeFromDocs]
		public void SetUVs(int channel, Vector4[] uvs, int start, int length); // 0x00000001821B9F90-0x00000001821BA020
		public void SetUVs(int channel, Vector4[] uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B9CC0-0x00000001821B9D50
		public void SetUVs<T>(int channel, NativeArray<T> uvs)
			where T : struct;
		[ExcludeFromDocs]
		public void SetUVs<T>(int channel, NativeArray<T> uvs, int start, int length)
			where T : struct;
		public void SetUVs<T>(int channel, NativeArray<T> uvs, int start, int length, [DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags)
			where T : struct;
		public void SetVertexBufferParams(int vertexCount, params VertexAttributeDescriptor[] attributes); // 0x00000001821BA190-0x00000001821BA250
		public void SetVertexBufferData<T>(NativeArray<T> data, int dataStart, int meshBufferStart, int count, int stream = 0 /* Metadata: 0x0069D3C0 */, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3C1 */)
			where T : struct;
		public static MeshDataArray AcquireReadOnlyMeshData(Mesh mesh); // 0x00000001821B5430-0x00000001821B5460
		public static MeshDataArray AllocateWritableMeshData(int meshCount); // 0x00000001821B5460-0x00000001821B5550
		public static void ApplyAndDisposeWritableMeshData(MeshDataArray data, Mesh mesh, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3C2 */); // 0x00000001821B5550-0x00000001821B5800
		public GraphicsBuffer GetVertexBuffer(int index); // 0x00000001821B7600-0x00000001821B7740
		public GraphicsBuffer GetIndexBuffer(); // 0x00000001821B5F60-0x00000001821B6090
		private void PrintErrorCantAccessIndices(); // 0x00000001821B7BD0-0x00000001821B7C50
		private bool CheckCanAccessSubmesh(int submesh, bool errorAboutTriangles); // 0x00000001821B5820-0x00000001821B5980
		private bool CheckCanAccessSubmeshTriangles(int submesh); // 0x00000001821B5810-0x00000001821B5820
		private bool CheckCanAccessSubmeshIndices(int submesh); // 0x00000001821B5800-0x00000001821B5810
		public int[] GetTriangles(int submesh); // 0x00000001821B6C80-0x00000001821B6E20
		public int[] GetTriangles(int submesh, [DefaultValue("true")] bool applyBaseVertex); // 0x00000001821B6FD0-0x00000001821B7170
		public int[] GetTriangles(int submesh, int meshLod, bool applyBaseVertex); // 0x00000001821B6E20-0x00000001821B6FD0
		[ExcludeFromDocs]
		public int[] GetIndices(int submesh); // 0x00000001821B6430-0x00000001821B65D0
		public int[] GetIndices(int submesh, int meshLod, bool applyBaseVertex = true /* Metadata: 0x0069D3C3 */); // 0x00000001821B65D0-0x00000001821B6780
		public void SetIndexBufferData<T>(NativeArray<T> data, int dataStart, int meshBufferStart, int count, MeshUpdateFlags flags = MeshUpdateFlags.Default /* Metadata: 0x0069D3C4 */)
			where T : struct;
		public uint GetIndexCount(int submesh); // 0x00000001821B6150-0x00000001821B6250
		private void CheckIndicesArrayRange(int valuesLength, int start, int length); // 0x00000001821B5980-0x00000001821B5BD0
		private void SetTrianglesImpl<T>(int submesh, IndexFormat indicesFormat, T[] triangles, int trianglesArrayLength, int start, int length, bool calculateBounds, int baseVertex, int meshLod)
			where T : struct;
		[ExcludeFromDocs]
		public void SetIndices(int[] indices, MeshTopology topology, int submesh); // 0x00000001821B88E0-0x00000001821B8950
		[ExcludeFromDocs]
		public void SetIndices(int[] indices, MeshTopology topology, int submesh, bool calculateBounds); // 0x00000001821B8F50-0x00000001821B8FD0
		public void SetIndices(int[] indices, MeshTopology topology, int submesh, [DefaultValue("true")] bool calculateBounds, [DefaultValue("0")] int baseVertex); // 0x00000001821B8C60-0x00000001821B8CE0
		public void SetIndices(int[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true /* Metadata: 0x0069D3C5 */, int baseVertex = 0 /* Metadata: 0x0069D3C6 */); // 0x00000001821B8890-0x00000001821B88E0
		public void SetIndices(int[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, int meshLod, bool calculateBounds = true /* Metadata: 0x0069D3C7 */, int baseVertex = 0 /* Metadata: 0x0069D3C8 */); // 0x00000001821B8670-0x00000001821B8890
		public void SetIndices(ushort[] indices, MeshTopology topology, int submesh, bool calculateBounds = true /* Metadata: 0x0069D3C9 */, int baseVertex = 0 /* Metadata: 0x0069D3CA */); // 0x00000001821B85F0-0x00000001821B8670
		public void SetIndices(ushort[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true /* Metadata: 0x0069D3CB */, int baseVertex = 0 /* Metadata: 0x0069D3CC */); // 0x00000001821B8CE0-0x00000001821B8D30
		public void SetIndices(ushort[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, int meshLod, bool calculateBounds = true /* Metadata: 0x0069D3CD */, int baseVertex = 0 /* Metadata: 0x0069D3CE */); // 0x00000001821B8D30-0x00000001821B8F50
		public void SetIndices(List<int> indices, MeshTopology topology, int submesh, bool calculateBounds = true /* Metadata: 0x0069D3CF */, int baseVertex = 0 /* Metadata: 0x0069D3D0 */); // 0x00000001821B8950-0x00000001821B89D0
		public void SetIndices(List<int> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true /* Metadata: 0x0069D3D1 */, int baseVertex = 0 /* Metadata: 0x0069D3D2 */); // 0x00000001821B89D0-0x00000001821B8A20
		public void SetIndices(List<int> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, int meshLod, bool calculateBounds = true /* Metadata: 0x0069D3D3 */, int baseVertex = 0 /* Metadata: 0x0069D3D4 */); // 0x00000001821B8A20-0x00000001821B8C60
		[ExcludeFromDocs]
		public void Clear(); // 0x00000001821B5C80-0x00000001821B5CE0
		[ExcludeFromDocs]
		public void RecalculateBounds(); // 0x00000001821B7CF0-0x00000001821B7E00
		public void RecalculateBounds([DefaultValue("MeshUpdateFlags.Default")] MeshUpdateFlags flags); // 0x00000001821B7E00-0x00000001821B7F20
		public void MarkDynamic(); // 0x00000001821B7A90-0x00000001821B7B30
		public void UploadMeshData(bool markNoLongerReadable); // 0x00000001821BA480-0x00000001821BA530
		public MeshTopology GetTopology(int submesh); // 0x00000001821B6990-0x00000001821B6AA0
		private static IndexFormat get_indexFormat_Injected(IntPtr _unity_self); // 0x00000001821BA7F0-0x00000001821BA830
		private static void set_indexFormat_Injected(IntPtr _unity_self, IndexFormat value); // 0x00000001821BAE20-0x00000001821BAE60
		private static void SetIndexBufferParams_Injected(IntPtr _unity_self, int indexCount, IndexFormat format); // 0x00000001821B83B0-0x00000001821B8400
		private static void InternalSetIndexBufferData_Injected(IntPtr _unity_self, IntPtr data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags); // 0x00000001821B77E0-0x00000001821B7850
		private static void SetVertexBufferParamsFromArray_Injected(IntPtr _unity_self, int vertexCount, params ref ManagedSpanWrapper attributes); // 0x00000001821BA140-0x00000001821BA190
		private static void InternalSetVertexBufferData_Injected(IntPtr _unity_self, int stream, IntPtr data, int dataStart, int meshBufferStart, int count, int elemSize, MeshUpdateFlags flags); // 0x00000001821B78D0-0x00000001821B7930
		private static uint GetIndexCountImpl_Injected(IntPtr _unity_self, int submesh, int meshlod); // 0x00000001821B6090-0x00000001821B60E0
		private static void GetTrianglesImpl_Injected(IntPtr _unity_self, int submesh, bool applyBaseVertex, int meshlod, ); // 0x00000001821B6AA0-0x00000001821B6B10
		private static void GetIndicesImpl_Injected(IntPtr _unity_self, int submesh, bool applyBaseVertex, int meshlod, ); // 0x00000001821B6250-0x00000001821B62C0
		private static void SetIndicesImpl_Injected(IntPtr _unity_self, int submesh, MeshTopology topology, IndexFormat indicesFormat, ref ManagedSpanWrapper indices, int arrayStart, int arraySize, bool calculateBounds, int baseVertex, int meshlod); // 0x00000001821B8470-0x00000001821B84E0
		private static void PrintErrorCantAccessChannel_Injected(IntPtr _unity_self, VertexAttribute ch); // 0x00000001821B7B30-0x00000001821B7B70
		private static bool HasVertexAttribute_Injected(IntPtr _unity_self, VertexAttribute attr); // 0x00000001821B7740-0x00000001821B7780
		private static int GetVertexAttributeDimension_Injected(IntPtr _unity_self, VertexAttribute attr); // 0x00000001821B71F0-0x00000001821B7230
		private static VertexAttributeFormat GetVertexAttributeFormat_Injected(IntPtr _unity_self, VertexAttribute attr); // 0x00000001821B7290-0x00000001821B72D0
		private static int GetVertexAttributeStream_Injected(IntPtr _unity_self, VertexAttribute attr); // 0x00000001821B73D0-0x00000001821B7410
		private static int GetVertexAttributeOffset_Injected(IntPtr _unity_self, VertexAttribute attr); // 0x00000001821B7330-0x00000001821B7370
		private static void SetArrayForChannelImpl_Injected(IntPtr _unity_self, VertexAttribute channel, VertexAttributeFormat format, int dim, ref ManagedSpanWrapper values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags); // 0x00000001821B7F20-0x00000001821B7F80
		private static void SetNativeArrayForChannelImpl_Injected(IntPtr _unity_self, VertexAttribute channel, VertexAttributeFormat format, int dim, IntPtr values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags); // 0x00000001821B8FD0-0x00000001821B9030
		private static Array GetAllocArrayFromChannelImpl_Injected(IntPtr _unity_self, VertexAttribute channel, VertexAttributeFormat format, int dim); // 0x00000001821B5D90-0x00000001821B5DF0
		private static int GetVertexBufferStride_Injected(IntPtr _unity_self, int stream); // 0x00000001821B7560-0x00000001821B75A0
		private static IntPtr GetVertexBufferImpl_Injected(IntPtr _unity_self, int index); // 0x00000001821B7470-0x00000001821B74B0
		private static IntPtr GetIndexBufferImpl_Injected(IntPtr _unity_self); // 0x00000001821B5E70-0x00000001821B5EB0
		private static GraphicsBuffer.Target get_vertexBufferTarget_Injected(IntPtr _unity_self); // 0x00000001821BAAE0-0x00000001821BAB20
		private static void set_vertexBufferTarget_Injected(IntPtr _unity_self, GraphicsBuffer.Target value); // 0x00000001821BB1E0-0x00000001821BB220
		private static GraphicsBuffer.Target get_indexBufferTarget_Injected(IntPtr _unity_self); // 0x00000001821BA750-0x00000001821BA790
		private static void set_indexBufferTarget_Injected(IntPtr _unity_self, GraphicsBuffer.Target value); // 0x00000001821BAD80-0x00000001821BADC0
		private static bool get_canAccess_Injected(IntPtr _unity_self); // 0x00000001821BA660-0x00000001821BA6A0
		private static int get_vertexCount_Injected(IntPtr _unity_self); // 0x00000001821BAB80-0x00000001821BABC0
		private static int get_subMeshCount_Injected(IntPtr _unity_self); // 0x00000001821BA8D0-0x00000001821BA910
		private static void set_subMeshCount_Injected(IntPtr _unity_self, int value); // 0x00000001821BAF20-0x00000001821BAF60
		private static void SetSubMesh_Injected(IntPtr _unity_self, int index, in SubMeshDescriptor desc, MeshUpdateFlags flags); // 0x00000001821B99D0-0x00000001821B9A30
		private static void GetSubMesh_Injected(IntPtr _unity_self, int index, ); // 0x00000001821B6820-0x00000001821B6870
		private static int GetLodCount_Injected(IntPtr _unity_self); // 0x00000001821B6780-0x00000001821B67C0
		private static void get_bounds_Injected(IntPtr _unity_self, ); // 0x00000001821BA5A0-0x00000001821BA5F0
		private static void set_bounds_Injected(IntPtr _unity_self, in Bounds value); // 0x00000001821BAC60-0x00000001821BACB0
		private static void ClearImpl_Injected(IntPtr _unity_self, bool keepVertexLayout); // 0x00000001821B5BD0-0x00000001821B5C20
		private static void RecalculateBoundsImpl_Injected(IntPtr _unity_self, MeshUpdateFlags flags); // 0x00000001821B7C50-0x00000001821B7C90
		private static void MarkDynamicImpl_Injected(IntPtr _unity_self); // 0x00000001821B79F0-0x00000001821B7A30
		private static void UploadMeshDataImpl_Injected(IntPtr _unity_self, bool markNoLongerReadable); // 0x00000001821BA3D0-0x00000001821BA420
		private static MeshTopology GetTopologyImpl_Injected(IntPtr _unity_self, int submesh); // 0x00000001821B68F0-0x00000001821B6930
	}
}
