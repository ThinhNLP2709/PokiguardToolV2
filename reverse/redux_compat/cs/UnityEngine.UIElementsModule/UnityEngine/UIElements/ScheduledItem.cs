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
	internal abstract class ScheduledItem // TypeDefIndex: 4344
	{
		// Fields
		public Func<bool> timerUpdateStopCondition; // 0x10
		public static readonly Func<bool> OnceCondition; // 0x00
		public static readonly Func<bool> ForeverCondition; // 0x08
		[CompilerGenerated]
		private long _startMs_k__BackingField; // 0x18
		[CompilerGenerated]
		private long _delayMs_k__BackingField; // 0x20
		[CompilerGenerated]
		private long _intervalMs_k__BackingField; // 0x28
		[CompilerGenerated]
		private long _endTimeMs_k__BackingField; // 0x30
	
		// Properties
		public long startMs { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001804C2E30-0x00000001804C2E40
		public long delayMs { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181727440-0x0000000181727450
		public long intervalMs { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x0000000181C854D0-0x0000000181C854E0
		public long endTimeMs { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4345
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824DF020-0x00000001824DF090
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.cctor_b__26_0(); // 0x00000001802E7990-0x00000001802E79A0
			internal bool _.cctor_b__26_1(); // 0x00000001802E7840-0x00000001802E7850
		}
	
		// Constructors
		public ScheduledItem(long startMs); // 0x00000001824DCD10-0x00000001824DCD90
		static ScheduledItem(); // 0x00000001824DCBD0-0x00000001824DCD10
	
		// Methods
		protected void ResetStartTime(long startMs); // 0x00000001804C2E30-0x00000001804C2E40
		public abstract void PerformTimerUpdate(TimerState state);
		internal virtual void OnItemUnscheduled(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual bool ShouldUnschedule(); // 0x00000001824DCBB0-0x00000001824DCBD0
	}
}
