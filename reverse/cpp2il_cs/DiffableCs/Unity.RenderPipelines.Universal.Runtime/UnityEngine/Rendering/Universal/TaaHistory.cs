namespace UnityEngine.Rendering.Universal;

public sealed class TaaHistory : CameraHistoryItem
{
	private static readonly String[] m_TaaAccumulationNames; //Field offset: 0x0
	private Int32[] m_TaaAccumulationTextureIds; //Field offset: 0x20
	private Int32[] m_TaaAccumulationVersions; //Field offset: 0x28
	private RenderTextureDescriptor m_Descriptor; //Field offset: 0x30
	private Hash128 m_DescKey; //Field offset: 0x68

	private static TaaHistory() { }

	public TaaHistory() { }

	private void Alloc(ref RenderTextureDescriptor desc, bool xrMultipassEnabled) { }

	public RTHandle GetAccumulationTexture(int eyeIndex = 0) { }

	public int GetAccumulationVersion(int eyeIndex = 0) { }

	private bool IsDirty(ref RenderTextureDescriptor desc) { }

	private bool IsValid() { }

	public virtual void OnCreate(BufferedRTHandleSystem owner, uint typeId) { }

	public virtual void Reset() { }

	internal void SetAccumulationVersion(int eyeIndex, int version) { }

	internal bool Update(ref RenderTextureDescriptor cameraDesc, bool xrMultipassEnabled = false) { }

}

