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
	internal struct TextInputEvent : IEventProperties // TypeDefIndex: 15280
	{
		// Fields
		public char character; // 0x00
		[CompilerGenerated]
		private DiscreteTime _timestamp_k__BackingField; // 0x08
		[CompilerGenerated]
		private EventSource _eventSource_k__BackingField; // 0x10
		[CompilerGenerated]
		private uint _playerId_k__BackingField; // 0x14
		[CompilerGenerated]
		private EventModifiers _eventModifiers_k__BackingField; // 0x18
	
		// Properties
		public DiscreteTime timestamp { [CompilerGenerated] set; } // 0x0000000181663F00-0x0000000181663F10
		public EventSource eventSource { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public uint playerId { [CompilerGenerated] set; } // 0x0000000180E02550-0x0000000180E02560
		public EventModifiers eventModifiers { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Methods
		public override string ToString(); // 0x00000001822AC5D0-0x00000001822AC670
	}
}
