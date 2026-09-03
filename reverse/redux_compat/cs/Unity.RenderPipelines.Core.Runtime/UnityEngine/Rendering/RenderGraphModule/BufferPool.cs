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
	internal class BufferPool : RenderGraphResourcePool<GraphicsBuffer> // TypeDefIndex: 5946
	{
		// Constructors
		public BufferPool(); // 0x0000000181ED7E40-0x0000000181ED7EA0
	
		// Methods
		protected override void ReleaseInternalResource(GraphicsBuffer res); // 0x0000000181ED7E20-0x0000000181ED7E40
		protected override string GetResourceName([IsReadOnly] in GraphicsBuffer res); // 0x0000000181ED7D40-0x0000000181ED7D70
		protected override long GetResourceSize([IsReadOnly] in GraphicsBuffer res); // 0x0000000181ED7D70-0x0000000181ED7DC0
		protected override string GetResourceTypeName(); // 0x0000000181ED7DC0-0x0000000181ED7DF0
		protected override ulong GetSortIndex(GraphicsBuffer res); // 0x0000000181ED7DF0-0x0000000181ED7E20
	}
}
