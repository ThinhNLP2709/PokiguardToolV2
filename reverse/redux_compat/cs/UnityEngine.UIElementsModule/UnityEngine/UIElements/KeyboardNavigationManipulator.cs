/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class KeyboardNavigationManipulator : Manipulator // TypeDefIndex: 4221
	{
		// Fields
		private readonly Action<KeyboardNavigationOperation, EventBase> m_Action; // 0x18
		private static readonly EventCallbackGroupFactory<KeyboardNavigationManipulator> k_CallbackFactory; // 0x00
		private EventCallbackGroupFactory<KeyboardNavigationManipulator> m_RegisteredCallbacks; // 0x20
	
		// Nested types
		private class Callbacks // TypeDefIndex: 4222
		{
			// Fields
			public readonly EventCallbackGroup OnNavigationKeyDown; // 0x10
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 4223
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static EventCallback<NavigationMoveEvent, KeyboardNavigationManipulator> __9__1_0; // 0x08
				public static EventCallback<NavigationSubmitEvent, KeyboardNavigationManipulator> __9__1_1; // 0x10
				public static EventCallback<NavigationCancelEvent, KeyboardNavigationManipulator> __9__1_2; // 0x18
				public static EventCallback<KeyDownEvent, KeyboardNavigationManipulator> __9__1_3; // 0x20
	
				// Constructors
				static __c(); // 0x00000001824BE6C0-0x00000001824BE730
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _.ctor_b__1_0(NavigationMoveEvent e, KeyboardNavigationManipulator self); // 0x00000001824BE210-0x00000001824BE2E0
				internal void _.ctor_b__1_1(NavigationSubmitEvent e, KeyboardNavigationManipulator self); // 0x00000001824BE2E0-0x00000001824BE320
				internal void _.ctor_b__1_2(NavigationCancelEvent e, KeyboardNavigationManipulator self); // 0x00000001824BE320-0x00000001824BE360
				internal void _.ctor_b__1_3(KeyDownEvent e, KeyboardNavigationManipulator self); // 0x00000001824BE360-0x00000001824BE4A0
			}
	
			// Constructors
			public Callbacks(EventArg<KeyboardNavigationManipulator> arg); // 0x00000001824ACDD0-0x00000001824AD1C0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4224
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824BE5E0-0x00000001824BE650
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal EventCallbackGroup _.cctor_b__12_0(EventArg<KeyboardNavigationManipulator> arg); // 0x00000001824BDF80-0x00000001824BE000
		}
	
		[CompilerGenerated]
		private struct __c__DisplayClass7_0 // TypeDefIndex: 4225
		{
			// Fields
			public KeyDownEvent evt; // 0x00
		}
	
		// Constructors
		public KeyboardNavigationManipulator(Action<KeyboardNavigationOperation, EventBase> action); // 0x0000000180D9D6B0-0x0000000180D9D6F0
		static KeyboardNavigationManipulator(); // 0x00000001824B3420-0x00000001824B3520
	
		// Methods
		protected override void RegisterCallbacksOnTarget(); // 0x00000001824B3280-0x00000001824B3310
		protected override void UnregisterCallbacksFromTarget(); // 0x00000001824B33E0-0x00000001824B3420
		internal void OnKeyDown(KeyDownEvent evt); // 0x00000001824B3020-0x00000001824B3150
		private void OnNavigationCancel(NavigationCancelEvent evt); // 0x00000001824B3150-0x00000001824B3180
		private void OnNavigationSubmit(NavigationSubmitEvent evt); // 0x00000001824B3250-0x00000001824B3280
		private void OnNavigationMove(NavigationMoveEvent evt); // 0x00000001824B3180-0x00000001824B3250
		private void Invoke(KeyboardNavigationOperation operation, EventBase evt); // 0x00000001824B3000-0x00000001824B3020
		[CompilerGenerated]
		internal static KeyboardNavigationOperation _OnKeyDown_g__GetOperation_7_0(ref __c__DisplayClass7_0 param_00006ad5); // 0x00000001824B3310-0x00000001824B33E0
	}
}
