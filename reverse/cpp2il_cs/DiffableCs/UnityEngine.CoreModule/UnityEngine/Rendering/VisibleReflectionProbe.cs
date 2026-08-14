namespace UnityEngine.Rendering;

[UsedByNativeCode]
public struct VisibleReflectionProbe : IEquatable<VisibleReflectionProbe>
{
	private Bounds m_Bounds; //Field offset: 0x0
	private Matrix4x4 m_LocalToWorldMatrix; //Field offset: 0x18
	private Vector4 m_HdrData; //Field offset: 0x58
	private Vector3 m_Center; //Field offset: 0x68
	private float m_BlendDistance; //Field offset: 0x74
	private int m_Importance; //Field offset: 0x78
	private int m_BoxProjection; //Field offset: 0x7C
	private int m_InstanceId; //Field offset: 0x80
	private int m_TextureId; //Field offset: 0x84

	public float blendDistance
	{
		 get { } //Length: 8
	}

	public Bounds bounds
	{
		 get { } //Length: 20
	}

	public Vector4 hdrData
	{
		 get { } //Length: 11
	}

	public int importance
	{
		 get { } //Length: 6
	}

	public bool isBoxProjection
	{
		 get { } //Length: 75
	}

	public Matrix4x4 localToWorldMatrix
	{
		 get { } //Length: 35
	}

	public ReflectionProbe reflectionProbe
	{
		 get { } //Length: 125
	}

	public Texture texture
	{
		 get { } //Length: 151
	}

	public override bool Equals(VisibleReflectionProbe other) { }

	public virtual bool Equals(object obj) { }

	public float get_blendDistance() { }

	public Bounds get_bounds() { }

	public Vector4 get_hdrData() { }

	public int get_importance() { }

	public bool get_isBoxProjection() { }

	public Matrix4x4 get_localToWorldMatrix() { }

	public ReflectionProbe get_reflectionProbe() { }

	public Texture get_texture() { }

	public virtual int GetHashCode() { }

}

