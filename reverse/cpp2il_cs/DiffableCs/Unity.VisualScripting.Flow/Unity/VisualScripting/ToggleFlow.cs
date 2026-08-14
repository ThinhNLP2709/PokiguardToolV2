namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitFooterPorts(ControlInputs = True, ControlOutputs = True)]
[UnitOrder(18)]
public sealed class ToggleFlow : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	internal class Data : IGraphElementData
	{
		public bool isOn; //Field offset: 0x10

		public Data() { }

	}

	[CompilerGenerated]
	private bool <startOn>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlInput <turnOn>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlInput <turnOff>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ControlInput <toggle>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ControlOutput <exitOn>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ControlOutput <exitOff>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ControlOutput <turnedOn>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ControlOutput <turnedOff>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	private ValueOutput <isOn>k__BackingField; //Field offset: 0xD8

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
	[PortLabel("Off")]
	public private ControlOutput exitOff
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("On")]
	public private ControlOutput exitOn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput isOn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Start On")]
	public bool startOn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	public private ControlInput toggle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlOutput turnedOff
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlOutput turnedOn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Off")]
	public private ControlInput turnOff
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("On")]
	public private ControlInput turnOn
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public ToggleFlow() { }

	public override IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exitOff() { }

	[CompilerGenerated]
	public ControlOutput get_exitOn() { }

	[CompilerGenerated]
	public ValueOutput get_isOn() { }

	[CompilerGenerated]
	public bool get_startOn() { }

	[CompilerGenerated]
	public ControlInput get_toggle() { }

	[CompilerGenerated]
	public ControlOutput get_turnedOff() { }

	[CompilerGenerated]
	public ControlOutput get_turnedOn() { }

	[CompilerGenerated]
	public ControlInput get_turnOff() { }

	[CompilerGenerated]
	public ControlInput get_turnOn() { }

	private bool IsOn(Flow flow) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exitOff(ControlOutput value) { }

	[CompilerGenerated]
	private void set_exitOn(ControlOutput value) { }

	[CompilerGenerated]
	private void set_isOn(ValueOutput value) { }

	[CompilerGenerated]
	public void set_startOn(bool value) { }

	[CompilerGenerated]
	private void set_toggle(ControlInput value) { }

	[CompilerGenerated]
	private void set_turnedOff(ControlOutput value) { }

	[CompilerGenerated]
	private void set_turnedOn(ControlOutput value) { }

	[CompilerGenerated]
	private void set_turnOff(ControlInput value) { }

	[CompilerGenerated]
	private void set_turnOn(ControlInput value) { }

	private ControlOutput Toggle(Flow flow) { }

	private ControlOutput TurnOff(Flow flow) { }

	private ControlOutput TurnOn(Flow flow) { }

}

