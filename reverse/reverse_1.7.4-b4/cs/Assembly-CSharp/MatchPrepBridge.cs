/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class MatchPrepBridge // TypeDefIndex: 530
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 531
	{
		// Fields
		public bool done; // 0x10
		public MatchPrepDataDTO result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass1_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestMatchPrep_b__0(MatchPrepDataDTO data); // 0x00000001803C2C50-0x00000001803C2EA0
		internal void _RequestMatchPrep_b__1(string reason); // 0x00000001803C2EA0-0x00000001803C2F00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 532
	{
		// Fields
		public bool done; // 0x10
		public List<WorldBossDTO> result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass2_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestWorldBossList_b__0(List<WorldBossDTO> data); // 0x00000001802B4FE0-0x00000001802B5040
		internal void _RequestWorldBossList_b__1(string reason); // 0x00000001803C2EA0-0x00000001803C2F00
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass3_0 // TypeDefIndex: 533
	{
		// Fields
		public bool done; // 0x10
		public bool ok; // 0x11
		public string errMsg; // 0x18

		// Constructors
		public __c__DisplayClass3_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestWorldBossDamageSubmit_b__0(ChatMessageDTO msg); // 0x00000001803C2F00-0x00000001803C2F10
		internal void _RequestWorldBossDamageSubmit_b__1(string reason); // 0x00000001802B4FE0-0x00000001802B5040
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass4_0 // TypeDefIndex: 534
	{
		// Fields
		public bool done; // 0x10
		public PvpProfileDTO result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass4_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RequestPvpProfile_b__0(PvpProfileDTO data); // 0x00000001802B4FE0-0x00000001802B5040
		internal void _RequestPvpProfile_b__1(string reason); // 0x00000001803C2EA0-0x00000001803C2F00
	}

	[CompilerGenerated]
	private sealed class _RequestMatchPrep_d__1 : IEnumerator<object> // TypeDefIndex: 535
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		private __c__DisplayClass1_0 __8__1; // 0x28
		public long userPetId; // 0x30
		public long enemyPetId; // 0x38
		public long? bossScheduleId; // 0x40
		public string mode; // 0x50
		public Action<MatchPrepDataDTO> onSuccess; // 0x58
		private ChatService _chat_5__2; // 0x60
		private Action<MatchPrepDataDTO> _okHandler_5__3; // 0x68
		private Action<string> _failHandler_5__4; // 0x70
		private float _waitElapsed_5__5; // 0x78
		private bool _resentAfterReconnect_5__6; // 0x7C
		private float _wait_5__7; // 0x80

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RequestMatchPrep_d__1(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803C2F10-0x00000001803C30E0
		private bool MoveNext(); // 0x00000001803C30E0-0x00000001803C3E00
		private void __m__Finally1(); // 0x00000001803C3E00-0x00000001803C4030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C4030-0x00000001803C4070
	}

	[CompilerGenerated]
	private sealed class _RequestPvpProfile_d__4 : IEnumerator<object> // TypeDefIndex: 536
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public long? targetUserId; // 0x28
		private __c__DisplayClass4_0 __8__1; // 0x38
		public Action<PvpProfileDTO> onSuccess; // 0x40
		private ChatService _chat_5__2; // 0x48
		private Action<PvpProfileDTO> _okHandler_5__3; // 0x50
		private Action<string> _failHandler_5__4; // 0x58
		private float _elapsed_5__5; // 0x60

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RequestPvpProfile_d__4(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803C4070-0x00000001803C4240
		private bool MoveNext(); // 0x00000001803C4240-0x00000001803C4BF0
		private void __m__Finally1(); // 0x00000001803C4BF0-0x00000001803C4E20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C4E20-0x00000001803C4E60
	}

	[CompilerGenerated]
	private sealed class _RequestWorldBossDamageSubmit_d__3 : IEnumerator<object> // TypeDefIndex: 537
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public long bossScheduleId; // 0x28
		public int totalDamage; // 0x30
		public bool victory; // 0x34
		public int turnCount; // 0x38
		private __c__DisplayClass3_0 __8__1; // 0x40
		public Action onSuccess; // 0x48
		private ChatService _chat_5__2; // 0x50
		private Action<ChatMessageDTO> _okHandler_5__3; // 0x58
		private Action<string> _failHandler_5__4; // 0x60
		private float _elapsed_5__5; // 0x68

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RequestWorldBossDamageSubmit_d__3(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803C4E60-0x00000001803C5030
		private bool MoveNext(); // 0x00000001803C5030-0x00000001803C5870
		private void __m__Finally1(); // 0x00000001803C5870-0x00000001803C5AA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C5AA0-0x00000001803C5AE0
	}

	[CompilerGenerated]
	private sealed class _RequestWorldBossList_d__2 : IEnumerator<object> // TypeDefIndex: 538
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		private __c__DisplayClass2_0 __8__1; // 0x28
		public Action<List<WorldBossDTO>> onSuccess; // 0x30
		private ChatService _chat_5__2; // 0x38
		private Action<List<WorldBossDTO>> _okHandler_5__3; // 0x40
		private Action<string> _failHandler_5__4; // 0x48
		private float _waitElapsed_5__5; // 0x50
		private bool _resentAfterReconnect_5__6; // 0x54
		private float _wait_5__7; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RequestWorldBossList_d__2(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803C5AE0-0x00000001803C5CB0
		private bool MoveNext(); // 0x00000001803C5CB0-0x00000001803C67E0
		private void __m__Finally1(); // 0x00000001803C67E0-0x00000001803C6A10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C6A10-0x00000001803C6A50
	}

	// Methods
	[IteratorStateMachine(typeof(_RequestMatchPrep_d__1))]
	public static IEnumerator RequestMatchPrep(long userPetId, long enemyPetId, long? bossScheduleId, string mode, Action<MatchPrepDataDTO> onSuccess, Action<string> onError); // 0x00000001803C2760-0x00000001803C28F0
	[IteratorStateMachine(typeof(_RequestWorldBossList_d__2))]
	public static IEnumerator RequestWorldBossList(Action<List<WorldBossDTO>> onSuccess, Action<string> onError); // 0x00000001803C28F0-0x00000001803C2A00
	[IteratorStateMachine(typeof(_RequestWorldBossDamageSubmit_d__3))]
	public static IEnumerator RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount, Action onSuccess, Action<string> onError); // 0x00000001803C2A00-0x00000001803C2B40
	[IteratorStateMachine(typeof(_RequestPvpProfile_d__4))]
	public static IEnumerator RequestPvpProfile(long? targetUserId, Action<PvpProfileDTO> onSuccess, Action<string> onError); // 0x00000001803C2B40-0x00000001803C2C50
}

