/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR.Haptics
{
	public struct HapticCapabilities // TypeDefIndex: 6270
	{
		// Fields
		[CompilerGenerated]
		private readonly uint _numChannels_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly bool _supportsImpulse_k__BackingField; // 0x04
		[CompilerGenerated]
		private readonly bool _supportsBuffer_k__BackingField; // 0x05
		[CompilerGenerated]
		private readonly uint _frequencyHz_k__BackingField; // 0x08
		[CompilerGenerated]
		private readonly uint _maxBufferSize_k__BackingField; // 0x0C
		[CompilerGenerated]
		private readonly uint _optimalBufferSize_k__BackingField; // 0x10
	
		// Properties
		public uint numChannels { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180732D10-0x0000000180732D20 
		public bool supportsImpulse { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001813282D0-0x00000001813282E0 
		public bool supportsBuffer { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000181CCF9E0-0x0000000181CCF9F0 
		public uint frequencyHz { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180732D20-0x0000000180732D30 
		public uint maxBufferSize { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000180732D30-0x0000000180732D40 
		public uint optimalBufferSize { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		public HapticCapabilities(uint numChannels, bool supportsImpulse, bool supportsBuffer, uint frequencyHz, uint maxBufferSize, uint optimalBufferSize); // 0x0000000181D8C180-0x0000000181D8C1A0
		public HapticCapabilities(uint numChannels, uint frequencyHz, uint maxBufferSize); // 0x0000000181D8C160-0x0000000181D8C180
	}
}
