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
	internal struct RangeKey : IEquatable<RangeKey> // TypeDefIndex: 12832
	{
		// Fields
		public byte layer; // 0x00
		public uint renderingLayerMask; // 0x04
		public MotionVectorGenerationMode motionMode; // 0x08
		public ShadowCastingMode shadowCastingMode; // 0x0C
		public bool staticShadowCaster; // 0x10
		public int rendererPriority; // 0x14
		public bool supportsIndirect; // 0x18
	
		// Methods
		public bool Equals(RangeKey other); // 0x0000000181F2A390-0x0000000181F2A410
		public override int GetHashCode(); // 0x0000000181F2A410-0x0000000181F2A460
	}
}
