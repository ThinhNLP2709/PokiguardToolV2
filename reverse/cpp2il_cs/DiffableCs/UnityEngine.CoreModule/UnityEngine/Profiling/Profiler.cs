namespace UnityEngine.Profiling;

[MovedFrom("UnityEngine")]
[NativeHeader("Runtime/Profiler/MemoryProfiler.h")]
[NativeHeader("Runtime/Profiler/ScriptBindings/Profiler.bindings.h")]
[NativeHeader("Runtime/Utilities/MemoryUtilities.h")]
[NativeHeader("Runtime/ScriptingBackend/ScriptingApi.h")]
[NativeHeader("Runtime/Allocator/MemoryManager.h")]
[NativeHeader("Runtime/Profiler/Profiler.h")]
[UsedByNativeCode]
public sealed class Profiler
{

	public static bool enabled
	{
		[NativeConditional("ENABLE_PROFILER")]
		[NativeMethod(Name = "profiler_is_enabled", IsFreeFunction = True, IsThreadSafe = True)]
		 get { } //Length: 42
	}

	[NativeConditional("ENABLE_PROFILER")]
	[NativeMethod(Name = "profiler_is_enabled", IsFreeFunction = True, IsThreadSafe = True)]
	public static bool get_enabled() { }

	[NativeMethod(Name = "ProfilerBindings::GetRuntimeMemorySizeLong", IsFreeFunction = True)]
	public static long GetRuntimeMemorySizeLong(object o) { }

	private static long GetRuntimeMemorySizeLong_Injected(IntPtr o) { }

}

