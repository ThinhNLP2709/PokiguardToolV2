namespace UnityEngine.InputSystem.LowLevel;

public sealed class InputEventTrace : IDisposable, IEnumerable<InputEventPtr>, IEnumerable
{
	internal struct DeviceInfo
	{
		[SerializeField]
		internal int m_DeviceId; //Field offset: 0x0
		[SerializeField]
		internal string m_Layout; //Field offset: 0x8
		[SerializeField]
		internal FourCC m_StateFormat; //Field offset: 0x10
		[SerializeField]
		internal int m_StateSizeInBytes; //Field offset: 0x14
		[SerializeField]
		internal string m_FullLayoutJson; //Field offset: 0x18

		public int deviceId
		{
			 get { } //Length: 3
			 set { } //Length: 3
		}

		public string layout
		{
			 get { } //Length: 5
			 set { } //Length: 13
		}

		public FourCC stateFormat
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public int stateSizeInBytes
		{
			 get { } //Length: 4
			 set { } //Length: 4
		}

		public int get_deviceId() { }

		public string get_layout() { }

		public FourCC get_stateFormat() { }

		public int get_stateSizeInBytes() { }

		public void set_deviceId(int value) { }

		public void set_layout(string value) { }

		public void set_stateFormat(FourCC value) { }

		public void set_stateSizeInBytes(int value) { }

	}

	private class Enumerator : IEnumerator<InputEventPtr>, IEnumerator, IDisposable
	{
		private InputEventTrace m_Trace; //Field offset: 0x10
		private int m_ChangeCounter; //Field offset: 0x18
		internal InputEventPtr m_Current; //Field offset: 0x20

		public override InputEventPtr Current
		{
			 get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 69
		}

		public Enumerator(InputEventTrace trace) { }

		public override void Dispose() { }

		public override InputEventPtr get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[Flags]
	private enum FileFlags
	{
		FixedUpdate = 1,
	}

	internal class ReplayController : IDisposable
	{
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9; //Field offset: 0x0
			public static Comparison<InputEventPtr> <>9__38_0; //Field offset: 0x8

			private static <>c() { }

			public <>c() { }

			internal int <PlayAllEventsAccordingToTimestamps>b__38_0(InputEventPtr a, InputEventPtr b) { }

		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass43_0
		{
			public int originalDeviceId; //Field offset: 0x10

			public <>c__DisplayClass43_0() { }

			internal bool <ApplyDeviceMapping>b__0(DeviceInfo x) { }

		}

		[CompilerGenerated]
		private bool <finished>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private bool <paused>k__BackingField; //Field offset: 0x11
		[CompilerGenerated]
		private int <position>k__BackingField; //Field offset: 0x14
		private InputEventTrace m_EventTrace; //Field offset: 0x18
		private Enumerator m_Enumerator; //Field offset: 0x20
		private InlinedArray<KeyValuePair`2<Int32, Int32>> m_DeviceIDMappings; //Field offset: 0x28
		private bool m_CreateNewDevices; //Field offset: 0x40
		private InlinedArray<InputDevice> m_CreatedDevices; //Field offset: 0x48
		private Action m_OnFinished; //Field offset: 0x60
		private Action<InputEventPtr> m_OnEvent; //Field offset: 0x68
		private double m_StartTimeAsPerFirstEvent; //Field offset: 0x70
		private double m_StartTimeAsPerRuntime; //Field offset: 0x78
		private int m_AllEventsByTimeIndex; //Field offset: 0x80
		private List<InputEventPtr> m_AllEventsByTime; //Field offset: 0x88

		public IEnumerable<InputDevice> createdDevices
		{
			 get { } //Length: 80
		}

		public private bool finished
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			private set { } //Length: 4
		}

		public bool paused
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public private int position
		{
			[CompilerGenerated]
			 get { } //Length: 4
			[CompilerGenerated]
			private set { } //Length: 4
		}

		public InputEventTrace trace
		{
			 get { } //Length: 5
		}

		internal ReplayController(InputEventTrace trace) { }

		private int ApplyDeviceMapping(int originalDeviceId) { }

		public override void Dispose() { }

		private void Finished() { }

		public IEnumerable<InputDevice> get_createdDevices() { }

		[CompilerGenerated]
		public bool get_finished() { }

		[CompilerGenerated]
		public bool get_paused() { }

		[CompilerGenerated]
		public int get_position() { }

		public InputEventTrace get_trace() { }

		private bool MoveNext(bool skipFrameEvents, out InputEventPtr eventPtr) { }

		private void OnBeginFrame() { }

		public ReplayController OnEvent(Action<InputEventPtr> action) { }

		public ReplayController OnFinished(Action action) { }

		public ReplayController PlayAllEvents() { }

		public ReplayController PlayAllEventsAccordingToTimestamps() { }

		public ReplayController PlayAllFramesOneByOne() { }

		public ReplayController PlayOneEvent() { }

		private void QueueEvent(InputEventPtr eventPtr) { }

		public ReplayController Rewind() { }

		[CompilerGenerated]
		private void set_finished(bool value) { }

		[CompilerGenerated]
		public void set_paused(bool value) { }

		[CompilerGenerated]
		private void set_position(int value) { }

		public ReplayController WithAllDevicesMappedToNewInstances() { }

		public ReplayController WithDeviceMappedFromTo(InputDevice recordedDevice, InputDevice playbackDevice) { }

		public ReplayController WithDeviceMappedFromTo(int recordedDeviceId, int playbackDeviceId) { }

	}

	private const int kDefaultBufferSize = 1048576; //Field offset: 0x0
	private static readonly ProfilerMarker k_InputEvenTraceMarker; //Field offset: 0x0
	private static int kFileVersion; //Field offset: 0x8
	private int m_ChangeCounter; //Field offset: 0x10
	private bool m_Enabled; //Field offset: 0x14
	private Func<InputEventPtr, InputDevice, Boolean> m_OnFilterEvent; //Field offset: 0x18
	[SerializeField]
	private int m_DeviceId; //Field offset: 0x20
	private CallbackArray<Action`1<InputEventPtr>> m_EventListeners; //Field offset: 0x28
	[SerializeField]
	private long m_EventBufferSize; //Field offset: 0x78
	[SerializeField]
	private long m_MaxEventBufferSize; //Field offset: 0x80
	[SerializeField]
	private long m_GrowIncrementSize; //Field offset: 0x88
	[SerializeField]
	private long m_EventCount; //Field offset: 0x90
	[SerializeField]
	private long m_EventSizeInBytes; //Field offset: 0x98
	[SerializeField]
	private ulong m_EventBufferStorage; //Field offset: 0xA0
	[SerializeField]
	private ulong m_EventBufferHeadStorage; //Field offset: 0xA8
	[SerializeField]
	private ulong m_EventBufferTailStorage; //Field offset: 0xB0
	[SerializeField]
	private bool m_HasWrapped; //Field offset: 0xB8
	[SerializeField]
	private bool m_RecordFrameMarkers; //Field offset: 0xB9
	[SerializeField]
	private DeviceInfo[] m_DeviceInfos; //Field offset: 0xC0

