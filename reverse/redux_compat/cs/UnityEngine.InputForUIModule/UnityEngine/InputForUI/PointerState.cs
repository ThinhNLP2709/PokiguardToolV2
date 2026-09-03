/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	internal struct PointerState // TypeDefIndex: 15297
	{
		// Fields
		[CompilerGenerated]
		private PointerEvent.Button _LastPressedButton_k__BackingField; // 0x00
		private PointerEvent.ButtonsState _buttonsState; // 0x04
		[CompilerGenerated]
		private DiscreteTime _NextPressTime_k__BackingField; // 0x08
		[CompilerGenerated]
		private int _ClickCount_k__BackingField; // 0x10
		[CompilerGenerated]
		private Vector2 _LastPosition_k__BackingField; // 0x14
		[CompilerGenerated]
		private int _LastDisplayIndex_k__BackingField; // 0x1C
		[CompilerGenerated]
		private bool _LastPositionValid_k__BackingField; // 0x20
		private static readonly DiscreteTime kClickDelay; // 0x00
	
		// Properties
		public PointerEvent.Button LastPressedButton { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public PointerEvent.ButtonsState ButtonsState { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public DiscreteTime NextPressTime { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181663F00-0x0000000181663F10
		public int ClickCount { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public Vector2 LastPosition { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] private set; } // 0x000000018112F6D0-0x000000018112F6F0 0x00000001822AC5C0-0x00000001822AC5D0
		public int LastDisplayIndex { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public bool LastPositionValid { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Constructors
		static PointerState(); // 0x00000001822AC520-0x00000001822AC5C0
	
		// Methods
		public void OnButtonDown(DiscreteTime currentTime, PointerEvent.Button button); // 0x00000001822AC260-0x00000001822AC390
		public void OnButtonUp(DiscreteTime currentTime, PointerEvent.Button button); // 0x00000001822AC390-0x00000001822AC3F0
		public void OnButtonChange(DiscreteTime currentTime, PointerEvent.Button button, bool previousState, bool newState); // 0x00000001822AC170-0x00000001822AC260
		public void OnMove(DiscreteTime currentTime, Vector2 position, int displayIndex); // 0x00000001822AC3F0-0x00000001822AC460
		public void Reset(); // 0x00000001822AC460-0x00000001822AC520
	}
}
