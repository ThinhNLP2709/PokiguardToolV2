namespace UnityEngine.Rendering;

[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
[NativeHeader("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
public struct CullingResults : IEquatable<CullingResults>
{
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.VFXModule"})]
	internal IntPtr ptr; //Field offset: 0x0
	private CullingAllocationInfo* m_AllocationInfo; //Field offset: 0x8

	public int lightAndReflectionProbeIndexCount
	{
		 get { } //Length: 106
	}

	public NativeArray<VisibleLight> visibleLights
	{
		 get { } //Length: 112
	}

	public NativeArray<VisibleReflectionProbe> visibleReflectionProbes
	{
		 get { } //Length: 113
	}

	public bool ComputeDirectionalShadowMatricesAndCullingPrimitives(int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::ComputeDirectionalShadowMatricesAndCullingPrimitives")]
	private static bool ComputeDirectionalShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	private static bool ComputeDirectionalShadowMatricesAndCullingPrimitives_Injected(IntPtr cullingResultsPtr, int activeLightIndex, int splitIndex, int splitCount, in Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	public bool ComputePointShadowMatricesAndCullingPrimitives(int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::ComputePointShadowMatricesAndCullingPrimitives")]
	private static bool ComputePointShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::ComputeSpotShadowMatricesAndCullingPrimitives")]
	private static bool ComputeSpotShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	public bool ComputeSpotShadowMatricesAndCullingPrimitives(int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(CullingResults other) { }

	[FreeFunction("FillLightAndReflectionProbeIndices")]
	private static void FillLightAndReflectionProbeIndices(IntPtr cullingResultsPtr, ComputeBuffer computeBuffer) { }

	public void FillLightAndReflectionProbeIndices(ComputeBuffer computeBuffer) { }

	private static void FillLightAndReflectionProbeIndices_Injected(IntPtr cullingResultsPtr, IntPtr computeBuffer) { }

	[FreeFunction("FillLightIndexMapScriptable")]
	private static void FillLightIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize) { }

	public int get_lightAndReflectionProbeIndexCount() { }

	public NativeArray<VisibleLight> get_visibleLights() { }

	public NativeArray<VisibleReflectionProbe> get_visibleReflectionProbes() { }

	public virtual int GetHashCode() { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::GetLightIndexCount")]
	private static int GetLightIndexCount(IntPtr cullingResultsPtr) { }

	public NativeArray<Int32> GetLightIndexMap(Allocator allocator) { }

	[FreeFunction("GetLightIndexMapSize")]
	private static int GetLightIndexMapSize(IntPtr cullingResultsPtr) { }

	private NativeArray<T> GetNativeArray(Void* dataPointer, int length) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::GetReflectionProbeIndexCount")]
	private static int GetReflectionProbeIndexCount(IntPtr cullingResultsPtr) { }

	public bool GetShadowCasterBounds(int lightIndex, out Bounds outBounds) { }

	[FreeFunction("ScriptableRenderPipeline_Bindings::GetShadowCasterBounds")]
	private static bool GetShadowCasterBounds(IntPtr cullingResultsPtr, int lightIndex, out Bounds bounds) { }

	public static bool op_Equality(CullingResults left, CullingResults right) { }

	public void SetLightIndexMap(NativeArray<Int32> lightIndexMap) { }

	[FreeFunction("SetLightIndexMapScriptable")]
	private static void SetLightIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize) { }

}

