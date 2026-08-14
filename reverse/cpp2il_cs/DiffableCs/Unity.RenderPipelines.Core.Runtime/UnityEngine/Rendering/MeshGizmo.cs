namespace UnityEngine.Rendering;

internal class MeshGizmo : IDisposable
{
	[CompilerGenerated]
	private struct <>c__DisplayClass10_0
	{
		public MeshGizmo <>4__this; //Field offset: 0x0
		public Color color; //Field offset: 0x8

	}

	public static readonly int vertexCountPerCube; //Field offset: 0x0
	public Mesh mesh; //Field offset: 0x10
	private List<Vector3> vertices; //Field offset: 0x18
	private List<Int32> indices; //Field offset: 0x20
	private List<Color> colors; //Field offset: 0x28
	private Material wireMaterial; //Field offset: 0x30
	private Material dottedWireMaterial; //Field offset: 0x38
	private Material solidMaterial; //Field offset: 0x40

	private static MeshGizmo() { }

	public MeshGizmo(int capacity = 0) { }

	[CompilerGenerated]
	private void <AddWireCube>g__AddEdge|10_0(Vector3 p1, Vector3 p2, ref <>c__DisplayClass10_0 unnamed_param_2) { }

	public void AddWireCube(Vector3 center, Vector3 size, Color color) { }

	public void Clear() { }

	public override void Dispose() { }

	private void DrawMesh(Matrix4x4 trs, Material mat, MeshTopology topology, CompareFunction depthTest, string gizmoName) { }

	public void RenderWireframe(Matrix4x4 trs, CompareFunction depthTest = 4, string gizmoName = null) { }

}

