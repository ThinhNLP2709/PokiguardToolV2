/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	public struct BufferDesc // TypeDefIndex: 5944
	{
		// Fields
		public int count; // 0x00
		public int stride; // 0x04
		public string name; // 0x08
		public GraphicsBuffer.Target target; // 0x10
		public GraphicsBuffer.UsageFlags usageFlags; // 0x14
	
		// Constructors
		public BufferDesc(int count, int stride); // 0x0000000181ED7970-0x0000000181ED7990
		public BufferDesc(int count, int stride, GraphicsBuffer.Target target); // 0x0000000181ED7990-0x0000000181ED79B0
	
		// Methods
		public override int GetHashCode(); // 0x0000000181ED7930-0x0000000181ED7970
	}
}
