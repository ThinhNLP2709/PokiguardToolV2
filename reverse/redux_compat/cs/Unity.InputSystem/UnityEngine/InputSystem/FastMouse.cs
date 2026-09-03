/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	internal class FastMouse : Mouse, IInputStateCallbackReceiver, IEventMerger // TypeDefIndex: 6170
	{
		// Fields
		public const string metadata = "AutoWindowSpace;Vector2;Delta;Button;Axis;Digital;Integer;Mouse;Pointer"; // Metadata: 0x00698B88
	
		// Constructors
		public FastMouse(); // 0x0000000181D6EEC0-0x0000000181D70380
	
		// Methods
		private Vector2Control Initialize_ctrlMouseposition(InternedString kVector2Layout, InputControl parent); // 0x0000000181D6C080-0x0000000181D6C2D0
		private DeltaControl Initialize_ctrlMousedelta(InternedString kDeltaLayout, InputControl parent); // 0x0000000181D6A370-0x0000000181D6A5A0
		private DeltaControl Initialize_ctrlMousescroll(InternedString kDeltaLayout, InputControl parent); // 0x0000000181D6D640-0x0000000181D6D860
		private ButtonControl Initialize_ctrlMousepress(InternedString kButtonLayout, InputControl parent); // 0x0000000181D6C7C0-0x0000000181D6CA30
		private ButtonControl Initialize_ctrlMouseleftButton(InternedString kButtonLayout, InputControl parent); // 0x0000000181D6B910-0x0000000181D6BBD0
		private ButtonControl Initialize_ctrlMouserightButton(InternedString kButtonLayout, InputControl parent); // 0x0000000181D6D370-0x0000000181D6D640
		private ButtonControl Initialize_ctrlMousemiddleButton(InternedString kButtonLayout, InputControl parent); // 0x0000000181D6BBD0-0x0000000181D6BE80
		private ButtonControl Initialize_ctrlMouseforwardButton(InternedString kButtonLayout, InputControl parent); // 0x0000000181D6B690-0x0000000181D6B910
		private ButtonControl Initialize_ctrlMousebackButton(InternedString kButtonLayout, InputControl parent); // 0x0000000181D69ED0-0x0000000181D6A150
		private AxisControl Initialize_ctrlMousepressure(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6CA30-0x0000000181D6CC80
		private Vector2Control Initialize_ctrlMouseradius(InternedString kVector2Layout, InputControl parent); // 0x0000000181D6CC80-0x0000000181D6CEB0
		private IntegerControl Initialize_ctrlMousepointerId(InternedString kDigitalLayout, InputControl parent); // 0x0000000181D6BE80-0x0000000181D6C080
		private IntegerControl Initialize_ctrlMousedisplayIndex(InternedString kIntegerLayout, InputControl parent); // 0x0000000181D6B480-0x0000000181D6B690
		private IntegerControl Initialize_ctrlMouseclickCount(InternedString kIntegerLayout, InputControl parent); // 0x0000000181D6A150-0x0000000181D6A370
		private AxisControl Initialize_ctrlMousepositionx(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6C2D0-0x0000000181D6C540
		private AxisControl Initialize_ctrlMousepositiony(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6C540-0x0000000181D6C7C0
		private AxisControl Initialize_ctrlMousedeltaup(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6AD40-0x0000000181D6AFC0
		private AxisControl Initialize_ctrlMousedeltadown(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6A5A0-0x0000000181D6A830
		private AxisControl Initialize_ctrlMousedeltaleft(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6A830-0x0000000181D6AAC0
		private AxisControl Initialize_ctrlMousedeltaright(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6AAC0-0x0000000181D6AD40
		private AxisControl Initialize_ctrlMousedeltax(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6AFC0-0x0000000181D6B220
		private AxisControl Initialize_ctrlMousedeltay(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6B220-0x0000000181D6B480
		private AxisControl Initialize_ctrlMousescrollup(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6E000-0x0000000181D6E280
		private AxisControl Initialize_ctrlMousescrolldown(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6D860-0x0000000181D6DAF0
		private AxisControl Initialize_ctrlMousescrollleft(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6DAF0-0x0000000181D6DD80
		private AxisControl Initialize_ctrlMousescrollright(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6DD80-0x0000000181D6E000
		private AxisControl Initialize_ctrlMousescrollx(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6E280-0x0000000181D6E4F0
		private AxisControl Initialize_ctrlMousescrolly(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6E4F0-0x0000000181D6E780
		private AxisControl Initialize_ctrlMouseradiusx(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6CEB0-0x0000000181D6D110
		private AxisControl Initialize_ctrlMouseradiusy(InternedString kAxisLayout, InputControl parent); // 0x0000000181D6D110-0x0000000181D6D370
		protected new void OnNextUpdate(); // 0x0000000181D6E8C0-0x0000000181D6E9E0
		protected new void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D6E9E0-0x0000000181D6EBB0
		new void IInputStateCallbackReceiver.OnNextUpdate(); // 0x0000000181D6E8C0-0x0000000181D6E9E0
		new void IInputStateCallbackReceiver.OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D6ECF0-0x0000000181D6EEC0
		internal static bool MergeForward(InputEventPtr currentEventPtr, InputEventPtr nextEventPtr); // 0x0000000181D6E780-0x0000000181D6E8C0
		bool IEventMerger.MergeForward(InputEventPtr currentEventPtr, InputEventPtr nextEventPtr); // 0x0000000181D6EBB0-0x0000000181D6ECF0
	}
}
