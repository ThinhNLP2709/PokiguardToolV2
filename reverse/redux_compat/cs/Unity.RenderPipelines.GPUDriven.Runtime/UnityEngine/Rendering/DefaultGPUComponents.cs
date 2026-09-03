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
	internal struct DefaultGPUComponents // TypeDefIndex: 12759
	{
		// Fields
		public readonly GPUComponentHandle shCoefficients; // 0x00
		public readonly GPUComponentHandle lightmapScaleOffset; // 0x02
		public readonly GPUComponentHandle objectToWorld; // 0x04
		public readonly GPUComponentHandle worldToObject; // 0x06
		public readonly GPUComponentHandle matrixPreviousM; // 0x08
		public readonly GPUComponentHandle matrixPreviousMI; // 0x0A
		public readonly GPUComponentHandle rendererUserValues; // 0x0C
		public readonly GPUComponentHandle lightProbeUsages; // 0x0E
		public readonly GPUComponentHandle boundingSphere; // 0x10
		public readonly NativeArray<GPUComponentHandle> speedTreeWind; // 0x18
		public readonly NativeArray<GPUComponentHandle> speedTreeWindHistory; // 0x28
		public readonly GPUComponentSet requiredComponentSet; // 0x38
		public readonly GPUComponentSet lightProbesComponentSet; // 0x40
		public readonly GPUComponentSet speedTreeComponentSet; // 0x48
		public readonly GPUComponentSet defaultGOComponentSet; // 0x50
		public readonly GPUComponentSet defaultSpeedTreeComponentSet; // 0x58
		public readonly GPUArchetypeHandle defaultGOArchetype; // 0x60
	
		// Constructors
		public DefaultGPUComponents(ref GPUArchetypeManager archetypeManager, bool enableBoundingSpheresInstanceData); // 0x0000000181F05770-0x0000000181F06000
	
		// Methods
		public void Dispose(); // 0x0000000181F05710-0x0000000181F05770
	}
}
