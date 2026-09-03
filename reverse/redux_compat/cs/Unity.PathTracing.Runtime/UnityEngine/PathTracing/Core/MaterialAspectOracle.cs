/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal static class MaterialAspectOracle // TypeDefIndex: 13591
	{
		// Nested types
		private enum RenderQueue // TypeDefIndex: 13592
		{
			GeometryRenderQueue = 2000,
			AlphaTestRenderQueue = 2450,
			TransparentRenderQueue = 3000,
			OverlayRenderQueue = 4000
		}
	
		private static class SID // TypeDefIndex: 13593
		{
			// Fields
			public static readonly int EmissionColor; // 0x00
			public static readonly int EmissionMap; // 0x04
			public static readonly int UseEmissiveMap; // 0x08
			public static readonly int TransparencyLm; // 0x0C
			public static readonly int Color; // 0x10
			public static readonly int BaseColor; // 0x14
			public static readonly int Cutoff; // 0x18
			public static readonly int AlphaTestRef; // 0x1C
			public static readonly int MainTex; // 0x20
	
			// Constructors
			static SID(); // 0x0000000181DFC820-0x0000000181DFC9D0
		}
	
		// Methods
		public static MaterialPropertyDesc GetEmission(Material mat, EmissionMode emissionMode); // 0x0000000181DF4A70-0x0000000181DF4DB0
		private static bool EnumerableArrayContains(IEnumerable<string> array, string value); // 0x0000000181DF44D0-0x0000000181DF4840
		private static bool MaterialHasPropertyWithFlag(Material mat, ShaderPropertyFlags flag); // 0x0000000181DF5260-0x0000000181DF5340
		public static TransmissionDesc GetTransmission(Material mat); // 0x0000000181DF4DB0-0x0000000181DF50B0
		private static bool HasEmissionMap(Material mat); // 0x0000000181DF50B0-0x0000000181DF51E0
		private static bool IsMaterialWithEmissionKeyword(Material mat); // 0x0000000181DF51E0-0x0000000181DF5260
		public static float GetAlpha(Material mat); // 0x0000000181DF4900-0x0000000181DF4A70
		public static bool UsesAlphaCutoff(Material mat); // 0x0000000181DF5360-0x0000000181DF5420
		public static float GetAlphaCutoff(Material mat); // 0x0000000181DF4840-0x0000000181DF4900
		private static float3 ToFloat3(Color col); // 0x0000000181DF5340-0x0000000181DF5360
	}
}
