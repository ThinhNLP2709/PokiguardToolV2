/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Bindings;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct KeyEvent : IEventProperties // TypeDefIndex: 15268
	{
		// Fields
		public Type type; // 0x00
		public KeyCode keyCode; // 0x04
		public ButtonsState buttonsState; // 0x08
		[CompilerGenerated]
		private DiscreteTime _timestamp_k__BackingField; // 0x30
		[CompilerGenerated]
		private EventSource _eventSource_k__BackingField; // 0x38
		[CompilerGenerated]
		private uint _playerId_k__BackingField; // 0x3C
		[CompilerGenerated]
		private EventModifiers _eventModifiers_k__BackingField; // 0x40
	
		// Properties
		public DiscreteTime timestamp { [CompilerGenerated] set; } // 0x000000018172A4B0-0x000000018172A4C0
		public EventSource eventSource { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018047EDE0-0x000000018047EDF0 0x00000001805D5570-0x00000001805D5580
		public uint playerId { [CompilerGenerated] set; } // 0x00000001805D5550-0x00000001805D5560
		public EventModifiers eventModifiers { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
	
		// Nested types
		public enum Type // TypeDefIndex: 15269
		{
			KeyPressed = 1,
			KeyRepeated = 2,
			KeyReleased = 3,
			State = 4
		}
	
		public struct ButtonsState // TypeDefIndex: 15270
		{
			// Fields
			private unsafe fixed /* 0x00000000-0x00000000 */ byte buttons[0]; // 0x00
	
			// Nested types
			[CompilerGenerated]
			private sealed class _GetAllPressed_d__8 : IEnumerable<KeyCode>, IEnumerator<KeyCode> // TypeDefIndex: 15271
			{
				// Fields
				private int __1__state; // 0x10
				private KeyCode __2__current; // 0x14
				private int __l__initialThreadId; // 0x18
				public ButtonsState __4__this; // 0x1C
				public ButtonsState __3____4__this; // 0x44
				private uint _index_5__2; // 0x6C
	
				// Properties
				KeyCode IEnumerator<UnityEngine.KeyCode>.Current { [DebuggerHidden] get; } // 0x0000000180A5E110-0x0000000180A5E120 
				object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001822AC7F0-0x00000001822AC840 
	
				// Constructors
				[DebuggerHidden]
				public _GetAllPressed_d__8(int __1__state); // 0x0000000180A5E820-0x0000000180A5E850
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
				private bool MoveNext(); // 0x00000001822AC6A0-0x00000001822AC700
				[DebuggerHidden]
				void IEnumerator.Reset(); // 0x00000001822AC7B0-0x00000001822AC7F0
				[DebuggerHidden]
				IEnumerator<KeyCode> IEnumerable<KeyCode>.GetEnumerator(); // 0x00000001822AC700-0x00000001822AC7B0
				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator(); // 0x00000001822AC700-0x00000001822AC7B0
			}
	
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _buttons_e__FixedBuffer // TypeDefIndex: 15272
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
	
			// Methods
			internal static bool ShouldBeProcessed(KeyCode keyCode); // 0x00000001822A2B90-0x00000001822A2BA0
			private bool GetUnchecked(uint index); // 0x00000001822A2AC0-0x00000001822A2AE0
			private void SetUnchecked(uint index); // 0x00000001822A2B70-0x00000001822A2B90
			private void ClearUnchecked(uint index); // 0x00000001822A2A20-0x00000001822A2A40
			public bool IsPressed(KeyCode keyCode); // 0x00000001822A2AF0-0x00000001822A2B20
			[IteratorStateMachine(typeof(_GetAllPressed_d__8))]
			public IEnumerable<KeyCode> GetAllPressed(); // 0x00000001822A2A40-0x00000001822A2AC0
			public void SetPressed(KeyCode keyCode, bool pressed); // 0x00000001822A2B40-0x00000001822A2B70
			public void Reset(); // 0x00000001822A2B20-0x00000001822A2B40
			public override string ToString(); // 0x00000001822A2BA0-0x00000001822A2C60
		}
	
		// Methods
		public override string ToString(); // 0x00000001822AAA50-0x00000001822AABB0
	}
}
