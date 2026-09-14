/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGuard.Audition
{
	public static class AuditionRunner // TypeDefIndex: 2545
	{
		// Fields
		[CompilerGenerated]
		private static string _LastShownGrade_k__BackingField; // 0x00
	
		// Properties
		public static string LastShownGrade { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BC7030-0x0000000180BC7070 0x0000000180BC7070-0x0000000180BC7110
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass12_0 // TypeDefIndex: 2546
		{
			// Fields
			public IAuditionHost host; // 0x10
	
			// Constructors
			public __c__DisplayClass12_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Run_b__0(int elapsedMs); // 0x0000000180BC7D60-0x0000000180BC7FD0
		}
	
		[CompilerGenerated]
		private sealed class _Run_d__12 : IEnumerator<object> // TypeDefIndex: 2547
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public IAuditionHost host; // 0x20
			public MonoBehaviour co; // 0x28
			private __c__DisplayClass12_0 __8__1; // 0x30
			private AuditionChallenge _ch_5__2; // 0x38
			private AuditionStage _stage_5__3; // 0x40
			private bool _paused_5__4; // 0x48
			private float _durSec_5__5; // 0x4C
			private float _elapsed_5__6; // 0x50
			private bool _aborted_5__7; // 0x54
			private Coroutine _hide_5__8; // 0x58
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _Run_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180BC7FD0-0x0000000180BC8130
			private bool MoveNext(); // 0x0000000180BC8130-0x0000000180BC90A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BC90A0-0x0000000180BC90E0
		}
	
		[CompilerGenerated]
		private sealed class _TickFor_d__13 : IEnumerator<object> // TypeDefIndex: 2548
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public AuditionStage stage; // 0x20
			public float qteElapsed; // 0x28
			public float sec; // 0x2C
			private float _t_5__2; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _TickFor_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180BC90E0-0x0000000180BC9200
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180BC9200-0x0000000180BC9240
		}
	
		// Methods
		public static void ClearLastShownGrade(); // 0x0000000180BC7110-0x0000000180BC7120
		public static bool ServerSupportsV3(); // 0x0000000180BC7120-0x0000000180BC73B0
		public static void AbortFor(IAuditionHost host); // 0x0000000180BC73B0-0x0000000180BC7470
		public static void AbortAll(); // 0x0000000180BC7470-0x0000000180BC7550
		[IteratorStateMachine(typeof(_Run_d__12))]
		public static IEnumerator Run(IAuditionHost host, MonoBehaviour co); // 0x0000000180BC7550-0x0000000180BC7660
		[IteratorStateMachine(typeof(_TickFor_d__13))]
		private static IEnumerator TickFor(AuditionStage stage, float qteElapsed, float sec, IAuditionHost host); // 0x0000000180BC7660-0x0000000180BC7720
		public static string Grade(AuditionChallenge ch, bool tapped, int elapsedMs, int correct); // 0x0000000180BC7720-0x0000000180BC7870
		private static float MultFor(AuditionChallenge ch, string grade); // 0x0000000180BC7870-0x0000000180BC79D0
		private static void RelayQte(string phase, long challengeId, IAuditionHost host); // 0x0000000180BC79D0-0x0000000180BC7D60
	}
}
