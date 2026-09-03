/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal static class LightGridUtils // TypeDefIndex: 13583
	{
		// Methods
		public static Vector3Int ComputeLightGridDims(Vector3 sceneBounds, int maxLightGridCellCount, GridSizingStrategy lightGridSizingStrategy); // 0x0000000181DEE7D0-0x0000000181DEEA60
		public static int ComputeMaxLightsInAnyCell(int2[] grid, Vector3Int gridDims); // 0x0000000181DEEA60-0x0000000181DEEB40
	}
}
