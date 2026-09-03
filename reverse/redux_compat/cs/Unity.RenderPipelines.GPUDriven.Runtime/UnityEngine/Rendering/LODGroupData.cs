/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct LODGroupData // TypeDefIndex: 12814
	{
		// Fields
		public const int k_MaxLODLevelsCount = 8; // Metadata: 0x006A75BF
		public bool valid; // 0x00
		public int lodCount; // 0x04
		public int rendererCount; // 0x08
		public unsafe fixed /* 0x00000000-0x00000000 */ float screenRelativeTransitionHeights[0]; // 0x0C
		public unsafe fixed /* 0x00000000-0x00000000 */ float fadeTransitionWidth[0]; // 0x2C
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _fadeTransitionWidth_e__FixedBuffer // TypeDefIndex: 12815
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _screenRelativeTransitionHeights_e__FixedBuffer // TypeDefIndex: 12816
		{
			// Fields
			public float FixedElementField; // 0x00
		}
	}
}
