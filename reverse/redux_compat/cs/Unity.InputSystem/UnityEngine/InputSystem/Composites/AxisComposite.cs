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
	[DisplayName("Positive/Negative Binding")]
	[DisplayStringFormat("{negative}/{positive}")]
	public class AxisComposite : InputBindingComposite<float> // TypeDefIndex: 6646
	{
		// Fields
		[InputControl(layout = "Axis")]
		public int negative; // 0x10
		[InputControl(layout = "Axis")]
		public int positive; // 0x14
		[Tooltip("Value to return when the negative side is fully actuated.")]
		public float minValue; // 0x18
		[Tooltip("Value to return when the positive side is fully actuated.")]
		public float maxValue; // 0x1C
		[Tooltip("If both the positive and negative side are actuated, decides what value to return. \'Neither\' (default) means that the resulting value is the midpoint between min and max. \'Positive\' means that max will be returned. \'Negative\' means that min will be returned.")]
		public WhichSideWins whichSideWins; // 0x20
	
		// Properties
		public float midPoint { get; } // 0x0000000181CF8360-0x0000000181CF8380 
	
		// Nested types
		public enum WhichSideWins // TypeDefIndex: 6647
		{
			Neither = 0,
			Positive = 1,
			Negative = 2
		}
	
		// Constructors
		public AxisComposite(); // 0x0000000181CF8340-0x0000000181CF8360
	
		// Methods
		public override float ReadValue(ref InputBindingCompositeContext context); // 0x0000000181CF8220-0x0000000181CF8340
		public override float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181CF8180-0x0000000181CF8220
	}
}
