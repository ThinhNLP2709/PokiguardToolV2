/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.SpriteShape.External.LibTessDotNet;
using UnityEngine;
using UnityEngine.U2D.Common.UTess;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[BurstCompile]
	internal struct SpriteShapeGenerator : IJob // TypeDefIndex: 14003
	{
		// Fields
		public ProfilerMarker generateGeometry; // 0x00
		public ProfilerMarker generateCollider; // 0x08
		[ReadOnly]
		private JobParameters m_ShapeParams; // 0x10
		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<JobSpriteInfo> m_SpriteInfos; // 0x50
		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<JobSpriteInfo> m_CornerSpriteInfos; // 0x60
		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<JobAngleRange> m_AngleRanges; // 0x70
		[DeallocateOnJobCompletion]
		private NativeArray<JobSegmentInfo> m_Segments; // 0x80
		private int m_SegmentCount; // 0x90
		[DeallocateOnJobCompletion]
		private NativeArray<JobContourPoint> m_ContourPoints; // 0x98
		private int m_ContourPointCount; // 0xA8
		[DeallocateOnJobCompletion]
		private NativeArray<JobCornerInfo> m_Corners; // 0xB0
		private int m_CornerCount; // 0xC0
		[DeallocateOnJobCompletion]
		private NativeArray<float2> m_TessPoints; // 0xC8
		private int m_TessPointCount; // 0xD8
		[DeallocateOnJobCompletion]
		private NativeArray<JobControlPoint> m_ControlPoints; // 0xE0
		private int m_ControlPointCount; // 0xF0
		[DeallocateOnJobCompletion]
		private NativeArray<float2> m_CornerCoordinates; // 0xF8
		[DeallocateOnJobCompletion]
		private NativeArray<JobControlPoint> m_GeneratedControlPoints; // 0x108
		[DeallocateOnJobCompletion]
		private NativeArray<int2> m_SpriteIndices; // 0x118
		[DeallocateOnJobCompletion]
		private NativeArray<JobIntersectPoint> m_Intersectors; // 0x128
		private int m_IndexArrayCount; // 0x138
		public NativeArray<ushort> m_IndexArray; // 0x140
		private int m_VertexArrayCount; // 0x150
		public NativeSlice<Vector3> m_PosArray; // 0x158
		public NativeSlice<Vector2> m_Uv0Array; // 0x168
		public NativeSlice<Vector4> m_TanArray; // 0x178
		private int m_GeomArrayCount; // 0x188
		public NativeArray<SpriteShapeSegment> m_GeomArray; // 0x190
		private int m_ColliderPointCount; // 0x1A0
		public NativeArray<float2> m_ColliderPoints; // 0x1A8
		private int m_ShadowPointCount; // 0x1B8
		public NativeArray<float2> m_ShadowPoints; // 0x1C0
		public NativeArray<Bounds> m_Bounds; // 0x1D0
		public NativeArray<SpriteShapeGeneratorStats> m_Stats; // 0x1E0
		private int m_IndexDataCount; // 0x1F0
		private int m_VertexDataCount; // 0x1F4
		private int m_ColliderDataCount; // 0x1F8
		private int m_ShadowDataCount; // 0x1FC
		private int m_ActiveIndexCount; // 0x200
		private int m_ActiveVertexCount; // 0x204
		private float2 m_FirstLT; // 0x208
		private float2 m_FirstLB; // 0x210
		private float4x4 m_Transform; // 0x218
		private int kModeLinear; // 0x258
		private int kModeContinous; // 0x25C
		private int kModeBroken; // 0x260
		private int kModeUTess; // 0x264
		private int kCornerTypeOuterTopLeft; // 0x268
		private int kCornerTypeOuterTopRight; // 0x26C
		private int kCornerTypeOuterBottomLeft; // 0x270
		private int kCornerTypeOuterBottomRight; // 0x274
		private int kCornerTypeInnerTopLeft; // 0x278
		private int kCornerTypeInnerTopRight; // 0x27C
		private int kCornerTypeInnerBottomLeft; // 0x280
		private int kCornerTypeInnerBottomRight; // 0x284
		private int kControlPointCount; // 0x288
		private int kMaxArrayCount; // 0x28C
		private float kEpsilon; // 0x290
		private float kEpsilonOrder; // 0x294
		private float kEpsilonRelaxed; // 0x298
		private float kExtendSegment; // 0x29C
		private float kRenderQuality; // 0x2A0
		private float kOptimizeRender; // 0x2A4
		private float kColliderQuality; // 0x2A8
		private float kOptimizeCollider; // 0x2AC
		private float kShadowQuality; // 0x2B0
		private float kLowestQualityTolerance; // 0x2B4
		private float kHighestQualityTolerance; // 0x2B8
	
		// Properties
		private int vertexDataCount { get; } // 0x0000000181C58AC0-0x0000000181C58AD0 
		private int vertexArrayCount { get; } // 0x0000000181C405B0-0x0000000181C405C0 
		private int indexDataCount { get; } // 0x0000000181C58A90-0x0000000181C58AA0 
		private int spriteCount { get; } // 0x000000018033D260-0x000000018033D270 
		private int cornerSpriteCount { get; } // 0x00000001803002C0-0x00000001803002D0 
		private int angleRangeCount { get; } // 0x000000018169BB50-0x000000018169BB60 
		private int controlPointCount { get; } // 0x0000000181C0F730-0x0000000181C0F740 
		private int contourPointCount { get; } // 0x00000001806671D0-0x00000001806671E0 
		private int segmentCount { get; } // 0x000000018169CBC0-0x000000018169CBD0 
		private bool hasCollider { get; } // 0x0000000181C58A70-0x0000000181C58A80 
		private bool hasShadow { get; } // 0x0000000181C58A80-0x0000000181C58A90 
		private float colliderPivot { get; } // 0x00000001806CCB40-0x00000001806CCB50 
		private float shadowPivot { get; } // 0x0000000181C58AB0-0x0000000181C58AC0 
		private float borderPivot { get; } // 0x0000000181230A40-0x0000000181230A50 
		private int splineDetail { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		private bool isCarpet { get; } // 0x0000000180D91AF0-0x0000000180D91B00 
		private bool isAdaptive { get; } // 0x0000000181C58AA0-0x0000000181C58AB0 
		private bool hasSpriteBorder { get; } // 0x0000000181C119B0-0x0000000181C119C0 
	
		// Nested types
		private struct JobParameters // TypeDefIndex: 14004
		{
			// Fields
			public int4 shapeData; // 0x00
			public int4 splineData; // 0x10
			public float4 curveData; // 0x20
			public float4 fillData; // 0x30
		}
	
		private struct JobSpriteInfo // TypeDefIndex: 14005
		{
			// Fields
			public float4 texRect; // 0x00
			public float4 texData; // 0x10
			public float4 uvInfo; // 0x20
			public float4 metaInfo; // 0x30
			public float4 border; // 0x40
		}
	
		private struct JobAngleRange // TypeDefIndex: 14006
		{
			// Fields
			public float4 spriteAngles; // 0x00
			public int4 spriteData; // 0x10
		}
	
		private struct JobControlPoint // TypeDefIndex: 14007
		{
			// Fields
			public int4 cpData; // 0x00
			public int4 exData; // 0x10
			public float2 cpInfo; // 0x20
			public float2 position; // 0x28
			public float2 tangentLt; // 0x30
			public float2 tangentRt; // 0x38
		}
	
		private struct JobContourPoint // TypeDefIndex: 14008
		{
			// Fields
			public float2 position; // 0x00
			public float2 ptData; // 0x08
		}
	
		private struct JobIntersectPoint // TypeDefIndex: 14009
		{
			// Fields
			public float2 top; // 0x00
			public float2 bottom; // 0x08
		}
	
		private struct JobSegmentInfo // TypeDefIndex: 14010
		{
			// Fields
			public int4 sgInfo; // 0x00
			public float4 spriteInfo; // 0x10
		}
	
		private struct JobCornerInfo // TypeDefIndex: 14011
		{
			// Fields
			public float2 bottom; // 0x00
			public float2 top; // 0x08
			public float2 left; // 0x10
			public float2 right; // 0x18
			public int2 cornerData; // 0x20
		}
	
		private struct JobShapeVertex // TypeDefIndex: 14012
		{
			// Fields
			public float2 pos; // 0x00
			public float2 uv; // 0x08
			public float4 tan; // 0x10
			public float2 meta; // 0x20
			public int4 sprite; // 0x28
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14013
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<int, ushort> __9__155_0; // 0x08
			public static Func<ContourVertex, Vector2> __9__155_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181C62F10-0x0000000181C62F80
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal ushort _TessellateContourMainThread_b__155_0(int i); // 0x0000000181C62EE0-0x0000000181C62EF0
			internal Vector2 _TessellateContourMainThread_b__155_1(ContourVertex v); // 0x0000000181C62EF0-0x0000000181C62F10
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void UTessellator_000001B2_PostfixBurstDelegate(ref SpriteShapeSegment geom, int maxCount, float2* tessPoints, int tessPointCount, ushort* indices, ref int iCount, byte* vertices, int stride, ref int vCount, Allocator label); // TypeDefIndex: 14014; 0x0000000181C636A0-0x0000000181C636C0
	
		internal static class UTessellator_000001B2_BurstDirectCall // TypeDefIndex: 14015
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C62F80-0x0000000181C62FC0
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001ad9b); // 0x0000000181C62FC0-0x0000000181C63130
			private static IntPtr GetFunctionPointer(); // 0x0000000181C63130-0x0000000181C63290
			public static unsafe void Invoke(ref SpriteShapeSegment geom, int maxCount, float2* tessPoints, int tessPointCount, ushort* indices, ref int iCount, byte* vertices, int stride, ref int vCount, Allocator label); // 0x0000000181C63290-0x0000000181C63530
		}
	
		// Methods
		private JobSpriteInfo GetSpriteInfo(int index); // 0x0000000181C51630-0x0000000181C51680
		private JobSpriteInfo GetCornerSpriteInfo(int index); // 0x0000000181C50AD0-0x0000000181C50B20
		private JobAngleRange GetAngleRange(int index); // 0x0000000181C50A30-0x0000000181C50A60
		private JobControlPoint GetControlPoint(int index); // 0x0000000181C50A90-0x0000000181C50AD0
		private JobContourPoint GetContourPoint(int index); // 0x0000000181C50A70-0x0000000181C50A90
		private JobSegmentInfo GetSegmentInfo(int index); // 0x0000000181C514E0-0x0000000181C51510
		private int GetContourIndex(int index); // 0x0000000181C50A60-0x0000000181C50A70
		private int GetEndContourIndexOfSegment(JobSegmentInfo isi); // 0x0000000181C50B20-0x0000000181C50B40
		private void SetResult(SpriteShapeGeneratorResult result); // 0x0000000181C53D80-0x0000000181C53DA0
		private static void CopyToNativeArray<T>(NativeArray<T> from, int length, ref NativeArray<T> to)
			where T : struct;
		private static void SafeDispose<T>(NativeArray<T> na)
			where T : struct;
		private static bool IsPointOnLine(float epsilon, float2 a, float2 b, float2 c); // 0x0000000181C51C30-0x0000000181C51D40
		private static bool IsPointOnLines(float epsilon, float2 p1, float2 p2, float2 p3, float2 p4, float2 r); // 0x0000000181C51D40-0x0000000181C51DC0
		private static bool Colinear(float2 p, float2 q, float2 r); // 0x0000000181C4E2B0-0x0000000181C4E370
		private static int Det(float epsilon, float2 p, float2 q, float2 r); // 0x0000000181C4E9B0-0x0000000181C4EA30
		private static bool LineIntersectionTest(float epsilon, float2 p1, float2 q1, float2 p2, float2 q2); // 0x0000000181C51DC0-0x0000000181C51F40
		private static bool LineIntersection(float epsilon, float2 p1, float2 p2, float2 p3, float2 p4, ref float2 result); // 0x0000000181C51F40-0x0000000181C52090
		private static float AngleBetweenVector(float2 a, float2 b); // 0x0000000181C4CF90-0x0000000181C4D040
		private static bool GenerateColumnsBi(float2 a, float2 b, float2 whsize, bool flip, ref float2 rt, ref float2 rb, float cph, float pivot); // 0x0000000181C4F540-0x0000000181C4F700
		private static bool GenerateColumnsTri(float2 a, float2 b, float2 c, float2 whsize, bool flip, ref float2 rt, ref float2 rb, float cph, float pivot); // 0x0000000181C4F700-0x0000000181C4F960
		private void AppendCornerCoordinates(ref NativeArray<float2> corners, ref int cornerCount, float2 a, float2 b, float2 c, float2 d); // 0x0000000181C4D060-0x0000000181C4D0C0
		private void PrepareInput(SpriteShapeParameters shapeParams, int maxArrayCount, NativeArray<ShapeControlPoint> shapePoints, bool optimizeGeometry, bool updateCollider, bool optimizeCollider, float colliderOffset, float colliderDetail, bool updateShadow, float shadowOffset, float shadowDetail); // 0x0000000181C52C40-0x0000000181C53690
		private void TransferSprites(ref NativeArray<JobSpriteInfo> spriteInfos, Sprite[] sprites, int maxCount); // 0x0000000181C57800-0x0000000181C57D20
		private void PrepareSprites(Sprite[] edgeSprites, Sprite[] cornerSprites); // 0x0000000181C53690-0x0000000181C53770
		private void PrepareAngleRanges(AngleRangeInfo[] angleRanges); // 0x0000000181C527C0-0x0000000181C52910
		private void PrepareControlPoints(NativeArray<ShapeControlPoint> shapePoints, NativeArray<SplinePointMetaData> metaData); // 0x0000000181C529D0-0x0000000181C52C40
		private bool WithinRange(JobAngleRange angleRange, float inputAngle); // 0x0000000181C589F0-0x0000000181C58A70
		private bool AngleWithinRange(float t, float a, float b); // 0x0000000181C4D040-0x0000000181C4D060
		private static float2 BezierPoint(float2 st, float2 sp, float2 ep, float2 et, float t); // 0x0000000181C4DA30-0x0000000181C4DB30
		private static float SlopeAngle(float2 dirNormalized); // 0x0000000181C53F40-0x0000000181C54040
		private static float SlopeAngle(float2 start, float2 end); // 0x0000000181C54040-0x0000000181C540C0
		private bool ResolveAngle(float angle, int activeIndex, ref float renderOrder, ref int spriteIndex, ref int firstSpriteIndex); // 0x0000000181C53B70-0x0000000181C53C90
		private int GetSpriteIndex(int index, int previousIndex, ref int resolved); // 0x0000000181C51510-0x0000000181C51630
		private void GenerateSegments(); // 0x0000000181C50430-0x0000000181C50A30
		private void UpdateSegments(); // 0x0000000181C588F0-0x0000000181C589F0
		private bool GetSegmentBoundaryColumn(JobSegmentInfo segment, JobSpriteInfo sprInfo, float2 whsize, float2 startPos, float2 endPos, bool end, ref float2 top, ref float2 bottom); // 0x0000000181C51370-0x0000000181C514E0
		private void GenerateControlPoints(); // 0x0000000181C50090-0x0000000181C50430
		private float SegmentDistance(JobSegmentInfo isi); // 0x0000000181C53C90-0x0000000181C53D80
		private void GenerateContour(); // 0x0000000181C4F960-0x0000000181C50090
		private bool PrepareContour(); // 0x0000000181C52910-0x0000000181C529D0
		[BurstCompile]
		private static unsafe void UTessellator(ref SpriteShapeSegment geom, int maxCount, float2* tessPoints, int tessPointCount, ushort* indices, ref int iCount, byte* vertices, int stride, ref int vCount, Allocator label); // 0x0000000181C58650-0x0000000181C58660
		private bool TessellateContour(Allocator label); // 0x0000000181C55070-0x0000000181C551F0
		private void TessellateContourMainThread(); // 0x0000000181C54AD0-0x0000000181C55070
		private void CalculateBoundingBox(); // 0x0000000181C4DB30-0x0000000181C4DDC0
		private void CalculateTexCoords(); // 0x0000000181C4DE80-0x0000000181C4E0D0
		private void CopyVertexData(ref NativeSlice<Vector3> outPos, ref NativeSlice<Vector2> outUV0, ref NativeSlice<Vector4> outTan, int outIndex, ref Array<JobShapeVertex> inVertices, int inIndex, float sOrder); // 0x0000000181C4E4F0-0x0000000181C4E980
		private int CopySegmentRenderData(JobSpriteInfo ispr, ref NativeSlice<Vector3> outPos, ref NativeSlice<Vector2> outUV0, ref NativeSlice<Vector4> outTan, ref int outCount, ref NativeArray<ushort> indexData, ref int indexCount, ref Array<JobShapeVertex> inVertices, int inCount, float sOrder); // 0x0000000181C4E370-0x0000000181C4E4F0
		private void GetLineSegments(JobSpriteInfo sprInfo, JobSegmentInfo segment, float2 whsize, ref float2 vlt, ref float2 vlb, ref float2 vrt, ref float2 vrb); // 0x0000000181C51120-0x0000000181C51370
		private void TessellateSegment(int segmentIndex, JobSpriteInfo sprInfo, JobSegmentInfo segment, float2 whsize, float4 border, float pxlWidth, ref Array<JobShapeVertex> vertices, int vertexCount, bool useClosure, bool validHead, bool validTail, bool firstSegment, bool finalSegment, ref Array<JobShapeVertex> outputVertices, ref int outputCount); // 0x0000000181C55840-0x0000000181C56580
		private bool SkipSegment(JobSegmentInfo isi); // 0x0000000181C53DA0-0x0000000181C53F40
		private float InterpolateLinear(float a, float b, float t); // 0x0000000181C51B70-0x0000000181C51B80
		private float InterpolateSmooth(float a, float b, float t); // 0x0000000181C51B80-0x0000000181C51C30
		private bool AddVertex(ref Array<JobShapeVertex> array, ref int indexCount, JobShapeVertex vertex); // 0x0000000181C4CEF0-0x0000000181C4CF90
		private void TessellateSegments(); // 0x0000000181C56580-0x0000000181C57800
		private bool FetchStretcher(int segmentIndex, JobSpriteInfo sprInfo, JobSegmentInfo segment, float2 whsize, bool validHead, bool validTail, ref float4 stretcher); // 0x0000000181C4EBC0-0x0000000181C4F540
		private void StretchCorners(JobSegmentInfo segment, ref Array<JobShapeVertex> vertices, int vertexCount, bool validHead, bool validTail, float4 stretcher); // 0x0000000181C540C0-0x0000000181C54AD0
		private void ExtendSegment(ref float2 l0, ref float2 r0); // 0x0000000181C4EAB0-0x0000000181C4EBC0
		private bool GetIntersection(int cp, int ct, JobSpriteInfo ispr, ref float2 lt0, ref float2 lb0, ref float2 rt0, ref float2 rb0, ref float2 lt1, ref float2 lb1, ref float2 rt1, ref float2 rb1, ref float2 tp, ref float2 bt); // 0x0000000181C50B40-0x0000000181C51120
		private bool AttachCorner(int cp, int ct, JobSpriteInfo ispr, ref NativeArray<JobControlPoint> newPoints, ref int activePoint); // 0x0000000181C4D260-0x0000000181C4DA30
		private float2 CornerTextureCoordinate(int cornerType, int index); // 0x0000000181C4E980-0x0000000181C4E9B0
		private int CalculateCorner(int index, float angle, float2 lt, float2 rt); // 0x0000000181C4DDC0-0x0000000181C4DE80
		private bool InsertCorner(int index, ref NativeArray<int2> cpSpriteIndices, ref NativeArray<JobControlPoint> newPoints, ref int activePoint, ref bool cornerConsidered); // 0x0000000181C51680-0x0000000181C51B70
		private void TessellateCorners(); // 0x0000000181C551F0-0x0000000181C55840
		private bool AreCollinear(float2 a, float2 b, float2 c, float t); // 0x0000000181C4D0C0-0x0000000181C4D130
		private void OptimizePoints(float tolerance, bool tess, ref NativeArray<float2> pointSet, ref int pointCount); // 0x0000000181C52230-0x0000000181C52620
		private void AttachCornerToCollider(JobSegmentInfo isi, float pivot, ref NativeArray<float2> points, ref int pointCount); // 0x0000000181C4D130-0x0000000181C4D260
		private float2 UpdateExtraGeometry(JobSegmentInfo isi, JobSpriteInfo ispr, ref Array<JobShapeVertex> vertices, int count, ref NativeArray<float2> points, ref int pointCount, float _pivot); // 0x0000000181C58660-0x0000000181C588F0
		private static void TrimOverlaps(int cpCount, bool _isCarpet, int _splineDetail, float _kEpsilon, float _kEpsilonRelaxed, ref NativeArray<float2> _colliderPoints, ref int colliderPointCount); // 0x0000000181C57D20-0x0000000181C58330
		private void OptimizeCollider(); // 0x0000000181C52090-0x0000000181C52230
		private void OptimizeShadow(); // 0x0000000181C52620-0x0000000181C527C0
		[Obsolete]
		public void Prepare(SpriteShapeController controller, SpriteShapeParameters shapeParams, int maxArrayCount, NativeArray<ShapeControlPoint> shapePoints, NativeArray<SpriteShapeMetaData> metaData, AngleRangeInfo[] angleRanges, Sprite[] segmentSprites, Sprite[] cornerSprites); // 0x0000000181C53940-0x0000000181C53B70
		internal void Prepare(SpriteShapeController controller, SpriteShapeParameters shapeParams, int maxArrayCount, NativeArray<ShapeControlPoint> shapePoints, NativeArray<SplinePointMetaData> metaData, AngleRangeInfo[] angleRanges, Sprite[] segmentSprites, Sprite[] cornerSprites, bool UseUTess); // 0x0000000181C53770-0x0000000181C53940
		public void Execute(); // 0x0000000181C4EA30-0x0000000181C4EAB0
		public void Cleanup(); // 0x0000000181C4E0D0-0x0000000181C4E2B0
		[BurstCompile]
		[MonoPInvokeCallback(typeof(UTessellator_000001B2_PostfixBurstDelegate))]
		internal static unsafe void UTessellator_BurstManaged(ref SpriteShapeSegment geom, int maxCount, float2* tessPoints, int tessPointCount, ushort* indices, ref int iCount, byte* vertices, int stride, ref int vCount, Allocator label); // 0x0000000181C58330-0x0000000181C58650
	}
}
