namespace UnityEngine.Rendering;

public struct SortingLayerRange : IEquatable<SortingLayerRange>
{
	private short m_LowerBound; //Field offset: 0x0
	private short m_UpperBound; //Field offset: 0x2

	public static SortingLayerRange all
	{
		 get { } //Length: 13
	}

	public override bool Equals(SortingLayerRange other) { }

	public virtual bool Equals(object obj) { }

	public static SortingLayerRange get_all() { }

	public virtual int GetHashCode() { }

}

