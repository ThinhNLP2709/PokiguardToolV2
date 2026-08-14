namespace UnityEngine;

[NativeHeader("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
[StaticAccessor("AudioClipBindings", StaticAccessorType::DoubleColon (2))]
public sealed class AudioClip : AudioResource
{
	internal sealed class PCMReaderCallback : MulticastDelegate
	{

		public PCMReaderCallback(object object, IntPtr method) { }

		public override void Invoke(Single[] data) { }

	}

	internal sealed class PCMSetPositionCallback : MulticastDelegate
	{

		public PCMSetPositionCallback(object object, IntPtr method) { }

		public override void Invoke(int position) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private PCMReaderCallback m_PCMReaderCallback; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private PCMSetPositionCallback m_PCMSetPositionCallback; //Field offset: 0x20

	private event PCMReaderCallback m_PCMReaderCallback
	{
		[CompilerGenerated]
		private add { } //Length: 158
		[CompilerGenerated]
		private remove { } //Length: 158
	}

	private event PCMSetPositionCallback m_PCMSetPositionCallback
	{
		[CompilerGenerated]
		private add { } //Length: 158
		[CompilerGenerated]
		private remove { } //Length: 158
	}

	[NativeProperty("ChannelCount")]
	public int channels
	{
		 get { } //Length: 118
	}

	[NativeProperty("LengthSec")]
	public float length
	{
		 get { } //Length: 118
	}

	[NativeProperty("SampleCount")]
	public int samples
	{
		 get { } //Length: 118
	}

	[CompilerGenerated]
	private void add_m_PCMReaderCallback(PCMReaderCallback value) { }

	[CompilerGenerated]
	private void add_m_PCMSetPositionCallback(PCMSetPositionCallback value) { }

	private static AudioClip Construct_Internal() { }

	private static IntPtr Construct_Internal_Injected() { }

	public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback) { }

	public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream) { }

	private void CreateUserSound(string name, int lengthSamples, int channels, int frequency, bool stream) { }

	private static void CreateUserSound_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, int lengthSamples, int channels, int frequency, bool stream) { }

	public int get_channels() { }

	private static int get_channels_Injected(IntPtr _unity_self) { }

	public float get_length() { }

	private static float get_length_Injected(IntPtr _unity_self) { }

	public int get_samples() { }

	private static int get_samples_Injected(IntPtr _unity_self) { }

	public bool GetData(Single[] data, int offsetSamples) { }

	private static bool GetData(AudioClip clip, Span<Single> data, int samplesOffset) { }

	private static bool GetData_Injected(IntPtr clip, ref ManagedSpanWrapper data, int samplesOffset) { }

	private string GetName() { }

	private static void GetName_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret) { }

	[RequiredByNativeCode]
	private void InvokePCMReaderCallback_Internal(Single[] data) { }

	[RequiredByNativeCode]
	private void InvokePCMSetPositionCallback_Internal(int position) { }

	[CompilerGenerated]
	private void remove_m_PCMReaderCallback(PCMReaderCallback value) { }

	[CompilerGenerated]
	private void remove_m_PCMSetPositionCallback(PCMSetPositionCallback value) { }

	private static bool SetData(AudioClip clip, ReadOnlySpan<Single> data, int samplesOffset) { }

	public bool SetData(Single[] data, int offsetSamples) { }

	private static bool SetData_Injected(IntPtr clip, ref ManagedSpanWrapper data, int samplesOffset) { }

}

