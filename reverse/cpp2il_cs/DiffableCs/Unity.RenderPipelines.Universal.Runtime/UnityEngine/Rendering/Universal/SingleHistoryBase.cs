namespace UnityEngine.Rendering.Universal;

internal abstract class SingleHistoryBase : CameraHistoryItem
{
	private int m_Id; //Field offset: 0x20
	private RenderTextureDescriptor m_Descriptor; //Field offset: 0x24
	private Hash128 m_DescKey; //Field offset: 0x58

	protected SingleHistoryBase() { }

	private void Alloc(ref RenderTextureDescriptor desc) { }

	public RTHandle GetCurrentTexture() { }

	protected abstract RenderTextureDescriptor GetHistoryDescriptor(ref RenderTextureDescriptor cameraDesc) { }

	protected abstract int GetHistoryFrameCount() { }

	protected abstract string GetHistoryName() { }

	public RTHandle GetPreviousTexture() { }

	public RTHandle GetTexture(int frameIndex = 0) { }

	internal bool IsAllocated() { }

	internal bool IsDirty(ref RenderTextureDescriptor desc) { }

	public virtual void OnCreate(BufferedRTHandleSystem owner, uint typeId) { }

	public virtual void Reset() { }

	internal bool Update(ref RenderTextureDescriptor cameraDesc) { }

}

