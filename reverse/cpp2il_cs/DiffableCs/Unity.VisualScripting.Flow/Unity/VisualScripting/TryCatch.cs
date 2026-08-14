namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitFooterPorts(ControlOutputs = True)]
[UnitOrder(17)]
public sealed class TryCatch : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlOutput <try>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <catch>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlOutput <finally>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <exception>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private Type <exceptionType>k__BackingField; //Field offset: 0xB8

	public virtual bool canDefine
	{
		 get { } //Length: 185
	}

	[DoNotSerialize]
	public private ControlOutput catch
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
	public private ValueOutput exception
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[Serialize]
	[TypeFilter(new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(Exception)}, Matching = TypesMatching::AssignableToAll (1))]
	[TypeSet(TypeSet::SettingsAssembliesTypes (3))]
	[UnitHeaderInspectable]
	public Type exceptionType
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlOutput finally
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlOutput try
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public TryCatch() { }

	protected virtual void Definition() { }

	public ControlOutput Enter(Flow flow) { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public ControlOutput get_catch() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ValueOutput get_exception() { }

	[CompilerGenerated]
	public Type get_exceptionType() { }

	[CompilerGenerated]
	public ControlOutput get_finally() { }

	[CompilerGenerated]
	public ControlOutput get_try() { }

	[CompilerGenerated]
	private void set_catch(ControlOutput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exception(ValueOutput value) { }

	[CompilerGenerated]
	public void set_exceptionType(Type value) { }

	[CompilerGenerated]
	private void set_finally(ControlOutput value) { }

	[CompilerGenerated]
	private void set_try(ControlOutput value) { }

}

