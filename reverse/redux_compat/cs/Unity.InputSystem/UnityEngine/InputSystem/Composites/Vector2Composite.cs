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
	[DisplayName("Up/Down/Left/Right Composite")]
	[DisplayStringFormat("{up}/{left}/{down}/{right}")]
	public class Vector2Composite : InputBindingComposite<Vector2> // TypeDefIndex: 6656
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
		[Obsolete("Use Mode.DigitalNormalized with \'mode\' instead")]
		public bool normalize; // 0x20
		public Mode mode; // 0x24
	
		// Nested types
		public enum Mode // TypeDefIndex: 6657
		{
			DigitalNormalized = 0,
			Digital = 1,
			Analog = 2
		}
	
		// Constructors
		public Vector2Composite(); // 0x0000000181D01E00-0x0000000181D01E10
	
		// Methods
		public override Vector2 ReadValue(ref InputBindingCompositeContext context); // 0x0000000181D01C80-0x0000000181D01E00
		public override float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181D01BE0-0x0000000181D01C80
	}
}
