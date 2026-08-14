namespace UnityEngine.SubsystemsImplementation;

public class SubsystemDescriptorWithProvider : SubsystemDescriptorWithProvider
{

	public SubsystemDescriptorWithProvider`2() { }

	public TSubsystem Create() { }

	internal virtual ISubsystem CreateImpl() { }

	internal TProvider CreateProvider() { }

	internal virtual void ThrowIfInvalid() { }

}

