/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	[Serializable]
	public sealed class InputEventTrace : IDisposable, IEnumerable<InputEventPtr> // TypeDefIndex: 6470
	{
		// Fields
		private const int kDefaultBufferSize = 1048576; // Metadata: 0x006990B3
		private static readonly ProfilerMarker k_InputEvenTraceMarker; // 0x00
		[NonSerialized]
		private int m_ChangeCounter; // 0x10
		[NonSerialized]
		private bool m_Enabled; // 0x14
		[NonSerialized]
		private Func<InputEventPtr, InputDevice, bool> m_OnFilterEvent; // 0x18
		[SerializeField]
		private int m_DeviceId; // 0x20
		[NonSerialized]
		private CallbackArray<Action<InputEventPtr>> m_EventListeners; // 0x28
		[SerializeField]
		private long m_EventBufferSize; // 0x78
		[SerializeField]
		private long m_MaxEventBufferSize; // 0x80
		[SerializeField]
		private long m_GrowIncrementSize; // 0x88
		[SerializeField]
		private long m_EventCount; // 0x90
		[SerializeField]
		private long m_EventSizeInBytes; // 0x98
		[SerializeField]
		private ulong m_EventBufferStorage; // 0xA0
		[SerializeField]
		private ulong m_EventBufferHeadStorage; // 0xA8
		[SerializeField]
		private ulong m_EventBufferTailStorage; // 0xB0
		[SerializeField]
		private bool m_HasWrapped; // 0xB8
		[SerializeField]
		private bool m_RecordFrameMarkers; // 0xB9
		[SerializeField]
		private DeviceInfo[] m_DeviceInfos; // 0xC0
		private static int kFileVersion; // 0x08
	
		// Properties
		public static FourCC FrameMarkerEvent { get; } // 0x0000000181DCEB90-0x0000000181DCEBD0 
		public int deviceId { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public bool enabled { get; } // 0x0000000181102980-0x0000000181102990 
		public bool recordFrameMarkers { get; set; } // 0x0000000181DCEC60-0x0000000181DCEC70 0x0000000181DCECD0-0x0000000181DCEDB0
		public long eventCount { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public long totalEventSizeInBytes { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public long allocatedSizeInBytes { get; } // 0x0000000181DCEBD0-0x0000000181DCEBF0 
		public long maxSizeInBytes { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public ReadOnlyArray<DeviceInfo> deviceInfos { get; } // 0x0000000181DCEBF0-0x0000000181DCEC20 
		public Func<InputEventPtr, InputDevice, bool> onFilterEvent { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		private unsafe byte* m_EventBuffer { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x000000018170D430-0x000000018170D440
		private unsafe byte* m_EventBufferHead { get; set; } // 0x000000018033D510-0x000000018033D520 0x000000018170D560-0x000000018170D570
		private unsafe byte* m_EventBufferTail { get; set; } // 0x00000001806BAE60-0x00000001806BAE70 0x0000000181DCECC0-0x0000000181DCECD0
		private static FourCC kFileFormat { get; } // 0x0000000181DCEC20-0x0000000181DCEC60 
	
		// Events
		public event Action<InputEventPtr> onEvent {
			add; // 0x0000000181DCEB40-0x0000000181DCEB90
			remove; // 0x0000000181DCEC70-0x0000000181DCECC0
		}
	
		// Nested types
		private class Enumerator : IEnumerator<InputEventPtr> // TypeDefIndex: 6471
		{
			// Fields
			private InputEventTrace m_Trace; // 0x10
			private int m_ChangeCounter; // 0x18
			internal InputEventPtr m_Current; // 0x20
	
			// Properties
			public InputEventPtr Current { get; } // 0x00000001802F8630-0x00000001802F8640 
			object IEnumerator.Current { get; } // 0x0000000181DD9A20-0x0000000181DD9A70 
	
			// Constructors
			public Enumerator(InputEventTrace trace); // 0x0000000181DD9AD0-0x0000000181DD9B20
	
			// Methods
			public void Dispose(); // 0x0000000181DD98F0-0x0000000181DD9920
			public bool MoveNext(); // 0x0000000181DD9920-0x0000000181DD99F0
			public void Reset(); // 0x0000000181DD99F0-0x0000000181DD9A20
		}
	
		[Flags]
		private enum FileFlags // TypeDefIndex: 6472
		{
			FixedUpdate = 1
		}
	
		public class ReplayController : IDisposable // TypeDefIndex: 6473
		{
			// Fields
			[CompilerGenerated]
			private bool _finished_k__BackingField; // 0x10
			[CompilerGenerated]
			private bool _paused_k__BackingField; // 0x11
			[CompilerGenerated]
			private int _position_k__BackingField; // 0x14
			private InputEventTrace m_EventTrace; // 0x18
			private Enumerator m_Enumerator; // 0x20
			private InlinedArray<KeyValuePair<int, int>> m_DeviceIDMappings; // 0x28
			private bool m_CreateNewDevices; // 0x40
			private InlinedArray<InputDevice> m_CreatedDevices; // 0x48
			private Action m_OnFinished; // 0x60
			private Action<InputEventPtr> m_OnEvent; // 0x68
			private double m_StartTimeAsPerFirstEvent; // 0x70
			private double m_StartTimeAsPerRuntime; // 0x78
			private int m_AllEventsByTimeIndex; // 0x80
			private List<InputEventPtr> m_AllEventsByTime; // 0x88
	
			// Properties
			public InputEventTrace trace { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public bool finished { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
			public bool paused { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E10-0x0000000180E38E20 0x00000001815C0340-0x00000001815C0350
			public int position { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
			public IEnumerable<InputDevice> createdDevices { get; } // 0x0000000181DE9180-0x0000000181DE91D0 
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 6474
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static Comparison<InputEventPtr> __9__38_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181DEA470-0x0000000181DEA4E0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal int _PlayAllEventsAccordingToTimestamps_b__38_0(InputEventPtr a, InputEventPtr b); // 0x0000000181DEA0B0-0x0000000181DEA100
			}
	
			[CompilerGenerated]
			private sealed class __c__DisplayClass43_0 // TypeDefIndex: 6475
			{
				// Fields
				public int originalDeviceId; // 0x10
	
				// Constructors
				public __c__DisplayClass43_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal bool _ApplyDeviceMapping_b__0(DeviceInfo x); // 0x00000001804AA970-0x00000001804AA980
			}
	
			// Constructors
			internal ReplayController(InputEventTrace trace); // 0x0000000181DE9100-0x0000000181DE9180
	
			// Methods
			public void Dispose(); // 0x0000000181DE7F40-0x0000000181DE81D0
			public ReplayController WithDeviceMappedFromTo(InputDevice recordedDevice, InputDevice playbackDevice); // 0x0000000181DE8F10-0x0000000181DE8FE0
			public ReplayController WithDeviceMappedFromTo(int recordedDeviceId, int playbackDeviceId); // 0x0000000181DE8FE0-0x0000000181DE9100
			public ReplayController WithAllDevicesMappedToNewInstances(); // 0x0000000181DE8F00-0x0000000181DE8F10
			public ReplayController OnFinished(Action action); // 0x00000001806F7570-0x00000001806F7590
			public ReplayController OnEvent(Action<InputEventPtr> action); // 0x00000001807163E0-0x0000000180716400
			public ReplayController PlayOneEvent(); // 0x0000000181DE8BF0-0x0000000181DE8C80
			public ReplayController Rewind(); // 0x0000000181DE8EB0-0x0000000181DE8F00
			public ReplayController PlayAllFramesOneByOne(); // 0x0000000181DE8B50-0x0000000181DE8BF0
			public ReplayController PlayAllEvents(); // 0x0000000181DE8AB0-0x0000000181DE8B50
			public ReplayController PlayAllEventsAccordingToTimestamps(); // 0x0000000181DE87F0-0x0000000181DE8AB0
			private void OnBeginFrame(); // 0x0000000181DE8600-0x0000000181DE87F0
			private void Finished(); // 0x0000000181DE81D0-0x0000000181DE8280
			private void QueueEvent(InputEventPtr eventPtr); // 0x0000000181DE8C80-0x0000000181DE8EB0
			private bool MoveNext(bool skipFrameEvents, out InputEventPtr eventPtr); // 0x0000000181DE8280-0x0000000181DE8600
			private int ApplyDeviceMapping(int originalDeviceId); // 0x0000000181DE7C10-0x0000000181DE7F40
		}
	
		[Serializable]
		public struct DeviceInfo // TypeDefIndex: 6476
		{
			// Fields
			[SerializeField]
			internal int m_DeviceId; // 0x00
			[SerializeField]
			internal string m_Layout; // 0x08
			[SerializeField]
			internal FourCC m_StateFormat; // 0x10
			[SerializeField]
			internal int m_StateSizeInBytes; // 0x14
			[SerializeField]
			internal string m_FullLayoutJson; // 0x18
	
			// Properties
			public int deviceId { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
			public string layout { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
			public FourCC stateFormat { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
			public int stateSizeInBytes { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		}
	
		// Constructors
		public InputEventTrace(InputDevice device, long bufferSizeInBytes = 1048576 /* Metadata: 0x00699079 */, bool growBuffer = false /* Metadata: 0x00699081 */, long maxBufferSizeInBytes = -1 /* Metadata: 0x00699082 */, long growIncrementSizeInBytes = -1 /* Metadata: 0x0069908A */); // 0x0000000181DCEA50-0x0000000181DCEB40
		public InputEventTrace(long bufferSizeInBytes = 1048576 /* Metadata: 0x00699092 */, bool growBuffer = false /* Metadata: 0x0069909A */, long maxBufferSizeInBytes = -1 /* Metadata: 0x0069909B */, long growIncrementSizeInBytes = -1 /* Metadata: 0x006990A3 */); // 0x0000000181DCE9D0-0x0000000181DCEA50
		static InputEventTrace(); // 0x0000000181DCE950-0x0000000181DCE9D0
	
		// Methods
		public void WriteTo(string filePath); // 0x0000000181DCE820-0x0000000181DCE950
		public void WriteTo(Stream stream); // 0x0000000181DCE100-0x0000000181DCE820
		public void ReadFrom(string filePath); // 0x0000000181DCD450-0x0000000181DCD580
		public void ReadFrom(Stream stream); // 0x0000000181DCD580-0x0000000181DCDD70
		public static InputEventTrace LoadFrom(string filePath); // 0x0000000181DCCB20-0x0000000181DCCDA0
		public static InputEventTrace LoadFrom(Stream stream); // 0x0000000181DCC9D0-0x0000000181DCCB20
		public ReplayController Replay(); // 0x0000000181DCDDF0-0x0000000181DCDE50
		public bool Resize(long newBufferSize, long newMaxBufferSize = -1 /* Metadata: 0x006990AB */); // 0x0000000181DCDE50-0x0000000181DCE100
		public void Clear(); // 0x0000000181DCC5E0-0x0000000181DCC620
		public void Enable(); // 0x0000000181DCC7B0-0x0000000181DCC8F0
		public void Disable(); // 0x0000000181DCC620-0x0000000181DCC730
		public bool GetNextEvent(ref InputEventPtr current); // 0x0000000181DCC950-0x0000000181DCC9D0
		public IEnumerator<InputEventPtr> GetEnumerator(); // 0x0000000181DCC8F0-0x0000000181DCC950
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181DCC8F0-0x0000000181DCC950
		public void Dispose(); // 0x0000000181DCC730-0x0000000181DCC7B0
		private void Allocate(); // 0x0000000181DCC5B0-0x0000000181DCC5E0
		private void Release(); // 0x0000000181DCDD70-0x0000000181DCDDF0
		private void OnBeforeUpdate(); // 0x0000000181DCCDA0-0x0000000181DCCEC0
		private void OnInputEvent(InputEventPtr inputEvent, InputDevice device); // 0x0000000181DCCEC0-0x0000000181DCD450
	}
}
