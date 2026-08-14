namespace UnityEngine.TextCore;

[NativeHeader("Modules/TextCoreTextEngine/Native/TextGenerationSettings.h")]
[UsedByNativeCode("TextGenerationSettings")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule"})]
internal struct NativeTextGenerationSettings
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<TextSpan> <>9__17_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <get_hasLink>b__17_0(TextSpan span) { }

	}

	public IntPtr fontAsset; //Field offset: 0x0
	public IntPtr[] globalFontAssetFallbacks; //Field offset: 0x8
	public string text; //Field offset: 0x10
	public int screenWidth; //Field offset: 0x18
	public int screenHeight; //Field offset: 0x1C
	public WhiteSpace wordWrap; //Field offset: 0x20
	public TextOverflow overflow; //Field offset: 0x24
	public LanguageDirection languageDirection; //Field offset: 0x28
	public int vertexPadding; //Field offset: 0x2C
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal HorizontalAlignment horizontalAlignment; //Field offset: 0x30
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal VerticalAlignment verticalAlignment; //Field offset: 0x34
	public int fontSize; //Field offset: 0x38
	public FontStyles fontStyle; //Field offset: 0x3C
	public TextFontWeight fontWeight; //Field offset: 0x40
	public TextSpan[] textSpans; //Field offset: 0x48
	public Color32 color; //Field offset: 0x50

	public static NativeTextGenerationSettings Default
	{
		 get { } //Length: 82
	}

	public bool hasLink
	{
		 get { } //Length: 290
	}

	[IsReadOnly]
	public TextSpan CreateTextSpan() { }

	public static NativeTextGenerationSettings get_Default() { }

	public bool get_hasLink() { }

	public virtual string ToString() { }

}

