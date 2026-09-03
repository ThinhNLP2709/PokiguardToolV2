/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[IsReadOnly]
	internal struct TextureAccess // TypeDefIndex: 5960
	{
		// Fields
		public readonly TextureHandle textureHandle; // 0x00
		public readonly int mipLevel; // 0x10
		public readonly int depthSlice; // 0x14
		public readonly AccessFlags flags; // 0x18
	
		// Constructors
		public TextureAccess([IsReadOnly] in TextureHandle handle, AccessFlags flags, int mipLevel, int depthSlice); // 0x0000000181EEEC80-0x0000000181EEECA0
		public TextureAccess([IsReadOnly] in TextureAccess access, [IsReadOnly] in TextureHandle handle); // 0x0000000181EEECA0-0x0000000181EEECC0
	}
}
