namespace UnityEngine;

[NativeHeader("Runtime/Camera/ReflectionProbes.h")]
public sealed class ReflectionProbe : Behaviour
{
	internal enum ReflectionProbeEvent
	{
		ReflectionProbeAdded = 0,
		ReflectionProbeRemoved = 1,
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<ReflectionProbe, ReflectionProbeEvent> reflectionProbeChanged; //Field offset: 0x0
	private static Dictionary<Int32, Action`1<Texture>> registeredDefaultReflectionSetActions; //Field offset: 0x8
	private static List<Action`1<Texture>> registeredDefaultReflectionTextureActions; //Field offset: 0x10

	[StaticAccessor("GetReflectionProbes()")]
	public static Texture defaultTexture
	{
		 get { } //Length: 117
	}

	[StaticAccessor("GetReflectionProbes()")]
	public static Vector4 defaultTextureHDRDecodeValues
	{
		 get { } //Length: 109
	}

	public ReflectionProbeRefreshMode refreshMode
	{
		 get { } //Length: 151
	}

	private static ReflectionProbe() { }

	[RequiredByNativeCode]
	private static void CallReflectionProbeEvent(ReflectionProbe probe, ReflectionProbeEvent probeEvent) { }

	[RequiredByNativeCode]
	private static void CallSetDefaultReflection(Texture defaultReflectionCubemap) { }

	public static Texture get_defaultTexture() { }

	private static IntPtr get_defaultTexture_Injected() { }

	public static Vector4 get_defaultTextureHDRDecodeValues() { }

	private static void get_defaultTextureHDRDecodeValues_Injected(out Vector4 ret) { }

	public ReflectionProbeRefreshMode get_refreshMode() { }

	private static ReflectionProbeRefreshMode get_refreshMode_Injected(IntPtr _unity_self) { }

}

