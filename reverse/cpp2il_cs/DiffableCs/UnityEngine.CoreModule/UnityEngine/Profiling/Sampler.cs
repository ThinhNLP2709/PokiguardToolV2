namespace UnityEngine.Profiling;

[NativeHeader("Runtime/Profiler/ScriptBindings/Sampler.bindings.h")]
[UsedByNativeCode]
public class Sampler
{
	internal static Sampler s_InvalidSampler; //Field offset: 0x0
	internal IntPtr m_Ptr; //Field offset: 0x10

	public bool isValid
	{
		 get { } //Length: 11
	}

	private static Sampler() { }

	internal Sampler() { }

	internal Sampler(IntPtr ptr) { }

	public bool get_isValid() { }

	public Recorder GetRecorder() { }

}

