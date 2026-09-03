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
	public class ScaleVector2Processor : InputProcessor<Vector2> // TypeDefIndex: 6523
	{
		// Fields
		[Tooltip("Scale factor to multiply the incoming Vector2\'s X component by.")]
		public float x; // 0x10
		[Tooltip("Scale factor to multiply the incoming Vector2\'s Y component by.")]
		public float y; // 0x14
	
		// Constructors
		public ScaleVector2Processor(); // 0x0000000181DE9310-0x0000000181DE9330
	
		// Methods
		public override Vector2 Process(Vector2 value, InputControl control); // 0x0000000181DE9250-0x0000000181DE9280
		public override string ToString(); // 0x0000000181DE9280-0x0000000181DE9310
	}
}
