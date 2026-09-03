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
	internal struct DrawBatch // TypeDefIndex: 12835
	{
		// Fields
		public DrawKey key; // 0x00
		public int instanceCount; // 0x40
		public int instanceOffset; // 0x44
		public MeshTopology topology; // 0x48
		public uint baseVertex; // 0x4C
		public uint firstIndex; // 0x50
		public uint indexCount; // 0x54
	}
}
