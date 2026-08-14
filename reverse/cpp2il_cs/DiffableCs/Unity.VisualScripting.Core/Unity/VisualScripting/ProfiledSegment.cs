namespace Unity.VisualScripting;

public class ProfiledSegment
{
	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Stopwatch <stopwatch>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private long <calls>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private ProfiledSegment <parent>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private ProfiledSegmentCollection <children>k__BackingField; //Field offset: 0x30

	public long calls
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 5
	}

	public private ProfiledSegmentCollection children
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private ProfiledSegment parent
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private Stopwatch stopwatch
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public ProfiledSegment(ProfiledSegment parent, string name) { }

	[CompilerGenerated]
	public long get_calls() { }

	[CompilerGenerated]
	public ProfiledSegmentCollection get_children() { }

	[CompilerGenerated]
	public string get_name() { }

	[CompilerGenerated]
	public ProfiledSegment get_parent() { }

	[CompilerGenerated]
	public Stopwatch get_stopwatch() { }

	[CompilerGenerated]
	public void set_calls(long value) { }

	[CompilerGenerated]
	private void set_children(ProfiledSegmentCollection value) { }

	[CompilerGenerated]
	private void set_name(string value) { }

	[CompilerGenerated]
	private void set_parent(ProfiledSegment value) { }

	[CompilerGenerated]
	private void set_stopwatch(Stopwatch value) { }

}

