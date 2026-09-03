/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[BurstCompile(FloatMode = FloatMode.Default, DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct TilingJob : IJobFor // TypeDefIndex: 9803
	{
		// Fields
		[ReadOnly]
		public NativeArray<VisibleLight> lights; // 0x00
		[ReadOnly]
		public NativeArray<VisibleReflectionProbe> reflectionProbes; // 0x10
		[ReadOnly]
		public bool reflectionProbeRotation; // 0x20
		[NativeDisableParallelForRestriction]
		public NativeArray<InclusiveRange> tileRanges; // 0x28
		public int itemsPerTile; // 0x38
		public int rangesPerItem; // 0x3C
		public Fixed2<float4x4> worldToViews; // 0x40
		public float2 tileScale; // 0xC0
		public float2 tileScaleInv; // 0xC8
		public Fixed2<float> viewPlaneBottoms; // 0xD0
		public Fixed2<float> viewPlaneTops; // 0xD8
		public Fixed2<float4> viewToViewportScaleBiases; // 0xE0
		public int2 tileCount; // 0x100
		public float near; // 0x108
		public bool isOrthographic; // 0x10C
		private InclusiveRange m_TileYRange; // 0x10E
		private int m_Offset; // 0x114
		private int m_ViewIndex; // 0x118
		private float2 m_CenterOffset; // 0x11C
		private static readonly float3[] k_CubePoints; // 0x00
		private static readonly int4[] k_CubeLineIndices; // 0x08
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass20_0 // TypeDefIndex: 9804
		{
			// Fields
			public VisibleLight light; // 0x00
			public float3 lightPositionVS; // 0x90
			public float3 lightDirectionVS; // 0x9C
			public float cosHalfAngle; // 0xA8
			public float coneHeight; // 0xAC
		}
	
		[CompilerGenerated]
		private struct __c__DisplayClass21_0 // TypeDefIndex: 9805
		{
			// Fields
			public VisibleLight light; // 0x00
			public float3 lightPosVS; // 0x90
			public float3 lightDirVS; // 0x9C
			public float cosHalfAngle; // 0xA8
		}
	
		// Constructors
		static TilingJob(); // 0x0000000181FF3B80-0x0000000181FF3D80
	
		// Methods
		public void Execute(int jobIndex); // 0x0000000181FECD60-0x0000000181FECE80
		private void TileLight(int lightIndex); // 0x0000000181FF0180-0x0000000181FF2CB0
		private void TileLightOrthographic(int lightIndex); // 0x0000000181FEF310-0x0000000181FF0180
		private void TileReflectionProbe(int index); // 0x0000000181FF2CB0-0x0000000181FF37D0
		private float2 ViewToTileSpace(float3 positionVS); // 0x0000000181FF3AC0-0x0000000181FF3B80
		private float2 ViewToTileSpaceOrthographic(float3 positionVS); // 0x0000000181FF3A10-0x0000000181FF3AC0
		private void ExpandY(float3 positionVS); // 0x0000000181FED070-0x0000000181FED180
		private void ExpandOrthographic(float3 positionVS); // 0x0000000181FECE80-0x0000000181FECF90
		private void ExpandRangeOrthographic(ref InclusiveRange range, float xVS); // 0x0000000181FECF90-0x0000000181FED070
		private static float square(float x); // 0x0000000181FF3D80-0x0000000181FF3D90
		private static void GetSphereHorizon(float2 center, float radius, float near, float clipRadius, out float2 p0, out float2 p1); // 0x0000000181FEE6D0-0x0000000181FEE9B0
		private static void GetSphereYPlaneHorizon(float3 center, float sphereRadius, float near, float clipRadius, float y, out float3 left, out float3 right); // 0x0000000181FEE9B0-0x0000000181FEEDA0
		private static bool GetCircleClipPoints(float3 circleCenter, float3 circleNormal, float circleRadius, float near, out float3 p0, out float3 p1); // 0x0000000181FEDBC0-0x0000000181FEDE40
		private static ValueTuple<float, float> IntersectEllipseLine(float a, float b, float3 line); // 0x0000000181FEF190-0x0000000181FEF310
		private static void GetProjectedCircleHorizon(float2 center, float radius, float2 U, float2 V, out float2 uv1, out float2 uv2); // 0x0000000181FEE420-0x0000000181FEE6D0
		private static bool IntersectCircleYPlane(float y, float3 circleCenter, float3 circleNormal, float3 circleU, float3 circleV, float circleRadius, out float3 p1, out float3 p2); // 0x0000000181FEEDA0-0x0000000181FEF190
		private static void GetConeSideTangentPoints(float3 vertex, float3 axis, float cosHalfAngle, float circleRadius, float coneHeight, float range, float3 circleU, float3 circleV, out float3 l1, out float3 l2); // 0x0000000181FEDE40-0x0000000181FEE420
		private static float3 EvaluateNearConic(float near, float3 o, float3 d, float r, float3 u, float3 v, float theta); // 0x0000000181FECAC0-0x0000000181FECD60
		private static float2 FindNearConicTangentTheta(float2 o, float2 d, float r, float2 u, float2 v); // 0x0000000181FED180-0x0000000181FED470
		private static float2 FindNearConicYTheta(float near, float3 o, float3 d, float r, float3 u, float3 v, float y); // 0x0000000181FED470-0x0000000181FEDBC0
		[CompilerGenerated]
		internal static bool _TileLight_g__SpherePointIsValid_20_0(float3 p, ref __c__DisplayClass20_0 param_00012427); // 0x0000000181FF37D0-0x0000000181FF38C0
		[CompilerGenerated]
		internal static bool _TileLight_g__ConicPointIsValid_20_1(float3 p, ref __c__DisplayClass20_0 param_00012429); // 0x0000000181FF38C0-0x0000000181FF3A10
		[CompilerGenerated]
		internal static bool _TileLightOrthographic_g__SpherePointIsValid_21_0(float3 p, ref __c__DisplayClass21_0 param_0001242b); // 0x0000000181FF37D0-0x0000000181FF38C0
	}
}
