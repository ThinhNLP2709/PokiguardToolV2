//Type is in global namespace

public static class ServerSignatureHelper
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public string deviceId; //Field offset: 0x10
		public string nonce; //Field offset: 0x18
		public Action<SignatureResponse> onSuccess; //Field offset: 0x20
		public Action<String> onError; //Field offset: 0x28

		public <>c__DisplayClass2_0() { }

		internal void <RequestSignature>b__0(SignatureResponse response) { }

		internal void <RequestSignature>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <RequestSignature>d__2 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<SignatureResponse> onSuccess; //Field offset: 0x20
		public Action<String> onError; //Field offset: 0x28
		public long userId; //Field offset: 0x30
		public long bossScheduleId; //Field offset: 0x38
		public int damageDealt; //Field offset: 0x40
		public int turnCount; //Field offset: 0x44
		public bool victory; //Field offset: 0x48

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
		public <RequestSignature>d__2(int <>1__state) { }

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

	internal class SignatureRequest
	{
		public long userId; //Field offset: 0x10
		public long bossScheduleId; //Field offset: 0x18
		public int damageDealt; //Field offset: 0x20
		public int turnCount; //Field offset: 0x24
		public bool victory; //Field offset: 0x28
		public long timestamp; //Field offset: 0x30
		public string deviceId; //Field offset: 0x38
		public string nonce; //Field offset: 0x40
		public string gameVersion; //Field offset: 0x48

		public SignatureRequest() { }

	}

	internal class SignatureResponse
	{
		public bool success; //Field offset: 0x10
		public string signature; //Field offset: 0x18
		public long serverTimestamp; //Field offset: 0x20
		public string message; //Field offset: 0x28
		public string sessionToken; //Field offset: 0x30
		public string deviceId; //Field offset: 0x38
		public string nonce; //Field offset: 0x40

		public SignatureResponse() { }

	}


	public static string CalculateChecksum(long userId, long bossId, int damage, int turnCount, bool victory) { }

	public static string GenerateNonce() { }

	public static long GetCurrentTimestamp() { }

	public static string GetDeviceId() { }

	[IteratorStateMachine(typeof(<RequestSignature>d__2))]
	public static IEnumerator RequestSignature(long userId, long bossScheduleId, int damageDealt, int turnCount, bool victory, Action<SignatureResponse> onSuccess, Action<String> onError) { }

}

