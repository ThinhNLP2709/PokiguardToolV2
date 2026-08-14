namespace UnityEngine.SubsystemsImplementation;

public abstract class SubsystemWithProvider : SubsystemWithProvider
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private TSubsystemDescriptor <subsystemDescriptor>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private TProvider <provider>k__BackingField; //Field offset: 0x0

	internal virtual SubsystemDescriptorWithProvider descriptor
	{
		internal get { } //Length: 5
	}

	protected private TProvider provider
	{
		[CompilerGenerated]
		private get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private TSubsystemDescriptor subsystemDescriptor
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	protected SubsystemWithProvider`3() { }

	internal virtual SubsystemDescriptorWithProvider get_descriptor() { }

	[CompilerGenerated]
	protected private TProvider get_provider() { }

	[CompilerGenerated]
	public TSubsystemDescriptor get_subsystemDescriptor() { }

	internal virtual void Initialize(SubsystemDescriptorWithProvider descriptor, SubsystemProvider provider) { }

	protected override void OnCreate() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnStart() { }

	protected virtual void OnStop() { }

	[CompilerGenerated]
	private void set_provider(TProvider value) { }

	[CompilerGenerated]
	private void set_subsystemDescriptor(TSubsystemDescriptor value) { }

}

