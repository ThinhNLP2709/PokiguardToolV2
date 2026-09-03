/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct QueryPairedUserAccountCommand : IInputDeviceCommandInfo // TypeDefIndex: 6411
	{
		// Fields
		internal const int kMaxNameLength = 256; // Metadata: 0x00698FB9
		internal const int kMaxIdLength = 256; // Metadata: 0x00698FBB
		internal const int kSize = 1040; // Metadata: 0x00698FBD
		public InputDeviceCommand baseCommand; // 0x00
		public ulong handle; // 0x08
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte nameBuffer[0]; // 0x10
		internal unsafe fixed /* 0x00000000-0x00000000 */ byte idBuffer[0]; // 0x210
	
		// Properties
		public static FourCC Type { get; } // 0x0000000181DD00E0-0x0000000181DD0120 
		public string id { get; set; } // 0x0000000181DD0120-0x0000000181DD0140 0x0000000181DD01A0-0x0000000181DD02B0
		public string name { get; set; } // 0x0000000181DD0140-0x0000000181DD0160 0x0000000181DD02B0-0x0000000181DD03C0
		public FourCC typeStatic { get; } // 0x0000000181DD0160-0x0000000181DD01A0 
	
		// Nested types
		[Flags]
		public enum Result : long // TypeDefIndex: 6412
		{
			DevicePairedToUserAccount = 2,
			UserAccountSelectionInProgress = 4,
			UserAccountSelectionComplete = 8,
			UserAccountSelectionCanceled = 16
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _idBuffer_e__FixedBuffer // TypeDefIndex: 6413
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _nameBuffer_e__FixedBuffer // TypeDefIndex: 6414
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		// Methods
		public static QueryPairedUserAccountCommand Create(); // 0x0000000181DD0070-0x0000000181DD00E0
	}
}
