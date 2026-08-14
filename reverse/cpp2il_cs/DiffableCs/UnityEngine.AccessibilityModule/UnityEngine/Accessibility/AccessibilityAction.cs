namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityAction.h")]
[RequiredByNativeCode]
internal sealed class AccessibilityAction : IDisposable
{
	private IntPtr m_Ptr; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Func<Boolean> <activated>k__BackingField; //Field offset: 0x18

	public Func<Boolean> activated
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public override void Dispose() { }

	private void Dispose(bool disposing) { }

	[CompilerGenerated]
	public Func<Boolean> get_activated() { }

	private static void Internal_Destroy(IntPtr ptr) { }

	[RequiredByNativeCode]
	private bool Internal_InvokeActivated() { }

}

