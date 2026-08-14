namespace UnityEngine.InputSystem;

public struct InputBinding : IEquatable<InputBinding>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, Boolean> <>9__45_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <MaskByGroups>b__45_0(string x) { }

	}

	[Flags]
	internal enum DisplayStringOptions
	{
		DontUseShortDisplayNames = 1,
		DontOmitDevice = 2,
		DontIncludeInteractions = 4,
		IgnoreBindingOverrides = 8,
	}

	[Flags]
	public enum Flags
	{
		None = 0,
		Composite = 4,
		PartOfComposite = 8,
	}

	[Flags]
	public enum MatchOptions
	{
		EmptyGroupMatchesAny = 1,
	}

	public const char Separator = '\u3B'; //Field offset: 0x0
	internal const string kSeparatorString = ";"; //Field offset: 0x0
	[SerializeField]
	private string m_Name; //Field offset: 0x0
	[SerializeField]
	internal string m_Id; //Field offset: 0x8
	[SerializeField]
	[Tooltip("Path of the control to bind to. Matched at runtime to controls from InputDevices present at the time.\n\nCan either be graphically from the control picker dropdown UI or edited manually in text mode by clicking the 'T' button. Internally, both methods result in control path strings that look like, for example, \"<Gamepad>/buttonSouth\".")]
	private string m_Path; //Field offset: 0x10
	[SerializeField]
	private string m_Interactions; //Field offset: 0x18
	[SerializeField]
	private string m_Processors; //Field offset: 0x20
	[SerializeField]
	internal string m_Groups; //Field offset: 0x28
	[SerializeField]
	private string m_Action; //Field offset: 0x30
	[SerializeField]
	internal Flags m_Flags; //Field offset: 0x38
	private string m_OverridePath; //Field offset: 0x40
	private string m_OverrideInteractions; //Field offset: 0x48
	private string m_OverrideProcessors; //Field offset: 0x50

	public string action
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string effectiveInteractions
	{
		 get { } //Length: 14
	}

	public string effectivePath
	{
		 get { } //Length: 14
	}

	public string effectiveProcessors
	{
		 get { } //Length: 14
	}

	public string groups
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool hasOverrides
	{
		 get { } //Length: 26
	}

	public Guid id
	{
		 get { } //Length: 78
		 set { } //Length: 44
	}

	public string interactions
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool isComposite
	{
		 get { } //Length: 9
		 set { } //Length: 25
	}

	internal bool isEmpty
	{
		internal get { } //Length: 72
	}

	public bool isPartOfComposite
	{
		 get { } //Length: 9
		 set { } //Length: 25
	}

	public string name
	{
		 get { } //Length: 4
		 set { } //Length: 8
	}

	public string overrideInteractions
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string overridePath
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string overrideProcessors
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string path
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public string processors
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public InputBinding(string path, string action = null, string groups = null, string processors = null, string interactions = null, string name = null) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(InputBinding other) { }

	internal void GenerateId() { }

	public string get_action() { }

	public string get_effectiveInteractions() { }

	public string get_effectivePath() { }

	public string get_effectiveProcessors() { }

	public string get_groups() { }

	public bool get_hasOverrides() { }

	public Guid get_id() { }

	public string get_interactions() { }

	public bool get_isComposite() { }

	internal bool get_isEmpty() { }

	public bool get_isPartOfComposite() { }

	public string get_name() { }

	public string get_overrideInteractions() { }

	public string get_overridePath() { }

	public string get_overrideProcessors() { }

	public string get_path() { }

	public string get_processors() { }

	public virtual int GetHashCode() { }

	public string GetNameOfComposite() { }

	public static InputBinding MaskByGroup(string group) { }

	public static InputBinding MaskByGroups(String[] groups) { }

	internal bool Matches(ref InputBinding binding, MatchOptions options = 0) { }

	public bool Matches(InputBinding binding) { }

	public static bool op_Equality(InputBinding left, InputBinding right) { }

	public static bool op_Inequality(InputBinding left, InputBinding right) { }

	internal void RemoveOverrides() { }

	public void set_action(string value) { }

	public void set_groups(string value) { }

	public void set_id(Guid value) { }

	public void set_interactions(string value) { }

	public void set_isComposite(bool value) { }

	public void set_isPartOfComposite(bool value) { }

	public void set_name(string value) { }

	public void set_overrideInteractions(string value) { }

	public void set_overridePath(string value) { }

	public void set_overrideProcessors(string value) { }

	public void set_path(string value) { }

	public void set_processors(string value) { }

	public string ToDisplayString(DisplayStringOptions options = 0, InputControl control = null) { }

	public string ToDisplayString(out string deviceLayoutName, out string controlPath, DisplayStringOptions options = 0, InputControl control = null) { }

	public virtual string ToString() { }

	internal bool TriggersAction(InputAction action) { }

}

