namespace Unity.VisualScripting;

public sealed class InvokeMember : MemberUnit
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<String, Object>, Boolean> <>9__38_0; //Field offset: 0x8
		public static Func<KeyValuePair`2<String, Object>, Boolean> <>9__38_1; //Field offset: 0x10
		public static Func<KeyValuePair`2<String, Object>, String> <>9__38_2; //Field offset: 0x18
		public static Func<ParameterInfo, String> <>9__39_0; //Field offset: 0x20
		public static Func<ValueConnection, ValueOutput> <>9__40_0; //Field offset: 0x28
		public static Func<ValueConnection, ValueInput> <>9__40_1; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal string <Definition>b__39_0(ParameterInfo pInfo) { }

		internal bool <HandleDependencies>b__38_0(KeyValuePair<String, Object> d) { }

		internal bool <HandleDependencies>b__38_1(KeyValuePair<String, Object> d) { }

		internal string <HandleDependencies>b__38_2(KeyValuePair<String, Object> defaultValue) { }

		internal ValueOutput <PostDeserializeRemapParameterNames>b__40_0(ValueConnection con) { }

		internal ValueInput <PostDeserializeRemapParameterNames>b__40_1(ValueConnection con) { }

	}

	private bool useExpandedParameters; //Field offset: 0xA0
	[CompilerGenerated]
	private bool <chainable>k__BackingField; //Field offset: 0xA1
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private Dictionary<Int32, ValueInput> <inputParameters>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <targetOutput>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <result>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private Dictionary<Int32, ValueOutput> <outputParameters>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xD0
	[DoNotSerialize]
	private int parameterCount; //Field offset: 0xD8
	[Serialize]
	private List<String> parameterNames; //Field offset: 0xE0

	[InspectableIf("supportsChaining")]
	[Serialize]
	public bool chainable
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput exit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private Dictionary<Int32, ValueInput> inputParameters
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[MemberFilter(Methods = True, Constructors = True)]
	public Member invocation
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	[DoNotSerialize]
	public private Dictionary<Int32, ValueOutput> outputParameters
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput result
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public bool supportsChaining
	{
		 get { } //Length: 32
	}

	[DoNotSerialize]
	[PortLabel("Target")]
	[PortLabelHidden]
	public private ValueOutput targetOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public InvokeMember() { }

	public InvokeMember(Member member) { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public bool get_chainable() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public Dictionary<Int32, ValueInput> get_inputParameters() { }

	public Member get_invocation() { }

	[CompilerGenerated]
	public Dictionary<Int32, ValueOutput> get_outputParameters() { }

	[CompilerGenerated]
	public ValueOutput get_result() { }

	public bool get_supportsChaining() { }

	[CompilerGenerated]
	public ValueOutput get_targetOutput() { }

	public virtual AnalyticsIdentifier GetAnalyticsIdentifier() { }

	private object GetAndChainTarget(Flow flow) { }

	public virtual bool HandleDependencies() { }

	private object Invoke(object target, Flow flow) { }

	protected virtual bool IsMemberValid(Member member) { }

	private void PostDeserializeRemapParameterNames() { }

	private object Result(Flow flow) { }

	[CompilerGenerated]
	public void set_chainable(bool value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_inputParameters(Dictionary<Int32, ValueInput> value) { }

	public void set_invocation(Member value) { }

	[CompilerGenerated]
	private void set_outputParameters(Dictionary<Int32, ValueOutput> value) { }

	[CompilerGenerated]
	private void set_result(ValueOutput value) { }

	[CompilerGenerated]
	private void set_targetOutput(ValueOutput value) { }

}

