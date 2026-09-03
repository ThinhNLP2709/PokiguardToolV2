/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	public static class BezierUtility // TypeDefIndex: 13985
	{
		// Methods
		public static Vector3 BezierPoint(Vector3 startRightTangent, Vector3 startPosition, Vector3 endPosition, Vector3 endLeftTangent, float t); // 0x0000000181C40E50-0x0000000181C40FB0
		internal static float GetSpritePixelWidth(Sprite sprite); // 0x0000000181C42190-0x0000000181C422D0
		internal static float BezierLength(NativeArray<ShapeControlPoint> shapePoints, int splineDetail, ref float smallestSegment); // 0x0000000181C40AC0-0x0000000181C40E50
		internal static Vector3 ClosestPointOnCurve(Vector3 point, Vector3 startPosition, Vector3 endPosition, Vector3 startTangent, Vector3 endTangent, float sqrError, out float t); // 0x0000000181C41830-0x0000000181C41EF0
		internal static Vector3 ClosestPointOnCurveFast(Vector3 point, Vector3 startPosition, Vector3 endPosition, Vector3 startTangent, Vector3 endTangent, float sqrError, out float t); // 0x0000000181C40FB0-0x0000000181C410C0
		private static Vector3 ClosestPointOnCurveIterative(Vector3 point, Vector3 startPosition, Vector3 endPosition, Vector3 startTangent, Vector3 endTangent, float sqrError, ref float startT, ref float endT); // 0x0000000181C410C0-0x0000000181C41830
		internal static void SplitBezier(float t, Vector3 startPosition, Vector3 endPosition, Vector3 startRightTangent, Vector3 endLeftTangent, out Vector3 leftStartPosition, out Vector3 leftEndPosition, out Vector3 leftStartTangent, out Vector3 leftEndTangent, out Vector3 rightStartPosition, out Vector3 rightEndPosition, out Vector3 rightStartTangent, out Vector3 rightEndTangent); // 0x0000000181C422D0-0x0000000181C425D0
		internal static Vector3 ClosestPointToSegment(Vector3 point, Vector3 segmentStart, Vector3 segmentEnd, out float t); // 0x0000000181C41EF0-0x0000000181C42130
		private static float SqrDistanceToPolyLine(Vector3 point, NativeArray<Vector3> points); // 0x0000000181C425D0-0x0000000181C42940
		private static float SqrDistanceToSegment(Vector3 point, Vector3 segmentStart, Vector3 segmentEnd); // 0x0000000181C42940-0x0000000181C42BF0
		private static bool Colinear(Vector3 v1, Vector3 v2, float error = 0.0001f /* Metadata: 0x006A9157 */); // 0x0000000181C42130-0x0000000181C42190
	}
}
