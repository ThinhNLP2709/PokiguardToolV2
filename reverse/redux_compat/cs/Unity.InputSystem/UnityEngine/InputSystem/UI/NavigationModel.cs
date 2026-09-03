/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	internal struct NavigationModel // TypeDefIndex: 6308
	{
		// Fields
		public Vector2 move; // 0x00
		public int consecutiveMoveCount; // 0x08
		public MoveDirection lastMoveDirection; // 0x0C
		public float lastMoveTime; // 0x10
		public AxisEventData eventData; // 0x18
		public InputDevice device; // 0x20
	
		// Methods
		public void Reset(); // 0x0000000181DB5E20-0x0000000181DB5E50
	}
}
