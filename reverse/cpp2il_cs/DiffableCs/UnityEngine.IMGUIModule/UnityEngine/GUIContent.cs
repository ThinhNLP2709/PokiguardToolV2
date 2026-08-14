namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUIContent.h")]
[RequiredByNativeCode(Optional = True, GenerateProxy = True)]
public class GUIContent
{
	private static readonly GUIContent s_Text; //Field offset: 0x0
	private static readonly GUIContent s_Image; //Field offset: 0x8
	private static readonly GUIContent s_TextImage; //Field offset: 0x10
	internal static string k_ZeroWidthSpace; //Field offset: 0x18
	public static GUIContent none; //Field offset: 0x20
	[SerializeField]
	private string m_Text; //Field offset: 0x10
	[SerializeField]
	private Texture m_Image; //Field offset: 0x18
	[SerializeField]
	private string m_Tooltip; //Field offset: 0x20
	[SerializeField]
	private string m_TextWithWhitespace; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action OnTextChanged; //Field offset: 0x30

	internal event Action OnTextChanged
	{
		[CompilerGenerated]
		internal add { } //Length: 158
		[CompilerGenerated]
		internal remove { } //Length: 158
	}

	public Texture image
	{
		 set { } //Length: 13
	}

	public string text
	{
		 get { } //Length: 7
		 set { } //Length: 96
	}

	internal string textWithWhitespace
	{
		internal get { } //Length: 110
		internal set { } //Length: 123
	}

	public string tooltip
	{
		 get { } //Length: 7
		 set { } //Length: 13
	}

	private static GUIContent() { }

	public GUIContent(GUIContent src) { }

	public GUIContent(string text, Texture image, string tooltip) { }

	public GUIContent(string text, string tooltip) { }

	public GUIContent(string text) { }

	public GUIContent() { }

	[CompilerGenerated]
	internal void add_OnTextChanged(Action value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void ClearStaticCache() { }

	public string get_text() { }

	internal string get_textWithWhitespace() { }

	public string get_tooltip() { }

	[CompilerGenerated]
	internal void remove_OnTextChanged(Action value) { }

	public void set_image(Texture value) { }

	public void set_text(string value) { }

	internal void set_textWithWhitespace(string value) { }

	public void set_tooltip(string value) { }

	internal void SetTextWithoutNotify(string value) { }

	internal static GUIContent Temp(string t) { }

	public virtual string ToString() { }

}

