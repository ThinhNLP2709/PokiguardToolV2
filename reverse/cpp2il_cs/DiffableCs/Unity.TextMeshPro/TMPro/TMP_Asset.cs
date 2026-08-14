namespace TMPro;

public abstract class TMP_Asset : ScriptableObject
{
	[SerializeField]
	internal string m_Version; //Field offset: 0x18
	internal int m_InstanceID; //Field offset: 0x20
	internal int m_HashCode; //Field offset: 0x24
	[SerializeField]
	internal FaceInfo m_FaceInfo; //Field offset: 0x28
	[FormerlySerializedAs("material")]
	[SerializeField]
	internal Material m_Material; //Field offset: 0x88
	internal int m_MaterialHashCode; //Field offset: 0x90

	public FaceInfo faceInfo
	{
		 get { } //Length: 51
		 set { } //Length: 58
	}

	public int hashCode
	{
		 get { } //Length: 109
		 set { } //Length: 4
	}

	public int instanceID
	{
		 get { } //Length: 40
	}

	public Material material
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public int materialHashCode
	{
		 get { } //Length: 202
		 set { } //Length: 7
	}

	public internal string version
	{
		 get { } //Length: 5
		internal set { } //Length: 13
	}

	protected TMP_Asset() { }

	public FaceInfo get_faceInfo() { }

	public int get_hashCode() { }

	public int get_instanceID() { }

	public Material get_material() { }

	public int get_materialHashCode() { }

	public string get_version() { }

	public void set_faceInfo(FaceInfo value) { }

	public void set_hashCode(int value) { }

	public void set_material(Material value) { }

	public void set_materialHashCode(int value) { }

	internal void set_version(string value) { }

}

