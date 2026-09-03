/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Processors
{
	public class StickDeadzoneProcessor : InputProcessor<Vector2> // TypeDefIndex: 6525
	{
		// Fields
		public float min; // 0x10
		public float max; // 0x14
	
		// Properties
		private float minOrDefault { get; } // 0x0000000181DE9E40-0x0000000181DE9EB0 
		private float maxOrDefault { get; } // 0x0000000181DE9DD0-0x0000000181DE9E40 
	
		// Constructors
		public StickDeadzoneProcessor(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override Vector2 Process(Vector2 value, InputControl control = null); // 0x0000000181DE9A80-0x0000000181DE9CA0
		private float GetDeadZoneAdjustedValue(float value); // 0x0000000181DE9930-0x0000000181DE9A80
		public override string ToString(); // 0x0000000181DE9CA0-0x0000000181DE9DD0
	}
}
