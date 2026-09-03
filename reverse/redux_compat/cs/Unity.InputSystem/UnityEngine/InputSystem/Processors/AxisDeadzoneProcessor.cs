/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Processors
{
	public class AxisDeadzoneProcessor : InputProcessor<float> // TypeDefIndex: 6512
	{
		// Fields
		public float min; // 0x10
		public float max; // 0x14
	
		// Properties
		private float minOrDefault { get; } // 0x0000000181DD5180-0x0000000181DD51F0 
		private float maxOrDefault { get; } // 0x0000000181DD5110-0x0000000181DD5180 
	
		// Constructors
		public AxisDeadzoneProcessor(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override float Process(float value, InputControl control = null); // 0x0000000181DD4E90-0x0000000181DD4FE0
		public override string ToString(); // 0x0000000181DD4FE0-0x0000000181DD5110
	}
}
