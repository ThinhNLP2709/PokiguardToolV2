namespace UnityEngine.InputSystem.XR;

public struct Bone
{
	public uint m_ParentBoneIndex; //Field offset: 0x0
	public Vector3 m_Position; //Field offset: 0x4
	public Quaternion m_Rotation; //Field offset: 0x10

	public uint parentBoneIndex
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public Vector3 position
	{
		 get { } //Length: 19
		 set { } //Length: 16
	}

	public Quaternion rotation
	{
		 get { } //Length: 11
		 set { } //Length: 8
	}

	public uint get_parentBoneIndex() { }

	public Vector3 get_position() { }

	public Quaternion get_rotation() { }

	public void set_parentBoneIndex(uint value) { }

	public void set_position(Vector3 value) { }

	public void set_rotation(Quaternion value) { }

}