	public event Action<InputEventPtr> onEvent
	{
		 add { } //Length: 73
		 remove { } //Length: 73
	}

	public long allocatedSizeInBytes
	{
		 get { } //Length: 18
	}

	public int deviceId
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	public ReadOnlyArray<DeviceInfo> deviceInfos
	{
		 get { } //Length: 90
	}

	public bool enabled
	{
		 get { } //Length: 5
	}

	public long eventCount
	{
		 get { } //Length: 8
	}

	public static FourCC FrameMarkerEvent
	{
		 get { } //Length: 58
	}

	private static FourCC kFileFormat
	{
		private get { } //Length: 58
	}

	private Byte* m_EventBuffer
	{
		private get { } //Length: 8
		private set { } //Length: 8
	}

	private Byte* m_EventBufferHead
	{
		private get { } //Length: 8
		private set { } //Length: 8
	}

	private Byte* m_EventBufferTail
	{
		private get { } //Length: 8
		private set { } //Length: 8
	}

	public long maxSizeInBytes
	{
		 get { } //Length: 8
	}

	public Func<InputEventPtr, InputDevice, Boolean> onFilterEvent
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public bool recordFrameMarkers
	{
		 get { } //Length: 8
		 set { } //Length: 223
	}

	public long totalEventSizeInBytes
	{
		 get { } //Length: 8
	}

	private static InputEventTrace() { }

	public InputEventTrace(long bufferSizeInBytes = 1048576, bool growBuffer = false, long maxBufferSizeInBytes = -1, long growIncrementSizeInBytes = -1) { }

	public InputEventTrace(InputDevice device, long bufferSizeInBytes = 1048576, bool growBuffer = false, long maxBufferSizeInBytes = -1, long growIncrementSizeInBytes = -1) { }

	public void add_onEvent(Action<InputEventPtr> value) { }

	private void Allocate() { }

	public void Clear() { }

	public void Disable() { }

	public override void Dispose() { }

	public void Enable() { }

	public long get_allocatedSizeInBytes() { }

	public int get_deviceId() { }

	public ReadOnlyArray<DeviceInfo> get_deviceInfos() { }

	public bool get_enabled() { }

	public long get_eventCount() { }

	public static FourCC get_FrameMarkerEvent() { }

	private static FourCC get_kFileFormat() { }

	private Byte* get_m_EventBuffer() { }

	private Byte* get_m_EventBufferHead() { }

	private Byte* get_m_EventBufferTail() { }

	public long get_maxSizeInBytes() { }

	public Func<InputEventPtr, InputDevice, Boolean> get_onFilterEvent() { }

	public bool get_recordFrameMarkers() { }

	public long get_totalEventSizeInBytes() { }

	public override IEnumerator<InputEventPtr> GetEnumerator() { }

	public bool GetNextEvent(ref InputEventPtr current) { }

	public static InputEventTrace LoadFrom(string filePath) { }

	public static InputEventTrace LoadFrom(Stream stream) { }

	private void OnBeforeUpdate() { }

	private void OnInputEvent(InputEventPtr inputEvent, InputDevice device) { }

	public void ReadFrom(Stream stream) { }

	public void ReadFrom(string filePath) { }

	private void Release() { }

	public void remove_onEvent(Action<InputEventPtr> value) { }

	public ReplayController Replay() { }

	public bool Resize(long newBufferSize, long newMaxBufferSize = -1) { }

	public void set_deviceId(int value) { }

	private void set_m_EventBuffer(Byte* value) { }

	private void set_m_EventBufferHead(Byte* value) { }

	private void set_m_EventBufferTail(Byte* value) { }

	public void set_onFilterEvent(Func<InputEventPtr, InputDevice, Boolean> value) { }

	public void set_recordFrameMarkers(bool value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public void WriteTo(string filePath) { }

	public void WriteTo(Stream stream) { }

}

