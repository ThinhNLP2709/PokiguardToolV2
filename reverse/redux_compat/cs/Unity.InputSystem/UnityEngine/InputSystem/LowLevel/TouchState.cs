/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct TouchState : IInputStateTypeInfo // TypeDefIndex: 6445
	{
		// Fields
		internal const int kSizeInBytes = 56; // Metadata: 0x00699020
		[InputControl(displayName = "Touch ID", layout = "Integer", synthetic = true, dontReset = true)]
		public int touchId; // 0x00
		[InputControl(displayName = "Position", dontReset = true)]
		public Vector2 position; // 0x04
		[InputControl(displayName = "Delta", layout = "Delta")]
		public Vector2 delta; // 0x0C
		[InputControl(displayName = "Pressure", layout = "Axis")]
		public float pressure; // 0x14
		[InputControl(displayName = "Radius")]
		public Vector2 radius; // 0x18
		[InputControl(name = "phase", displayName = "Touch Phase", layout = "TouchPhase", synthetic = true)]
		[InputControl(name = "press", displayName = "Touch Contact?", layout = "TouchPress", useStateFrom = "phase")]
		public byte phaseId; // 0x20
		[InputControl(name = "tapCount", displayName = "Tap Count", layout = "Integer")]
		public byte tapCount; // 0x21
		[InputControl(name = "displayIndex", displayName = "Display Index", layout = "Integer")]
		public byte displayIndex; // 0x22
		[InputControl(name = "indirectTouch", displayName = "Indirect Touch?", layout = "Button", bit = 0, synthetic = true)]
		[InputControl(name = "tap", displayName = "Tap", layout = "Button", bit = 4)]
		public byte flags; // 0x23
		internal uint updateStepCount; // 0x24
		[InputControl(displayName = "Start Time", layout = "Double", synthetic = true)]
		public double startTime; // 0x28
		[InputControl(displayName = "Start Position", synthetic = true)]
		public Vector2 startPosition; // 0x30
	
		// Properties
		public static FourCC Format { get; } // 0x0000000181DD2800-0x0000000181DD2840 
		public UnityEngine.InputSystem.TouchPhase phase { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public bool isNoneEndedOrCanceled { get; } // 0x0000000181DD28C0-0x0000000181DD28E0 
		public bool isInProgress { get; } // 0x0000000181DD2890-0x0000000181DD28B0 
		public bool isPrimaryTouch { get; set; } // 0x0000000181DD28F0-0x0000000181DD2900 0x0000000181DD29B0-0x0000000181DD29E0
		internal bool isOrphanedPrimaryTouch { get; set; } // 0x0000000181DD28E0-0x0000000181DD28F0 0x0000000181DD2980-0x0000000181DD29B0
		public bool isIndirectTouch { get; set; } // 0x0000000181DD28B0-0x0000000181DD28C0 0x0000000181DD2950-0x0000000181DD2980
		public bool isTap { get; set; } // 0x0000000181DD2900-0x0000000181DD2910 0x0000000181DD29E0-0x0000000181DD2A10
		internal bool isTapPress { get; set; } // 0x0000000181DD2900-0x0000000181DD2910 0x0000000181DD29E0-0x0000000181DD2A10
		internal bool isTapRelease { get; set; } // 0x0000000181DD2910-0x0000000181DD2920 0x0000000181DD2A10-0x0000000181DD2A40
		internal bool beganInSameFrame { get; set; } // 0x0000000181DD2840-0x0000000181DD2850 0x0000000181DD2920-0x0000000181DD2950
		public FourCC format { get; } // 0x0000000181DD2850-0x0000000181DD2890 
	
		// Methods
		public override string ToString(); // 0x0000000181DD24B0-0x0000000181DD2800
	}
}
