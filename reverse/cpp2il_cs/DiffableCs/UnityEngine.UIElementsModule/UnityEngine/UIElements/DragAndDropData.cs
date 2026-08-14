namespace UnityEngine.UIElements;

public abstract class DragAndDropData
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private String[] <paths>k__BackingField; //Field offset: 0x10

	public override String[] paths
	{
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public abstract object source
	{
		 get { } //Length: 0
	}

	protected DragAndDropData() { }

	public abstract object get_source() { }

	public abstract object GetGenericData(string key) { }

	[CompilerGenerated]
	public override void set_paths(String[] value) { }

}

