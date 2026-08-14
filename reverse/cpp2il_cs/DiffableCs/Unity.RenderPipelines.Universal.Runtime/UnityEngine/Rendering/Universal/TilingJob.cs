namespace UnityEngine.Rendering.Universal;

[BurstCompile(FloatMode = FloatMode::Default (0), DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct TilingJob : IJobFor
{
	[CompilerGenerated]
	private struct <>c__DisplayClass19_0
	{
		public VisibleLight light; //Field offset: 0x0
		public float3 lightPositionVS; //Field offset: 0x74
		public float3 lightDirectionVS; //Field offset: 0x80
		public float cosHalfAngle; //Field offset: 0x8C
		public float coneHeight; //Field offset: 0x90

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass20_0
	{
		public VisibleLight light; //Field offset: 0x0
		public float3 lightPosVS; //Field offset: 0x74
		public float3 lightDirVS; //Field offset: 0x80
		public float cosHalfAngle; //Field offset: 0x8C

	}

	private static readonly float3[] k_CubePoints; //Field offset: 0x0
	private static readonly int4[] k_CubeLineIndices; //Field offset: 0x8
	[ReadOnly]
	public NativeArray<VisibleLight> lights; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<VisibleReflectionProbe> reflectionProbes; //Field offset: 0x10
	[NativeDisableParallelForRestriction]
	public NativeArray<InclusiveRange> tileRanges; //Field offset: 0x20
	public int itemsPerTile; //Field offset: 0x30
	public int rangesPerItem; //Field offset: 0x34
	public Fixed2<float4x4> worldToViews; //Field offset: 0x38
	public float2 tileScale; //Field offset: 0xB8
	public float2 tileScaleInv; //Field offset: 0xC0
	public Fixed2<Single> viewPlaneBottoms; //Field offset: 0xC8
	public Fixed2<Single> viewPlaneTops; //Field offset: 0xD0
	public Fixed2<float4> viewToViewportScaleBiases; //Field offset: 0xD8
	public int2 tileCount; //Field offset: 0xF8
	public float near; //Field offset: 0x100
	public bool isOrthographic; //Field offset: 0x104
	private InclusiveRange m_TileYRange; //Field offset: 0x106
	private int m_Offset; //Field offset: 0x10C
	private int m_ViewIndex; //Field offset: 0x110
	private float2 m_CenterOffset; //Field offset: 0x114

	private static TilingJob() { }

	[CompilerGenerated]
	internal static bool <TileLight>g__ConicPointIsValid|19_1(float3 p, ref <>c__DisplayClass19_0 unnamed_param_1) { }

	[CompilerGenerated]
	internal static bool <TileLight>g__SpherePointIsValid|19_0(float3 p, ref <>c__DisplayClass19_0 unnamed_param_1) { }

	[CompilerGenerated]
	internal static bool <TileLightOrthographic>g__SpherePointIsValid|20_0(float3 p, ref <>c__DisplayClass20_0 unnamed_param_1) { }

	private static float3 EvaluateNearConic(float near, float3 o, float3 d, float r, float3 u, float3 v, float theta) { }

	public override void Execute(int jobIndex) { }

	private void ExpandOrthographic(float3 positionVS) { }

	private void ExpandRangeOrthographic(ref InclusiveRange range, float xVS) { }

	private void ExpandY(float3 positionVS) { }

	private static float2 FindNearConicTangentTheta(float2 o, float2 d, float r, float2 u, float2 v) { }

	private static float2 FindNearConicYTheta(float near, float3 o, float3 d, float r, float3 u, float3 v, float y) { }

	private static bool GetCircleClipPoints(float3 circleCenter, float3 circleNormal, float circleRadius, float near, out float3 p0, out float3 p1) { }

	private static void GetConeSideTangentPoints(float3 vertex, float3 axis, float cosHalfAngle, float circleRadius, float coneHeight, float range, float3 circleU, float3 circleV, out float3 l1, out float3 l2) { }

	private static void GetProjectedCircleHorizon(float2 center, float radius, float2 U, float2 V, out float2 uv1, out float2 uv2) { }

	private static void GetSphereHorizon(float2 center, float radius, float near, float clipRadius, out float2 p0, out float2 p1) { }

	private static void GetSphereYPlaneHorizon(float3 center, float sphereRadius, float near, float clipRadius, float y, out float3 left, out float3 right) { }

	private static bool IntersectCircleYPlane(float y, float3 circleCenter, float3 circleNormal, float3 circleU, float3 circleV, float circleRadius, out float3 p1, out float3 p2) { }

	private static ValueTuple<Single, Single> IntersectEllipseLine(float a, float b, float3 line) { }

	private static float square(float x) { }

	private void TileLight(int lightIndex) { }

	private void TileLightOrthographic(int lightIndex) { }

	private void TileReflectionProbe(int index) { }

	private float2 ViewToTileSpace(float3 positionVS) { }

	private float2 ViewToTileSpaceOrthographic(float3 positionVS) { }

}

