/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public abstract class UniversalResourceDataBase : ContextItem // TypeDefIndex: 9481
	{
		// Fields
		[CompilerGenerated]
		private bool _isAccessible_k__BackingField; // 0x10
	
		// Properties
		internal bool isAccessible { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
	
		// Nested types
		internal enum ActiveID // TypeDefIndex: 9482
		{
			Camera = 0,
			BackBuffer = 1
		}
	
		// Constructors
		protected UniversalResourceDataBase(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal void InitFrame(); // 0x000000018030F220-0x000000018030F230
		internal void EndFrame(); // 0x0000000181738210-0x0000000181738220
		protected void CheckAndSetTextureHandle(ref TextureHandle handle, [IsReadOnly] in TextureHandle newHandle); // 0x0000000181F9E7F0-0x0000000181F9E880
		protected TextureHandle CheckAndGetTextureHandle(ref TextureHandle handle); // 0x0000000181F9E6E0-0x0000000181F9E7F0
		protected void CheckAndSetTextureHandle(ref TextureHandle[] handle, [IsReadOnly] in TextureHandle[] newHandle); // 0x0000000181F9E880-0x0000000181F9E9D0
		protected TextureHandle[] CheckAndGetTextureHandle(ref TextureHandle[] handle); // 0x0000000181F9E5A0-0x0000000181F9E6E0
		protected bool CheckAndWarnAboutAccessibility(); // 0x0000000181F9E9D0-0x0000000181F9EA40
	}
}
