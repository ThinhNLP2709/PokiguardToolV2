namespace UnityEngine.Rendering.Universal;

internal struct AdditionalLightsShadowAtlasLayout
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ShadowResolutionRequest, ShadowResolutionRequest, Int32> <>9__24_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <CreateCompareShadowResolutionRequesPredicate>b__24_0(ShadowResolutionRequest curr, ShadowResolutionRequest other) { }

	}

	public struct ShadowResolutionRequest
	{
		[Flags]
		private enum SettingsOptions
		{
			None = 0,
			SoftShadow = 1,
			PointLightShadow = 2,
			All = 65535,
		}

		public ushort visibleLightIndex; //Field offset: 0x0
		public ushort perLightShadowSliceIndex; //Field offset: 0x2
		public ushort requestedResolution; //Field offset: 0x4
		public ushort offsetX; //Field offset: 0x6
		public ushort offsetY; //Field offset: 0x8
		public ushort allocatedResolution; //Field offset: 0xA
		private SettingsOptions m_ShadowProperties; //Field offset: 0xC

		public bool pointLightShadow
		{
			 get { } //Length: 9
			 set { } //Length: 36
		}

		public bool softShadow
		{
			 get { } //Length: 7
			 set { } //Length: 36
		}

		public bool get_pointLightShadow() { }

		public bool get_softShadow() { }

		public void set_pointLightShadow(bool value) { }

		public void set_softShadow(bool value) { }

	}

	private static List<RectInt> s_UnusedAtlasSquareAreas; //Field offset: 0x0
	private static List<ShadowResolutionRequest> s_ShadowResolutionRequests; //Field offset: 0x8
	private static Single[] s_VisibleLightIndexToCameraSquareDistance; //Field offset: 0x10
	private static Func<ShadowResolutionRequest, ShadowResolutionRequest, Int32> s_CompareShadowResolutionRequest; //Field offset: 0x18
	private static ShadowResolutionRequest[] s_SortedShadowResolutionRequests; //Field offset: 0x20
	private NativeArray<ShadowResolutionRequest> m_SortedShadowResolutionRequests; //Field offset: 0x0
	private NativeArray<Int32> m_VisibleLightIndexToSortedShadowResolutionRequestsFirstSliceIndex; //Field offset: 0x10
	private int m_TotalShadowSlicesCount; //Field offset: 0x20
	private int m_TotalShadowResolutionRequestCount; //Field offset: 0x24
	private bool m_TooManyShadowMaps; //Field offset: 0x28
	private int m_ShadowSlicesScaleFactor; //Field offset: 0x2C
	private int m_AtlasSize; //Field offset: 0x30

	public AdditionalLightsShadowAtlasLayout(UniversalLightData lightData, UniversalShadowData shadowData, UniversalCameraData cameraData) { }

	public static void ClearStaticCaches() { }

	private static Func<ShadowResolutionRequest, ShadowResolutionRequest, Int32> CreateCompareShadowResolutionRequesPredicate() { }

	private static int EstimateScaleFactorNeededToFitAllShadowsInAtlas(in NativeArray<ShadowResolutionRequest>& shadowResolutionRequests, int endIndex, int atlasSize) { }

	public int GetAtlasSize() { }

	public int GetShadowSlicesScaleFactor() { }

	public ShadowResolutionRequest GetSliceShadowResolutionRequest(int originalVisibleLightIndex, int sliceIndex) { }

	public ShadowResolutionRequest GetSortedShadowResolutionRequest(int sortedShadowResolutionRequestIndex) { }

	public int GetTotalShadowResolutionRequestCount() { }

	public int GetTotalShadowSlicesCount() { }

	public bool HasSpaceForLight(int originalVisibleLightIndex) { }

	public bool HasTooManyShadowMaps() { }

}

