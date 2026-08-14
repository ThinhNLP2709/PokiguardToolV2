namespace UnityEngine.UIElements.UIR;

internal class MeshGenerator : IMeshGenerator, IDisposable
{
	internal struct BackgroundRepeatInstance
	{
		public Rect rect; //Field offset: 0x0
		public Rect backgroundRepeatRect; //Field offset: 0x10
		public Rect uv; //Field offset: 0x20

	}

	internal struct BorderParams
	{
		public Rect rect; //Field offset: 0x0
		public Color playmodeTintColor; //Field offset: 0x10
		public Color leftColor; //Field offset: 0x20
		public Color topColor; //Field offset: 0x30
		public Color rightColor; //Field offset: 0x40
		public Color bottomColor; //Field offset: 0x50
		public float leftWidth; //Field offset: 0x60
		public float topWidth; //Field offset: 0x64
		public float rightWidth; //Field offset: 0x68
		public float bottomWidth; //Field offset: 0x6C
		public Vector2 topLeftRadius; //Field offset: 0x70
		public Vector2 topRightRadius; //Field offset: 0x78
		public Vector2 bottomRightRadius; //Field offset: 0x80
		public Vector2 bottomLeftRadius; //Field offset: 0x88
		internal ColorPage leftColorPage; //Field offset: 0x90
		internal ColorPage topColorPage; //Field offset: 0x98
		internal ColorPage rightColorPage; //Field offset: 0xA0
		internal ColorPage bottomColorPage; //Field offset: 0xA8

		internal NativeBorderParams ToNativeParams() { }

	}

	internal struct RectangleParams
	{
		public Rect rect; //Field offset: 0x0
		public Rect uv; //Field offset: 0x10
		public Color color; //Field offset: 0x20
		public Rect subRect; //Field offset: 0x30
		public Rect backgroundRepeatRect; //Field offset: 0x40
		public NativePagedList<BackgroundRepeatInstance> backgroundRepeatInstanceList; //Field offset: 0x50
		public int backgroundRepeatInstanceListStartIndex; //Field offset: 0x58
		public int backgroundRepeatInstanceListEndIndex; //Field offset: 0x5C
		public BackgroundPosition backgroundPositionX; //Field offset: 0x60
		public BackgroundPosition backgroundPositionY; //Field offset: 0x6C
		public BackgroundRepeat backgroundRepeat; //Field offset: 0x78
		public BackgroundSize backgroundSize; //Field offset: 0x80
		public Texture texture; //Field offset: 0x98
		public Sprite sprite; //Field offset: 0xA0
		public VectorImage vectorImage; //Field offset: 0xA8
		public ScaleMode scaleMode; //Field offset: 0xB0
		public Color playmodeTintColor; //Field offset: 0xB4
		public Vector2 topLeftRadius; //Field offset: 0xC4
		public Vector2 topRightRadius; //Field offset: 0xCC
		public Vector2 bottomRightRadius; //Field offset: 0xD4
		public Vector2 bottomLeftRadius; //Field offset: 0xDC
		public Vector2 contentSize; //Field offset: 0xE4
		public Vector2 textureSize; //Field offset: 0xEC
		public int leftSlice; //Field offset: 0xF4
		public int topSlice; //Field offset: 0xF8
		public int rightSlice; //Field offset: 0xFC
		public int bottomSlice; //Field offset: 0x100
		public float sliceScale; //Field offset: 0x104
		internal Rect spriteGeomRect; //Field offset: 0x108
		public Vector4 rectInset; //Field offset: 0x118
		internal ColorPage colorPage; //Field offset: 0x128
		internal MeshFlags meshFlags; //Field offset: 0x130

		private static void AdjustSpriteUVsForScaleMode(Rect containerRect, Rect srcRect, Rect spriteGeomRect, Sprite sprite, ScaleMode scaleMode, out Rect rectOut, out Rect uvOut) { }

		private static void AdjustUVsForScaleMode(Rect rect, Rect uv, Texture texture, ScaleMode scaleMode, out Rect rectOut, out Rect uvOut) { }

		private static Rect ApplyPackingRotation(Rect uv, SpritePackingRotation rotation) { }

		private static Rect ComputeGeomRect(Sprite sprite) { }

		private static Rect ComputeUVRect(Sprite sprite) { }

		internal bool HasRadius(float epsilon) { }

		internal bool HasSlices(float epsilon) { }

		public static RectangleParams MakeSprite(Rect containerRect, Rect subRect, Sprite sprite, ScaleMode scaleMode, Color playModeTintColor, bool hasRadius, ref Vector4 slices, bool useForRepeat = false) { }

		public static RectangleParams MakeTextured(Rect rect, Rect uv, Texture texture, ScaleMode scaleMode, Color playModeTintColor) { }

		public static RectangleParams MakeVectorTextured(Rect rect, Rect uv, VectorImage vectorImage, ScaleMode scaleMode, Color playModeTintColor) { }

		internal static Rect RectIntersection(Rect a, Rect b) { }

		internal NativeRectParams ToNativeParams() { }

	}

	private struct RepeatRectUV
	{
		public Rect rect; //Field offset: 0x0
		public Rect uv; //Field offset: 0x10

	}

	private struct TessellationJob : IJobParallelFor
	{
		[ReadOnly]
		public TempMeshAllocator allocator; //Field offset: 0x0
		[ReadOnly]
		public NativeSlice<TessellationJobParameters> jobParameters; //Field offset: 0x8

		private void ApplyInset(ref NativeRectParams rectParams, Texture tex) { }

