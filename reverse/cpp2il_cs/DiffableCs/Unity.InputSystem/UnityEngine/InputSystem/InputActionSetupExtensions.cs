namespace UnityEngine.InputSystem;

[Extension]
public static class InputActionSetupExtensions
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public InputBinding binding; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <RemoveAction>b__0(InputBinding b) { }

	}

	internal struct BindingSyntax
	{
		private readonly InputActionMap m_ActionMap; //Field offset: 0x0
		private readonly InputAction m_Action; //Field offset: 0x8
		internal readonly int m_BindingIndexInMap; //Field offset: 0x10

		public InputBinding binding
		{
			 get { } //Length: 295
		}

		public int bindingIndex
		{
			 get { } //Length: 132
		}

		public bool valid
		{
			 get { } //Length: 100
		}

		internal BindingSyntax(InputActionMap map, int bindingIndexInMap, InputAction action = null) { }

		public void Erase() { }

		public InputBinding get_binding() { }

		public int get_bindingIndex() { }

		public bool get_valid() { }

		public BindingSyntax InsertPartBinding(string partName, string path) { }

		private BindingSyntax Iterate(bool next) { }

		private BindingSyntax IterateCompositeBinding(bool next, string compositeName) { }

		private BindingSyntax IteratePartBinding(bool next, string partName) { }

		public BindingSyntax NextBinding() { }

		public BindingSyntax NextCompositeBinding(string compositeName = null) { }

		public BindingSyntax NextPartBinding(string partName) { }

		public BindingSyntax PreviousBinding() { }

		public BindingSyntax PreviousCompositeBinding(string compositeName = null) { }

		public BindingSyntax PreviousPartBinding(string partName) { }

		public BindingSyntax To(InputBinding binding) { }

		public BindingSyntax Triggering(InputAction action) { }

		public BindingSyntax WithGroup(string group) { }

		public BindingSyntax WithGroups(string groups) { }

		public BindingSyntax WithInteraction() { }

		public BindingSyntax WithInteraction(string interaction) { }

		public BindingSyntax WithInteractions(string interactions) { }

		public BindingSyntax WithName(string name) { }

		public BindingSyntax WithPath(string path) { }

		public BindingSyntax WithProcessor(string processor) { }

		public BindingSyntax WithProcessor() { }

		public BindingSyntax WithProcessors(string processors) { }

	}

	internal struct CompositeSyntax
	{
		private readonly InputAction m_Action; //Field offset: 0x0
		private readonly InputActionMap m_ActionMap; //Field offset: 0x8
		private int m_BindingIndexInMap; //Field offset: 0x10

		public int bindingIndex
		{
			 get { } //Length: 37
		}

		internal CompositeSyntax(InputActionMap map, InputAction action, int compositeIndex) { }

		public int get_bindingIndex() { }

		public CompositeSyntax With(string name, string binding, string groups = null, string processors = null) { }

	}

	internal struct ControlSchemeSyntax
	{
		private readonly InputActionAsset m_Asset; //Field offset: 0x0
		private readonly int m_ControlSchemeIndex; //Field offset: 0x8
		private InputControlScheme m_ControlScheme; //Field offset: 0x10

		internal ControlSchemeSyntax(InputActionAsset asset, int index) { }

		internal ControlSchemeSyntax(InputControlScheme controlScheme) { }

		private void AddDeviceEntry(string controlPath, Flags flags) { }

		private string DeviceTypeToControlPath() { }

		public InputControlScheme Done() { }

		public ControlSchemeSyntax OrWithOptionalDevice() { }

		public ControlSchemeSyntax OrWithOptionalDevice(string controlPath) { }

		public ControlSchemeSyntax OrWithRequiredDevice() { }

		public ControlSchemeSyntax OrWithRequiredDevice(string controlPath) { }

		public ControlSchemeSyntax WithBindingGroup(string bindingGroup) { }

		public ControlSchemeSyntax WithOptionalDevice() { }

		public ControlSchemeSyntax WithOptionalDevice(string controlPath) { }

		public ControlSchemeSyntax WithRequiredDevice() { }

		public ControlSchemeSyntax WithRequiredDevice(string controlPath) { }

	}


	[Extension]
	public static InputAction AddAction(InputActionMap map, string name, InputActionType type = 0, string binding = null, string interactions = null, string processors = null, string groups = null, string expectedControlLayout = null) { }

	[Extension]
	public static InputActionMap AddActionMap(InputActionAsset asset, string name) { }

	[Extension]
	public static void AddActionMap(InputActionAsset asset, InputActionMap map) { }

	[Extension]
	public static BindingSyntax AddBinding(InputAction action, string path, string interactions = null, string processors = null, string groups = null) { }

	[Extension]
	public static BindingSyntax AddBinding(InputAction action, InputControl control) { }

	[Extension]
	public static BindingSyntax AddBinding(InputAction action, InputBinding binding = null) { }

	[Extension]
	public static BindingSyntax AddBinding(InputActionMap actionMap, string path, string interactions = null, string groups = null, string action = null, string processors = null) { }

	[Extension]
	public static BindingSyntax AddBinding(InputActionMap actionMap, string path, InputAction action, string interactions = null, string groups = null) { }

	[Extension]
	public static BindingSyntax AddBinding(InputActionMap actionMap, string path, Guid action, string interactions = null, string groups = null) { }

	[Extension]
	public static BindingSyntax AddBinding(InputActionMap actionMap, InputBinding binding) { }

	private static int AddBindingInternal(InputActionMap map, InputBinding binding, int bindingIndex = -1) { }

	[Extension]
	public static CompositeSyntax AddCompositeBinding(InputAction action, string composite, string interactions = null, string processors = null) { }

	[Extension]
	public static ControlSchemeSyntax AddControlScheme(InputActionAsset asset, string name) { }

	[Extension]
	public static void AddControlScheme(InputActionAsset asset, InputControlScheme controlScheme) { }

	[Extension]
	public static BindingSyntax ChangeBinding(InputAction action, InputBinding match) { }

	[Extension]
	public static BindingSyntax ChangeBinding(InputActionMap actionMap, int index) { }

	[Extension]
	public static BindingSyntax ChangeBinding(InputAction action, string name) { }

	[Extension]
	public static BindingSyntax ChangeBinding(InputAction action, int index) { }

	[Extension]
	public static BindingSyntax ChangeBindingWithGroup(InputAction action, string group) { }

	[Extension]
	public static BindingSyntax ChangeBindingWithId(InputAction action, string id) { }

	[Extension]
	public static BindingSyntax ChangeBindingWithId(InputAction action, Guid id) { }

	[Extension]
	public static BindingSyntax ChangeBindingWithPath(InputAction action, string path) { }

	[Extension]
	public static BindingSyntax ChangeCompositeBinding(InputAction action, string compositeName) { }

	[Extension]
	public static InputControlScheme OrWithOptionalDevice(InputControlScheme scheme, string controlPath) { }

	[Extension]
	public static InputControlScheme OrWithRequiredDevice(InputControlScheme scheme, string controlPath) { }

	[Extension]
	public static void RemoveAction(InputActionAsset asset, string nameOrId) { }

	[Extension]
	public static void RemoveAction(InputAction action) { }

	[Extension]
	public static void RemoveActionMap(InputActionAsset asset, string nameOrId) { }

	[Extension]
	public static void RemoveActionMap(InputActionAsset asset, InputActionMap map) { }

	[Extension]
	public static void RemoveControlScheme(InputActionAsset asset, string name) { }

	[Extension]
	public static void Rename(InputAction action, string newName) { }

	[Extension]
	public static InputControlScheme WithBindingGroup(InputControlScheme scheme, string bindingGroup) { }

	[Extension]
	public static InputControlScheme WithDevice(InputControlScheme scheme, string controlPath, bool required) { }

	[Extension]
	public static InputControlScheme WithOptionalDevice(InputControlScheme scheme, string controlPath) { }

	[Extension]
	public static InputControlScheme WithRequiredDevice(InputControlScheme scheme, string controlPath) { }

}

