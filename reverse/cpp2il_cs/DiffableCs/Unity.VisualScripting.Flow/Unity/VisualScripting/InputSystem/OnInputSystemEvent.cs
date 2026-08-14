namespace Unity.VisualScripting.InputSystem;

[UnitCategory("Events/Input")]
public abstract class OnInputSystemEvent : MachineEventUnit<EmptyEventArgs>
{
	private class Data : Data<EmptyEventArgs>
	{
		internal InputAction Action; //Field offset: 0x40

		public Data() { }

	}

	[Inspectable]
	[Serialize]
	[UnitHeaderInspectable]
	public InputActionChangeOption InputActionChangeType; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <InputAction>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <Target>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <FloatValue>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <Vector2Value>k__BackingField; //Field offset: 0xC0
	private Vector2 m_Value; //Field offset: 0xC8

	[PortLabelHidden]
	public private ValueOutput FloatValue
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected virtual string hookName
	{
		 get { } //Length: 121
	}

	[DoNotSerialize]
	public private ValueInput InputAction
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected abstract OutputType OutputType
	{
		 get { } //Length: 0
	}

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public private ValueInput Target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[PortLabelHidden]
	public private ValueOutput Vector2Value
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected OnInputSystemEvent() { }

	[CompilerGenerated]
	private float <Definition>b__24_0(Flow _) { }

	[CompilerGenerated]
	private Vector2 <Definition>b__24_1(Flow _) { }

	public virtual IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	private void DoAssignArguments(Flow flow, Data data) { }

	[CompilerGenerated]
	public ValueOutput get_FloatValue() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueInput get_InputAction() { }

	protected abstract OutputType get_OutputType() { }

	[CompilerGenerated]
	public ValueInput get_Target() { }

	[CompilerGenerated]
	public ValueOutput get_Vector2Value() { }

	[CompilerGenerated]
	private void set_FloatValue(ValueOutput value) { }

	[CompilerGenerated]
	private void set_InputAction(ValueInput value) { }

	[CompilerGenerated]
	private void set_Target(ValueInput value) { }

	[CompilerGenerated]
	private void set_Vector2Value(ValueOutput value) { }

	protected virtual bool ShouldTrigger(Flow flow, EmptyEventArgs args) { }

	public virtual void StartListening(GraphStack stack) { }

	public virtual void StopListening(GraphStack stack) { }

}

