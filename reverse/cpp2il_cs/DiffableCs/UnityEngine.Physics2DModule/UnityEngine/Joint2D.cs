namespace UnityEngine;

[NativeHeader("Modules/Physics2D/Joint2D.h")]
[RequireComponent(typeof(Transform), typeof(Rigidbody2D))]
public class Joint2D : Behaviour
{

	public float breakForce
	{
		 get { } //Length: 118
	}

	public float breakTorque
	{
		 get { } //Length: 118
	}

	public Rigidbody2D connectedBody
	{
		 get { } //Length: 309
	}

	public Vector2 reactionForce
	{
		[NativeMethod("GetReactionForceFixedTime")]
		 get { } //Length: 135
	}

	public float reactionTorque
	{
		[NativeMethod("GetReactionTorqueFixedTime")]
		 get { } //Length: 118
	}

	public float get_breakForce() { }

	private static float get_breakForce_Injected(IntPtr _unity_self) { }

	public float get_breakTorque() { }

	private static float get_breakTorque_Injected(IntPtr _unity_self) { }

	public Rigidbody2D get_connectedBody() { }

	private static IntPtr get_connectedBody_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetReactionForceFixedTime")]
	public Vector2 get_reactionForce() { }

	private static void get_reactionForce_Injected(IntPtr _unity_self, out Vector2 ret) { }

	[NativeMethod("GetReactionTorqueFixedTime")]
	public float get_reactionTorque() { }

	private static float get_reactionTorque_Injected(IntPtr _unity_self) { }

}

