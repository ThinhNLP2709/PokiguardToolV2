namespace UnityEngine.SubsystemsImplementation;

public abstract class SubsystemDescriptorWithProvider : ISubsystemDescriptor
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private string <id>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Type <providerType>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Type <subsystemTypeOverride>k__BackingField; //Field offset: 0x20

	public override string id
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	protected private Type providerType
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	protected private Type subsystemTypeOverride
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	protected SubsystemDescriptorWithProvider() { }

	internal abstract ISubsystem CreateImpl() { }

	[CompilerGenerated]
	public override string get_id() { }

	[CompilerGenerated]
	protected private Type get_providerType() { }

	[CompilerGenerated]
	protected private Type get_subsystemTypeOverride() { }

	[CompilerGenerated]
	public void set_id(string value) { }

	[CompilerGenerated]
	protected private void set_providerType(Type value) { }

	[CompilerGenerated]
	protected private void set_subsystemTypeOverride(Type value) { }

	internal abstract void ThrowIfInvalid() { }

	private override ISubsystem UnityEngine.ISubsystemDescriptor.Create() { }

}

