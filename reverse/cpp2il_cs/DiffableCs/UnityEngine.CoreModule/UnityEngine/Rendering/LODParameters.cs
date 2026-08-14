namespace UnityEngine.Rendering;

public struct LODParameters : IEquatable<LODParameters>
{
	private int m_IsOrthographic; //Field offset: 0x0
	private Vector3 m_CameraPosition; //Field offset: 0x4
	private float m_FieldOfView; //Field offset: 0x10
	private float m_OrthoSize; //Field offset: 0x14
	private int m_CameraPixelHeight; //Field offset: 0x18

	public Vector3 cameraPosition
	{
		 get { } //Length: 19
	}

	public float fieldOfView
	{
		 get { } //Length: 8
	}

	public bool isOrthographic
	{
		 get { } //Length: 74
	}

	public float orthoSize
	{
		 get { } //Length: 8
	}

	public override bool Equals(LODParameters other) { }

	public virtual bool Equals(object obj) { }

	public Vector3 get_cameraPosition() { }

	public float get_fieldOfView() { }

	public bool get_isOrthographic() { }

	public float get_orthoSize() { }

	public virtual int GetHashCode() { }

}

