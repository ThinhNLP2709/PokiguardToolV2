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
	[DisplayName("Binding With Two Modifiers")]
	[DisplayStringFormat("{modifier1}+{modifier2}+{binding}")]
	public class TwoModifiersComposite : InputBindingComposite // TypeDefIndex: 6654
	{
		// Fields
		[InputControl(layout = "Button")]
		public int modifier1; // 0x10
		[InputControl(layout = "Button")]
		public int modifier2; // 0x14
		[InputControl]
		public int binding; // 0x18
		[Obsolete("Use ModifiersOrder.Unordered with \'modifiersOrder\' instead")]
		[Tooltip("Obsolete please use modifiers Order. If enabled, this will override the Input Consumption setting, allowing the modifier keys to be pressed after the button and the composite will still trigger.")]
		public bool overrideModifiersNeedToBePressedFirst; // 0x1C
		[Tooltip("By default it follows the Input Consumption setting to determine if the modifers keys need to be pressed first.")]
		public ModifiersOrder modifiersOrder; // 0x20
		private int m_ValueSizeInBytes; // 0x24
		private Type m_ValueType; // 0x28
		private bool m_BindingIsButton; // 0x30
	
		// Properties
		public override Type valueType { get; } // 0x000000018033D240-0x000000018033D250 
		public override int valueSizeInBytes { get; } // 0x0000000180D17D10-0x0000000180D17D20 
	
		// Nested types
		public enum ModifiersOrder // TypeDefIndex: 6655
		{
			Default = 0,
			Ordered = 1,
			Unordered = 2
		}
	
		// Constructors
		public TwoModifiersComposite(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override float EvaluateMagnitude(ref InputBindingCompositeContext context); // 0x0000000181D00150-0x0000000181D001A0
		public override unsafe void ReadValue(ref InputBindingCompositeContext context, void* buffer, int bufferSize); // 0x0000000181D00370-0x0000000181D003E0
		private bool ModifiersArePressed(ref InputBindingCompositeContext context); // 0x0000000181D00250-0x0000000181D00310
		protected override void FinishSetup(ref InputBindingCompositeContext context); // 0x0000000181D001A0-0x0000000181D00250
		public override object ReadValueAsObject(ref InputBindingCompositeContext context); // 0x0000000181D00310-0x0000000181D00370
	}
}
