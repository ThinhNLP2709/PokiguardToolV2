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
	internal static class LightmapUtils // TypeDefIndex: 12984
	{
		// Fields
		public const short LightmapIndexNull = -1; // Metadata: 0x006A7691
		public const short LightmapIndexInfluenceOnly = -2; // Metadata: 0x006A7693
		public static readonly float4 kDefaultLightmapST; // 0x00
	
		// Constructors
		static LightmapUtils(); // 0x0000000181F4EBB0-0x0000000181F4EBF0
	
		// Methods
		public static bool IsNull(int lightmapIndex); // 0x0000000181F4EB90-0x0000000181F4EBA0
		public static bool IsInfluenceOnly(int lightmapIndex); // 0x0000000181F4EB80-0x0000000181F4EB90
		public static bool UsesLightmaps(int lightmapIndex); // 0x0000000181F4EBA0-0x0000000181F4EBB0
		public static bool AffectsLightmaps(int lightmapIndex); // 0x0000000181F4EB70-0x0000000181F4EB80
	}
}
