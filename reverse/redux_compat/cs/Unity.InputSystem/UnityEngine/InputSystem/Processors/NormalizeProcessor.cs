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
	public class NormalizeProcessor : InputProcessor<float> // TypeDefIndex: 6519
	{
		// Fields
		public float min; // 0x10
		public float max; // 0x14
		public float zero; // 0x18
	
		// Constructors
		public NormalizeProcessor(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override float Process(float value, InputControl control); // 0x0000000181DE6A70-0x0000000181DE6B20
		public static float Normalize(float value, float min, float max, float zero); // 0x0000000181DE69B0-0x0000000181DE6A70
		internal static float Denormalize(float value, float min, float max, float zero); // 0x0000000181DE6960-0x0000000181DE69B0
		public override string ToString(); // 0x0000000181DE6B20-0x0000000181DE6BD0
	}
}
