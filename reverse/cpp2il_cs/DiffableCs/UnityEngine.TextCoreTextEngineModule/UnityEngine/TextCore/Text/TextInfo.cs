namespace UnityEngine.TextCore.Text;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule"})]
internal class TextInfo
{
	private static Vector2 s_InfinityVectorPositive; //Field offset: 0x0
	private static Vector2 s_InfinityVectorNegative; //Field offset: 0x8
	public int characterCount; //Field offset: 0x10
	public int spriteCount; //Field offset: 0x14
	public int spaceCount; //Field offset: 0x18
	public int wordCount; //Field offset: 0x1C
	public int linkCount; //Field offset: 0x20
	public int lineCount; //Field offset: 0x24
	public int pageCount; //Field offset: 0x28
	public int materialCount; //Field offset: 0x2C
	public TextElementInfo[] textElementInfo; //Field offset: 0x30
	public WordInfo[] wordInfo; //Field offset: 0x38
	public LinkInfo[] linkInfo; //Field offset: 0x40
	public LineInfo[] lineInfo; //Field offset: 0x48
	public PageInfo[] pageInfo; //Field offset: 0x50
	public MeshInfo[] meshInfo; //Field offset: 0x58
	public double lastTimeInCache; //Field offset: 0x60
	public Action removedFromCache; //Field offset: 0x68
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VertexDataLayout <vertexDataLayout>k__BackingField; //Field offset: 0x70
	public bool hasMultipleColors; //Field offset: 0x74

	public private VertexDataLayout vertexDataLayout
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private static TextInfo() { }

	public TextInfo(VertexDataLayout vertexDataLayout) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal void Clear() { }

	internal void ClearLineInfo() { }

	internal void ClearMeshInfo(bool updateMesh) { }

	internal void ClearPageInfo() { }

	private static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point) { }

	public int FindIntersectingLink(Vector3 position, Rect screenRect, bool inverseYAxis = true) { }

	public int FindNearestCharacterOnLine(Vector2 position, int line, bool visibleOnly) { }

	public int FindNearestLine(Vector2 position) { }

	[CompilerGenerated]
	public VertexDataLayout get_vertexDataLayout() { }

	public float GetCharacterHeightFromIndex(int index) { }

	public int GetCorrespondingStringIndex(int index) { }

	public int GetCursorIndexFromPosition(Vector2 position, Rect screenRect, bool inverseYAxis = true) { }

	public override Vector2 GetCursorPositionFromStringIndexUsingCharacterHeight(int index, Rect screenRect, float lineHeight, bool inverseYAxis = true) { }

	public Vector2 GetCursorPositionFromStringIndexUsingLineHeight(int index, Rect screenRect, float lineHeight, bool useXAdvance = false, bool inverseYAxis = true) { }

	public float GetLineHeight(int lineNumber) { }

	public float GetLineHeightFromCharacterIndex(int index) { }

	public LineInfo GetLineInfoFromCharacterIndex(int index) { }

	public int GetLineNumber(int index) { }

	public int IndexOf(char value, int startIndex) { }

	public int LastIndexOf(char value, int startIndex) { }

	public int LineDownCharacterPosition(int originalPos) { }

	public int LineUpCharacterPosition(int originalPos) { }

	private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d) { }

	public void RemoveFromCache() { }

	internal static void Resize(ref T[] array, int size) { }

	internal static void Resize(ref T[] array, int size, bool isBlockAllocated) { }

	[CompilerGenerated]
	private void set_vertexDataLayout(VertexDataLayout value) { }

	public string Substring(int startIndex, int length) { }

}

