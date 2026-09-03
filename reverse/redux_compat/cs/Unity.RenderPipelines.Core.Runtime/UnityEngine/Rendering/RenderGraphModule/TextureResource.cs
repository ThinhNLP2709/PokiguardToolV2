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
	[DebuggerDisplay("TextureResource ({desc.name})")]
	internal class TextureResource : RenderGraphResource<TextureDesc, RTHandle> // TypeDefIndex: 5967
	{
		// Fields
		private static int m_TextureCreationIndex; // 0x00
		internal TextureUVOriginSelection textureUVOrigin; // 0xC8
	
		// Constructors
		public TextureResource(); // 0x0000000180A6DF30-0x0000000180A6DF40
	
		// Methods
		public override string GetName(); // 0x0000000181EF05E0-0x0000000181EF0650
		public override int GetDescHashCode(); // 0x0000000181EF05D0-0x0000000181EF05E0
		public override void CreateGraphicsResource(); // 0x0000000181EF0210-0x0000000181EF05D0
		public override void UpdateGraphicsResource(); // 0x0000000181EF0680-0x0000000181EF06D0
		public override void ReleaseGraphicsResource(); // 0x0000000181EF0650-0x0000000181EF0680
	}
}
