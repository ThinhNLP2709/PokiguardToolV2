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
	[DisplayName("Binding With One Modifier")]
	[DisplayStringFormat("{modifier}+{binding}")]
	public class OneModifierComposite : InputBindingComposite // TypeDefIndex: 6652
	{
		// Fields
		[InputControl(layout = "Button")]
		public int modifier; // 0x10
		[InputControl]
		public int binding; // 0x14
		[Obsolete("Use ModifiersOrder.Unordered with \'modifiersOrder\' instead")]
		[Tooltip("Obsolete please use modifiers Order. If enabled, this will override the Input Consumption setting, allowing the modifier keys to be pressed after the button and the composite will still trigger.")]
		public bool overrideModifiersNeedToBePressedFirst; // 0x18
		[Tooltip("By default it follows the Input Consumption setting to determine if the modifers keys need to be pressed first.")]
		public ModifiersOrder modifiersOrder; // 0x1C
		private int m_ValueSizeInBytes; // 0x20
		private Type m_ValueType; // 0x28
		private bool m_BindingIsButton; // 0x30
	
		// Properties
		public override Type valueType { get; } // 0x000000018033D240-0x000000018033D250 
		public override int valueSizeInBytes { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Nested types
		public enum ModifiersOrder // TypeDefIndex: 6653
		{
			Default = 0,
			Ordered = 1,
			Unordered = 2
		}
	
		// Constructors
		public OneModifierComposite(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181CFBBC0-0x0000000181CFBC50
		public override unsafe void ReadValue(ref InputBindingCompositeContext context, void* buffer, int bufferSize); // 0x0000000181CFBDC0-0x0000000181CFBE80
		private bool ModifierIsPressed(ref InputBindingCompositeContext context); // 0x0000000181CFBD00-0x0000000181CFBD70
		protected override void FinishSetup(ref InputBindingCompositeContext context); // 0x0000000181CFBC50-0x0000000181CFBD00
		public override object ReadValueAsObject(ref InputBindingCompositeContext context); // 0x0000000181CFBD70-0x0000000181CFBDC0
		internal static void DetermineValueTypeAndSize(ref InputBindingCompositeContext context, int part, out Type valueType, out int valueSizeInBytes, out bool isButton); // 0x0000000181CFB740-0x0000000181CFBBC0
	}
}
