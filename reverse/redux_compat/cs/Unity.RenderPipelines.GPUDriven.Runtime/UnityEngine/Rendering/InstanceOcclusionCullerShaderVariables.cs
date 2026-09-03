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
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\GPUDriven\\Culling\\InstanceOcclusionCullerShaderVariables.cs", needAccessors = false, generateCBuffer = true)]
	internal struct InstanceOcclusionCullerShaderVariables // TypeDefIndex: 12877
	{
		// Fields
		public uint _DrawInfoAllocIndex; // 0x00
		public uint _DrawInfoCount; // 0x04
		public uint _InstanceInfoAllocIndex; // 0x08
		public uint _InstanceInfoCount; // 0x0C
		public int _BoundingSphereInstanceDataAddress; // 0x10
		public int _DebugCounterIndex; // 0x14
		public int _InstanceMultiplierShift; // 0x18
		public int _InstanceOcclusionCullerPad0; // 0x1C
	}
}
