namespace UnityEngine.Rendering;

public abstract class CameraHistoryItem : ContextItem
{
	private BufferedRTHandleSystem m_owner; //Field offset: 0x10
	private uint m_TypeId; //Field offset: 0x18

	protected BufferedRTHandleSystem storage
	{
		 get { } //Length: 5
	}

	protected CameraHistoryItem() { }

	protected RTHandle AllocHistoryFrameRT(int id, int count, ref RenderTextureDescriptor desc, string name = "") { }

	protected BufferedRTHandleSystem get_storage() { }

	protected RTHandle GetCurrentFrameRT(int id) { }

	protected RTHandle GetPreviousFrameRT(int id) { }

	protected int MakeId(uint index) { }

	public override void OnCreate(BufferedRTHandleSystem owner, uint typeId) { }

	protected void ReleaseHistoryFrameRT(int id) { }

}

