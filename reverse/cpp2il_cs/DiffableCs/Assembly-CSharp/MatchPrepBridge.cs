//Type is in global namespace

public static class MatchPrepBridge
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public bool done; //Field offset: 0x10
		public MatchPrepDataDTO result; //Field offset: 0x18
		public string errMsg; //Field offset: 0x20

		public <>c__DisplayClass1_0() { }

		internal void <RequestMatchPrep>b__0(MatchPrepDataDTO data) { }

		internal void <RequestMatchPrep>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public bool done; //Field offset: 0x10
		public List<WorldBossDTO> result; //Field offset: 0x18
		public string errMsg; //Field offset: 0x20

		public <>c__DisplayClass2_0() { }

		internal void <RequestWorldBossList>b__0(List<WorldBossDTO> data) { }

		internal void <RequestWorldBossList>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public bool done; //Field offset: 0x10
		public bool ok; //Field offset: 0x11
		public string errMsg; //Field offset: 0x18

		public <>c__DisplayClass3_0() { }

		internal void <RequestWorldBossDamageSubmit>b__0(ChatMessageDTO msg) { }

		internal void <RequestWorldBossDamageSubmit>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public bool done; //Field offset: 0x10
		public PvpProfileDTO result; //Field offset: 0x18
		public string errMsg; //Field offset: 0x20

		public <>c__DisplayClass4_0() { }

		internal void <RequestPvpProfile>b__0(PvpProfileDTO data) { }

		internal void <RequestPvpProfile>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public bool done; //Field offset: 0x10
		public PetRewardDataDTO result; //Field offset: 0x18
		public string errMsg; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <RequestMatchReward>b__0(PetRewardDataDTO data) { }

		internal void <RequestMatchReward>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <RequestMatchPrep>d__1 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		private <>c__DisplayClass1_0 <>8__1; //Field offset: 0x28
		public long userPetId; //Field offset: 0x30
		public long enemyPetId; //Field offset: 0x38
		public Nullable<Int64> bossScheduleId; //Field offset: 0x40
		public string mode; //Field offset: 0x50
		public Action<MatchPrepDataDTO> onSuccess; //Field offset: 0x58
		private ChatService <chat>5__2; //Field offset: 0x60
		private Action<MatchPrepDataDTO> <okHandler>5__3; //Field offset: 0x68
		private Action<String> <failHandler>5__4; //Field offset: 0x70
		private float <waitElapsed>5__5; //Field offset: 0x78
		private bool <resentAfterReconnect>5__6; //Field offset: 0x7C
		private float <wait>5__7; //Field offset: 0x80

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RequestMatchPrep>d__1(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RequestMatchReward>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		public long petId; //Field offset: 0x28
		public bool victory; //Field offset: 0x30
		public long t; //Field offset: 0x38
		public string s; //Field offset: 0x40
		private <>c__DisplayClass5_0 <>8__1; //Field offset: 0x48
		public Action<PetRewardDataDTO> onSuccess; //Field offset: 0x50
		private ChatService <chat>5__2; //Field offset: 0x58
		private Action<PetRewardDataDTO> <okHandler>5__3; //Field offset: 0x60
		private Action<String> <failHandler>5__4; //Field offset: 0x68
		private float <elapsed>5__5; //Field offset: 0x70

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RequestMatchReward>d__5(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RequestPvpProfile>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		public Nullable<Int64> targetUserId; //Field offset: 0x28
		private <>c__DisplayClass4_0 <>8__1; //Field offset: 0x38
		public Action<PvpProfileDTO> onSuccess; //Field offset: 0x40
		private ChatService <chat>5__2; //Field offset: 0x48
		private Action<PvpProfileDTO> <okHandler>5__3; //Field offset: 0x50
		private Action<String> <failHandler>5__4; //Field offset: 0x58
		private float <elapsed>5__5; //Field offset: 0x60

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RequestPvpProfile>d__4(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RequestWorldBossDamageSubmit>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		public long bossScheduleId; //Field offset: 0x28
		public int totalDamage; //Field offset: 0x30
		public bool victory; //Field offset: 0x34
		public int turnCount; //Field offset: 0x38
		private <>c__DisplayClass3_0 <>8__1; //Field offset: 0x40
		public Action onSuccess; //Field offset: 0x48
		private ChatService <chat>5__2; //Field offset: 0x50
		private Action<ChatMessageDTO> <okHandler>5__3; //Field offset: 0x58
		private Action<String> <failHandler>5__4; //Field offset: 0x60
		private float <elapsed>5__5; //Field offset: 0x68

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RequestWorldBossDamageSubmit>d__3(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RequestWorldBossList>d__2 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		private <>c__DisplayClass2_0 <>8__1; //Field offset: 0x28
		public Action<List`1<WorldBossDTO>> onSuccess; //Field offset: 0x30
		private ChatService <chat>5__2; //Field offset: 0x38
		private Action<List`1<WorldBossDTO>> <okHandler>5__3; //Field offset: 0x40
		private Action<String> <failHandler>5__4; //Field offset: 0x48
		private float <waitElapsed>5__5; //Field offset: 0x50
		private bool <resentAfterReconnect>5__6; //Field offset: 0x54
		private float <wait>5__7; //Field offset: 0x58

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RequestWorldBossList>d__2(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private const float TIMEOUT_SECONDS = 10; //Field offset: 0x0

	[IteratorStateMachine(typeof(<RequestMatchPrep>d__1))]
	public static IEnumerator RequestMatchPrep(long userPetId, long enemyPetId, Nullable<Int64> bossScheduleId, string mode, Action<MatchPrepDataDTO> onSuccess, Action<String> onError) { }

	[IteratorStateMachine(typeof(<RequestMatchReward>d__5))]
	public static IEnumerator RequestMatchReward(long petId, bool victory, long t, string s, Action<PetRewardDataDTO> onSuccess, Action<String> onError) { }

	[IteratorStateMachine(typeof(<RequestPvpProfile>d__4))]
	public static IEnumerator RequestPvpProfile(Nullable<Int64> targetUserId, Action<PvpProfileDTO> onSuccess, Action<String> onError) { }

	[IteratorStateMachine(typeof(<RequestWorldBossDamageSubmit>d__3))]
	public static IEnumerator RequestWorldBossDamageSubmit(long bossScheduleId, int totalDamage, bool victory, int turnCount, Action onSuccess, Action<String> onError) { }

	[IteratorStateMachine(typeof(<RequestWorldBossList>d__2))]
	public static IEnumerator RequestWorldBossList(Action<List`1<WorldBossDTO>> onSuccess, Action<String> onError) { }

}

