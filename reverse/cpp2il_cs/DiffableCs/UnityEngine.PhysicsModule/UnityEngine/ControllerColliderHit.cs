namespace UnityEngine;

[RequiredByNativeCode]
public class ControllerColliderHit
{
	internal CharacterController m_Controller; //Field offset: 0x10
	internal Collider m_Collider; //Field offset: 0x18
	internal Vector3 m_Point; //Field offset: 0x20
	internal Vector3 m_Normal; //Field offset: 0x2C
	internal Vector3 m_MoveDirection; //Field offset: 0x38
	internal float m_MoveLength; //Field offset: 0x44
	internal int m_Push; //Field offset: 0x48

	public Collider collider
	{
		 get { } //Length: 7
	}

	public CharacterController controller
	{
		 get { } //Length: 7
	}

	public Vector3 moveDirection
	{
		 get { } //Length: 19
	}

	public float moveLength
	{
		 get { } //Length: 8
	}

	public Vector3 normal
	{
		 get { } //Length: 19
	}

	public Vector3 point
	{
		 get { } //Length: 19
	}

	public Collider get_collider() { }

	public CharacterController get_controller() { }

	public Vector3 get_moveDirection() { }

	public float get_moveLength() { }

	public Vector3 get_normal() { }

	public Vector3 get_point() { }

}

