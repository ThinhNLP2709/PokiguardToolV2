namespace UnityEngine.AI;

[HelpURL("https://docs.unity3d.com/Packages/com.unity.ai.navigation@2.0/manual/NavMeshAgent.html")]
[MovedFrom("UnityEngine")]
[NativeHeader("Modules/AI/NavMesh/NavMesh.bindings.h")]
[NativeHeader("Modules/AI/Components/NavMeshAgent.bindings.h")]
public sealed class NavMeshAgent : Behaviour
{

	public NavMeshPathStatus pathStatus
	{
		 get { } //Length: 118
	}

	public float remainingDistance
	{
		 get { } //Length: 118
	}

	public NavMeshPathStatus get_pathStatus() { }

	private static NavMeshPathStatus get_pathStatus_Injected(IntPtr _unity_self) { }

	public float get_remainingDistance() { }

	private static float get_remainingDistance_Injected(IntPtr _unity_self) { }

}

