namespace UnityEngine;

[NativeClass("TextRendering::Font")]
[NativeHeader("Modules/TextRendering/Public/FontImpl.h")]
[NativeHeader("Modules/TextRendering/Public/Font.h")]
[StaticAccessor("TextRenderingPrivate", StaticAccessorType::DoubleColon (2))]
public sealed class Font : object
{
	internal sealed class FontTextureRebuildCallback : MulticastDelegate
	{

		public FontTextureRebuildCallback(object object, IntPtr method) { }

		public override void Invoke() { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Font> textureRebuilt; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private FontTextureRebuildCallback m_FontTextureRebuildCallback; //Field offset: 0x18

	public static event Action<Font> textureRebuilt
	{
		[CompilerGenerated]
		 add { } //Length: 215
		[CompilerGenerated]
		 remove { } //Length: 215
	}

	public bool dynamic
	{
		 get { } //Length: 118
	}

	public int fontSize
	{
		 get { } //Length: 118
	}

	public Material material
	{
		 get { } //Length: 144
	}

	private Font(String[] names, int size) { }

	[CompilerGenerated]
	public static void add_textureRebuilt(Action<Font> value) { }

	public static Font CreateDynamicFontFromOSFont(string fontname, int size) { }

	public bool get_dynamic() { }

	private static bool get_dynamic_Injected(IntPtr _unity_self) { }

	public int get_fontSize() { }

	private static int get_fontSize_Injected(IntPtr _unity_self) { }

	public Material get_material() { }

	private static IntPtr get_material_Injected(IntPtr _unity_self) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.TextCoreTextEngineModule"})]
	internal static String[] GetOSFallbacks() { }

	public static String[] GetPathsToOSFonts() { }

	public bool HasCharacter(char c) { }

	private bool HasCharacter(int c) { }

	private static bool HasCharacter_Injected(IntPtr _unity_self, int c) { }

	private static void Internal_CreateDynamicFont(Font self, String[] _names, int size) { }

	[RequiredByNativeCode]
	internal static void InvokeTextureRebuilt_Internal(Font font) { }

	[CompilerGenerated]
	public static void remove_textureRebuilt(Action<Font> value) { }

}

