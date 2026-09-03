/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal static class ProbeVolumeConstantRuntimeResources // TypeDefIndex: 5608
	{
		// Fields
		private static ComputeBuffer m_SkySamplingDirectionsBuffer; // 0x00
		private static ComputeBuffer m_AntiLeakDataBuffer; // 0x08
		private const int NB_SKY_PRECOMPUTED_DIRECTIONS = 255; // Metadata: 0x00661737
		private static Vector3[] k_SkyDirections; // 0x10
		private static readonly uint[] k_AntiLeakData; // 0x18
	
		// Constructors
		static ProbeVolumeConstantRuntimeResources(); // 0x0000000181E85170-0x0000000181E85300
	
		// Methods
		internal static void GetRuntimeResources(ref ProbeReferenceVolume.RuntimeResources rr); // 0x0000000181E84EC0-0x0000000181E84F40
		internal static void Initialize(); // 0x0000000181E84F90-0x0000000181E85170
		public static Vector3[] GetSkySamplingDirections(); // 0x0000000181E84F40-0x0000000181E84F90
		internal static void Cleanup(); // 0x0000000181E84B70-0x0000000181E84C60
		private static Vector3[] GenerateSkyDirections(); // 0x0000000181E84C60-0x0000000181E84EC0
	}
}
