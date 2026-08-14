namespace UnityEngine;

[NativeHeader("Runtime/Graphics/Mesh/MeshFilter.h")]
[RequireComponent(typeof(Transform))]
public sealed class MeshFilter : Component
{

	public Mesh mesh
	{
		[NativeName("GetInstantiatedMeshFromScript")]
		 get { } //Length: 144
	}

	public Mesh sharedMesh
	{
		 set { } //Length: 186
	}

	[RequiredByNativeCode]
	private void DontStripMeshFilter() { }

	[NativeName("GetInstantiatedMeshFromScript")]
	public Mesh get_mesh() { }

	private static IntPtr get_mesh_Injected(IntPtr _unity_self) { }

	public void set_sharedMesh(Mesh value) { }

	private static void set_sharedMesh_Injected(IntPtr _unity_self, IntPtr value) { }

}

