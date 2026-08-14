namespace UnityEngine.UIElements;

internal class UITKTextJobSystem
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal ManagedJobData <.cctor>b__25_0() { }

		internal void <.cctor>b__25_1(ManagedJobData inst) { }

		internal List<Material> <.cctor>b__25_2() { }

		internal void <.cctor>b__25_3(List<Material> list) { }

		internal List<GlyphRenderMode> <.cctor>b__25_4() { }

		internal void <.cctor>b__25_5(List<GlyphRenderMode> list) { }

		internal List<NativeSlice`1<Vertex>> <.cctor>b__25_6() { }

		internal void <.cctor>b__25_7(List<NativeSlice`1<Vertex>> list) { }

		internal List<NativeSlice`1<UInt16>> <.cctor>b__25_8() { }

		internal void <.cctor>b__25_9(List<NativeSlice`1<UInt16>> list) { }

	}

	private struct GenerateTextJobData : IJobParallelFor
	{
		public GCHandle managedJobDataHandle; //Field offset: 0x0
		[ReadOnly]
		public TempMeshAllocator alloc; //Field offset: 0x8

		public override void Execute(int index) { }

	}

	private class ManagedJobData
	{
		public TextElement visualElement; //Field offset: 0x10
		public MeshGenerationNode node; //Field offset: 0x18
		public List<Material> materials; //Field offset: 0x20
		public List<GlyphRenderMode> renderModes; //Field offset: 0x28
		public List<NativeSlice`1<Vertex>> vertices; //Field offset: 0x30
		public List<NativeSlice`1<UInt16>> indices; //Field offset: 0x38
		public bool prepareSuccess; //Field offset: 0x40

		public ManagedJobData() { }

		public void Release() { }

	}

	private struct PrepareTextJobData : IJobParallelFor
	{
		public GCHandle managedJobDataHandle; //Field offset: 0x0

		public override void Execute(int index) { }

	}

	private static readonly ProfilerMarker k_ExecuteMarker; //Field offset: 0x0
	private static readonly ProfilerMarker k_UpdateMainThreadMarker; //Field offset: 0x8
	private static readonly ProfilerMarker k_PrepareMainThreadMarker; //Field offset: 0x10
	private static readonly ProfilerMarker k_PrepareJobifiedMarker; //Field offset: 0x18
	private static ObjectPool<ManagedJobData> s_JobDataPool; //Field offset: 0x20
	private static ObjectPool<List`1<Material>> s_MaterialPool; //Field offset: 0x28
	private static ObjectPool<List`1<GlyphRenderMode>> s_RenderModesPool; //Field offset: 0x30
	private static ObjectPool<List`1<NativeSlice`1<Vertex>>> s_VerticesPool; //Field offset: 0x38
	private static ObjectPool<List`1<NativeSlice`1<UInt16>>> s_IndicesPool; //Field offset: 0x40
	private GCHandle textJobDatasHandle; //Field offset: 0x10
	private List<ManagedJobData> textJobDatas; //Field offset: 0x18
	private bool hasPendingTextWork; //Field offset: 0x20
	internal MeshGenerationCallback m_PrepareTextJobifiedCallback; //Field offset: 0x28
	internal MeshGenerationCallback m_GenerateTextJobifiedCallback; //Field offset: 0x30
	internal MeshGenerationCallback m_AddDrawEntriesCallback; //Field offset: 0x38

	private static UITKTextJobSystem() { }

	public UITKTextJobSystem() { }

	private void AddDrawEntries(MeshGenerationContext mgc, object _) { }

	private static void ConvertMeshInfoToUIRVertex(MeshInfo[] meshInfos, TempMeshAllocator alloc, TextElement visualElement, ref List<Material>& materials, ref List<NativeSlice`1<Vertex>>& verticesArray, ref List<NativeSlice`1<UInt16>>& indicesArray, ref List<GlyphRenderMode>& renderModes) { }

	internal void GenerateText(MeshGenerationContext mgc, TextElement textElement) { }

	private void GenerateTextJobified(MeshGenerationContext mgc, object _) { }

	private static void OnGetManagedJob(ManagedJobData managedJobData) { }

	internal void PrepareTextJobified(MeshGenerationContext mgc, object _) { }

}

