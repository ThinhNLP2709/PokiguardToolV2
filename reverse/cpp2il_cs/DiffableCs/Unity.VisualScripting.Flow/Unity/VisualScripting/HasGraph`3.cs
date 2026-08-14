namespace Unity.VisualScripting;

[UnitCategory("Graphs/Graph Nodes")]
public abstract class HasGraph : Unit
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TGraph, TMacro, TMachine> <>9; //Field offset: 0x0
		public static Func<TMachine, Boolean> <>9__26_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal bool <OutputHasGraph>b__26_0(TMachine currentMachine) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public TMacro macro; //Field offset: 0x0

		public <>c__DisplayClass26_0() { }

		internal bool <OutputHasGraph>b__1(TMachine currentMachine) { }

	}

	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <graphInput>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <hasGraphOutput>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0x0

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
	[PortLabel("Graph")]
	[PortLabelHidden]
	public private ValueInput graphInput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Has Graph")]
	[PortLabelHidden]
	public private ValueOutput hasGraphOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected abstract bool isGameObject
	{
		 get { } //Length: 0
	}

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public private ValueInput target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	private Type targetType
	{
		private get { } //Length: 135
	}

	protected HasGraph`3() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_graphInput() { }

	[CompilerGenerated]
	public ValueOutput get_hasGraphOutput() { }

	protected abstract bool get_isGameObject() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	private Type get_targetType() { }

	private bool OutputHasGraph(Flow flow) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_graphInput(ValueInput value) { }

	[CompilerGenerated]
	private void set_hasGraphOutput(ValueOutput value) { }

	[CompilerGenerated]
	private void set_target(ValueInput value) { }

	private ControlOutput TriggerHasGraph(Flow flow) { }

}

