namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule"})]
internal struct MeshInfo
{
	[Ignore]
	private static readonly Color32 k_DefaultColor; //Field offset: 0x0
	[Ignore]
	private static readonly Vector3 k_DefaultNormal; //Field offset: 0x4
	[Ignore]
	private static readonly Vector4 k_DefaultTangent; //Field offset: 0x10
	public int vertexCount; //Field offset: 0x0
	public TextCoreVertex[] vertexData; //Field offset: 0x8
	public Material material; //Field offset: 0x10
	[Ignore]
	public Vector3[] vertices; //Field offset: 0x18
	[Ignore]
	public Vector3[] normals; //Field offset: 0x20
	[Ignore]
	public Vector4[] tangents; //Field offset: 0x28
	[Ignore]
	public int vertexBufferSize; //Field offset: 0x30
	[Ignore]
	public Vector4[] uvs0; //Field offset: 0x38
	[Ignore]
	public Vector2[] uvs2; //Field offset: 0x40
	[Ignore]
	public Color32[] colors32; //Field offset: 0x48
	[Ignore]
	public Int32[] triangles; //Field offset: 0x50
	[Ignore]
	public VertexDataLayout vertexDataLayout; //Field offset: 0x58
	[Ignore]
	public bool applySDF; //Field offset: 0x5C
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal GlyphRenderMode glyphRenderMode; //Field offset: 0x60

	private static MeshInfo() { }

	public MeshInfo(int size, VertexDataLayout layout, bool isIMGUI) { }

	internal void Clear(bool uploadChanges) { }

	internal void ClearUnusedVertices() { }

	internal void ResizeMeshInfo(int size, bool isIMGUI) { }

	internal void SortGeometry(VertexSortingOrder order) { }

	internal void SwapVertexData(int src, int dst) { }

}

