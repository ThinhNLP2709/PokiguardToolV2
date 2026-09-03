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
	public class ScaleVector3Processor : InputProcessor<Vector3> // TypeDefIndex: 6524
	{
		// Fields
		[Tooltip("Scale factor to multiply the incoming Vector3\'s X component by.")]
		public float x; // 0x10
		[Tooltip("Scale factor to multiply the incoming Vector3\'s Y component by.")]
		public float y; // 0x14
		[Tooltip("Scale factor to multiply the incoming Vector3\'s Z component by.")]
		public float z; // 0x18
	
		// Constructors
		public ScaleVector3Processor(); // 0x0000000181DE9420-0x0000000181DE9440
	
		// Methods
		public override Vector3 Process(Vector3 value, InputControl control); // 0x0000000181DE9330-0x0000000181DE9370
		public override string ToString(); // 0x0000000181DE9370-0x0000000181DE9420
	}
}
