/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct Line // TypeDefIndex: 12976
	{
		// Fields
		public float3 m; // 0x00
		public float3 t; // 0x0C
	
		// Methods
		internal static Line LineOfPlaneIntersectingPlane(float4 a, float4 b); // 0x0000000181F4EBF0-0x0000000181F4ECB0
		internal static float4 PlaneContainingLineAndPoint(Line a, float3 b); // 0x0000000181F4ECB0-0x0000000181F4EDB0
		internal static float4 PlaneContainingLineWithNormalPerpendicularToVector(Line a, float3 b); // 0x0000000181F4EDB0-0x0000000181F4EE90
	}
}
