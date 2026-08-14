namespace UnityEngine.UIElements.Layout;

[IsReadOnly]
internal struct LayoutHandle
{
	public readonly int Index; //Field offset: 0x0
	public readonly int Version; //Field offset: 0x4

	public static LayoutHandle Undefined
	{
		 get { } //Length: 3
	}

	internal LayoutHandle(int index, int version) { }

	public bool Equals(LayoutHandle other) { }

	public virtual bool Equals(object obj) { }

	public static LayoutHandle get_Undefined() { }

	public virtual int GetHashCode() { }

}

