namespace UnityEngine.UIElements;

public class DropdownMenu
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Status status; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal Status <AppendAction>b__0(DropdownMenuAction e) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public string subMenuPath; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <AppendSeparator>b__0(DropdownMenuItem item) { }

	}

	private List<DropdownMenuItem> m_MenuItems; //Field offset: 0x10
	private DropdownMenuEventInfo m_DropdownMenuEventInfo; //Field offset: 0x18

	internal int Count
	{
		internal get { } //Length: 60
	}

	public DropdownMenu() { }

	public void AppendAction(string actionName, Action<DropdownMenuAction> action, Func<DropdownMenuAction, Status> actionStatusCallback, object userData = null) { }

	public void AppendAction(string actionName, Action<DropdownMenuAction> action, Status status = 1) { }

	public void AppendSeparator(string subMenuPath = null) { }

	internal int get_Count() { }

	public void InsertSeparator(string subMenuPath, int atIndex) { }

	public List<DropdownMenuItem> MenuItems() { }

	public void PrepareForDisplay(EventBase e) { }

}

