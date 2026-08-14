namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
[RequiredByNativeCode]
public sealed class Mesh : object
{
	[NativeHeader("Runtime/Graphics/Mesh/MeshScriptBindings.h")]
	[StaticAccessor("MeshDataBindings", StaticAccessorType::DoubleColon (2))]
	internal struct MeshData
	{
		[NativeDisableUnsafePtrRestriction]
		internal IntPtr m_Ptr; //Field offset: 0x0

	}


	public Bounds bounds
	{
		 get { } //Length: 148
		 set { } //Length: 133
	}

	internal bool canAccess
	{
		[NativeMethod("CanAccessFromScript")]
		internal get { } //Length: 118
	}

	public Color32[] colors32
	{
		 get { } //Length: 80
		 set { } //Length: 105
	}

	public IndexFormat indexFormat
	{
		 set { } //Length: 131
	}

	public Vector3[] normals
	{
		 get { } //Length: 62
		 set { } //Length: 86
	}

	public int subMeshCount
	{
		[NativeMethod(Name = "GetSubMeshCount")]
		 get { } //Length: 118
	}

	public Vector4[] tangents
	{
		 get { } //Length: 62
		 set { } //Length: 86
	}

	public Int32[] triangles
	{
		 set { } //Length: 244
	}

	public Vector2[] uv
	{
		 set { } //Length: 86
	}

	public Vector2[] uv2
	{
		 set { } //Length: 86
	}

	public int vertexCount
	{
		[NativeMethod("GetVertexCount")]
		 get { } //Length: 118
	}

	public Vector3[] vertices
	{
		 get { } //Length: 59
		 set { } //Length: 83
	}

	[RequiredByNativeCode]
	public Mesh() { }

	private bool CheckCanAccessSubmesh(int submesh, bool errorAboutTriangles) { }

	private bool CheckCanAccessSubmeshIndices(int submesh) { }

	private bool CheckCanAccessSubmeshTriangles(int submesh) { }

	private void CheckIndicesArrayRange(int valuesLength, int start, int length) { }

	[ExcludeFromDocs]
	public void Clear() { }

	[NativeMethod("Clear")]
	private void ClearImpl(bool keepVertexLayout) { }

	private static void ClearImpl_Injected(IntPtr _unity_self, bool keepVertexLayout) { }

	internal static int DefaultDimensionForChannel(VertexAttribute channel) { }

	public Bounds get_bounds() { }

	private static void get_bounds_Injected(IntPtr _unity_self, out Bounds ret) { }

	[NativeMethod("CanAccessFromScript")]
	internal bool get_canAccess() { }

	private static bool get_canAccess_Injected(IntPtr _unity_self) { }

	public Color32[] get_colors32() { }

	public Vector3[] get_normals() { }

	[NativeMethod(Name = "GetSubMeshCount")]
	public int get_subMeshCount() { }

	private static int get_subMeshCount_Injected(IntPtr _unity_self) { }

	public Vector4[] get_tangents() { }

	[NativeMethod("GetVertexCount")]
	public int get_vertexCount() { }

	private static int get_vertexCount_Injected(IntPtr _unity_self) { }

	public Vector3[] get_vertices() { }

	private T[] GetAllocArrayFromChannel(VertexAttribute channel, VertexAttributeFormat format, int dim) { }

	private T[] GetAllocArrayFromChannel(VertexAttribute channel) { }

