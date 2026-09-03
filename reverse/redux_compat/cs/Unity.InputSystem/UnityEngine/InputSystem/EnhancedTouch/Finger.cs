/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.EnhancedTouch
{
	public class Finger // TypeDefIndex: 6359
	{
		// Fields
		[CompilerGenerated]
		private readonly Touchscreen _screen_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly int _index_k__BackingField; // 0x18
		internal readonly InputStateHistory<TouchState> m_StateHistory; // 0x20
	
		// Properties
		public Touchscreen screen { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public int index { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
		public bool isActive { get; } // 0x0000000181DC5480-0x0000000181DC5500 
		public Vector2 screenPosition { get; } // 0x0000000181DC55F0-0x0000000181DC56F0 
		public Touch lastTouch { get; } // 0x0000000181DC5500-0x0000000181DC55F0 
		public Touch currentTouch { get; } // 0x0000000181DC5280-0x0000000181DC5480 
		public TouchHistory touchHistory { get; } // 0x0000000181DC56F0-0x0000000181DC5770 
	
		// Constructors
		internal Finger(Touchscreen screen, int index, InputUpdateType updateMask); // 0x0000000181DC4F40-0x0000000181DC5280
	
		// Methods
		private static bool ShouldRecordTouch(InputControl control, double time, InputEventPtr eventPtr); // 0x0000000181DC4EA0-0x0000000181DC4F40
		private void OnTouchRecorded(InputStateHistory.Record record); // 0x0000000181DC4C10-0x0000000181DC4EA0
		private Touch FindTouch(uint uniqueId); // 0x0000000181DC4690-0x0000000181DC4950
		internal TouchHistory GetTouchHistory(Touch touch); // 0x0000000181DC4950-0x0000000181DC4C10
	}
}
