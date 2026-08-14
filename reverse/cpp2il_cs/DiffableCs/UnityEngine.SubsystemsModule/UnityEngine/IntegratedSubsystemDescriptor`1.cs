namespace UnityEngine;

[NativeHeader("Modules/Subsystems/SubsystemDescriptor.h")]
[UsedByNativeCode("SubsystemDescriptor")]
public class IntegratedSubsystemDescriptor : IntegratedSubsystemDescriptor
{

	public IntegratedSubsystemDescriptor`1() { }

	public TSubsystem Create() { }

	internal virtual ISubsystem CreateImpl() { }

}

