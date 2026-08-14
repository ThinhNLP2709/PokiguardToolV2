namespace UnityEngine.InputSystem.XR;

public struct Eyes
{
	public Vector3 m_LeftEyePosition; //Field offset: 0x0
	public Quaternion m_LeftEyeRotation; //Field offset: 0xC
	public Vector3 m_RightEyePosition; //Field offset: 0x1C
	public Quaternion m_RightEyeRotation; //Field offset: 0x28
	public Vector3 m_FixationPoint; //Field offset: 0x38
	public float m_LeftEyeOpenAmount; //Field offset: 0x44
	public float m_RightEyeOpenAmount; //Field offset: 0x48

	public Vector3 fixationPoint
	{
		 get { } //Length: 19
		 set { } //Length: 16
	}

	public float leftEyeOpenAmount
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public Vector3 leftEyePosition
	{
		 get { } //Length: 18
		 set { } //Length: 15
	}

	public Quaternion leftEyeRotation
	{
		 get { } //Length: 11
		 set { } //Length: 8
	}

	public float rightEyeOpenAmount
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public Vector3 rightEyePosition
	{
		 get { } //Length: 19
		 set { } //Length: 16
	}

	public Quaternion rightEyeRotation
	{
		 get { } //Length: 11
		 set { } //Length: 8
	}

	public Vector3 get_fixationPoint() { }

	public float get_leftEyeOpenAmount() { }

	public Vector3 get_leftEyePosition() { }

	public Quaternion get_leftEyeRotation() { }

	public float get_rightEyeOpenAmount() { }

	public Vector3 get_rightEyePosition() { }

	public Quaternion get_rightEyeRotation() { }

	public void set_fixationPoint(Vector3 value) { }

	public void set_leftEyeOpenAmount(float value) { }

	public void set_leftEyePosition(Vector3 value) { }

	public void set_leftEyeRotation(Quaternion value) { }

	public void set_rightEyeOpenAmount(float value) { }

	public void set_rightEyePosition(Vector3 value) { }

	public void set_rightEyeRotation(Quaternion value) { }

}