	[FreeFunction(Name = "AllocExtractMeshComponentFromScript", HasExplicitThis = True)]
	private Array GetAllocArrayFromChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim) { }

	private static Array GetAllocArrayFromChannelImpl_Injected(IntPtr _unity_self, VertexAttribute channel, VertexAttributeFormat format, int dim) { }

	[FreeFunction(Name = "ExtractMeshComponentFromScript", HasExplicitThis = True)]
	private void GetArrayFromChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, Array values) { }

	private static void GetArrayFromChannelImpl_Injected(IntPtr _unity_self, VertexAttribute channel, VertexAttributeFormat format, int dim, Array values) { }

	public uint GetIndexCount(int submesh) { }

	[FreeFunction(Name = "MeshScripting::GetIndexCount", HasExplicitThis = True)]
	private uint GetIndexCountImpl(int submesh) { }

	private static uint GetIndexCountImpl_Injected(IntPtr _unity_self, int submesh) { }

	public Int32[] GetIndices(int submesh, bool applyBaseVertex) { }

	[ExcludeFromDocs]
	public Int32[] GetIndices(int submesh) { }

	[FreeFunction(Name = "MeshScripting::GetIndices", HasExplicitThis = True)]
	private Int32[] GetIndicesImpl(int submesh, bool applyBaseVertex) { }

	private static void GetIndicesImpl_Injected(IntPtr _unity_self, int submesh, bool applyBaseVertex, out BlittableArrayWrapper ret) { }

	private void GetListForChannel(List<T> buffer, int capacity, VertexAttribute channel, int dim) { }

	private void GetListForChannel(List<T> buffer, int capacity, VertexAttribute channel, int dim, VertexAttributeFormat channelType) { }

	internal static VertexAttribute GetUVChannel(int uvIndex) { }

	public void GetUVs(int channel, List<Vector4> uvs) { }

	private void GetUVsImpl(int uvIndex, List<T> uvs, int dim) { }

	[FreeFunction(Name = "MeshScripting::HasChannel", HasExplicitThis = True)]
	public bool HasVertexAttribute(VertexAttribute attr) { }

	private static bool HasVertexAttribute_Injected(IntPtr _unity_self, VertexAttribute attr) { }

	[FreeFunction("MeshScripting::CreateMesh")]
	private static void Internal_Create(Mesh mono) { }

	public void MarkDynamic() { }

	[NativeMethod("MarkDynamic")]
	private void MarkDynamicImpl() { }

	private static void MarkDynamicImpl_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "MeshScripting::PrintErrorCantAccessChannel", HasExplicitThis = True)]
	private void PrintErrorCantAccessChannel(VertexAttribute ch) { }

	private static void PrintErrorCantAccessChannel_Injected(IntPtr _unity_self, VertexAttribute ch) { }

	private void PrintErrorCantAccessIndices() { }

	[ExcludeFromDocs]
	public void RecalculateBounds() { }

	public void RecalculateBounds(MeshUpdateFlags flags) { }

	[NativeMethod("RecalculateBounds")]
	private void RecalculateBoundsImpl(MeshUpdateFlags flags) { }

	private static void RecalculateBoundsImpl_Injected(IntPtr _unity_self, MeshUpdateFlags flags) { }

	public void set_bounds(Bounds value) { }

	private static void set_bounds_Injected(IntPtr _unity_self, in Bounds value) { }

	public void set_colors32(Color32[] value) { }

	public void set_indexFormat(IndexFormat value) { }

	private static void set_indexFormat_Injected(IntPtr _unity_self, IndexFormat value) { }

	public void set_normals(Vector3[] value) { }

	public void set_tangents(Vector4[] value) { }

	public void set_triangles(Int32[] value) { }

	public void set_uv(Vector2[] value) { }

	public void set_uv2(Vector2[] value) { }

	public void set_vertices(Vector3[] value) { }

	private void SetArrayForChannel(VertexAttribute channel, T[] values, MeshUpdateFlags flags = 0) { }

	private void SetArrayForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, T[] values, MeshUpdateFlags flags = 0) { }

	[FreeFunction(Name = "SetMeshComponentFromArrayFromScript", HasExplicitThis = True)]
	private void SetArrayForChannelImpl(VertexAttribute channel, VertexAttributeFormat format, int dim, Array values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags) { }

	private static void SetArrayForChannelImpl_Injected(IntPtr _unity_self, VertexAttribute channel, VertexAttributeFormat format, int dim, Array values, int arraySize, int valuesStart, int valuesCount, MeshUpdateFlags flags) { }

	public void SetColors(List<Color32> inColors, int start, int length, MeshUpdateFlags flags) { }

	[ExcludeFromDocs]
	public void SetColors(List<Color32> inColors, int start, int length) { }

	[ExcludeFromDocs]
	public void SetColors(List<Color> inColors, int start, int length) { }

	public void SetColors(List<Color> inColors, int start, int length, MeshUpdateFlags flags) { }

	public void SetColors(List<Color32> inColors) { }

	public void SetColors(List<Color> inColors) { }

	public void SetIndices(Int32[] indices, MeshTopology topology, int submesh, bool calculateBounds, int baseVertex) { }

	public void SetIndices(List<Int32> indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) { }

	public void SetIndices(List<Int32> indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) { }

	public void SetIndices(UInt16[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) { }

	public void SetIndices(UInt16[] indices, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) { }

	public void SetIndices(Int32[] indices, int indicesStart, int indicesLength, MeshTopology topology, int submesh, bool calculateBounds = true, int baseVertex = 0) { }

	[ExcludeFromDocs]
	public void SetIndices(Int32[] indices, MeshTopology topology, int submesh, bool calculateBounds) { }

	[FreeFunction(Name = "SetMeshIndicesFromScript", HasExplicitThis = True, ThrowsException = True)]
	private void SetIndicesImpl(int submesh, MeshTopology topology, IndexFormat indicesFormat, Array indices, int arrayStart, int arraySize, bool calculateBounds, int baseVertex) { }

	private static void SetIndicesImpl_Injected(IntPtr _unity_self, int submesh, MeshTopology topology, IndexFormat indicesFormat, Array indices, int arrayStart, int arraySize, bool calculateBounds, int baseVertex) { }

	private void SetListForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, List<T> values, int start, int length, MeshUpdateFlags flags) { }

	private void SetListForChannel(VertexAttribute channel, List<T> values, int start, int length, MeshUpdateFlags flags) { }

	public void SetNormals(List<Vector3> inNormals) { }

	public void SetNormals(List<Vector3> inNormals, int start, int length, MeshUpdateFlags flags) { }

	[ExcludeFromDocs]
	public void SetNormals(List<Vector3> inNormals, int start, int length) { }

	private void SetSizedArrayForChannel(VertexAttribute channel, VertexAttributeFormat format, int dim, Array values, int valuesArrayLength, int valuesStart, int valuesCount, MeshUpdateFlags flags) { }

	public void SetTangents(List<Vector4> inTangents) { }

	[ExcludeFromDocs]
	public void SetTangents(List<Vector4> inTangents, int start, int length) { }

	public void SetTangents(List<Vector4> inTangents, int start, int length, MeshUpdateFlags flags) { }

	public void SetTriangles(List<Int32> triangles, int submesh, bool calculateBounds, int baseVertex) { }

	[ExcludeFromDocs]
	public void SetTriangles(List<Int32> triangles, int submesh) { }

	public void SetTriangles(List<Int32> triangles, int trianglesStart, int trianglesLength, int submesh, bool calculateBounds = true, int baseVertex = 0) { }

	private void SetTrianglesImpl(int submesh, IndexFormat indicesFormat, Array triangles, int trianglesArrayLength, int start, int length, bool calculateBounds, int baseVertex) { }

	[ExcludeFromDocs]
	public void SetUVs(int channel, Vector4[] uvs, int start, int length) { }

	public void SetUVs(int channel, Vector4[] uvs, int start, int length, MeshUpdateFlags flags) { }

	public void SetUVs(int channel, List<Vector2> uvs) { }

	public void SetUVs(int channel, List<Vector4> uvs) { }

	[ExcludeFromDocs]
	public void SetUVs(int channel, List<Vector2> uvs, int start, int length) { }

	public void SetUVs(int channel, List<Vector2> uvs, int start, int length, MeshUpdateFlags flags) { }

	[ExcludeFromDocs]
	public void SetUVs(int channel, List<Vector4> uvs, int start, int length) { }

	public void SetUVs(int channel, List<Vector4> uvs, int start, int length, MeshUpdateFlags flags) { }

	public void SetUVs(int channel, Vector4[] uvs) { }

	private void SetUvsImpl(int uvIndex, int dim, List<T> uvs, int start, int length, MeshUpdateFlags flags) { }

	private void SetUvsImpl(int uvIndex, int dim, Array uvs, int arrayStart, int arraySize, MeshUpdateFlags flags) { }

	public void SetVertices(List<Vector3> inVertices, int start, int length, MeshUpdateFlags flags) { }

	[ExcludeFromDocs]
	public void SetVertices(List<Vector3> inVertices, int start, int length) { }

	public void SetVertices(List<Vector3> inVertices) { }

	public void UploadMeshData(bool markNoLongerReadable) { }

	[NativeMethod("UploadMeshData")]
	private void UploadMeshDataImpl(bool markNoLongerReadable) { }

	private static void UploadMeshDataImpl_Injected(IntPtr _unity_self, bool markNoLongerReadable) { }

}

