/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[Serializable]
	public struct InputActionProperty : IEquatable<InputActionProperty>, IEquatable<InputAction>, IEquatable<InputActionReference> // TypeDefIndex: 6082
	{
		// Fields
		[SerializeField]
		private bool m_UseReference; // 0x00
		[SerializeField]
		private InputAction m_Action; // 0x08
		[SerializeField]
		private InputActionReference m_Reference; // 0x10
	
		// Properties
		public InputAction action { get; } // 0x0000000181CD2E20-0x0000000181CD2EB0 
		public InputActionReference reference { get; } // 0x0000000181CD2EB0-0x0000000181CD2EC0 
		internal InputAction serializedAction { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		internal InputActionReference serializedReference { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public InputActionProperty(InputAction action); // 0x0000000181CD2DA0-0x0000000181CD2DE0
		public InputActionProperty(InputActionReference reference); // 0x0000000181CD2DE0-0x0000000181CD2E20
	
		// Methods
		public bool Equals(InputActionProperty other); // 0x0000000181CD2A30-0x0000000181CD2AD0
		public bool Equals(InputAction other); // 0x0000000181CD2BE0-0x0000000181CD2CA0
		public bool Equals(InputActionReference other); // 0x0000000181CD2CA0-0x0000000181CD2D00
		public override bool Equals(object obj); // 0x0000000181CD2AD0-0x0000000181CD2BE0
		public override int GetHashCode(); // 0x0000000181CD2D00-0x0000000181CD2DA0
		public static bool operator ==(InputActionProperty left, InputActionProperty right); // 0x0000000181CD2EC0-0x0000000181CD2F50
		public static bool operator !=(InputActionProperty left, InputActionProperty right); // 0x0000000181CD2F50-0x0000000181CD2FE0
	}
}
