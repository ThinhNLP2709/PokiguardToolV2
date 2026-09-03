/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR.Haptics
{
	public struct BufferedRumble // TypeDefIndex: 6267
	{
		// Fields
		[CompilerGenerated]
		private HapticCapabilities _capabilities_k__BackingField; // 0x00
		[CompilerGenerated]
		private InputDevice _device_k__BackingField; // 0x18
	
		// Properties
		public HapticCapabilities capabilities { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8ABA0-0x0000000181D8ABB0 0x0000000181D8ABB0-0x0000000181D8ABC0
		private InputDevice device { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		public BufferedRumble(InputDevice device); // 0x0000000181D8AA50-0x0000000181D8ABA0
	
		// Methods
		public void EnqueueRumble(byte[] samples); // 0x0000000181D8A7F0-0x0000000181D8AA50
	}
}
