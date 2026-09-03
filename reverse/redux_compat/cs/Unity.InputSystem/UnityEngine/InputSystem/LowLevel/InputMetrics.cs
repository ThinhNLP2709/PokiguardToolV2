/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	[Serializable]
	public struct InputMetrics // TypeDefIndex: 6484
	{
		// Fields
		[CompilerGenerated]
		private int _maxNumDevices_k__BackingField; // 0x00
		[CompilerGenerated]
		private int _currentNumDevices_k__BackingField; // 0x04
		[CompilerGenerated]
		private int _maxStateSizeInBytes_k__BackingField; // 0x08
		[CompilerGenerated]
		private int _currentStateSizeInBytes_k__BackingField; // 0x0C
		[CompilerGenerated]
		private int _currentControlCount_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _currentLayoutCount_k__BackingField; // 0x14
		[CompilerGenerated]
		private int _totalEventBytes_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _totalEventCount_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _totalUpdateCount_k__BackingField; // 0x20
		[CompilerGenerated]
		private double _totalEventProcessingTime_k__BackingField; // 0x28
		[CompilerGenerated]
		private double _totalEventLagTime_k__BackingField; // 0x30
	
		// Properties
		public int maxNumDevices { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int currentNumDevices { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int maxStateSizeInBytes { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public int currentStateSizeInBytes { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public int currentControlCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int currentLayoutCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public int totalEventBytes { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public int totalEventCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public int totalUpdateCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public double totalEventProcessingTime { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DDED70-0x0000000181DDED80 0x0000000181DDED90-0x0000000181DDEDA0
		public double totalEventLagTime { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DDED60-0x0000000181DDED70 0x0000000181DDED80-0x0000000181DDED90
		public float averageEventBytesPerFrame { get; } // 0x0000000181DDED00-0x0000000181DDED20 
		public double averageProcessingTimePerEvent { get; } // 0x0000000181DDED40-0x0000000181DDED60 
		public double averageLagTimePerEvent { get; } // 0x0000000181DDED20-0x0000000181DDED40 
	}
}
