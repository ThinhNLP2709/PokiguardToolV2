/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct AdditionalLightsShadowAtlasLayout // TypeDefIndex: 9548
	{
		// Fields
		private static List<RectInt> s_UnusedAtlasSquareAreas; // 0x00
		private static List<ShadowResolutionRequest> s_ShadowResolutionRequests; // 0x08
		private static float[] s_VisibleLightIndexToCameraSquareDistance; // 0x10
		private static Func<ShadowResolutionRequest, ShadowResolutionRequest, int> s_CompareShadowResolutionRequest; // 0x18
		private static ShadowResolutionRequest[] s_SortedShadowResolutionRequests; // 0x20
		private NativeArray<ShadowResolutionRequest> m_SortedShadowResolutionRequests; // 0x00
		private NativeArray<int> m_VisibleLightIndexToSortedShadowResolutionRequestsFirstSliceIndex; // 0x10
		private int m_TotalShadowSlicesCount; // 0x20
		private int m_TotalShadowResolutionRequestCount; // 0x24
		private bool m_TooManyShadowMaps; // 0x28
		private int m_ShadowSlicesScaleFactor; // 0x2C
		private int m_AtlasSize; // 0x30
	
		// Nested types
		internal struct ShadowResolutionRequest // TypeDefIndex: 9549
		{
			// Fields
			public ushort visibleLightIndex; // 0x00
			public ushort perLightShadowSliceIndex; // 0x02
			public ushort requestedResolution; // 0x04
			public ushort offsetX; // 0x06
			public ushort offsetY; // 0x08
			public ushort allocatedResolution; // 0x0A
			private SettingsOptions m_ShadowProperties; // 0x0C
	
			// Properties
			public bool softShadow { get; set; } // 0x0000000181F981F0-0x0000000181F98200 0x0000000181F98230-0x0000000181F98260
			public bool pointLightShadow { get; set; } // 0x0000000181F981E0-0x0000000181F981F0 0x0000000181F98200-0x0000000181F98230
	
			// Nested types
			[Flags]
			private enum SettingsOptions : ushort // TypeDefIndex: 9550
			{
				None = 0,
				SoftShadow = 1,
				PointLightShadow = 2,
				All = 65535
			}
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9551
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<ShadowResolutionRequest, ShadowResolutionRequest, int> __9__24_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F9B2C0-0x0000000181F9B330
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _CreateCompareShadowResolutionRequesPredicate_b__24_0(ShadowResolutionRequest curr, ShadowResolutionRequest other); // 0x0000000181F99F50-0x0000000181F9A100
		}
	
		// Constructors
		public AdditionalLightsShadowAtlasLayout(UniversalLightData lightData, UniversalShadowData shadowData, UniversalCameraData cameraData); // 0x0000000181F879F0-0x0000000181F88B90
	
		// Methods
		public int GetTotalShadowSlicesCount(); // 0x0000000180C4F680-0x0000000180C4F690
		public int GetTotalShadowResolutionRequestCount(); // 0x0000000180D17D10-0x0000000180D17D20
		public bool HasTooManyShadowMaps(); // 0x0000000180327270-0x0000000180327280
		public int GetShadowSlicesScaleFactor(); // 0x00000001803B5DE0-0x00000001803B5DF0
		public int GetAtlasSize(); // 0x000000018033D100-0x000000018033D110
		public bool HasSpaceForLight(int originalVisibleLightIndex); // 0x0000000181F879E0-0x0000000181F879F0
		public ShadowResolutionRequest GetSortedShadowResolutionRequest(int sortedShadowResolutionRequestIndex); // 0x0000000180C2E740-0x0000000180C2E770
		public ShadowResolutionRequest GetSliceShadowResolutionRequest(int originalVisibleLightIndex, int sliceIndex); // 0x0000000181F879A0-0x0000000181F879E0
		public static void ClearStaticCaches(); // 0x0000000181F87740-0x0000000181F87840
		private static int EstimateScaleFactorNeededToFitAllShadowsInAtlas([IsReadOnly] in NativeArray<ShadowResolutionRequest> shadowResolutionRequests, int endIndex, int atlasSize); // 0x0000000181F87920-0x0000000181F879A0
		private static Func<ShadowResolutionRequest, ShadowResolutionRequest, int> CreateCompareShadowResolutionRequesPredicate(); // 0x0000000181F87840-0x0000000181F87920
	}
}
