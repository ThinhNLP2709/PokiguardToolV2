namespace UnityEngine.Profiling;

[UsedByNativeCode]
public sealed class Recorder
{
	private const ProfilerRecorderOptions s_RecorderDefaultOptions = 153; //Field offset: 0x0
	internal static Recorder s_InvalidRecorder; //Field offset: 0x0
	private ProfilerRecorder m_RecorderCPU; //Field offset: 0x10
	private ProfilerRecorder m_RecorderGPU; //Field offset: 0x18

	public long elapsedNanoseconds
	{
		 get { } //Length: 48
	}

	public bool enabled
	{
		 get { } //Length: 13
		 set { } //Length: 108
	}

	public long gpuElapsedNanoseconds
	{
		 get { } //Length: 48
	}

	public int gpuSampleBlockCount
	{
		 get { } //Length: 86
	}

	public int sampleBlockCount
	{
		 get { } //Length: 86
	}

	private static Recorder() { }

	internal Recorder() { }

	internal Recorder(ProfilerRecorderHandle handle) { }

	protected virtual void Finalize() { }

	public long get_elapsedNanoseconds() { }

	public bool get_enabled() { }

	public long get_gpuElapsedNanoseconds() { }

	public int get_gpuSampleBlockCount() { }

	public int get_sampleBlockCount() { }

	public void set_enabled(bool value) { }

	private void SetEnabled(bool state) { }

}

