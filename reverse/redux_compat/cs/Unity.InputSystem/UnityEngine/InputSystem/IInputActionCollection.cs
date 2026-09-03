/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public interface IInputActionCollection : IEnumerable<UnityEngine.InputSystem.InputAction> // TypeDefIndex: 6043
	{
		// Properties
		InputBinding? bindingMask { get; set; }
		ReadOnlyArray<InputDevice>? devices { get; set; }
		ReadOnlyArray<InputControlScheme> controlSchemes { get; }
	
		// Methods
		bool Contains(InputAction action);
		void Enable();
		void Disable();
	}
}
