namespace UnityEngine.Rendering;

public struct DepthState : IEquatable<DepthState>
{
	private byte m_WriteEnabled; //Field offset: 0x0
	private sbyte m_CompareFunction; //Field offset: 0x1

	public CompareFunction compareFunction
	{
		 get { } //Length: 7
	}

	public static DepthState defaultValue
	{
		 get { } //Length: 81
	}

	public DepthState(bool writeEnabled = true, CompareFunction compareFunction = 2) { }

	public override bool Equals(DepthState other) { }

	public virtual bool Equals(object obj) { }

	public CompareFunction get_compareFunction() { }

	public static DepthState get_defaultValue() { }

	public virtual int GetHashCode() { }

}

