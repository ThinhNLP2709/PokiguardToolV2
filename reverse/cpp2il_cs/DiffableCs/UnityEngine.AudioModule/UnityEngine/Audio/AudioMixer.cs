namespace UnityEngine.Audio;

[ExcludeFromObjectFactory]
[ExcludeFromPreset]
[NativeHeader("Modules/Audio/Public/AudioMixer.h")]
[NativeHeader("Modules/Audio/Public/ScriptBindings/AudioMixer.bindings.h")]
public class AudioMixer : object
{

	[NativeMethod]
	public bool GetFloat(string name, out float value) { }

	private static bool GetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, out float value) { }

	[NativeMethod]
	public bool SetFloat(string name, float value) { }

	private static bool SetFloat_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value) { }

}

