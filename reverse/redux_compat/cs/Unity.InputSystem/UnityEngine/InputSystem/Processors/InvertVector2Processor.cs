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
	public class InvertVector2Processor : InputProcessor<Vector2> // TypeDefIndex: 6517
	{
		// Fields
		public bool invertX; // 0x10
		public bool invertY; // 0x11
	
		// Constructors
		public InvertVector2Processor(); // 0x0000000181DE4CD0-0x0000000181DE4CE0
	
		// Methods
		public override Vector2 Process(Vector2 value, InputControl control); // 0x0000000181DE4BF0-0x0000000181DE4C50
		public override string ToString(); // 0x0000000181DE4C50-0x0000000181DE4CD0
	}
}
