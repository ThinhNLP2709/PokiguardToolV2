/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class Clickable : PointerManipulator // TypeDefIndex: 3865
	{
		// Fields
		[CompilerGenerated]
		private Action<EventBase> clickedWithEventInfo; // 0x28
		[CompilerGenerated]
		private Action clicked; // 0x30
		private readonly long m_Delay; // 0x38
		private readonly long m_Interval; // 0x40
		[CompilerGenerated]
		private bool _active_k__BackingField; // 0x48
		[CompilerGenerated]
		private Vector2 _lastMousePosition_k__BackingField; // 0x4C
		private int m_ActivePointerId; // 0x54
		private bool m_AcceptClicksIfDisabled; // 0x58
		private IVisualElementScheduledItem m_Repeater; // 0x60
		private IVisualElementScheduledItem m_PendingActivePseudoStateReset; // 0x68
		private static readonly EventCallbackGroupFactory<Clickable> k_DefaultCallbackFactory; // 0x00
		private static readonly EventCallbackGroupFactory<Clickable> k_IncludeDisabledCallbackFactory; // 0x08
		private EventCallbackGroupFactory<Clickable> m_RegisteredCallbacks; // 0x70
	
		// Properties
		protected bool active { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
		public Vector2 lastMousePosition { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001823846F0-0x0000000182384710 0x0000000182384810-0x0000000182384820
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal bool acceptClicksIfDisabled { get; set; } // 0x0000000181424750-0x0000000181424760 0x00000001823847B0-0x0000000182384810
	
		// Events
		public event Action clicked {
			add; // 0x0000000182384650-0x00000001823846F0
			remove; // 0x0000000182384710-0x00000001823847B0
		}
	
		// Nested types
		private class Callbacks // TypeDefIndex: 3866
		{
			// Fields
			public readonly EventCallbackGroup OnPointer; // 0x10
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 3867
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static EventCallback<PointerDownEvent, Clickable> __9__1_0; // 0x08
				public static EventCallback<PointerMoveEvent, Clickable> __9__1_1; // 0x10
				public static EventCallback<PointerUpEvent, Clickable> __9__1_2; // 0x18
				public static EventCallback<PointerCancelEvent, Clickable> __9__1_3; // 0x20
				public static EventCallback<PointerCaptureOutEvent, Clickable> __9__1_4; // 0x28
	
				// Constructors
				static __c(); // 0x00000001823935A0-0x0000000182393610
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.ctor_b__1_0(PointerDownEvent e, Clickable self); // 0x0000000182393230-0x00000001823932B0
				internal void _.ctor_b__1_1(PointerMoveEvent e, Clickable self); // 0x00000001823932B0-0x0000000182393310
				internal void _.ctor_b__1_2(PointerUpEvent e, Clickable self); // 0x0000000182393310-0x0000000182393390
				internal void _.ctor_b__1_3(PointerCancelEvent e, Clickable self); // 0x0000000182393390-0x0000000182393400
				internal void _.ctor_b__1_4(PointerCaptureOutEvent e, Clickable self); // 0x0000000182393400-0x0000000182393450
			}
	
			// Constructors
			public Callbacks(EventArg<Clickable> arg, bool acceptClicksIfDisabled); // 0x0000000182381CF0-0x00000001823821B0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3868
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000182393530-0x00000001823935A0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal EventCallbackGroup _.cctor_b__52_0(EventArg<Clickable> arg); // 0x0000000182392ED0-0x0000000182392F50
			internal EventCallbackGroup _.cctor_b__52_1(EventArg<Clickable> arg); // 0x0000000182392F50-0x0000000182392FD0
		}
	
		// Constructors
		public Clickable(Action handler, long delay, long interval); // 0x00000001823843F0-0x0000000182384530
		public Clickable(Action handler); // 0x0000000182384530-0x0000000182384650
		static Clickable(); // 0x0000000182384270-0x00000001823843F0
	
		// Methods
		private void OnTimer(TimerState timerState); // 0x00000001823839A0-0x0000000182383AA0
		private bool IsRepeatable(); // 0x0000000182383790-0x00000001823837B0
		protected override void RegisterCallbacksOnTarget(); // 0x00000001823840F0-0x00000001823841B0
		protected override void UnregisterCallbacksFromTarget(); // 0x0000000182384200-0x0000000182384270
		protected void OnPointerDown(PointerDownEvent evt); // 0x0000000182383850-0x00000001823838D0
		protected void OnPointerMove(PointerMoveEvent evt); // 0x00000001823838D0-0x0000000182383920
		protected void OnPointerUp(PointerUpEvent evt); // 0x0000000182383920-0x00000001823839A0
		private void OnPointerCancel(PointerCancelEvent evt); // 0x00000001823837B0-0x0000000182383810
		private void OnPointerCaptureOut(PointerCaptureOutEvent evt); // 0x0000000182383810-0x0000000182383850
		private bool ContainsPointer(int pointerId); // 0x00000001823836E0-0x0000000182383740
		protected void Invoke(EventBase evt); // 0x0000000182383740-0x0000000182383790
		private void ResetActivePseudoState(); // 0x00000001823841B0-0x0000000182384200
		protected virtual void ProcessDownEvent(EventBase evt, Vector2 localPosition, int pointerId); // 0x0000000182383B90-0x0000000182383ED0
		protected virtual void ProcessMoveEvent(EventBase evt, Vector2 localPosition); // 0x0000000182383ED0-0x0000000182383F60
		protected virtual void ProcessUpEvent(EventBase evt, Vector2 localPosition, int pointerId); // 0x0000000182383F60-0x00000001823840F0
		protected virtual void ProcessCancelEvent(EventBase evt, int pointerId); // 0x0000000182383AA0-0x0000000182383B90
	}
}
