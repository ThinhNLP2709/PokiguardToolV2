namespace UnityEngine;

[NativeClass("TextRenderingPrivate::TextMesh")]
[NativeHeader("Modules/TextRendering/Public/TextMesh.h")]
[RequireComponent(typeof(Transform), typeof(MeshRenderer))]
public sealed class TextMesh : Component
{

	public TextAlignment alignment
	{
		 set { } //Length: 131
	}

	public TextAnchor anchor
	{
		 set { } //Length: 131
	}

	public Color color
	{
		 get { } //Length: 142
		 set { } //Length: 133
	}

	public Font font
	{
		 get { } //Length: 144
		 set { } //Length: 186
	}

	public int fontSize
	{
		 set { } //Length: 131
	}

	public FontStyle fontStyle
	{
		 set { } //Length: 131
	}

	public float offsetZ
	{
		 set { } //Length: 134
	}

	public bool richText
	{
		 set { } //Length: 134
	}

	public string text
	{
		 set { } //Length: 437
	}

	public Color get_color() { }

	private static void get_color_Injected(IntPtr _unity_self, out Color ret) { }

	public Font get_font() { }

	private static IntPtr get_font_Injected(IntPtr _unity_self) { }

	public void set_alignment(TextAlignment value) { }

	private static void set_alignment_Injected(IntPtr _unity_self, TextAlignment value) { }

	public void set_anchor(TextAnchor value) { }

	private static void set_anchor_Injected(IntPtr _unity_self, TextAnchor value) { }

	public void set_color(Color value) { }

	private static void set_color_Injected(IntPtr _unity_self, in Color value) { }

	public void set_font(Font value) { }

	private static void set_font_Injected(IntPtr _unity_self, IntPtr value) { }

	public void set_fontSize(int value) { }

	private static void set_fontSize_Injected(IntPtr _unity_self, int value) { }

	public void set_fontStyle(FontStyle value) { }

	private static void set_fontStyle_Injected(IntPtr _unity_self, FontStyle value) { }

	public void set_offsetZ(float value) { }

	private static void set_offsetZ_Injected(IntPtr _unity_self, float value) { }

	public void set_richText(bool value) { }

	private static void set_richText_Injected(IntPtr _unity_self, bool value) { }

	public void set_text(string value) { }

	private static void set_text_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value) { }

}

