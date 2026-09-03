/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	internal struct NavigationEvent : IEventProperties // TypeDefIndex: 15273
	{
		// Fields
		public Type type; // 0x00
		public Direction direction; // 0x04
		public bool shouldBeUsed; // 0x08
		[CompilerGenerated]
		private DiscreteTime _timestamp_k__BackingField; // 0x10
		[CompilerGenerated]
		private EventSource _eventSource_k__BackingField; // 0x18
		[CompilerGenerated]
		private uint _playerId_k__BackingField; // 0x1C
		[CompilerGenerated]
		private EventModifiers _eventModifiers_k__BackingField; // 0x20
	
		// Properties
		public DiscreteTime timestamp { [CompilerGenerated] set; } // 0x0000000180719060-0x0000000180719070
		public EventSource eventSource { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public uint playerId { [CompilerGenerated] set; } // 0x0000000180E025C0-0x0000000180E025D0
		public EventModifiers eventModifiers { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
	
		// Nested types
		public enum Type // TypeDefIndex: 15274
		{
			Move = 1,
			Submit = 2,
			Cancel = 3
		}
	
		public enum Direction // TypeDefIndex: 15275
		{
			None = 0,
			Left = 1,
			Up = 2,
			Right = 3,
			Down = 4,
			Next = 5,
			Previous = 6
		}
	
		// Methods
		public override string ToString(); // 0x00000001822AAE30-0x00000001822AAF50
		internal static Direction DetermineMoveDirection(Vector2 vec, float deadZone = 0.6f /* Metadata: 0x006A9F34 */); // 0x00000001822AADC0-0x00000001822AAE30
	}
}
