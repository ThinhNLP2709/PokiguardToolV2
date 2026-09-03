/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class Universal2DResourceData : UniversalResourceDataBase // TypeDefIndex: 9476
	{
		// Fields
		private TextureHandle[][] _lightTextures; // 0x18
		private TextureHandle[] _cameraNormalsTexture; // 0x20
		private TextureHandle _normalsDepth; // 0x28
		private TextureHandle[][] _shadowTextures; // 0x38
		private TextureHandle _shadowDepth; // 0x40
		private TextureHandle _upscaleTexture; // 0x50
		private TextureHandle _cameraSortingLayerTexture; // 0x60
		private TextureHandle _renderingLayersTexture; // 0x70
	
		// Properties
		public TextureHandle[][] lightTextures { get; set; } // 0x0000000181F9BC00-0x0000000181F9BC10 0x0000000181F9BD10-0x0000000181F9BD30
		public TextureHandle[] normalsTexture { get; set; } // 0x0000000181F9BC40-0x0000000181F9BC50 0x0000000181F9BD50-0x0000000181F9BD70
		public TextureHandle normalsDepth { get; set; } // 0x0000000181F9BC10-0x0000000181F9BC40 0x0000000181F9BD30-0x0000000181F9BD50
		public TextureHandle[][] shadowTextures { get; set; } // 0x0000000181F9BCB0-0x0000000181F9BCC0 0x0000000181F9BDB0-0x0000000181F9BDD0
		public TextureHandle shadowDepth { get; set; } // 0x0000000181F9BC80-0x0000000181F9BCB0 0x0000000181F9BD90-0x0000000181F9BDB0
		internal TextureHandle upscaleTexture { get; set; } // 0x0000000181F9BCC0-0x0000000181F9BCF0 0x0000000181F9BDD0-0x0000000181F9BDF0
		public TextureHandle cameraSortingLayerTexture { get; set; } // 0x0000000181F9BBD0-0x0000000181F9BC00 0x0000000181F9BCF0-0x0000000181F9BD10
		public TextureHandle renderingLayersTexture { get; internal set; } // 0x0000000181F9BC50-0x0000000181F9BC80 0x0000000181F9BD70-0x0000000181F9BD90
	
		// Constructors
		public Universal2DResourceData(); // 0x0000000181F9BB30-0x0000000181F9BBD0
	
		// Methods
		private TextureHandle[][] CheckAndGetTextureHandle(ref TextureHandle[][] handle); // 0x0000000181F9B440-0x0000000181F9B5C0
		private void CheckAndSetTextureHandle(ref TextureHandle[][] handle, [IsReadOnly] in TextureHandle[][] newHandle); // 0x0000000181F9B5C0-0x0000000181F9B720
		public override void Reset(); // 0x0000000181F9B720-0x0000000181F9BB30
	}
}
