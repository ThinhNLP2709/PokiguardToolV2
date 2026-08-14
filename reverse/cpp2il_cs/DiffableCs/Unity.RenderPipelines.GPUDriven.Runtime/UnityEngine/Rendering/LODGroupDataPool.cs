namespace UnityEngine.Rendering;

internal class LODGroupDataPool : IDisposable
{
	private static class LodGroupShaderIDs
	{
		public static readonly int _SupportDitheringCrossFade; //Field offset: 0x0
		public static readonly int _LodGroupCullingDataGPUByteSize; //Field offset: 0x4
		public static readonly int _LodGroupCullingDataStartOffset; //Field offset: 0x8
		public static readonly int _LodCullingDataQueueCount; //Field offset: 0xC
		public static readonly int _InputLodCullingDataIndices; //Field offset: 0x10
		public static readonly int _InputLodCullingDataBuffer; //Field offset: 0x14
		public static readonly int _LodGroupCullingData; //Field offset: 0x18

		private static LodGroupShaderIDs() { }

	}

	private NativeList<LODGroupData> m_LODGroupData; //Field offset: 0x10
	private NativeParallelHashMap<Int32, GPUInstanceIndex> m_LODGroupDataHash; //Field offset: 0x18
	private NativeList<LODGroupCullingData> m_LODGroupCullingData; //Field offset: 0x28
	private NativeList<GPUInstanceIndex> m_FreeLODGroupDataHandles; //Field offset: 0x30
	private int m_CrossfadedRendererCount; //Field offset: 0x38
	private bool m_SupportDitheringCrossFade; //Field offset: 0x3C

	public int activeLodGroupCount
	{
		 get { } //Length: 75
	}

	public int crossfadedRendererCount
	{
		 get { } //Length: 4
	}

	public NativeList<LODGroupCullingData> lodGroupCullingData
	{
		 get { } //Length: 5
	}

	public NativeParallelHashMap<Int32, GPUInstanceIndex> lodGroupDataHash
	{
		 get { } //Length: 11
	}

	public LODGroupDataPool(GPUResidentDrawerResources resources, int initialInstanceCount, bool supportDitheringCrossFade) { }

	public override void Dispose() { }

	public void FreeLODGroupData(NativeArray<Int32> destroyedLODGroupsID) { }

	public int get_activeLodGroupCount() { }

	public int get_crossfadedRendererCount() { }

	public NativeList<LODGroupCullingData> get_lodGroupCullingData() { }

	public NativeParallelHashMap<Int32, GPUInstanceIndex> get_lodGroupDataHash() { }

	public void UpdateLODGroupData(in GPUDrivenLODGroupData inputData) { }

	public void UpdateLODGroupTransformData(in GPUDrivenLODGroupData inputData) { }

}

