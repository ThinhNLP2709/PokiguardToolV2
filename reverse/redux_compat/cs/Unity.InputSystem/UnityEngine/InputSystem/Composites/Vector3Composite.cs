/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Composites
{
	[DisplayName("Up/Down/Left/Right/Forward/Backward Composite")]
	[DisplayStringFormat("{up}+{down}/{left}+{right}/{forward}+{backward}")]
	public class Vector3Composite : InputBindingComposite<Vector3> // TypeDefIndex: 6658
	{
		// Fields
		[InputControl(layout = "Axis")]
		public int up; // 0x10
		[InputControl(layout = "Axis")]
		public int down; // 0x14
		[InputControl(layout = "Axis")]
		public int left; // 0x18
		[InputControl(layout = "Axis")]
		public int right; // 0x1C
		[InputControl(layout = "Axis")]
		public int forward; // 0x20
		[InputControl(layout = "Axis")]
		public int backward; // 0x24
		public Mode mode; // 0x28
	
		// Nested types
		public enum Mode // TypeDefIndex: 6659
		{
			Analog = 0,
			DigitalNormalized = 1,
			Digital = 2
		}
	
		// Constructors
		public Vector3Composite(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override Vector3 ReadValue(ref InputBindingCompositeContext context); // 0x0000000181D01EE0-0x0000000181D02390
		public override float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181D01E10-0x0000000181D01EE0
	}
}
