/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal static class LODRenderingUtils // TypeDefIndex: 12993
	{
		// Methods
		public static float CalculateFOVHalfAngle(float fieldOfView); // 0x0000000181F4E890-0x0000000181F4E8B0
		public static float CalculateScreenRelativeMetricNoBias(LODParameters lodParams); // 0x0000000181F4E950-0x0000000181F4E9A0
		public static float CalculateMeshLodConstant(LODParameters lodParams, float screenRelativeMetric, float meshLodThreshold); // 0x0000000181F4E8C0-0x0000000181F4E8E0
		public static float CalculatePerspectiveDistance(Vector3 objPosition, Vector3 camPosition, float sqrScreenRelativeMetric); // 0x0000000181F4E8E0-0x0000000181F4E950
		public static float CalculateSqrPerspectiveDistance(Vector3 objPosition, Vector3 camPosition, float sqrScreenRelativeMetric); // 0x0000000181F4E9A0-0x0000000181F4E9F0
		public static float CalculateLODDistance(float relativeScreenHeight, float size); // 0x0000000181F4E8B0-0x0000000181F4E8C0
	
		// Extension methods
		public static Vector3 GetWorldReferencePoint(this LODGroup lodGroup); // 0x0000000181F4E9F0-0x0000000181F4EA80
		public static float GetWorldSpaceScale(this LODGroup lodGroup); // 0x0000000181F4EA80-0x0000000181F4EAE0
		public static float GetWorldSpaceSize(this LODGroup lodGroup); // 0x0000000181F4EAE0-0x0000000181F4EB70
	}
}
