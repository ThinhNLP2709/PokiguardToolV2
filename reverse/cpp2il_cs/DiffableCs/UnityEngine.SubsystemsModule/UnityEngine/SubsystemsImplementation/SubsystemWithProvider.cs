namespace UnityEngine.SubsystemsImplementation;

public abstract class SubsystemWithProvider : ISubsystem
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <running>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private SubsystemProvider <providerBase>k__BackingField; //Field offset: 0x18

	internal abstract SubsystemDescriptorWithProvider descriptor
	{
		internal get { } //Length: 0
	}

	internal SubsystemProvider providerBase
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	public private override bool running
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	protected SubsystemWithProvider() { }

	public override void Destroy() { }

	internal abstract SubsystemDescriptorWithProvider get_descriptor() { }

	[CompilerGenerated]
	internal SubsystemProvider get_providerBase() { }

	[CompilerGenerated]
	public override bool get_running() { }

	internal abstract void Initialize(SubsystemDescriptorWithProvider descriptor, SubsystemProvider subsystemProvider) { }

	protected abstract void OnDestroy() { }

	protected abstract void OnStart() { }

	protected abstract void OnStop() { }

	[CompilerGenerated]
	internal void set_providerBase(SubsystemProvider value) { }

	[CompilerGenerated]
	private void set_running(bool value) { }

	public override void Start() { }

	public override void Stop() { }

}

