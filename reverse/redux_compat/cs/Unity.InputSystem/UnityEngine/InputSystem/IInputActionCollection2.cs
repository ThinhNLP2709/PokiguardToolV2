/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public interface IInputActionCollection2 : IInputActionCollection // TypeDefIndex: 6044
	{
		// Properties
		IEnumerable<InputBinding> bindings { get; }
	
		// Methods
		InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false /* Metadata: 0x006988E8 */);
		int FindBinding(InputBinding mask, out InputAction action);
	}
}
