namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
public sealed class GraphGroup : GraphElement<IGraph>
{
	[DoNotSerialize]
	public static readonly Color defaultColor; //Field offset: 0x0
	[CompilerGenerated]
	private Rect <position>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <label>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private string <comment>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private Color <color>k__BackingField; //Field offset: 0x48

	[Inspectable]
	[Serialize]
	public Color color
	{
		[CompilerGenerated]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[InspectorTextArea(minLines = 1, maxLines = 10)]
	[Serialize]
	public string comment
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Serialize]
	public string label
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Serialize]
	public Rect position
	{
		[CompilerGenerated]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	private static GraphGroup() { }

	public GraphGroup() { }

	[CompilerGenerated]
	public Color get_color() { }

	[CompilerGenerated]
	public string get_comment() { }

	[CompilerGenerated]
	public string get_label() { }

	[CompilerGenerated]
	public Rect get_position() { }

	[CompilerGenerated]
	public void set_color(Color value) { }

	[CompilerGenerated]
	public void set_comment(string value) { }

	[CompilerGenerated]
	public void set_label(string value) { }

	[CompilerGenerated]
	public void set_position(Rect value) { }

}

