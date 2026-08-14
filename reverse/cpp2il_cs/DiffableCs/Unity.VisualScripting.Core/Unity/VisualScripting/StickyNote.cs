namespace Unity.VisualScripting;

public class StickyNote : GraphElement<IGraph>
{
	internal enum ColorEnum
	{
		Classic = 0,
		Black = 1,
		Dark = 2,
		Orange = 3,
		Green = 4,
		Blue = 5,
		Red = 6,
		Purple = 7,
		Teal = 8,
	}

	[DoNotSerialize]
	public static readonly Color defaultColor; //Field offset: 0x0
	[CompilerGenerated]
	private Rect <position>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <title>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private string <body>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private ColorEnum <colorTheme>k__BackingField; //Field offset: 0x48

	[InspectorTextArea(minLines = 1)]
	[Serialize]
	public string body
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Inspectable]
	[Serialize]
	public ColorEnum colorTheme
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	[Serialize]
	public Rect position
	{
		[CompilerGenerated]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[Serialize]
	public string title
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private static StickyNote() { }

	public StickyNote() { }

	[CompilerGenerated]
	public string get_body() { }

	[CompilerGenerated]
	public ColorEnum get_colorTheme() { }

	[CompilerGenerated]
	public Rect get_position() { }

	[CompilerGenerated]
	public string get_title() { }

	public static Color GetFontColor(ColorEnum enumValue) { }

	public static Color GetStickyColor(ColorEnum enumValue) { }

	[CompilerGenerated]
	public void set_body(string value) { }

	[CompilerGenerated]
	public void set_colorTheme(ColorEnum value) { }

	[CompilerGenerated]
	public void set_position(Rect value) { }

	[CompilerGenerated]
	public void set_title(string value) { }

}

