namespace UnityEngine.Rendering;

public sealed class DebugManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Boolean> <>9__49_0; //Field offset: 0x8
		public static Action <>9__49_1; //Field offset: 0x10
		public static Func<Widget, Int32> <>9__60_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal DebugManager <.cctor>b__95_0() { }

		internal void <.ctor>b__49_0(bool <p0>) { }

		internal void <.ctor>b__49_1() { }

		internal int <TogglePersistent>b__60_0(Widget w) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass67_0
	{
		public string displayName; //Field offset: 0x10

		public <>c__DisplayClass67_0() { }

		internal bool <FindPanelIndex>b__0(Panel p) { }

	}

	internal enum UIMode
	{
		EditorMode = 0,
		RuntimeMode = 1,
	}

	private class UIState
	{
		public UIMode mode; //Field offset: 0x10
		[SerializeField]
		private bool m_Open; //Field offset: 0x14

		public bool open
		{
			 get { } //Length: 5
			 set { } //Length: 134
		}

		public UIState() { }

		public bool get_open() { }

		public void set_open(bool value) { }

	}

	private const string kEnableDebugBtn1 = "Enable Debug Button 1"; //Field offset: 0x0
	private const string kEnableDebug = "Enable Debug"; //Field offset: 0x0
	private const string kResetBtn = "Debug Reset"; //Field offset: 0x0
	private const string kMultiplierBtn = "Debug Multiplier"; //Field offset: 0x0
	private const string kDPadHorizontal = "Debug Horizontal"; //Field offset: 0x0
	private const string kDPadVertical = "Debug Vertical"; //Field offset: 0x0
	private static readonly Lazy<DebugManager> s_Instance; //Field offset: 0x0
	private const string kValidateBtn = "Debug Validate"; //Field offset: 0x0
	private const string kDebugNextBtn = "Debug Next"; //Field offset: 0x0
	private const string kDebugPreviousBtn = "Debug Previous"; //Field offset: 0x0
	private const string kEnableDebugBtn2 = "Enable Debug Button 2"; //Field offset: 0x0
	private const string kPersistentBtn = "Debug Persistent"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<UIMode, Boolean> windowStateChanged; //Field offset: 0x8
	private DebugActionDesc[] m_DebugActions; //Field offset: 0x10
	private DebugActionState[] m_DebugActionStates; //Field offset: 0x18
	private InputActionMap debugActionMap; //Field offset: 0x20
	private ReadOnlyCollection<Panel> m_ReadOnlyPanels; //Field offset: 0x28
	private readonly List<Panel> m_Panels; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Boolean> onDisplayRuntimeUIChanged; //Field offset: 0x38
	[CompilerGenerated]
	private Action onSetDirty; //Field offset: 0x40
	[CompilerGenerated]
	private Action resetData; //Field offset: 0x48
	public bool refreshEditorRequested; //Field offset: 0x50
	private Nullable<Int32> m_RequestedPanelIndex; //Field offset: 0x54
	private GameObject m_Root; //Field offset: 0x60
	private DebugUIHandlerCanvas m_RootUICanvas; //Field offset: 0x68
	private GameObject m_PersistentRoot; //Field offset: 0x70
	private DebugUIHandlerPersistentCanvas m_RootUIPersistentCanvas; //Field offset: 0x78
	private UIState editorUIState; //Field offset: 0x80
	private bool m_EnableRuntimeUI; //Field offset: 0x88
	private UIState runtimeUIState; //Field offset: 0x90

	public event Action<Boolean> onDisplayRuntimeUIChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action onSetDirty
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	private event Action resetData
	{
		[CompilerGenerated]
		private add { } //Length: 158
		[CompilerGenerated]
		private remove { } //Length: 158
	}

	public static event Action<UIMode, Boolean> windowStateChanged
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public bool displayEditorUI
	{
		 get { } //Length: 30
		 set { } //Length: 33
	}

	public bool displayPersistentRuntimeUI
	{
		 get { } //Length: 125
		 set { } //Length: 146
	}

	public bool displayRuntimeUI
	{
		 get { } //Length: 125
		 set { } //Length: 638
	}

	public bool enableRuntimeUI
	{
		 get { } //Length: 8
		 set { } //Length: 28
	}

	public static DebugManager instance
	{
		 get { } //Length: 111
	}

	public bool isAnyDebugUIActive
	{
		 get { } //Length: 140
	}

	public ReadOnlyCollection<Panel> panels
	{
		 get { } //Length: 43
	}

	private static DebugManager() { }

	private DebugManager() { }

	[CompilerGenerated]
	public void add_onDisplayRuntimeUIChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	public void add_onSetDirty(Action value) { }

	[CompilerGenerated]
	private void add_resetData(Action value) { }

	[CompilerGenerated]
	public static void add_windowStateChanged(Action<UIMode, Boolean> value) { }

	private void AddAction(DebugAction action, DebugActionDesc desc) { }

	internal void ChangeSelection(DebugUIHandlerWidget widget, bool fromNext) { }

	internal void EnableInputActions() { }

	private void EnsurePersistentCanvas() { }

	public int FindPanelIndex(string displayName) { }

	public bool get_displayEditorUI() { }

	public bool get_displayPersistentRuntimeUI() { }

	public bool get_displayRuntimeUI() { }

	public bool get_enableRuntimeUI() { }

	public static DebugManager get_instance() { }

	public bool get_isAnyDebugUIActive() { }

	public ReadOnlyCollection<Panel> get_panels() { }

	internal float GetAction(DebugAction action) { }

	internal bool GetActionReleaseScrollTarget() { }

	internal bool GetActionToggleDebugMenuWithTouch() { }

	public Widget GetItem(string queryPath) { }

	private Widget GetItem(string queryPath, IContainer container) { }

	public Widget[] GetItems(Flags flags) { }

	internal Widget[] GetItemsFromContainer(Flags flags, IContainer container) { }

	public Panel GetPanel(string displayName, bool createIfNull = false, int groupIndex = 0, bool overrideIfExist = false) { }

	internal Nullable<Int32> GetRequestedEditorWindowPanelIndex() { }

	public int GetState() { }

	private void OnPanelDirty(Panel panel) { }

	public string PanelDiplayName(int panelIndex) { }

	public int PanelIndex(string displayName) { }

	public void ReDrawOnScreenDebug() { }

	public void RefreshEditor() { }

	private void RegisterActions() { }

	public void RegisterData(IDebugData data) { }

	private void RegisterInputs() { }

	internal void RegisterRootCanvas(DebugUIHandlerCanvas root) { }

	[CompilerGenerated]
	public void remove_onDisplayRuntimeUIChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	public void remove_onSetDirty(Action value) { }

	[CompilerGenerated]
	private void remove_resetData(Action value) { }

	[CompilerGenerated]
	public static void remove_windowStateChanged(Action<UIMode, Boolean> value) { }

	public void RemovePanel(string displayName) { }

	public void RemovePanel(Panel panel) { }

	public void RequestEditorWindowPanelIndex(int index) { }

	public void Reset() { }

	private void SampleAction(int actionIndex) { }

	public void set_displayEditorUI(bool value) { }

	public void set_displayPersistentRuntimeUI(bool value) { }

	public void set_displayRuntimeUI(bool value) { }

	public void set_enableRuntimeUI(bool value) { }

	internal void SetScrollTarget(DebugUIHandlerWidget widget) { }

	[Obsolete("Use DebugManager.instance.displayEditorUI property instead. #from(23.1)")]
	public void ToggleEditorUI(bool open) { }

	internal void TogglePersistent(Widget widget, Nullable<Int32> forceTupleIndex = null) { }

	public void UnregisterData(IDebugData data) { }

	private void UpdateAction(int actionIndex) { }

	internal void UpdateActions() { }

	private void UpdateReadOnlyCollection() { }

}

