namespace UnityEngine.Accessibility;

public class AccessibilityNode
{
	[DefaultMember("Item")]
	private class ObservableList
	{
		private readonly List<T> m_Items; //Field offset: 0x0
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
		private Action listChanged; //Field offset: 0x0

		public event Action listChanged
		{
			[CompilerGenerated]
			 add { } //Length: 158
			[CompilerGenerated]
			 remove { } //Length: 158
		}

		public override int Count
		{
			 get { } //Length: 26
		}

		public override T Item
		{
			 get { } //Length: 42
		}

		[CompilerGenerated]
		public void add_listChanged(Action value) { }

		public override int get_Count() { }

		public override T get_Item(int index) { }

		public override IEnumerator<T> GetEnumerator() { }

		[CompilerGenerated]
		public void remove_listChanged(Action value) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <id>k__BackingField; //Field offset: 0x10
	private Func<Rect> m_FrameGetter; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<AccessibilityNode, Boolean> focusChanged; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Func<Boolean> selected; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action incremented; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action decremented; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Func<Boolean> dismissed; //Field offset: 0x40
	private string m_Label; //Field offset: 0x48
	private string m_Value; //Field offset: 0x50
	private string m_Hint; //Field offset: 0x58
	private bool m_IsActive; //Field offset: 0x60
	private AccessibilityRole m_Role; //Field offset: 0x62
	private bool m_AllowsDirectInteraction; //Field offset: 0x64
	private AccessibilityState m_State; //Field offset: 0x66
	private AccessibilityNode m_Parent; //Field offset: 0x68
	private ObservableList<AccessibilityNode> m_Children; //Field offset: 0x70
	private ObservableList<AccessibilityAction> m_Actions; //Field offset: 0x78
	private Rect m_Frame; //Field offset: 0x80
	private SystemLanguage m_Language; //Field offset: 0x90
	private AccessibilityHierarchy m_Hierarchy; //Field offset: 0x98

	public bool allowsDirectInteraction
	{
		 get { } //Length: 5
	}

	internal IList<AccessibilityNode> childList
	{
		internal get { } //Length: 5
	}

	public Rect frame
	{
		 get { } //Length: 401
	}

	public Func<Rect> frameGetter
	{
		 get { } //Length: 5
	}

	public string hint
	{
		 get { } //Length: 5
	}

	public int id
	{
		[CompilerGenerated]
		 get { } //Length: 4
	}

	public bool isActive
	{
		 get { } //Length: 5
	}

	public string label
	{
		 get { } //Length: 5
	}

	internal SystemLanguage language
	{
		internal get { } //Length: 7
	}

	public AccessibilityNode parent
	{
		 get { } //Length: 5
	}

	public AccessibilityRole role
	{
		 get { } //Length: 5
	}

	public AccessibilityState state
	{
		 get { } //Length: 5
	}

	public string value
	{
		 get { } //Length: 5
	}

	private void ActionsChanged() { }

	internal void CalculateFrame() { }

	private void ChildrenChanged() { }

	internal bool Dismissed() { }

	internal void FreeNative(bool freeChildren) { }

	public bool get_allowsDirectInteraction() { }

	internal IList<AccessibilityNode> get_childList() { }

	public Rect get_frame() { }

	public Func<Rect> get_frameGetter() { }

	public string get_hint() { }

	[CompilerGenerated]
	public int get_id() { }

	public bool get_isActive() { }

	public string get_label() { }

	internal SystemLanguage get_language() { }

	public AccessibilityNode get_parent() { }

	public AccessibilityRole get_role() { }

	public AccessibilityState get_state() { }

	public string get_value() { }

	internal void GetNodeData(ref AccessibilityNodeData nodeData) { }

	internal void InvokeDecremented() { }

	internal void InvokeFocusChanged(bool isNodeFocused) { }

	internal void InvokeIncremented() { }

	internal bool InvokeSelected() { }

	private bool IsInActiveHierarchy() { }

	internal void NotifyFocusChanged(bool isNodeFocused) { }

	private void SetFrame(Rect frame) { }

}

