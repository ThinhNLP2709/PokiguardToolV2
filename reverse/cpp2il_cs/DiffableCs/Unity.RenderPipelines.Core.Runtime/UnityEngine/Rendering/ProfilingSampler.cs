namespace UnityEngine.Rendering;

[IgnoredByDeepProfiler]
public class ProfilingSampler
{
	[CompilerGenerated]
	private CustomSampler <sampler>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private CustomSampler <inlineSampler>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <name>k__BackingField; //Field offset: 0x20
	private Recorder m_Recorder; //Field offset: 0x28
	private Recorder m_InlineRecorder; //Field offset: 0x30

	public float cpuElapsedTime
	{
		 get { } //Length: 81
	}

	public int cpuSampleCount
	{
		 get { } //Length: 63
	}

	public bool enableRecording
	{
		 set { } //Length: 68
	}

	public float gpuElapsedTime
	{
		 get { } //Length: 81
	}

	public int gpuSampleCount
	{
		 get { } //Length: 63
	}

	public float inlineCpuElapsedTime
	{
		 get { } //Length: 81
	}

	public int inlineCpuSampleCount
	{
		 get { } //Length: 63
	}

	internal CustomSampler inlineSampler
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string name
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	internal CustomSampler sampler
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	private ProfilingSampler() { }

	public ProfilingSampler(string name) { }

	public void Begin(CommandBuffer cmd) { }

	public void End(CommandBuffer cmd) { }

	public static ProfilingSampler Get(TEnum marker) { }

	public float get_cpuElapsedTime() { }

	public int get_cpuSampleCount() { }

	public float get_gpuElapsedTime() { }

	public int get_gpuSampleCount() { }

	public float get_inlineCpuElapsedTime() { }

	public int get_inlineCpuSampleCount() { }

	[CompilerGenerated]
	internal CustomSampler get_inlineSampler() { }

	[CompilerGenerated]
	public string get_name() { }

	[CompilerGenerated]
	internal CustomSampler get_sampler() { }

	internal bool IsValid() { }

	public void set_enableRecording(bool value) { }

	[CompilerGenerated]
	private void set_inlineSampler(CustomSampler value) { }

	[CompilerGenerated]
	private void set_name(string value) { }

	[CompilerGenerated]
	private void set_sampler(CustomSampler value) { }

}

