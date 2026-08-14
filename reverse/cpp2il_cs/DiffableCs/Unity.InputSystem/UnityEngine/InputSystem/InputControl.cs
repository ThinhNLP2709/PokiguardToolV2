namespace UnityEngine.InputSystem;

[DebuggerDisplay("{DebuggerDisplay(),nq}")]
[DefaultMember("Item")]
public abstract class InputControl
{
	[Flags]
	public enum ControlFlags
	{
		ConfigUpToDate = 1,
		IsNoisy = 2,
		IsSynthetic = 4,
		IsButton = 8,
		DontReset = 16,
		SetupFinished = 32,
		UsesStateFromOtherControl = 64,
	}

	protected private InputStateBlock m_StateBlock; //Field offset: 0x10
	internal InternedString m_Name; //Field offset: 0x20
	internal string m_Path; //Field offset: 0x30
	internal string m_DisplayName; //Field offset: 0x38
	internal string m_DisplayNameFromLayout; //Field offset: 0x40
	internal string m_ShortDisplayName; //Field offset: 0x48
	internal string m_ShortDisplayNameFromLayout; //Field offset: 0x50
	internal InternedString m_Layout; //Field offset: 0x58
	internal InternedString m_Variants; //Field offset: 0x68
	internal InputDevice m_Device; //Field offset: 0x78
	internal InputControl m_Parent; //Field offset: 0x80
	internal int m_UsageCount; //Field offset: 0x88
	internal int m_UsageStartIndex; //Field offset: 0x8C
	internal int m_AliasCount; //Field offset: 0x90
	internal int m_AliasStartIndex; //Field offset: 0x94
	internal int m_ChildCount; //Field offset: 0x98
	internal int m_ChildStartIndex; //Field offset: 0x9C
	internal ControlFlags m_ControlFlags; //Field offset: 0xA0
	internal bool m_CachedValueIsStale; //Field offset: 0xA4
	internal bool m_UnprocessedCachedValueIsStale; //Field offset: 0xA5
	internal PrimitiveValue m_DefaultState; //Field offset: 0xA8
	internal PrimitiveValue m_MinValue; //Field offset: 0xB8
	internal PrimitiveValue m_MaxValue; //Field offset: 0xC8
	internal FourCC m_OptimizedControlDataType; //Field offset: 0xD8

	public ReadOnlyArray<InternedString> aliases
	{
		 get { } //Length: 119
	}

	public ReadOnlyArray<InputControl> children
	{
		 get { } //Length: 119
	}

	protected private Void* currentStatePtr
	{
		private get { } //Length: 24
	}

	protected private Void* defaultStatePtr
	{
		private get { } //Length: 54
	}

	public InputDevice device
	{
		 get { } //Length: 5
	}

	public string displayName
	{
		 get { } //Length: 105
		 set { } //Length: 13
	}

	internal bool dontReset
	{
		internal get { } //Length: 12
		internal set { } //Length: 31
	}

	internal bool hasDefaultState
	{
		internal get { } //Length: 25
	}

	internal bool isButton
	{
		internal get { } //Length: 12
		internal set { } //Length: 31
	}

	internal bool isConfigUpToDate
	{
		internal get { } //Length: 10
		internal set { } //Length: 31
	}

	internal bool isSetupFinished
	{
		internal get { } //Length: 12
		internal set { } //Length: 31
	}

	public InputControl Item
	{
		 get { } //Length: 173
	}

	public string layout
	{
		 get { } //Length: 30
	}

	public float magnitude
	{
		 get { } //Length: 56
	}

	public string name
	{
		 get { } //Length: 30
	}

	protected private Void* noiseMaskPtr
	{
		private get { } //Length: 55
	}

	public internal bool noisy
	{
		 get { } //Length: 11
		internal set { } //Length: 315
	}

	public FourCC optimizedControlDataType
	{
		 get { } //Length: 7
	}

	public InputControl parent
	{
		 get { } //Length: 8
	}

	public string path
	{
		 get { } //Length: 262
	}

	protected private Void* previousFrameStatePtr
	{
		private get { } //Length: 24
	}

	public string shortDisplayName
	{
		 get { } //Length: 86
		 set { } //Length: 13
	}

	public InputStateBlock stateBlock
	{
		 get { } //Length: 11
	}

