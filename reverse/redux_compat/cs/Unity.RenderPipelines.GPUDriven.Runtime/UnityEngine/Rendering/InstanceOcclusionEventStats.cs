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
	internal struct InstanceOcclusionEventStats // TypeDefIndex: 12917
	{
		// Fields
		public EntityId viewID; // 0x00
		public InstanceOcclusionEventType eventType; // 0x08
		public int occluderVersion; // 0x0C
		public int subviewMask; // 0x10
		public OcclusionTest occlusionTest; // 0x14
		public int visibleInstances; // 0x18
		public int culledInstances; // 0x1C
		public int visiblePrimitives; // 0x20
		public int culledPrimitives; // 0x24
	}
}
