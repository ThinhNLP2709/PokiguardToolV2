namespace UnityEngine.Rendering;

[UsedByNativeCode]
public struct ScriptableCullingParameters : IEquatable<ScriptableCullingParameters>
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <m_CullingPlanes>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <m_LayerFarCullDistances>e__FixedBuffer
	{
		public float FixedElementField; //Field offset: 0x0

	}

	private const int k_MaximumCullingPlaneCount = 10; //Field offset: 0x0
	public static readonly int maximumCullingPlaneCount; //Field offset: 0x0
	private const int k_LayerCount = 32; //Field offset: 0x0
	private const int k_CullingJobCountUpperLimit = 16; //Field offset: 0x0
	private const int k_CullingJobCountLowerLimit = 1; //Field offset: 0x0
	public static readonly int layerCount; //Field offset: 0x4
	private LODParameters m_LODParameters; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 160)]
	internal <m_CullingPlanes>e__FixedBuffer m_CullingPlanes; //Field offset: 0x1C
	private int m_CullingPlaneCount; //Field offset: 0xBC
	private uint m_CullingMask; //Field offset: 0xC0
	private ulong m_SceneMask; //Field offset: 0xC8
	private ulong m_ViewID; //Field offset: 0xD0
	[FixedBuffer(typeof(float), 32)]
	internal <m_LayerFarCullDistances>e__FixedBuffer m_LayerFarCullDistances; //Field offset: 0xD8
	private int m_LayerCull; //Field offset: 0x158
	private Matrix4x4 m_CullingMatrix; //Field offset: 0x15C
	private Vector3 m_Origin; //Field offset: 0x19C
	private float m_ShadowDistance; //Field offset: 0x1A8
	private float m_ShadowNearPlaneOffset; //Field offset: 0x1AC
	private CullingOptions m_CullingOptions; //Field offset: 0x1B0
	private ReflectionProbeSortingCriteria m_ReflectionProbeSortingCriteria; //Field offset: 0x1B4
	private CameraProperties m_CameraProperties; //Field offset: 0x1B8
	private float m_AccurateOcclusionThreshold; //Field offset: 0x59C
	private int m_MaximumPortalCullingJobs; //Field offset: 0x5A0
	private Matrix4x4 m_StereoViewMatrix; //Field offset: 0x5A4
	private Matrix4x4 m_StereoProjectionMatrix; //Field offset: 0x5E4
	private float m_StereoSeparationDistance; //Field offset: 0x624
	private int m_maximumVisibleLights; //Field offset: 0x628
	private bool m_ConservativeEnclosingSphere; //Field offset: 0x62C
	private int m_NumIterationsEnclosingSphere; //Field offset: 0x630

	public bool conservativeEnclosingSphere
	{
		 set { } //Length: 7
	}

	public CullingOptions cullingOptions
	{
		 get { } //Length: 9
		 set { } //Length: 7
	}

	public int cullingPlaneCount
	{
		 get { } //Length: 9
	}

	public int maximumVisibleLights
	{
		 set { } //Length: 7
	}

	public int numIterationsEnclosingSphere
	{
		 set { } //Length: 7
	}

	public ReflectionProbeSortingCriteria reflectionProbeSortingCriteria
	{
		 set { } //Length: 7
	}

	public float shadowDistance
	{
		 set { } //Length: 9
	}

	public Matrix4x4 stereoProjectionMatrix
	{
		 get { } //Length: 47
		 set { } //Length: 44
	}

	public float stereoSeparationDistance
	{
		 set { } //Length: 9
	}

	public Matrix4x4 stereoViewMatrix
	{
		 set { } //Length: 44
	}

	private static ScriptableCullingParameters() { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(ScriptableCullingParameters other) { }

	public CullingOptions get_cullingOptions() { }

	public int get_cullingPlaneCount() { }

	public Matrix4x4 get_stereoProjectionMatrix() { }

	public Plane GetCullingPlane(int index) { }

	public virtual int GetHashCode() { }

	public float GetLayerCullingDistance(int layerIndex) { }

	public void set_conservativeEnclosingSphere(bool value) { }

	public void set_cullingOptions(CullingOptions value) { }

	public void set_maximumVisibleLights(int value) { }

	public void set_numIterationsEnclosingSphere(int value) { }

	public void set_reflectionProbeSortingCriteria(ReflectionProbeSortingCriteria value) { }

	public void set_shadowDistance(float value) { }

	public void set_stereoProjectionMatrix(Matrix4x4 value) { }

	public void set_stereoSeparationDistance(float value) { }

	public void set_stereoViewMatrix(Matrix4x4 value) { }

}

