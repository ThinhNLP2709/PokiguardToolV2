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
	internal struct InstanceCullerViewStats // TypeDefIndex: 12915
	{
		// Fields
		public BatchCullingViewType viewType; // 0x00
		public EntityId viewID; // 0x08
		public int splitIndex; // 0x10
		public int visibleInstancesOnCPU; // 0x14
		public int visibleInstancesOnGPU; // 0x18
		public int visiblePrimitivesOnCPU; // 0x1C
		public int visiblePrimitivesOnGPU; // 0x20
		public int drawCommands; // 0x24
	}
}
