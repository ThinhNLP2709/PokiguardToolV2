namespace UnityEngine.Rendering;

public struct RenderQueueRange : IEquatable<RenderQueueRange>
{
	private const int k_MinimumBound = 0; //Field offset: 0x0
	public static readonly int minimumBound; //Field offset: 0x0
	private const int k_MaximumBound = 5000; //Field offset: 0x0
	public static readonly int maximumBound; //Field offset: 0x4
	private int m_LowerBound; //Field offset: 0x0
	private int m_UpperBound; //Field offset: 0x4

	public static RenderQueueRange all
	{
		 get { } //Length: 22
	}

	public int lowerBound
	{
		 get { } //Length: 5
	}

	public static RenderQueueRange opaque
	{
		 get { } //Length: 22
	}

	public static RenderQueueRange transparent
	{
		 get { } //Length: 22
	}

	public int upperBound
	{
		 get { } //Length: 6
	}

	private static RenderQueueRange() { }

	public override bool Equals(RenderQueueRange other) { }

	public virtual bool Equals(object obj) { }

	public static RenderQueueRange get_all() { }

	public int get_lowerBound() { }

	public static RenderQueueRange get_opaque() { }

	public static RenderQueueRange get_transparent() { }

	public int get_upperBound() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(RenderQueueRange left, RenderQueueRange right) { }

}

