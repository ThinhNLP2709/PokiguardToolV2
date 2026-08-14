namespace UnityEngine;

[NativeHeader("Modules/Physics/Collider.h")]
public class Collider : Component
{

	public Rigidbody attachedRigidbody
	{
		[NativeMethod("GetRigidbody")]
		 get { } //Length: 144
	}

	public bool enabled
	{
		 get { } //Length: 118
	}

	public Vector3 ClosestPoint(Vector3 position) { }

	private static void ClosestPoint_Injected(IntPtr _unity_self, in Vector3 position, out Vector3 ret) { }

	[NativeMethod("GetRigidbody")]
	public Rigidbody get_attachedRigidbody() { }

	private static IntPtr get_attachedRigidbody_Injected(IntPtr _unity_self) { }

	public bool get_enabled() { }

	private static bool get_enabled_Injected(IntPtr _unity_self) { }

}

