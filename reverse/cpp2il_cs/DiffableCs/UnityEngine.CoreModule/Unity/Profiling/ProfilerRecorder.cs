namespace Unity.Profiling;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(ProfilerRecorderDebugView))]
[NativeHeader("Runtime/Profiler/ScriptBindings/ProfilerRecorder.bindings.h")]
[UsedByNativeCode]
public struct ProfilerRecorder : IDisposable
{
	public enum ControlOptions
	{
		Start = 0,
		Stop = 1,
		Reset = 2,
		Release = 4,
		SetFilterToCurrentThread = 5,
		SetToCollectFromAllThreads = 6,
	}

	public enum CountOptions
	{
		Count = 0,
		MaxCount = 1,
	}

	internal const ProfilerRecorderOptions SharedRecorder = 128; //Field offset: 0x0
	internal ulong handle; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 145
	}

	public bool IsRunning
	{
		 get { } //Length: 143
	}

	public long LastValue
	{
		 get { } //Length: 143
	}

	public bool Valid
	{
		 get { } //Length: 81
	}

	public ProfilerRecorder(ProfilerRecorderHandle statHandle, int capacity = 1, ProfilerRecorderOptions options = 24) { }

	[BurstDiscard]
	private void CheckInitializedAndThrow() { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	private static void Control(ProfilerRecorder handle, ControlOptions options) { }

	private static void Control_Injected(in ProfilerRecorder handle, ControlOptions options) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	private static ProfilerRecorder Create(ProfilerRecorderHandle statHandle, int maxSampleCount, ProfilerRecorderOptions options) { }

	private static void Create_Injected(in ProfilerRecorderHandle statHandle, int maxSampleCount, ProfilerRecorderOptions options, out ProfilerRecorder ret) { }

	public override void Dispose() { }

	public int get_Count() { }

	public bool get_IsRunning() { }

	public long get_LastValue() { }

	public bool get_Valid() { }

	[NativeMethod(IsThreadSafe = True)]
	private static int GetCount(ProfilerRecorder handle, CountOptions countOptions) { }

	private static int GetCount_Injected(in ProfilerRecorder handle, CountOptions countOptions) { }

	[NativeMethod(IsThreadSafe = True)]
	private static long GetLastValue(ProfilerRecorder handle) { }

	private static long GetLastValue_Injected(in ProfilerRecorder handle) { }

	[NativeMethod(IsThreadSafe = True)]
	private static bool GetRunning(ProfilerRecorder handle) { }

	private static bool GetRunning_Injected(in ProfilerRecorder handle) { }

	public ProfilerRecorderSample GetSample(int index) { }

	[NativeMethod(IsThreadSafe = True, ThrowsException = True)]
	private static ProfilerRecorderSample GetSampleInternal(ProfilerRecorder handle, int index) { }

	private static void GetSampleInternal_Injected(in ProfilerRecorder handle, int index, out ProfilerRecorderSample ret) { }

	[NativeMethod(IsThreadSafe = True)]
	private static bool GetValid(ProfilerRecorder handle) { }

	private static bool GetValid_Injected(in ProfilerRecorder handle) { }

	public void Start() { }

	public void Stop() { }

}

