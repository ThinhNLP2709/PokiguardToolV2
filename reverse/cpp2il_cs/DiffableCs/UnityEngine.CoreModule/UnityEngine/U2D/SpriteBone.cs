namespace UnityEngine.U2D;

[MovedFrom("UnityEngine.Experimental.U2D")]
[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
[NativeHeader("Runtime/2D/Common/SpriteDataMarshalling.h")]
[NativeType(CodegenOptions::Custom (1), "ScriptingSpriteBone")]
[RequiredByNativeCode]
public struct SpriteBone
{
	[NativeName("name")]
	[SerializeField]
	private string m_Name; //Field offset: 0x0
	[NativeName("guid")]
	[SerializeField]
	private string m_Guid; //Field offset: 0x8
	[NativeName("position")]
	[SerializeField]
	private Vector3 m_Position; //Field offset: 0x10
	[NativeName("rotation")]
	[SerializeField]
	private Quaternion m_Rotation; //Field offset: 0x1C
	[NativeName("length")]
	[SerializeField]
	private float m_Length; //Field offset: 0x2C
	[NativeName("parentId")]
	[SerializeField]
	private int m_ParentId; //Field offset: 0x30
	[NativeName("color")]
	[SerializeField]
	private Color32 m_Color; //Field offset: 0x34

	public string guid
	{
		 get { } //Length: 7
	}

	public string name
	{
		 get { } //Length: 6
	}

	public int parentId
	{
		 get { } //Length: 6
	}

	public Vector3 position
	{
		 get { } //Length: 19
	}

	public Quaternion rotation
	{
		 get { } //Length: 11
	}

	public string get_guid() { }

	public string get_name() { }

	public int get_parentId() { }

	public Vector3 get_position() { }

	public Quaternion get_rotation() { }

}

