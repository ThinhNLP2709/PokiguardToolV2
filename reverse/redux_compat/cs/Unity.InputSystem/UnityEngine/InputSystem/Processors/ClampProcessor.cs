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
	public class ClampProcessor : InputProcessor<float> // TypeDefIndex: 6513
	{
		// Fields
		public float min; // 0x10
		public float max; // 0x14
	
		// Constructors
		public ClampProcessor(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override float Process(float value, InputControl control); // 0x0000000181DD5760-0x0000000181DD5780
		public override string ToString(); // 0x0000000181DD5780-0x0000000181DD5810
	}
}
