namespace UnityEngine.Rendering;

public static class CommandBufferPool
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal void <.cctor>b__4_0(CommandBuffer x) { }

	}

	private static ObjectPool<CommandBuffer> s_BufferPool; //Field offset: 0x0

	private static CommandBufferPool() { }

	public static CommandBuffer Get() { }

	public static CommandBuffer Get(string name) { }

	public static void Release(CommandBuffer buffer) { }

}

