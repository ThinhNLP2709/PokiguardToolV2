namespace UnityEngine.U2D.Animation;

internal class GpuDeformationSystem : BaseDeformationSystem
{
	private const string k_GpuSkinningShaderKeyword = "SKINNED_SPRITE"; //Field offset: 0x0
	private const string k_GlobalSpriteBoneBufferId = "_SpriteBoneTransforms"; //Field offset: 0x0
	private static ComputeBuffer s_FallbackBuffer; //Field offset: 0x0
	private readonly Dictionary<Int32, Material> m_KeywordEnabledMaterials; //Field offset: 0x118
	private NativeArray<Int32> m_BoneTransformBufferSizes; //Field offset: 0x120
	private ComputeBuffer m_BoneTransformsComputeBuffer; //Field offset: 0x130

	public virtual DeformationMethods deformationMethod
	{
		 get { } //Length: 6
	}

	public GpuDeformationSystem() { }

	internal virtual bool AddSpriteSkin(SpriteSkin spriteSkin) { }

	internal virtual void Cleanup() { }

	private void CleanupComputeResources() { }

	private static void ClearFallbackBuffer() { }

	private void CreateComputeBuffer(int bufferSize) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void CreateFallbackBuffer() { }

	internal static bool DoesShaderSupportGpuDeformation(Material material) { }

	public virtual DeformationMethods get_deformationMethod() { }

	protected virtual void InitializeArrays() { }

	private static bool IsComputeBufferValid(ComputeBuffer buffer) { }

	protected virtual void ResizeAndCopyArrays(int updatedCount) { }

	private void ResizeBuffers(int vertexBufferSize, in PerSkinJobData skinBatch) { }

	private JobHandle ScheduleCopySpriteRendererBoneTransformBuffersJob(JobHandle jobHandle, int batchCount) { }

	private void SetComputeBuffer() { }

	internal virtual void Update() { }

	internal virtual void UpdateMaterial(SpriteSkin spriteSkin) { }

}

