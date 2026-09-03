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
	public class InputActionReference : ScriptableObject // TypeDefIndex: 6083
	{
		// Fields
		[SerializeField]
		internal InputActionAsset m_Asset; // 0x18
		[SerializeField]
		internal string m_ActionId; // 0x20
		[NonSerialized]
		private InputAction m_Action; // 0x28
	
		// Properties
		public InputActionAsset asset { get; } // 0x0000000181CD3CF0-0x0000000181CD3D20 
		public InputAction action { get; } // 0x0000000181CD3B80-0x0000000181CD3CF0 
	
		// Constructors
		public InputActionReference(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		public void Set(InputAction action); // 0x0000000181CD3450-0x0000000181CD35A0
		public void Set(InputActionAsset asset, string mapName, string actionName); // 0x0000000181CD35A0-0x0000000181CD3850
		private void SetInternal(InputActionAsset assetArg, InputAction actionArg); // 0x0000000181CD3340-0x0000000181CD3450
		public override string ToString(); // 0x0000000181CD3940-0x0000000181CD3B80
		private static string GetDisplayName(InputAction action); // 0x0000000181CD3180-0x0000000181CD3240
		internal string ToDisplayName(); // 0x0000000181CD3850-0x0000000181CD3930
		public static implicit operator InputAction(InputActionReference reference); // 0x0000000181CD3D20-0x0000000181CD3D30
		public static InputActionReference Create(InputAction action); // 0x0000000181CD2FE0-0x0000000181CD3180
		internal static void InvalidateAll(); // 0x0000000181CD3240-0x0000000181CD3340
		internal void Invalidate(); // 0x0000000180DB8550-0x0000000180DB8570
		public InputAction ToInputAction(); // 0x0000000181CD3930-0x0000000181CD3940
		private void CheckImmutableReference(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
