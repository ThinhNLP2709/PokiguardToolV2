namespace UnityEngine.Rendering.Universal;

public class UniversalCameraHistory : ICameraHistoryReadAccess, ICameraHistoryWriteAccess, IPerFrameHistoryAccessTracker, IDisposable
{
	private struct Item
	{
		public ContextItem storage; //Field offset: 0x0
		public int requestVersion; //Field offset: 0x8
		public int writeVersion; //Field offset: 0xC

		public void Reset() { }

	}

	private static class TypeId
	{
		public static uint value; //Field offset: 0x0

		private static TypeId`1() { }

	}

	private const int k_ValidVersionCount = 2; //Field offset: 0x0
	private static uint s_TypeCount; //Field offset: 0x0
	private Item[] m_Items; //Field offset: 0x10
	private int m_Version; //Field offset: 0x18
	private BufferedRTHandleSystem m_HistoryTextures; //Field offset: 0x20
	[CompilerGenerated]
	private HistoryRequestDelegate OnGatherHistoryRequests; //Field offset: 0x28

	public override event HistoryRequestDelegate OnGatherHistoryRequests
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	internal UniversalCameraHistory() { }

	[CompilerGenerated]
	public override void add_OnGatherHistoryRequests(HistoryRequestDelegate value) { }

	public override void Dispose() { }

	internal void GatherHistoryRequests() { }

	public override Type GetHistoryForRead() { }

	public override Type GetHistoryForWrite() { }

	public override bool IsAccessRequested() { }

	private bool IsValid(int i) { }

	private bool IsValidRequest(int i) { }

	public override bool IsWritten() { }

	internal void ReleaseUnusedHistory() { }

	[CompilerGenerated]
	public override void remove_OnGatherHistoryRequests(HistoryRequestDelegate value) { }

	public override void RequestAccess() { }

	internal void SwapAndSetReferenceSize(int cameraWidth, int cameraHeight) { }

}

