namespace UnityEngine.Rendering;

internal class AtlasAllocator
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static UnityAction<AtlasNode> <>9__6_0; //Field offset: 0x8
		public static UnityAction<AtlasNode> <>9__6_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__6_0(AtlasNode _) { }

		internal void <.ctor>b__6_1(AtlasNode _) { }

	}

	private class AtlasNode
	{
		public AtlasNode m_RightChild; //Field offset: 0x10
		public AtlasNode m_BottomChild; //Field offset: 0x18
		public Vector4 m_Rect; //Field offset: 0x20

		public AtlasNode() { }

		public AtlasNode Allocate(ref ObjectPool<AtlasNode>& pool, int width, int height, bool powerOfTwoPadding) { }

		public void Release(ref ObjectPool<AtlasNode>& pool) { }

	}

	private AtlasNode m_Root; //Field offset: 0x10
	private int m_Width; //Field offset: 0x18
	private int m_Height; //Field offset: 0x1C
	private bool powerOfTwoPadding; //Field offset: 0x20
	private ObjectPool<AtlasNode> m_NodePool; //Field offset: 0x28

	public AtlasAllocator(int width, int height, bool potPadding) { }

	public bool Allocate(ref Vector4 result, int width, int height) { }

	public void Reset() { }

}

