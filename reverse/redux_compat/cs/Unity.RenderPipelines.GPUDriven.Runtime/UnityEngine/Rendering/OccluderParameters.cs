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
using UnityEngine.Rendering.RenderGraphModule;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	public struct OccluderParameters // TypeDefIndex: 12933
	{
		// Fields
		public EntityId viewInstanceID; // 0x00
		public int subviewCount; // 0x08
		public TextureHandle depthTexture; // 0x0C
		public Vector2Int depthSize; // 0x1C
		public bool depthIsArray; // 0x24
	
		// Constructors
		public OccluderParameters(EntityId viewInstanceID); // 0x0000000181F41F60-0x0000000181F42030
	}
}
