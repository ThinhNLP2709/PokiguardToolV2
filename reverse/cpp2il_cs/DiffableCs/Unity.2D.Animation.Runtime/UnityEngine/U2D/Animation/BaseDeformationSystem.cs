namespace UnityEngine.U2D.Animation;

internal abstract class BaseDeformationSystem
{
	internal static class Profiling
	{
		public static readonly ProfilerMarker transformAccessJob; //Field offset: 0x0
		public static readonly ProfilerMarker getSpriteSkinBatchData; //Field offset: 0x8
		public static readonly ProfilerMarker scheduleJobs; //Field offset: 0x10
		public static readonly ProfilerMarker setBatchDeformableBufferAndLocalAABB; //Field offset: 0x18
		public static readonly ProfilerMarker setBoneTransformsArray; //Field offset: 0x20

		private static Profiling() { }

	}

	protected int m_ObjectId; //Field offset: 0x10
	protected readonly HashSet<SpriteSkin> m_SpriteSkins; //Field offset: 0x18
	protected SpriteRenderer[] m_SpriteRenderers; //Field offset: 0x20
	private readonly HashSet<SpriteSkin> m_SpriteSkinsToAdd; //Field offset: 0x28
	private readonly HashSet<SpriteSkin> m_SpriteSkinsToRemove; //Field offset: 0x30
	private readonly List<Int32> m_TransformIdsToRemove; //Field offset: 0x38
	protected NativeByteArray m_DeformedVerticesBuffer; //Field offset: 0x40
	protected NativeArray<float4x4> m_FinalBoneTransforms; //Field offset: 0x48
	protected NativeArray<Boolean> m_IsSpriteSkinActiveForDeform; //Field offset: 0x58
	protected NativeArray<SpriteSkinData> m_SpriteSkinData; //Field offset: 0x68
	protected NativeArray<PerSkinJobData> m_PerSkinJobData; //Field offset: 0x78
	protected NativeArray<Bounds> m_BoundsData; //Field offset: 0x88
	protected NativeArray<IntPtr> m_Buffers; //Field offset: 0x98
	protected NativeArray<Int32> m_BufferSizes; //Field offset: 0xA8
	protected NativeArray<IntPtr> m_BoneTransformBuffers; //Field offset: 0xB8
	protected NativeArray<int2> m_BoneLookupData; //Field offset: 0xC8
	protected NativeArray<int2> m_VertexLookupData; //Field offset: 0xD8
	protected NativeArray<PerSkinJobData> m_SkinBatchArray; //Field offset: 0xE8
	private TransformAccessJob m_LocalToWorldTransformAccessJob; //Field offset: 0xF8
	private TransformAccessJob m_WorldToLocalTransformAccessJob; //Field offset: 0x100
	protected JobHandle m_DeformJobHandle; //Field offset: 0x108

	public abstract DeformationMethods deformationMethod
	{
		 get { } //Length: 0
	}

	protected BaseDeformationSystem() { }

	internal void AddBoneTransforms(SpriteSkin spriteSkin) { }

	internal override bool AddSpriteSkin(SpriteSkin spriteSkin) { }

	protected void BatchAddSpriteSkins() { }

	protected void BatchRemoveSpriteSkins() { }

	internal override void Cleanup() { }

	internal void CopyToSpriteSkinData(SpriteSkin spriteSkin) { }

	protected void DeactivateDeformableBuffers() { }

	public abstract DeformationMethods get_deformationMethod() { }

	internal NativeArray<Byte> GetDeformableBufferForSpriteSkin(SpriteSkin spriteSkin) { }

	internal HashSet<SpriteSkin> GetSpriteSkins() { }

	protected bool GotVerticesToDeform(out int vertexBufferSize) { }

	internal void Initialize(int objectId) { }

	protected override void InitializeArrays() { }

	internal bool IsSpriteSkinActiveForDeformation(SpriteSkin spriteSkin) { }

	protected void PrepareDataForDeformation(out JobHandle localToWorldJobHandle, out JobHandle worldToLocalJobHandle) { }

	internal void RemoveBoneTransforms(SpriteSkin spriteSkin) { }

	internal void RemoveSpriteSkin(SpriteSkin spriteSkin) { }

	protected override void ResizeAndCopyArrays(int updatedCount) { }

	protected JobHandle ScheduleBoneJobBatched(JobHandle jobHandle, PerSkinJobData skinBatch) { }

	protected JobHandle ScheduleCalculateSpriteSkinAABBJob(JobHandle jobHandle, int batchCount) { }

	protected JobHandle ScheduleCopySpriteRendererBuffersJob(JobHandle jobHandle, int batchCount) { }

	protected JobHandle SchedulePrepareJob(int batchCount) { }

	protected JobHandle ScheduleSkinDeformBatchedJob(JobHandle jobHandle, PerSkinJobData skinBatch) { }

	internal abstract void Update() { }

	internal override void UpdateMaterial(SpriteSkin spriteSkin) { }

	private void ValidateSpriteSkinData() { }

}

