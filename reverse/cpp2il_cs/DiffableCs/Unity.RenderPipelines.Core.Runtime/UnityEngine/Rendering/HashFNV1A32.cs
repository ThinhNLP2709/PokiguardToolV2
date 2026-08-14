namespace UnityEngine.Rendering;

[IsByRefLike]
[Obsolete("Types with embedded references are not supported in this version of your compiler.", True)]
internal struct HashFNV1A32
{
	private const uint k_Prime = 16777619; //Field offset: 0x0
	private const uint k_OffsetBasis = 2166136261; //Field offset: 0x0
	private uint m_Hash; //Field offset: 0x0

	public int value
	{
		 get { } //Length: 3
	}

	public void Append(in int input) { }

	public void Append(in uint input) { }

	public void Append(in bool input) { }

	public void Append(in float input) { }

	public void Append(in double input) { }

	public void Append(in Vector2 input) { }

	public void Append(in Vector3 input) { }

	public void Append(in Vector4 input) { }

	public void Append(T input) { }

	public void Append(Delegate del) { }

	public static HashFNV1A32 Create() { }

	public int get_value() { }

	internal static int GetFuncHashCode(Delegate del) { }

	public virtual int GetHashCode() { }

}

