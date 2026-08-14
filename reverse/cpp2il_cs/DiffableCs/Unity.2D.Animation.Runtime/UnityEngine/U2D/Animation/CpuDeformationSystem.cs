namespace UnityEngine.U2D.Animation;

internal class CpuDeformationSystem : BaseDeformationSystem
{
	private const string k_GpuSkinningShaderKeyword = "SKINNED_SPRITE"; //Field offset: 0x0
	private JobHandle m_BoundJobHandle; //Field offset: 0x118
	private JobHandle m_CopyJobHandle; //Field offset: 0x128

	public virtual DeformationMethods deformationMethod
	{
		 get { } //Length: 3
	}

	public CpuDeformationSystem() { }

	internal virtual void Cleanup() { }

	public virtual DeformationMethods get_deformationMethod() { }

	private void ResizeBuffers(int vertexBufferSize, in PerSkinJobData skinBatch) { }

	internal virtual void Update() { }

	internal virtual void UpdateMaterial(SpriteSkin spriteSkin) { }

}

