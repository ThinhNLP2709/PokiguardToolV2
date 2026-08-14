namespace UnityEngine.Rendering;

public struct BatchFilterSettings
{
	public uint renderingLayerMask; //Field offset: 0x0
	public int rendererPriority; //Field offset: 0x4
	private ulong m_sceneCullingMask; //Field offset: 0x8
	public byte layer; //Field offset: 0x10
	private byte m_batchLayer; //Field offset: 0x11
	private byte m_motionMode; //Field offset: 0x12
	private byte m_shadowMode; //Field offset: 0x13
	private byte m_receiveShadows; //Field offset: 0x14
	private byte m_staticShadowCaster; //Field offset: 0x15
	private byte m_allDepthSorted; //Field offset: 0x16
	private byte m_isSceneCullingMaskSet; //Field offset: 0x17

	public bool allDepthSorted
	{
		 set { } //Length: 6
	}

	public byte batchLayer
	{
		 set { } //Length: 4
	}

	public MotionVectorGenerationMode motionMode
	{
		 set { } //Length: 4
	}

	public bool receiveShadows
	{
		 set { } //Length: 6
	}

	public ShadowCastingMode shadowCastingMode
	{
		 set { } //Length: 4
	}

	public bool staticShadowCaster
	{
		 set { } //Length: 6
	}

	public void set_allDepthSorted(bool value) { }

	public void set_batchLayer(byte value) { }

	public void set_motionMode(MotionVectorGenerationMode value) { }

	public void set_receiveShadows(bool value) { }

	public void set_shadowCastingMode(ShadowCastingMode value) { }

	public void set_staticShadowCaster(bool value) { }

}

