namespace UnityEngine.Rendering;

public interface ICameraHistoryReadAccess
{
	internal sealed class HistoryRequestDelegate : MulticastDelegate
	{

		public HistoryRequestDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(IPerFrameHistoryAccessTracker historyAccess, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(IPerFrameHistoryAccessTracker historyAccess) { }

	}


	public event HistoryRequestDelegate OnGatherHistoryRequests
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	[CompilerGenerated]
	public void add_OnGatherHistoryRequests(HistoryRequestDelegate value) { }

	public Type GetHistoryForRead() { }

	[CompilerGenerated]
	public void remove_OnGatherHistoryRequests(HistoryRequestDelegate value) { }

}

