namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;

internal class CompilerContextData : IDisposable, ICompiledGraph
{
	internal struct NativePassIterator
	{
		private readonly CompilerContextData m_Ctx; //Field offset: 0x0
		private int m_Index; //Field offset: 0x8

		[IsReadOnly]
		public NativePassData Current
		{
			 get { } //Length: 74
		}

		public NativePassIterator(CompilerContextData ctx) { }

		public NativePassData get_Current() { }

		public NativePassIterator GetEnumerator() { }

		public bool MoveNext() { }

	}

	public ResourcesData resources; //Field offset: 0x10
	public NativeList<PassData> passData; //Field offset: 0x18
	public Dictionary<Int32, GraphicsFence> fences; //Field offset: 0x20
	public DynamicArray<Name> passNames; //Field offset: 0x28
	public NativeList<PassInputData> inputData; //Field offset: 0x30
	public NativeList<PassOutputData> outputData; //Field offset: 0x38
	public NativeList<PassFragmentData> fragmentData; //Field offset: 0x40
	public NativeList<ResourceHandle> createData; //Field offset: 0x48
	public NativeList<ResourceHandle> destroyData; //Field offset: 0x50
	public NativeList<PassRandomWriteData> randomAccessResourceData; //Field offset: 0x58
	public NativeList<NativePassData> nativePassData; //Field offset: 0x60
	public NativeList<SubPassDescriptor> nativeSubPassData; //Field offset: 0x68
	private bool m_Disposed; //Field offset: 0x70

	public NativePassIterator NativePasses
	{
		 get { } //Length: 41
	}

	public CompilerContextData(int estimatedNumPasses) { }

	public bool AddToFragmentList(TextureAccess access, int listFirstIndex, int numItems) { }

	public bool AddToRandomAccessResourceList(ResourceHandle h, int randomWriteSlotIndex, bool preserveCounterValue, int listFirstIndex, int numItems) { }

	private void Cleanup() { }

	public override void Clear() { }

	public void CullAllPasses(bool isCulled) { }

	public override void Dispose() { }

	protected virtual void Finalize() { }

	public NativePassIterator get_NativePasses() { }

	public Name GetFullPassName(int passId) { }

	internal List<NativePassData> GetNativePasses() { }

	public string GetPassName(int passId) { }

	public string GetResourceName(ResourceHandle h) { }

	public string GetResourceVersionedName(ResourceHandle h) { }

	public void Initialize(RenderGraphResourceRegistry resourceRegistry) { }

	public ReadOnlySpan<ResourceReaderData> Readers(ResourceHandle h) { }

	public ResourceReaderData ResourceReader(ResourceHandle h, int i) { }

	public void TagAllPasses(int value) { }

	public ResourceUnversionedData UnversionedResourceData(ResourceHandle h) { }

	public ResourceVersionedData VersionedResourceData(ResourceHandle h) { }

}

