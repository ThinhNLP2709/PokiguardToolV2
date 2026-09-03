/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(MouseState), isGenericTypeOfDevice = true)]
	public class Mouse : Pointer, IInputStateCallbackReceiver // TypeDefIndex: 6165
	{
		// Fields
		[CompilerGenerated]
		private DeltaControl _scroll_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ButtonControl _leftButton_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private ButtonControl _middleButton_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private ButtonControl _rightButton_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private ButtonControl _backButton_k__BackingField; // 0x1E0
		[CompilerGenerated]
		private ButtonControl _forwardButton_k__BackingField; // 0x1E8
		[CompilerGenerated]
		private IntegerControl _clickCount_k__BackingField; // 0x1F0
		[CompilerGenerated]
		private static Mouse _current_k__BackingField; // 0x00
		internal static Mouse s_PlatformMouseDevice; // 0x08
	
		// Properties
		public DeltaControl scroll { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		public ButtonControl leftButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		public ButtonControl middleButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		public ButtonControl rightButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB2290-0x0000000181CB22A0 0x0000000181380210-0x0000000181380230
		public ButtonControl backButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22B0-0x0000000181CB22C0 0x0000000181CB2330-0x0000000181CB2350
		public ButtonControl forwardButton { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D460-0x000000018033D470 0x0000000181CB2350-0x0000000181CB2370
		public IntegerControl clickCount { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22E0-0x0000000181CB22F0 0x0000000181CB2370-0x0000000181CB2390
		public static new Mouse current { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D84C10-0x0000000181D84C50 0x0000000181D84C50-0x0000000181D84CB0
	
		// Constructors
		public Mouse(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D848C0-0x0000000181D84960
		protected override void OnAdded(); // 0x0000000181D84960-0x0000000181D849E0
		protected override void OnRemoved(); // 0x0000000181D84AB0-0x0000000181D84B40
		public void WarpCursorPosition(Vector2 position); // 0x0000000181D84BD0-0x0000000181D84C10
		protected override void FinishSetup(); // 0x0000000181D846B0-0x0000000181D848C0
		protected new void OnNextUpdate(); // 0x0000000181D849E0-0x0000000181D84AB0
		protected new void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D84B40-0x0000000181D84BC0
		new void IInputStateCallbackReceiver.OnNextUpdate(); // 0x0000000181D849E0-0x0000000181D84AB0
		new void IInputStateCallbackReceiver.OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D84BC0-0x0000000181D84BD0
	}
}
