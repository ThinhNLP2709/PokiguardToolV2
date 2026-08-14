namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(14)]
public sealed class Once : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	internal sealed class Data : IGraphElementData
	{
		public bool executed; //Field offset: 0x10

		public Data() { }

	}

	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <reset>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <once>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlOutput <after>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private ControlOutput after
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
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
	public private ControlOutput once
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlInput reset
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Once() { }

	public override IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	public ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public ControlOutput get_after() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_once() { }

	[CompilerGenerated]
	public ControlInput get_reset() { }

	public ControlOutput Reset(Flow flow) { }

	[CompilerGenerated]
	private void set_after(ControlOutput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_once(ControlOutput value) { }

	[CompilerGenerated]
	private void set_reset(ControlInput value) { }

}

