namespace System.Runtime.CompilerServices;

[IsReadOnly]
public struct YieldAwaitable
{
	[IsReadOnly]
	internal struct YieldAwaiter : ICriticalNotifyCompletion
	{
		private static readonly WaitCallback s_waitCallbackRunAction; //Field offset: 0x0
		private static readonly SendOrPostCallback s_sendOrPostCallbackRunAction; //Field offset: 0x8

		public bool IsCompleted
		{
			 get { } //Length: 3
		}

		private static YieldAwaiter() { }

		public bool get_IsCompleted() { }

		public void GetResult() { }

		private static void QueueContinuation(Action continuation, bool flowContext) { }

		private static void RunAction(object state) { }

		public override void UnsafeOnCompleted(Action continuation) { }

	}


	public YieldAwaiter GetAwaiter() { }

}

