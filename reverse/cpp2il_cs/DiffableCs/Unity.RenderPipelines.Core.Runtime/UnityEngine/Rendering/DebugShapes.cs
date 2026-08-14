namespace UnityEngine.Rendering;

public class DebugShapes
{
	private static DebugShapes s_Instance; //Field offset: 0x0
	private Mesh m_sphereMesh; //Field offset: 0x10
	private Mesh m_boxMesh; //Field offset: 0x18
	private Mesh m_coneMesh; //Field offset: 0x20
	private Mesh m_pyramidMesh; //Field offset: 0x28

	public static DebugShapes instance
	{
		 get { } //Length: 141
	}

	public DebugShapes() { }

	private void BuildBox(ref Mesh outputMesh, float length, float width, float height) { }

	private void BuildCone(ref Mesh outputMesh, float height, float topRadius, float bottomRadius, int nbSides) { }

	public Mesh BuildCustomSphereMesh(float radius, uint longSubdiv, uint latSubdiv) { }

	private void BuildPyramid(ref Mesh outputMesh, float width, float height, float depth) { }

	private void BuildShapes() { }

	private void BuildSphere(ref Mesh outputMesh, float radius, uint longSubdiv, uint latSubdiv) { }

	public static DebugShapes get_instance() { }

	private void RebuildResources() { }

	public Mesh RequestBoxMesh() { }

	public Mesh RequestConeMesh() { }

	public Mesh RequestPyramidMesh() { }

	public Mesh RequestSphereMesh() { }

}

