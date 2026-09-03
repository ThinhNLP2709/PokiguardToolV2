/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Haptics
{
	internal struct DualMotorRumble // TypeDefIndex: 6392
	{
		// Fields
		[CompilerGenerated]
		private float _lowFrequencyMotorSpeed_k__BackingField; // 0x00
		[CompilerGenerated]
		private float _highFrequencyMotorSpeed_k__BackingField; // 0x04
	
		// Properties
		public float lowFrequencyMotorSpeed { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public float highFrequencyMotorSpeed { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public bool isRumbling { get; } // 0x0000000181DBFE40-0x0000000181DBFEC0 
	
		// Methods
		public void PauseHaptics(InputDevice device); // 0x0000000181DBFAD0-0x0000000181DBFBC0
		public void ResumeHaptics(InputDevice device); // 0x0000000181DBFC50-0x0000000181DBFCF0
		public void ResetHaptics(InputDevice device); // 0x0000000181DBFBC0-0x0000000181DBFC50
		public void SetMotorSpeeds(InputDevice device, float lowFrequency, float highFrequency); // 0x0000000181DBFCF0-0x0000000181DBFE40
	}
}
