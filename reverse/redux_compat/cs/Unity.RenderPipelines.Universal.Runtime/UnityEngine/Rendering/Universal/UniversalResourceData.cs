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
	public class UniversalResourceData : UniversalResourceDataBase // TypeDefIndex: 9483
	{
		// Fields
		[CompilerGenerated]
		private ActiveID _activeColorID_k__BackingField; // 0x18
		[CompilerGenerated]
		private ActiveID _activeDepthID_k__BackingField; // 0x1C
		private TextureHandle _backBufferColor; // 0x20
		private TextureHandle _backBufferDepth; // 0x30
		private TextureHandle _cameraColor; // 0x40
		private TextureHandle _cameraDepth; // 0x50
		private TextureHandle _mainShadowsTexture; // 0x60
		private TextureHandle _additionalShadowsTexture; // 0x70
		private TextureHandle[] _gBuffer; // 0x80
		private TextureHandle _cameraOpaqueTexture; // 0x88
		private TextureHandle _cameraDepthTexture; // 0x98
		private TextureHandle _cameraNormalsTexture; // 0xA8
		private TextureHandle _motionVectorColor; // 0xB8
		private TextureHandle _motionVectorDepth; // 0xC8
		private TextureHandle _internalColorLut; // 0xD8
		private TextureHandle _bloom; // 0xE8
		private TextureHandle _afterPostProcessColor; // 0xF8
		private TextureHandle _overlayUITexture; // 0x108
		private TextureHandle _renderingLayersTexture; // 0x118
		private TextureHandle[] _dBuffer; // 0x128
		private TextureHandle _dBufferDepth; // 0x130
		private TextureHandle _ssaoTexture; // 0x140
		private TextureHandle _irradianceTexture; // 0x150
		private TextureHandle _ssrTexture; // 0x160
		private TextureHandle _stpDebugView; // 0x170
		private TextureHandle _destinationCameraColor; // 0x180
	
		// Properties
		internal ActiveID activeColorID { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public TextureHandle activeColorTexture { get; } // 0x0000000181F9F300-0x0000000181F9F470 
		internal ActiveID activeDepthID { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public TextureHandle activeDepthTexture { get; } // 0x0000000181F9F470-0x0000000181F9F5E0 
		public bool isActiveTargetBackBuffer { get; } // 0x0000000181F9F810-0x0000000181F9F880 
		public TextureHandle backBufferColor { get; internal set; } // 0x0000000181F9F610-0x0000000181F9F640 0x0000000181F9F9F0-0x0000000181F9FA10
		public TextureHandle backBufferDepth { get; internal set; } // 0x0000000181F9F640-0x0000000181F9F670 0x0000000181F9FA10-0x0000000181F9FA30
		public TextureHandle cameraColor { get; set; } // 0x0000000181F9BC80-0x0000000181F9BCB0 0x0000000181F9BD90-0x0000000181F9BDB0
		public TextureHandle cameraDepth { get; set; } // 0x0000000181F9BCC0-0x0000000181F9BCF0 0x0000000181F9BDD0-0x0000000181F9BDF0
		public TextureHandle mainShadowsTexture { get; set; } // 0x0000000181F9BBD0-0x0000000181F9BC00 0x0000000181F9BCF0-0x0000000181F9BD10
		public TextureHandle additionalShadowsTexture { get; set; } // 0x0000000181F9BC50-0x0000000181F9BC80 0x0000000181F9BD70-0x0000000181F9BD90
		public TextureHandle[] gBuffer { get; set; } // 0x0000000181F9F7A0-0x0000000181F9F7B0 0x0000000181F9FB20-0x0000000181F9FB50
		public TextureHandle cameraOpaqueTexture { get; internal set; } // 0x0000000181F9F700-0x0000000181F9F730 0x0000000181F9FA90-0x0000000181F9FAB0
		public TextureHandle cameraDepthTexture { get; internal set; } // 0x0000000181F9F6A0-0x0000000181F9F6D0 0x0000000181F9FA50-0x0000000181F9FA70
		public TextureHandle cameraNormalsTexture { get; internal set; } // 0x0000000181F9F6D0-0x0000000181F9F700 0x0000000181F9FA70-0x0000000181F9FA90
		public TextureHandle motionVectorColor { get; set; } // 0x0000000181F9F880-0x0000000181F9F8B0 0x0000000181F9FB90-0x0000000181F9FBB0
		public TextureHandle motionVectorDepth { get; set; } // 0x0000000181F9F8B0-0x0000000181F9F8E0 0x0000000181F9FBB0-0x0000000181F9FBD0
		public TextureHandle internalColorLut { get; set; } // 0x0000000181F9F7B0-0x0000000181F9F7E0 0x0000000181F9FB50-0x0000000181F9FB70
		internal TextureHandle bloom { get; set; } // 0x0000000181F9F670-0x0000000181F9F6A0 0x0000000181F9FA30-0x0000000181F9FA50
		[Obsolete("AfterPostProcessColor has never been implemented. Use cameraColor instead.", false)]
		public TextureHandle afterPostProcessColor { get; internal set; } // 0x0000000181F9F5E0-0x0000000181F9F610 0x0000000181F9F9D0-0x0000000181F9F9F0
		public TextureHandle overlayUITexture { get; internal set; } // 0x0000000181F9F8E0-0x0000000181F9F910 0x0000000181F9FBD0-0x0000000181F9FBF0
		public TextureHandle renderingLayersTexture { get; internal set; } // 0x0000000181F9F910-0x0000000181F9F940 0x0000000181F9FBF0-0x0000000181F9FC10
		public TextureHandle[] dBuffer { get; set; } // 0x0000000181F9F760-0x0000000181F9F770 0x0000000181F9FAD0-0x0000000181F9FB00
		public TextureHandle dBufferDepth { get; set; } // 0x0000000181F9F730-0x0000000181F9F760 0x0000000181F9FAB0-0x0000000181F9FAD0
		public TextureHandle ssaoTexture { get; internal set; } // 0x0000000181F9F940-0x0000000181F9F970 0x0000000181F9FC10-0x0000000181F9FC30
		internal TextureHandle irradianceTexture { get; set; } // 0x0000000181F9F7E0-0x0000000181F9F810 0x0000000181F9FB70-0x0000000181F9FB90
		internal TextureHandle ssrTexture { get; set; } // 0x0000000181F9F970-0x0000000181F9F9A0 0x0000000181F9FC30-0x0000000181F9FC50
		internal TextureHandle stpDebugView { get; set; } // 0x0000000181F9F9A0-0x0000000181F9F9D0 0x0000000181F9FC50-0x0000000181F9FC70
		internal TextureHandle destinationCameraColor { get; set; } // 0x0000000181F9F770-0x0000000181F9F7A0 0x0000000181F9FB00-0x0000000181F9FB20
	
		// Constructors
		public UniversalResourceData(); // 0x0000000181F9F270-0x0000000181F9F300
	
		// Methods
		public void SwitchActiveTexturesToBackbuffer(); // 0x0000000181F9F260-0x0000000181F9F270
		public override void Reset(); // 0x0000000181F9EA40-0x0000000181F9F260
	}
}
