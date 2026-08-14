namespace UnityEngine;

[NativeHeader("Modules/TextRendering/TextGenerator.h")]
[UsedByNativeCode]
public sealed class TextGenerator : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(TextGenerator textGenerator) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10
	private string m_LastString; //Field offset: 0x18
	private TextGenerationSettings m_LastSettings; //Field offset: 0x20
	private bool m_HasGenerated; //Field offset: 0x80
	private TextGenerationError m_LastValid; //Field offset: 0x84
	private readonly List<UIVertex> m_Verts; //Field offset: 0x88
	private readonly List<UICharInfo> m_Characters; //Field offset: 0x90
	private readonly List<UILineInfo> m_Lines; //Field offset: 0x98
	private bool m_CachedVerts; //Field offset: 0xA0
	private bool m_CachedCharacters; //Field offset: 0xA1
	private bool m_CachedLines; //Field offset: 0xA2

	public int characterCount
	{
		 get { } //Length: 81
	}

	public int characterCountVisible
	{
		 get { } //Length: 83
	}

	public IList<UICharInfo> characters
	{
		 get { } //Length: 133
	}

	public int lineCount
	{
		 get { } //Length: 81
	}

	public IList<UILineInfo> lines
	{
		 get { } //Length: 133
	}

	public Rect rectExtents
	{
		 get { } //Length: 105
	}

	public IList<UIVertex> verts
	{
		 get { } //Length: 133
	}

	public TextGenerator() { }

	public TextGenerator(int initialCapacity) { }

	protected virtual void Finalize() { }

	public int get_characterCount() { }

	private static int get_characterCount_Injected(IntPtr _unity_self) { }

	public int get_characterCountVisible() { }

	public IList<UICharInfo> get_characters() { }

	public int get_lineCount() { }

	private static int get_lineCount_Injected(IntPtr _unity_self) { }

	public IList<UILineInfo> get_lines() { }

	public Rect get_rectExtents() { }

	private static void get_rectExtents_Injected(IntPtr _unity_self, out Rect ret) { }

	public IList<UIVertex> get_verts() { }

	public void GetCharacters(List<UICharInfo> characters) { }

	[NativeThrows]
	private void GetCharactersInternal(object characters) { }

	private static void GetCharactersInternal_Injected(IntPtr _unity_self, object characters) { }

	public void GetLines(List<UILineInfo> lines) { }

	[NativeThrows]
	private void GetLinesInternal(object lines) { }

	private static void GetLinesInternal_Injected(IntPtr _unity_self, object lines) { }

	public float GetPreferredHeight(string str, TextGenerationSettings settings) { }

	public float GetPreferredWidth(string str, TextGenerationSettings settings) { }

	public void GetVertices(List<UIVertex> vertices) { }

	[NativeThrows]
	private void GetVerticesInternal(object vertices) { }

	private static void GetVerticesInternal_Injected(IntPtr _unity_self, object vertices) { }

	[NativeMethod(IsThreadSafe = True)]
	private static IntPtr Internal_Create() { }

	[NativeMethod(IsThreadSafe = True)]
	private static void Internal_Destroy(IntPtr ptr) { }

	public void Invalidate() { }

	public bool Populate(string str, TextGenerationSettings settings) { }

	internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error) { }

	internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, VerticalWrapMode verticalOverFlow, HorizontalWrapMode horizontalOverflow, bool updateBounds, TextAnchor anchor, Vector2 extents, Vector2 pivot, bool generateOutOfBounds, bool alignByGeometry, out TextGenerationError error) { }

	private static bool Populate_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper str, IntPtr font, in Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error) { }

	private TextGenerationError PopulateAlways(string str, TextGenerationSettings settings) { }

	private TextGenerationError PopulateWithError(string str, TextGenerationSettings settings) { }

	public bool PopulateWithErrors(string str, TextGenerationSettings settings, GameObject context) { }

	private override void System.IDisposable.Dispose() { }

	private TextGenerationSettings ValidatedSettings(TextGenerationSettings settings) { }

}

