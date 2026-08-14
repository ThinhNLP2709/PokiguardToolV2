namespace UnityEngine;

[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
[UsedByNativeCode]
public class Behaviour : Component
{

	[NativeProperty]
	[RequiredByNativeCode]
	public bool enabled
	{
		 get { } //Length: 118
		 set { } //Length: 134
	}

	[NativeProperty]
	public bool isActiveAndEnabled
	{
		[NativeMethod("IsAddedToManager")]
		 get { } //Length: 118
	}

	public Behaviour() { }

	public bool get_enabled() { }

	private static bool get_enabled_Injected(IntPtr _unity_self) { }

	[NativeMethod("IsAddedToManager")]
	public bool get_isActiveAndEnabled() { }

	private static bool get_isActiveAndEnabled_Injected(IntPtr _unity_self) { }

	public void set_enabled(bool value) { }

	private static void set_enabled_Injected(IntPtr _unity_self, bool value) { }

}

