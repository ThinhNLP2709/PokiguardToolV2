namespace UnityEngine.Rendering;

[UsedByNativeCode]
public struct VisibleLight : IEquatable<VisibleLight>
{
	private LightType m_LightType; //Field offset: 0x0
	private Color m_FinalColor; //Field offset: 0x4
	private Rect m_ScreenRect; //Field offset: 0x14
	private Matrix4x4 m_LocalToWorldMatrix; //Field offset: 0x24
	private float m_Range; //Field offset: 0x64
	private float m_SpotAngle; //Field offset: 0x68
	private int m_InstanceId; //Field offset: 0x6C
	private VisibleLightFlags m_Flags; //Field offset: 0x70

	public Color finalColor
	{
		 get { } //Length: 11
	}

	public Light light
	{
		 get { } //Length: 122
	}

	public LightType lightType
	{
		 get { } //Length: 5
	}

	public Matrix4x4 localToWorldMatrix
	{
		 get { } //Length: 35
	}

	public float range
	{
		 get { } //Length: 8
	}

	public float spotAngle
	{
		 get { } //Length: 8
	}

	public override bool Equals(VisibleLight other) { }

	public virtual bool Equals(object obj) { }

	public Color get_finalColor() { }

	public Light get_light() { }

	public LightType get_lightType() { }

	public Matrix4x4 get_localToWorldMatrix() { }

	public float get_range() { }

	public float get_spotAngle() { }

	public virtual int GetHashCode() { }

}

