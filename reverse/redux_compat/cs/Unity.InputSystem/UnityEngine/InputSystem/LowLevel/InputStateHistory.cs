/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public class InputStateHistory : IDisposable, IEnumerable<InputStateHistory.Record>, IInputStateChangeMonitor // TypeDefIndex: 6501
	{
		// Fields
		private const int kDefaultHistorySize = 128; // Metadata: 0x00699156
		[CompilerGenerated]
		private Action<Record> _onRecordAdded_k__BackingField; // 0x10
		[CompilerGenerated]
		private Func<InputControl, double, InputEventPtr, bool> _onShouldRecordStateChange_k__BackingField; // 0x18
		internal InputControl[] m_Controls; // 0x20
		internal int m_ControlCount; // 0x28
		private NativeArray<byte> m_RecordBuffer; // 0x30
		private int m_StateSizeInBytes; // 0x40
		private int m_RecordCount; // 0x44
		private int m_HistoryDepth; // 0x48
		private int m_ExtraMemoryPerRecord; // 0x4C
		internal int m_HeadIndex; // 0x50
		internal uint m_CurrentVersion; // 0x54
		private InputUpdateType? m_UpdateMask; // 0x58
		internal readonly bool m_AddNewControls; // 0x60
	
		// Properties
		public int Count { get; } // 0x000000018033D780-0x000000018033D790 
		public uint version { get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
		public int historyDepth { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x0000000181DE3C40-0x0000000181DE3D00
		public int extraMemoryPerRecord { get; set; } // 0x000000018033D1B0-0x000000018033D1C0 0x0000000181DE3B80-0x0000000181DE3C40
		public InputUpdateType updateMask { get; set; } // 0x0000000181DE39A0-0x0000000181DE3A20 0x0000000181DE3D00-0x0000000181DE3DA0
		public ReadOnlyArray<InputControl> controls { get; } // 0x0000000181DE3960-0x0000000181DE39A0 
		public Record this[int index] { get => default; set {} } // 0x0000000181DE3800-0x0000000181DE3920 0x0000000181DE3A20-0x0000000181DE3B80
		public Action<Record> onRecordAdded { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public Func<InputControl, double, InputEventPtr, bool> onShouldRecordStateChange { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal int bytesPerRecord { get; } // 0x0000000181DE3920-0x0000000181DE3960 
	
		// Nested types
		private struct Enumerator : IEnumerator<Record> // TypeDefIndex: 6502
		{
			// Fields
			private readonly InputStateHistory m_History; // 0x00
			private int m_Index; // 0x08
	
			// Properties
			public Record Current { get; } // 0x0000000181DD9B20-0x0000000181DD9C60 
			object IEnumerator.Current { get; } // 0x0000000181DD9A70-0x0000000181DD9AD0 
	
			// Constructors
			public Enumerator(InputStateHistory history); // 0x000000018112D900-0x000000018112D920
	
			// Methods
			public bool MoveNext(); // 0x00000001811284A0-0x00000001811284D0
			public void Reset(); // 0x000000018112ACA0-0x000000018112ACB0
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		protected internal struct RecordHeader // TypeDefIndex: 6503
		{
			// Fields
			public double time; // 0x00
			public uint version; // 0x08
			public int controlIndex; // 0x0C
			private unsafe fixed /* 0x00000000-0x00000000 */ byte m_StateWithoutControlIndex[0]; // 0x0C
			private unsafe fixed /* 0x00000000-0x00000000 */ byte m_StateWithControlIndex[0]; // 0x10
			public const int kSizeWithControlIndex = 16; // Metadata: 0x00699158
			public const int kSizeWithoutControlIndex = 12; // Metadata: 0x00699159
	
			// Properties
			public unsafe byte* statePtrWithControlIndex { get; } // 0x0000000181DE6D40-0x0000000181DE6D50 
			public unsafe byte* statePtrWithoutControlIndex { get; } // 0x0000000181616650-0x0000000181616660 
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _m_StateWithControlIndex_e__FixedBuffer // TypeDefIndex: 6504
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
	
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _m_StateWithoutControlIndex_e__FixedBuffer // TypeDefIndex: 6505
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
		}
	
		public struct Record : IEquatable<Record> // TypeDefIndex: 6506
		{
			// Fields
			private readonly InputStateHistory m_Owner; // 0x00
			private readonly int m_IndexPlusOne; // 0x08
			private uint m_Version; // 0x0C
	
			// Properties
			internal unsafe RecordHeader* header { get; } // 0x0000000180D8B750-0x0000000180D8B780 
			internal int recordIndex { get; } // 0x0000000180D8BCC0-0x0000000180D8BCD0 
			internal uint version { get; } // 0x0000000180732D30-0x0000000180732D40 
			public bool valid { get; } // 0x0000000180D8BE00-0x0000000180D8BE50 
			public InputStateHistory owner { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public int index { get; } // 0x0000000181DE79A0-0x0000000181DE79E0 
			public double time { get; } // 0x0000000181DE7BD0-0x0000000181DE7C10 
			public InputControl control { get; } // 0x0000000181DE78B0-0x0000000181DE79A0 
			public Record next { get; } // 0x0000000181DE79E0-0x0000000181DE7AD0 
			public Record previous { get; } // 0x0000000181DE7AD0-0x0000000181DE7BD0 
	
			// Constructors
			internal unsafe Record(InputStateHistory owner, int index, RecordHeader* header); // 0x0000000180D8B3E0-0x0000000180D8B430
	
			// Methods
			public TValue ReadValue<TValue>()
				where TValue : struct;
			public object ReadValueAsObject(); // 0x0000000181DE7620-0x0000000181DE7790
			public unsafe void* GetUnsafeMemoryPtr(); // 0x0000000181DE7570-0x0000000181DE7620
			internal unsafe void* GetUnsafeMemoryPtrUnchecked(); // 0x0000000181DE74D0-0x0000000181DE7570
			public unsafe void* GetUnsafeExtraMemoryPtr(); // 0x0000000181DE73F0-0x0000000181DE74D0
			internal unsafe void* GetUnsafeExtraMemoryPtrUnchecked(); // 0x0000000181DE7320-0x0000000181DE73F0
			public void CopyFrom(Record record); // 0x0000000181DE6E20-0x0000000181DE7280
			internal void CheckValid(); // 0x0000000181DE6D50-0x0000000181DE6E20
			public bool Equals(Record other); // 0x0000000180BE3530-0x0000000180BE3550
			public override bool Equals(object obj); // 0x0000000181DE7280-0x0000000181DE7320
			public override int GetHashCode(); // 0x0000000180D8A960-0x0000000180D8A9B0
			public override string ToString(); // 0x0000000181DE7790-0x0000000181DE78B0
		}
	
		// Constructors
		public InputStateHistory(int maxStateSizeInBytes); // 0x0000000181DE3470-0x0000000181DE3510
		public InputStateHistory(string path); // 0x0000000181DE35A0-0x0000000181DE36D0
		public InputStateHistory(InputControl control); // 0x0000000181DE36D0-0x0000000181DE3800
		public InputStateHistory(IEnumerable<InputControl> controls); // 0x0000000181DE3510-0x0000000181DE35A0
	
		// Methods
		~InputStateHistory(); // 0x0000000181DE2530-0x0000000181DE2620
		public void Clear(); // 0x0000000181DE2440-0x0000000181DE2450
		public Record AddRecord(Record record); // 0x0000000181DE2000-0x0000000181DE2100
		public void StartRecording(); // 0x0000000181DE2FD0-0x0000000181DE3120
		public void StopRecording(); // 0x0000000181DE3120-0x0000000181DE3320
		public Record RecordStateChange(InputControl control, InputEventPtr eventPtr); // 0x0000000181DE2950-0x0000000181DE2C10
		public unsafe Record RecordStateChange(InputControl control, void* statePtr, double time); // 0x0000000181DE2C10-0x0000000181DE2FD0
		public IEnumerator<Record> GetEnumerator(); // 0x0000000181DE2620-0x0000000181DE2690
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181DE2620-0x0000000181DE2690
		public void Dispose(); // 0x0000000181DE24A0-0x0000000181DE2530
		protected void Destroy(); // 0x0000000181DE2450-0x0000000181DE24A0
		private void Allocate(); // 0x0000000181DE21A0-0x0000000181DE2440
		protected internal int RecordIndexToUserIndex(int index); // 0x0000000181DE2930-0x0000000181DE2950
		protected internal int UserIndexToRecordIndex(int index); // 0x0000000181DE3460-0x0000000181DE3470
		protected internal unsafe RecordHeader* GetRecord(int index); // 0x0000000181DE26E0-0x0000000181DE27E0
		internal unsafe RecordHeader* GetRecordUnchecked(int index); // 0x0000000181DE2690-0x0000000181DE26E0
		protected internal unsafe RecordHeader* AllocateRecord(out int index); // 0x0000000181DE2100-0x0000000181DE21A0
		protected unsafe TValue ReadValue<TValue>(RecordHeader* data)
			where TValue : struct;
		protected unsafe object ReadValueAsObject(RecordHeader* data); // 0x0000000181DE27E0-0x0000000181DE2930
		void IInputStateChangeMonitor.NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex); // 0x0000000181DE3320-0x0000000181DE3460
		void IInputStateChangeMonitor.NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
