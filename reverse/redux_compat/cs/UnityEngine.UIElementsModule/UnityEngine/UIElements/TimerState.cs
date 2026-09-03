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
	public struct TimerState : IEquatable<UnityEngine.UIElements.TimerState> // TypeDefIndex: 4343
	{
		// Fields
		[CompilerGenerated]
		private long _start_k__BackingField; // 0x00
		[CompilerGenerated]
		private long _now_k__BackingField; // 0x08
	
		// Properties
		public long start { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		public long now { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181663F00-0x0000000181663F10
		public long deltaTime { get; } // 0x00000001824DE9F0-0x00000001824DEA00 
	
		// Methods
		public override bool Equals(object obj); // 0x00000001824DE8D0-0x00000001824DE970
		public bool Equals(TimerState other); // 0x00000001824DE8A0-0x00000001824DE8D0
		public override int GetHashCode(); // 0x00000001824DE970-0x00000001824DE9F0
	}
}