		private void DrawBorder(UnsafeMeshGenerationNode node, ref BorderParams borderParams) { }

		private void DrawRectangle(UnsafeMeshGenerationNode node, ref NativeRectParams rectParams, Texture tex) { }

		private void DrawSprite(UnsafeMeshGenerationNode node, ref NativeRectParams rectParams, Sprite sprite) { }

		private void DrawVectorImage(UnsafeMeshGenerationNode node, ref NativeRectParams rectParams, VectorImage vi) { }

		public override void Execute(int i) { }

		private T ExtractHandle(IntPtr handlePtr) { }

	}

	private struct TessellationJobParameters
	{
		public bool isBorderJob; //Field offset: 0x0
		public NativeRectParams rectParams; //Field offset: 0x8
		public BorderParams borderParams; //Field offset: 0x120
		public UnsafeMeshGenerationNode node; //Field offset: 0x1D0

	}

	private static readonly ProfilerMarker k_MarkerDrawRectangle; //Field offset: 0x0
	private static readonly ProfilerMarker k_MarkerDrawBorder; //Field offset: 0x8
	private static readonly ProfilerMarker k_MarkerDrawVectorImage; //Field offset: 0x10
	private static readonly ProfilerMarker k_MarkerDrawRectangleRepeat; //Field offset: 0x18
	private MeshGenerationContext m_MeshGenerationContext; //Field offset: 0x10
	private List<RepeatRectUV>[] m_RepeatRectUVList; //Field offset: 0x18
	private NativePagedList<BackgroundRepeatInstance> m_BackgroundRepeatInstanceList; //Field offset: 0x20
	private GCHandlePool m_GCHandlePool; //Field offset: 0x28
	private NativeArray<TessellationJobParameters> m_JobParameters; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <currentElement>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private UITKTextJobSystem <textJobSystem>k__BackingField; //Field offset: 0x48
	private TextInfo m_TextInfo; //Field offset: 0x50
	private TextGenerationSettings m_Settings; //Field offset: 0x58
	private List<NativeSlice`1<Vertex>> m_VerticesArray; //Field offset: 0x60
	private List<NativeSlice`1<UInt16>> m_IndicesArray; //Field offset: 0x68
	private List<Material> m_Materials; //Field offset: 0x70
	private List<GlyphRenderMode> m_RenderModes; //Field offset: 0x78
	private MeshGenerationCallback m_OnMeshGenerationDelegate; //Field offset: 0x80
	private List<TessellationJobParameters> m_TesselationJobParameters; //Field offset: 0x88
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <disposed>k__BackingField; //Field offset: 0x90

	public override VisualElement currentElement
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	internal bool disposed
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public override UITKTextJobSystem textJobSystem
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private static MeshGenerator() { }

	public MeshGenerator(MeshGenerationContext mgc) { }

	public static void AdjustBackgroundSizeForBorders(VisualElement visualElement, ref RectangleParams rectParams) { }

	private static void AdjustSpriteWinding(Vector2[] vertices, UInt16[] indices, NativeSlice<UInt16> newIndices) { }

	private static Vector2 ConvertBorderRadiusPercentToPoints(Vector2 borderRectSize, Length length) { }

	internal static Vertex ConvertTextVertexToUIRVertex(TextCoreVertex vertex, Vector2 posOffset, bool isDynamicColor = false) { }

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	private void DoDrawRectangleRepeat(ref RectangleParams rectParams, Rect totalRect, float scaledPixelsPerPoint) { }

	public override void DrawBorder(BorderParams borderParams) { }

	public override void DrawNativeText(NativeTextInfo textInfo, Vector2 pos) { }

	public override void DrawRectangle(RectangleParams rectParams) { }

	public override void DrawRectangleRepeat(RectangleParams rectParams, Rect totalRect, float scaledPixelsPerPoint) { }

	public override void DrawText(List<NativeSlice`1<Vertex>> vertices, List<NativeSlice`1<UInt16>> indices, List<Material> materials, List<GlyphRenderMode> renderModes) { }

	private void DrawTextBase(TextInfo textInfo, NativeTextInfo nativeTextInfo, Vector2 pos, bool isNative) { }

	private void DrawTextInfo(List<NativeSlice`1<Vertex>> vertices, List<NativeSlice`1<UInt16>> indices, List<Material> materials, List<GlyphRenderMode> renderModes) { }

	[CompilerGenerated]
	internal bool get_disposed() { }

	[CompilerGenerated]
	public override UITKTextJobSystem get_textJobSystem() { }

	public static void GetVisualElementRadii(VisualElement ve, out Vector2 topLeft, out Vector2 bottomLeft, out Vector2 topRight, out Vector2 bottomRight) { }

	private void MakeText(Texture texture, NativeSlice<Vertex> vertices, NativeSlice<UInt16> indices, bool isSdf, float sdfScale, float sharpness, bool multiChannel) { }

	private void OnMeshGeneration(MeshGenerationContext ctx, object data) { }

	public override void ScheduleJobs(MeshGenerationContext mgc) { }

	[CompilerGenerated]
	public override void set_currentElement(VisualElement value) { }

	[CompilerGenerated]
	private void set_disposed(bool value) { }

	[CompilerGenerated]
	public override void set_textJobSystem(UITKTextJobSystem value) { }

	private void StampRectangleWithSubRect(RectangleParams rectParams, Rect targetRect, Rect totalRect, Rect targetUV, ref NativePagedList<BackgroundRepeatInstance>& backgroundRepeatInstanceList) { }

}

