/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class MatchPrepBridge // TypeDefIndex: 405
{
	// Fields
	private const float TIMEOUT_SECONDS = 10f; // Metadata: 0x0064C2C2

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 406
	{
		// Fields
		public bool done; // 0x10
		public MatchPrepDataDTO result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestMatchPrep_b__0(MatchPrepDataDTO data); // 0x00000001803445F0-0x00000001803446C0
		internal void _RequestMatchPrep_b__1(string reason); // 0x00000001803446C0-0x00000001803446E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass2_0 // TypeDefIndex: 407
	{
		// Fields
		public bool done; // 0x10
		public List<WorldBossDTO> result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass2_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestWorldBossList_b__0(List<WorldBossDTO> data); // 0x00000001802FB060-0x00000001802FB080
		internal void _RequestWorldBossList_b__1(string reason); // 0x00000001803446C0-0x00000001803446E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass3_0 // TypeDefIndex: 408
	{
		// Fields
		public bool done; // 0x10
		public bool ok; // 0x11
		public string errMsg; // 0x18

		// Constructors
		public __c__DisplayClass3_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestWorldBossDamageSubmit_b__0(ChatMessageDTO msg); // 0x00000001803468D0-0x00000001803468E0
		internal void _RequestWorldBossDamageSubmit_b__1(string reason); // 0x00000001802FB060-0x00000001802FB080
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass4_0 // TypeDefIndex: 409
	{
		// Fields
		public bool done; // 0x10
		public PvpProfileDTO result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass4_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestPvpProfile_b__0(PvpProfileDTO data); // 0x00000001802FB060-0x00000001802FB080
		internal void _RequestPvpProfile_b__1(string reason); // 0x00000001803446C0-0x00000001803446E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 410
	{
		// Fields
		public bool done; // 0x10
		public PetRewardDataDTO result; // 0x18
		public string errMsg; // 0x20

		// Constructors
		public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _RequestMatchReward_b__0(PetRewardDataDTO data); // 0x00000001802FB060-0x00000001802FB080
		internal void _RequestMatchReward_b__1(string reason); // 0x00000001803446C0-0x00000001803446E0
	}

	[CompilerGenerated]
	private sealed class _RequestMatchPrep_d__1 : IEnumerator<object> // TypeDefIndex: 411
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestMatchPrep_d__1(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180341810-0x0000000180341950
		private bool MoveNext(); // 0x0000000180340EC0-0x00000001803417D0
		private void __m__Finally1(); // 0x0000000180341950-0x00000001803419A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803417D0-0x0000000180341810
	}

	[CompilerGenerated]
	private sealed class _RequestMatchReward_d__5 : IEnumerator<object> // TypeDefIndex: 412
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<string> onError; // 0x20
		public long petId; // 0x28
		public bool victory; // 0x30
		public long t; // 0x38
		public string s; // 0x40
		private __c__DisplayClass5_0 __8__1; // 0x48
		public Action<PetRewardDataDTO> onSuccess; // 0x50
		private ChatService _chat_5__2; // 0x58
		private Action<PetRewardDataDTO> _okHandler_5__3; // 0x60
		private Action<string> _failHandler_5__4; // 0x68
		private float _elapsed_5__5; // 0x70

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestMatchReward_d__5(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180341F20-0x0000000180342060
		private bool MoveNext(); // 0x00000001803419A0-0x0000000180341EE0
		private void __m__Finally1(); // 0x0000000180342060-0x00000001803420B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180341EE0-0x0000000180341F20
	}

	[CompilerGenerated]
	private sealed class _RequestPvpProfile_d__4 : IEnumerator<object> // TypeDefIndex: 413
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestPvpProfile_d__4(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180342680-0x00000001803427C0
		private bool MoveNext(); // 0x00000001803420B0-0x0000000180342640
		private void __m__Finally1(); // 0x00000001803427C0-0x0000000180342810
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180342640-0x0000000180342680
	}

	[CompilerGenerated]
	private sealed class _RequestWorldBossDamageSubmit_d__3 : IEnumerator<object> // TypeDefIndex: 414
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestWorldBossDamageSubmit_d__3(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180342D90-0x0000000180342ED0
		private bool MoveNext(); // 0x0000000180342810-0x0000000180342D50
		private void __m__Finally1(); // 0x0000000180342ED0-0x0000000180342F20
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180342D50-0x0000000180342D90
	}

	[CompilerGenerated]
	private sealed class _RequestWorldBossList_d__2 : IEnumerator<object> // TypeDefIndex: 415
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RequestWorldBossList_d__2(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180343670-0x00000001803437B0
		private bool MoveNext(); // 0x0000000180342F20-0x0000000180343630
		private void __m__Finally1(); // 0x00000001803437B0-0x0000000180343800
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180343630-0x0000000180343670
	}

	// Methods
	[IteratorStateMachine(typeof(_RequestMatchPrep_d__1))]
	public static IEnumerator RequestMatchPrep(long userPetId, long enemyPetId, long? bossScheduleId, string mode, Action<MatchPrepDataDTO> onSuccess, Action<string> onError); // 0x00000001803349F0-0x0000000180334AC0
	[IteratorStateMachine(typeof(_RequestWorldBossList_d__2))]
	public static IEnumerator RequestWorldBossList(Action<List<WorldBossDTO>> onSuccess, Action<string> onError); // 0x0000000180334CE0-0x0000000180334D70
	[IteratorStateMachine(typeof(_RequestWorldBossDamageSubmit_d__3))]
	public static IEnumerator RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount, Action onSuccess, Action<string> onError); // 0x0000000180334C20-0x0000000180334CE0
	[IteratorStateMachine(typeof(_RequestPvpProfile_d__4))]
	public static IEnumerator RequestPvpProfile(long? targetUserId, Action<PvpProfileDTO> onSuccess, Action<string> onError); // 0x0000000180334B80-0x0000000180334C20
	[IteratorStateMachine(typeof(_RequestMatchReward_d__5))]
	public static IEnumerator RequestMatchReward(long petId, bool victory, long t, string s, Action<PetRewardDataDTO> onSuccess, Action<string> onError); // 0x0000000180334AC0-0x0000000180334B80
}

