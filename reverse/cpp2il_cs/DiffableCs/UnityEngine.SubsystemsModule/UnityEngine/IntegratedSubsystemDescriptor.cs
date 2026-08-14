namespace UnityEngine;

[UsedByNativeCode("SubsystemDescriptorBase")]
public abstract class IntegratedSubsystemDescriptor : ISubsystemDescriptor
{
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.XRModule"})]
	internal IntPtr m_Ptr; //Field offset: 0x10

	public override string id
	{
		 get { } //Length: 11
	}

	protected IntegratedSubsystemDescriptor() { }

	internal abstract ISubsystem CreateImpl() { }

	public override string get_id() { }

	private override ISubsystem UnityEngine.ISubsystemDescriptor.Create() { }

}

