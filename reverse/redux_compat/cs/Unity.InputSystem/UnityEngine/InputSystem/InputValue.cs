/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[DebuggerDisplay("Value = {Get()}")]
	public class InputValue // TypeDefIndex: 6234
	{
		// Fields
		internal InputAction.CallbackContext? m_Context; // 0x10
	
		// Properties
		public bool isPressed { get; } // 0x0000000181D947B0-0x0000000181D94810 
	
		// Constructors
		public InputValue(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public object Get(); // 0x0000000181D94770-0x0000000181D947B0
		public TValue Get<TValue>()
			where TValue : struct;
	}
}
