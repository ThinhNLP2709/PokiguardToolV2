namespace UnityEngine.Rendering.Universal;

public sealed class RawDepthHistory : CameraHistoryItem
{
	private static readonly String[] m_Names; //Field offset: 0x0
	private Int32[] m_Ids; //Field offset: 0x20
	private RenderTextureDescriptor m_Descriptor; //Field offset: 0x28
	private Hash128 m_DescKey; //Field offset: 0x60

	private static RawDepthHistory() { }

	public RawDepthHistory() { }

	private void Alloc(ref RenderTextureDescriptor desc, bool xrMultipassEnabled) { }

	public RTHandle GetCurrentTexture(int eyeIndex = 0) { }

	internal RenderTextureDescriptor GetHistoryDescriptor(ref RenderTextureDescriptor cameraDesc) { }

	public RTHandle GetPreviousTexture(int eyeIndex = 0) { }

	private bool IsAllocated() { }

	private bool IsDirty(ref RenderTextureDescriptor desc) { }

	public virtual void OnCreate(BufferedRTHandleSystem owner, uint typeId) { }

	public virtual void Reset() { }

	internal bool Update(ref RenderTextureDescriptor cameraDesc, bool xrMultipassEnabled) { }

}

