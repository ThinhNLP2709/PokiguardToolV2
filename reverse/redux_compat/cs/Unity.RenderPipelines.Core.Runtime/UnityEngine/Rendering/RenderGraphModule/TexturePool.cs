/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal class TexturePool : RenderGraphResourcePool<RTHandle> // TypeDefIndex: 5968
	{
		// Constructors
		public TexturePool(); // 0x0000000181EF01B0-0x0000000181EF0210
	
		// Methods
		protected override void ReleaseInternalResource(RTHandle res); // 0x0000000181EF0190-0x0000000181EF01B0
		protected override string GetResourceName([IsReadOnly] in RTHandle res); // 0x0000000181EF00E0-0x0000000181EF0110
		protected override long GetResourceSize([IsReadOnly] in RTHandle res); // 0x0000000181EF0110-0x0000000181EF0140
		protected override string GetResourceTypeName(); // 0x0000000181EF0140-0x0000000181EF0170
		protected override ulong GetSortIndex(RTHandle res); // 0x0000000181EF0170-0x0000000181EF0190
	}
}
