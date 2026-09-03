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
	[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\GPUDriven\\Culling\\InstanceOcclusionCuller.cs", needAccessors = false)]
	internal struct IndirectDrawInfo // TypeDefIndex: 12865
	{
		// Fields
		public uint indexCount; // 0x00
		public uint firstIndex; // 0x04
		public uint baseVertex; // 0x08
		public uint firstInstanceGlobalIndex; // 0x0C
		public uint maxInstanceCountAndTopology; // 0x10
	}
}
