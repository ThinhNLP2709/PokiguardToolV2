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
	[DesignTimeVisible(false)]
	[DisplayStringFormat("{modifier1}+{modifier2}+{button}")]
	public class ButtonWithTwoModifiers : InputBindingComposite<float> // TypeDefIndex: 6650
	{
		// Fields
		[InputControl(layout = "Button")]
		public int modifier1; // 0x10
		[InputControl(layout = "Button")]
		public int modifier2; // 0x14
		[InputControl(layout = "Button")]
		public int button; // 0x18
		[Obsolete("Use ModifiersOrder.Unordered with \'modifiersOrder\' instead")]
		[Tooltip("Obsolete please use modifiers Order. If enabled, this will override the Input Consumption setting, allowing the modifier keys to be pressed after the button and the composite will still trigger.")]
		public bool overrideModifiersNeedToBePressedFirst; // 0x1C
		[Tooltip("By default it follows the Input Consumption setting to determine if the modifers keys need to be pressed first.")]
		public ModifiersOrder modifiersOrder; // 0x20
	
		// Nested types
		public enum ModifiersOrder // TypeDefIndex: 6651
		{
			Default = 0,
			Ordered = 1,
			Unordered = 2
		}
	
		// Constructors
		public ButtonWithTwoModifiers(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override float ReadValue(ref InputBindingCompositeContext context); // 0x0000000181CF8750-0x0000000181CF8830
		private bool ModifiersArePressed(ref InputBindingCompositeContext context); // 0x0000000181CF8690-0x0000000181CF8750
		public override float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181CF8450-0x0000000181CF8470
		protected override void FinishSetup(ref InputBindingCompositeContext context); // 0x0000000181CF8610-0x0000000181CF8690
	}
}
