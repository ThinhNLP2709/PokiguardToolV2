//Type is in global namespace

internal class RenderGraphCompilationCache
{
	[CompilerGenerated]
	private sealed class <>c__11
	{
		public static readonly <>c__11<T> <>9; //Field offset: 0x0
		public static Predicate<HashEntry`1<T>> <>9__11_0; //Field offset: 0x0

		private static <>c__11`1() { }

		public <>c__11`1() { }

		internal bool <GetCompilationCache>b__11_0(HashEntry<T> value) { }

	}

	private struct HashEntry
	{
		public int hash; //Field offset: 0x0
		public int lastFrameUsed; //Field offset: 0x0
		public T compiledGraph; //Field offset: 0x0

	}

	private static SortComparer<HashEntry<CompiledGraph>> s_EntryComparer; //Field offset: 0x0
	private const int k_CachedGraphCount = 20; //Field offset: 0x0
	private static SortComparer<HashEntry<CompilerContextData>> s_NativeEntryComparer; //Field offset: 0x8
	private static int s_Hash; //Field offset: 0x10
	private DynamicArray<HashEntry`1<CompiledGraph>> m_HashEntries; //Field offset: 0x10
	private DynamicArray<HashEntry`1<CompilerContextData>> m_NativeHashEntries; //Field offset: 0x18
	private Stack<CompiledGraph> m_CompiledGraphPool; //Field offset: 0x20
	private Stack<CompilerContextData> m_NativeCompiledGraphPool; //Field offset: 0x28

	private static RenderGraphCompilationCache() { }

	public RenderGraphCompilationCache() { }

	public void Clear() { }

	private bool GetCompilationCache(int hash, int frameIndex, out T outGraph, DynamicArray<HashEntry`1<T>> hashEntries, Stack<T> pool, SortComparer<HashEntry<T>> comparer) { }

	public bool GetCompilationCache(int hash, int frameIndex, out CompiledGraph outGraph) { }

	public bool GetCompilationCache(int hash, int frameIndex, out CompilerContextData outGraph) { }

	private static int HashEntryComparer(HashEntry<T> a, HashEntry<T> b) { }

}

