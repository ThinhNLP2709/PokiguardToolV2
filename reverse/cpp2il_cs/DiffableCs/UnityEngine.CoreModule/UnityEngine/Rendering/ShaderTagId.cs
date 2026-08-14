namespace UnityEngine.Rendering;

public struct ShaderTagId : IEquatable<ShaderTagId>
{
	public static readonly ShaderTagId none; //Field offset: 0x0
	private int m_Id; //Field offset: 0x0

	internal int id
	{
		internal get { } //Length: 5
		internal set { } //Length: 3
	}

	public ShaderTagId(string name) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(ShaderTagId other) { }

	internal int get_id() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(ShaderTagId tag1, ShaderTagId tag2) { }

	public static bool op_Inequality(ShaderTagId tag1, ShaderTagId tag2) { }

	internal void set_id(int value) { }

}

