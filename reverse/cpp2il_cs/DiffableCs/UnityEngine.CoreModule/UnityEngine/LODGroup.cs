namespace UnityEngine;

[NativeHeader("Runtime/Graphics/LOD/LODGroupManager.h")]
[NativeHeader("Runtime/Graphics/LOD/LODGroup.h")]
[NativeHeader("Runtime/Graphics/LOD/LODUtility.h")]
[StaticAccessor("GetLODGroupManager()", StaticAccessorType::Dot (0))]
public class LODGroup : Component
{

	public Vector3 localReferencePoint
	{
		 get { } //Length: 144
	}

	public float size
	{
		 get { } //Length: 118
	}

	public Vector3 get_localReferencePoint() { }

	private static void get_localReferencePoint_Injected(IntPtr _unity_self, out Vector3 ret) { }

	public float get_size() { }

	private static float get_size_Injected(IntPtr _unity_self) { }

}

