namespace UnityEngine.InputSystem;

[DefaultMember("Item")]
public sealed class InputActionMap : ICloneable, ISerializationCallbackReceiver, IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct BindingJson
	{
		public string name; //Field offset: 0x0
		public string id; //Field offset: 0x8
		public string path; //Field offset: 0x10
		public string interactions; //Field offset: 0x18
		public string processors; //Field offset: 0x20
		public string groups; //Field offset: 0x28
		public string action; //Field offset: 0x30
		public bool isComposite; //Field offset: 0x38
		public bool isPartOfComposite; //Field offset: 0x39

		public static BindingJson FromBinding(ref InputBinding binding) { }

		public InputBinding ToBinding() { }

	}

	public struct BindingOverrideJson
	{
		public string action; //Field offset: 0x0
		public string id; //Field offset: 0x8
		public string path; //Field offset: 0x10
		public string interactions; //Field offset: 0x18
		public string processors; //Field offset: 0x20

		public static BindingOverrideJson FromBinding(InputBinding binding, string actionName) { }

		public static BindingOverrideJson FromBinding(InputBinding binding) { }

		public static InputBinding ToBinding(BindingOverrideJson bindingOverride) { }

	}

	public struct BindingOverrideListJson
	{
		public List<BindingOverrideJson> bindings; //Field offset: 0x0

	}

	public struct DeviceArray
	{
		private bool m_HaveValue; //Field offset: 0x0
		private int m_DeviceCount; //Field offset: 0x4
		private InputDevice[] m_DeviceArray; //Field offset: 0x8

		public Nullable<ReadOnlyArray`1<InputDevice>> Get() { }

		public int IndexOf(InputDevice device) { }

		public bool Remove(InputDevice device) { }

		public bool Set(Nullable<ReadOnlyArray`1<InputDevice>> devices) { }

	}

	[Flags]
	private enum Flags
	{
		NeedToResolveBindings = 1,
		BindingResolutionNeedsFullReResolve = 2,
		ControlsForEachActionInitialized = 4,
		BindingsForEachActionInitialized = 8,
	}

	public struct ReadActionJson
	{
		public string name; //Field offset: 0x0
		public string type; //Field offset: 0x8
		public string id; //Field offset: 0x10
		public string expectedControlType; //Field offset: 0x18
		public string expectedControlLayout; //Field offset: 0x20
		public string processors; //Field offset: 0x28
		public string interactions; //Field offset: 0x30
		public bool passThrough; //Field offset: 0x38
		public bool initialStateCheck; //Field offset: 0x39
		public BindingJson[] bindings; //Field offset: 0x40

		public InputAction ToAction(string actionName = null) { }

	}

	public struct ReadFileJson
	{
		public ReadActionJson[] actions; //Field offset: 0x0
		public ReadMapJson[] maps; //Field offset: 0x8

		public InputActionMap[] ToMaps() { }

	}

	public struct ReadMapJson
	{
		public string name; //Field offset: 0x0
		public string id; //Field offset: 0x8
		public ReadActionJson[] actions; //Field offset: 0x10
		public BindingJson[] bindings; //Field offset: 0x18

	}

	public struct WriteActionJson
	{
		public string name; //Field offset: 0x0
		public string type; //Field offset: 0x8
		public string id; //Field offset: 0x10
		public string expectedControlType; //Field offset: 0x18
		public string processors; //Field offset: 0x20
		public string interactions; //Field offset: 0x28
		public bool initialStateCheck; //Field offset: 0x30

		public static WriteActionJson FromAction(InputAction action) { }

	}

	public struct WriteFileJson
	{
		public WriteMapJson[] maps; //Field offset: 0x0

		public static WriteFileJson FromMap(InputActionMap map) { }

		public static WriteFileJson FromMaps(IEnumerable<InputActionMap> maps) { }

	}

	public struct WriteMapJson
	{
		public string name; //Field offset: 0x0
		public string id; //Field offset: 0x8
		public WriteActionJson[] actions; //Field offset: 0x10
		public BindingJson[] bindings; //Field offset: 0x18

		public static WriteMapJson FromMap(InputActionMap map) { }

	}

	private static readonly ProfilerMarker k_ResolveBindingsProfilerMarker; //Field offset: 0x0
	internal static int s_DeferBindingResolution; //Field offset: 0x8
	internal static bool s_NeedToResolveBindings; //Field offset: 0xC
	[SerializeField]
	internal string m_Name; //Field offset: 0x10
	[SerializeField]
	internal string m_Id; //Field offset: 0x18
	[SerializeField]
	internal InputActionAsset m_Asset; //Field offset: 0x20
	[SerializeField]
	internal InputAction[] m_Actions; //Field offset: 0x28
	[SerializeField]
	internal InputBinding[] m_Bindings; //Field offset: 0x30
	private InputBinding[] m_BindingsForEachAction; //Field offset: 0x38
	private InputControl[] m_ControlsForEachAction; //Field offset: 0x40
	internal int m_EnabledActionsCount; //Field offset: 0x48
	internal InputAction m_SingletonAction; //Field offset: 0x50
	internal int m_MapIndexInState; //Field offset: 0x58
	internal InputActionState m_State; //Field offset: 0x60
	internal Nullable<InputBinding> m_BindingMask; //Field offset: 0x68
	private Flags m_Flags; //Field offset: 0xC8
	internal int m_ParameterOverridesCount; //Field offset: 0xCC
	internal ParameterOverride[] m_ParameterOverrides; //Field offset: 0xD0
	internal DeviceArray m_Devices; //Field offset: 0xD8
	internal CallbackArray<Action`1<CallbackContext>> m_ActionCallbacks; //Field offset: 0xE8
	internal Dictionary<String, Int32> m_ActionIndexByNameOrId; //Field offset: 0x138

	public event Action<CallbackContext> actionTriggered
	{
		 add { } //Length: 76
		 remove { } //Length: 76
	}

	public ReadOnlyArray<InputAction> actions
	{
		 get { } //Length: 83
	}

	public InputActionAsset asset
	{
		 get { } //Length: 5
	}

	public override Nullable<InputBinding> bindingMask
	{
		 get { } //Length: 63
		 set { } //Length: 440
	}

	private bool bindingResolutionNeedsFullReResolve
	{
		private get { } //Length: 11
		private set { } //Length: 31
	}

	public ReadOnlyArray<InputBinding> bindings
	{
		 get { } //Length: 83
	}

	private bool bindingsForEachActionInitialized
	{
		private get { } //Length: 11
		private set { } //Length: 31
	}

	public override ReadOnlyArray<InputControlScheme> controlSchemes
	{
		 get { } //Length: 193
	}

	private bool controlsForEachActionInitialized
	{
		private get { } //Length: 11
		private set { } //Length: 31
	}

	public override Nullable<ReadOnlyArray`1<InputDevice>> devices
	{
		 get { } //Length: 205
		 set { } //Length: 76
	}

	public bool enabled
	{
		 get { } //Length: 8
	}

	public Guid id
	{
		 get { } //Length: 122
	}

	internal Guid idDontGenerate
	{
		internal get { } //Length: 78
	}

	public InputAction Item
	{
		 get { } //Length: 263
	}

	public string name
	{
		 get { } //Length: 5
	}

	private bool needToResolveBindings
	{
		private get { } //Length: 10
		private set { } //Length: 31
	}

	private override IEnumerable<InputBinding> UnityEngine.InputSystem.IInputActionCollection2.bindings
	{
		private get { } //Length: 128
	}

	private static InputActionMap() { }

	public InputActionMap(string name) { }

	public InputActionMap() { }

	public void add_actionTriggered(Action<CallbackContext> value) { }

	internal void ClearActionLookupTable() { }

	internal void ClearCachedActionData(bool onlyControls = false) { }

	public InputActionMap Clone() { }

	public override bool Contains(InputAction action) { }

	public override void Disable() { }

	public override void Dispose() { }

	public override void Enable() { }

	public InputAction FindAction(Guid id) { }

	public override InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false) { }

	internal int FindActionIndex(string nameOrId) { }

	private int FindActionIndex(Guid id) { }

	public override int FindBinding(InputBinding mask, out InputAction action) { }

	internal int FindBindingRelativeToMap(InputBinding mask) { }

	public static InputActionMap[] FromJson(string json) { }

	internal void GenerateId() { }

	public ReadOnlyArray<InputAction> get_actions() { }

	public InputActionAsset get_asset() { }

	public override Nullable<InputBinding> get_bindingMask() { }

	private bool get_bindingResolutionNeedsFullReResolve() { }

	public ReadOnlyArray<InputBinding> get_bindings() { }

	private bool get_bindingsForEachActionInitialized() { }

	public override ReadOnlyArray<InputControlScheme> get_controlSchemes() { }

	private bool get_controlsForEachActionInitialized() { }

	public override Nullable<ReadOnlyArray`1<InputDevice>> get_devices() { }

	public bool get_enabled() { }

	public Guid get_id() { }

	internal Guid get_idDontGenerate() { }

	public InputAction get_Item(string actionNameOrId) { }

	public string get_name() { }

	private bool get_needToResolveBindings() { }

	internal ReadOnlyArray<InputBinding> GetBindingsForSingleAction(InputAction action) { }

	internal ReadOnlyArray<InputControl> GetControlsForSingleAction(InputAction action) { }

	public override IEnumerator<InputAction> GetEnumerator() { }

	public bool IsUsableWithDevice(InputDevice device) { }

	internal bool LazyResolveBindings(bool fullResolve) { }

	public override void OnAfterDeserialize() { }

	public override void OnBeforeSerialize() { }

	internal void OnBindingModified() { }

	internal void OnSetupChanged() { }

	internal void OnWantToChangeSetup() { }

	public void remove_actionTriggered(Action<CallbackContext> value) { }

	internal void ResolveBindings() { }

	internal bool ResolveBindingsIfNecessary() { }

	public override void set_bindingMask(Nullable<InputBinding> value) { }

	private void set_bindingResolutionNeedsFullReResolve(bool value) { }

	private void set_bindingsForEachActionInitialized(bool value) { }

	private void set_controlsForEachActionInitialized(bool value) { }

	public override void set_devices(Nullable<ReadOnlyArray`1<InputDevice>> value) { }

	private void set_needToResolveBindings(bool value) { }

	private void SetUpActionLookupTable() { }

	private void SetUpPerActionControlAndBindingArrays() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private override object System.ICloneable.Clone() { }

	public static string ToJson(IEnumerable<InputActionMap> maps) { }

	public string ToJson() { }

	public virtual string ToString() { }

	private override IEnumerable<InputBinding> UnityEngine.InputSystem.IInputActionCollection2.get_bindings() { }

}