	protected private uint stateOffsetRelativeToDeviceRoot
	{
		private get { } //Length: 93
	}

	public internal bool synthetic
	{
		 get { } //Length: 11
		internal set { } //Length: 31
	}

	public ReadOnlyArray<InternedString> usages
	{
		 get { } //Length: 119
	}

	internal bool usesStateFromOtherControl
	{
		internal get { } //Length: 12
		internal set { } //Length: 31
	}

	public abstract int valueSizeInBytes
	{
		 get { } //Length: 0
	}

	public abstract Type valueType
	{
		 get { } //Length: 0
	}

	public string variants
	{
		 get { } //Length: 30
	}

	protected InputControl() { }

	internal override void AddProcessor(object first) { }

	public void ApplyParameterChanges() { }

	internal void BakeOffsetIntoStateBlockRecursive(uint offset) { }

	protected override FourCC CalculateOptimizedControlDataType() { }

	internal void CallFinishSetupRecursive() { }

	public abstract bool CompareValue(Void* firstStatePtr, Void* secondStatePtr) { }

	private string DebuggerDisplay() { }

	[Conditional("UNITY_EDITOR")]
	internal void EnsureOptimizationTypeHasNotChanged() { }

	public override float EvaluateMagnitude(Void* statePtr) { }

	public float EvaluateMagnitude() { }

	protected override void FinishSetup() { }

	public ReadOnlyArray<InternedString> get_aliases() { }

	public ReadOnlyArray<InputControl> get_children() { }

	protected private Void* get_currentStatePtr() { }

	protected private Void* get_defaultStatePtr() { }

	public InputDevice get_device() { }

	public string get_displayName() { }

	internal bool get_dontReset() { }

	internal bool get_hasDefaultState() { }

	internal bool get_isButton() { }

	internal bool get_isConfigUpToDate() { }

	internal bool get_isSetupFinished() { }

	public InputControl get_Item(string path) { }

	public string get_layout() { }

	public float get_magnitude() { }

	public string get_name() { }

	protected private Void* get_noiseMaskPtr() { }

	public bool get_noisy() { }

	public FourCC get_optimizedControlDataType() { }

	public InputControl get_parent() { }

	public string get_path() { }

	protected private Void* get_previousFrameStatePtr() { }

	public string get_shortDisplayName() { }

	public InputStateBlock get_stateBlock() { }

	protected private uint get_stateOffsetRelativeToDeviceRoot() { }

	public bool get_synthetic() { }

	public ReadOnlyArray<InternedString> get_usages() { }

	internal bool get_usesStateFromOtherControl() { }

	public abstract int get_valueSizeInBytes() { }

	public abstract Type get_valueType() { }

	public string get_variants() { }

	public InputControl GetChildControl(string path) { }

	public TControl GetChildControl(string path) { }

	internal int GetDeviceIndex() { }

	internal bool IsValueConsideredPressed(float value) { }

	internal string MakeChildPath(string path) { }

	internal void MarkAsStale() { }

	internal void MarkAsStaleRecursively() { }

	public abstract object ReadValueFromBufferAsObject(Void* buffer, int bufferSize) { }

	public abstract object ReadValueFromStateAsObject(Void* statePtr) { }

	public abstract void ReadValueFromStateIntoBuffer(Void* statePtr, Void* bufferPtr, int bufferSize) { }

	protected override void RefreshConfiguration() { }

	protected void RefreshConfigurationIfNeeded() { }

	protected void set_displayName(string value) { }

	internal void set_dontReset(bool value) { }

	internal void set_isButton(bool value) { }

	internal void set_isConfigUpToDate(bool value) { }

	internal void set_isSetupFinished(bool value) { }

	internal void set_noisy(bool value) { }

	protected void set_shortDisplayName(string value) { }

	internal void set_synthetic(bool value) { }

	internal void set_usesStateFromOtherControl(bool value) { }

	private void SetOptimizedControlDataType() { }

	internal void SetOptimizedControlDataTypeRecursively() { }

	public virtual string ToString() { }

	public InputControl TryGetChildControl(string path) { }

	public TControl TryGetChildControl(string path) { }

	public override void WriteValueFromBufferIntoState(Void* bufferPtr, int bufferSize, Void* statePtr) { }

	public override void WriteValueFromObjectIntoState(object value, Void* statePtr) { }

}

