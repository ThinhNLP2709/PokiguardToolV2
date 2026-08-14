namespace UnityEngine.UIElements;

[IsReadOnly]
public struct TreeViewItemData
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly int <id>k__BackingField; //Field offset: 0x0
	[CreateProperty]
	private readonly T m_Data; //Field offset: 0x0
	private readonly IList<TreeViewItemData`1<T>> m_Children; //Field offset: 0x0

	public IEnumerable<TreeViewItemData`1<T>> children
	{
		 get { } //Length: 5
	}

	public T data
	{
		 get { } //Length: 5
	}

	public int id
	{
		[CompilerGenerated]
		 get { } //Length: 3
	}

	public IEnumerable<TreeViewItemData`1<T>> get_children() { }

	public T get_data() { }

	[CompilerGenerated]
	public int get_id() { }

}

