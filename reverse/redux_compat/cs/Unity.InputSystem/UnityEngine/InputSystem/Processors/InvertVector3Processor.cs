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
	public class InvertVector3Processor : InputProcessor<Vector3> // TypeDefIndex: 6518
	{
		// Fields
		public bool invertX; // 0x10
		public bool invertY; // 0x11
		public bool invertZ; // 0x12
	
		// Constructors
		public InvertVector3Processor(); // 0x0000000181DE4DE0-0x0000000181DE4E00
	
		// Methods
		public override Vector3 Process(Vector3 value, InputControl control); // 0x0000000181DE4CE0-0x0000000181DE4D40
		public override string ToString(); // 0x0000000181DE4D40-0x0000000181DE4DE0
	}
}
