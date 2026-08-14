namespace UnityEngine;

[NativeHeader("Modules/Physics/Rigidbody.h")]
[RequireComponent(typeof(Transform))]
public class Rigidbody : Component
{

	public Vector3 position
	{
		 get { } //Length: 144
	}

	public Quaternion rotation
	{
		 get { } //Length: 142
		 set { } //Length: 863
	}

	public void AddForce(Vector3 force, ForceMode mode) { }

	[ExcludeFromDocs]
	public void AddForce(Vector3 force) { }

	private static void AddForce_Injected(IntPtr _unity_self, in Vector3 force, ForceMode mode) { }

	public void AddRelativeForce(Vector3 force, ForceMode mode) { }

	[ExcludeFromDocs]
	public void AddRelativeForce(Vector3 force) { }

	private static void AddRelativeForce_Injected(IntPtr _unity_self, in Vector3 force, ForceMode mode) { }

	public Vector3 get_position() { }

	private static void get_position_Injected(IntPtr _unity_self, out Vector3 ret) { }

	public Quaternion get_rotation() { }

	private static void get_rotation_Injected(IntPtr _unity_self, out Quaternion ret) { }

	public void MovePosition(Vector3 position) { }

	private static void MovePosition_Injected(IntPtr _unity_self, in Vector3 position) { }

	public void MoveRotation(Quaternion rot) { }

	private static void MoveRotation_Injected(IntPtr _unity_self, in Quaternion rot) { }

	public void set_rotation(Quaternion value) { }

	private static void set_rotation_Injected(IntPtr _unity_self, in Quaternion value) { }

}

