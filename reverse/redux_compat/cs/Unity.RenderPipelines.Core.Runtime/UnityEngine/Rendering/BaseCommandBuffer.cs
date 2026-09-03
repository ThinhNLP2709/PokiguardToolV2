/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class BaseCommandBuffer // TypeDefIndex: 5329
	{
		// Fields
		protected internal CommandBuffer m_WrappedCommandBuffer; // 0x10
		internal RenderGraphPass m_ExecutingPass; // 0x18
	
		// Properties
		public string name { get; } // 0x0000000181E1E070-0x0000000181E1E090 
		public int sizeInBytes { get; } // 0x0000000181E1E090-0x0000000181E1E0B0 
	
		// Constructors
		internal BaseCommandBuffer(CommandBuffer wrapped, RenderGraphPass executingPass, bool isAsync); // 0x0000000181E1DFF0-0x0000000181E1E070
	
		// Methods
		[Conditional("UNITY_ENABLE_CHECKS")]
		protected internal void ThrowIfGlobalStateNotAllowed(); // 0x0000000181E1D710-0x0000000181E1D7B0
		[Conditional("UNITY_ENABLE_CHECKS")]
		protected internal void ThrowIfRasterNotAllowed(); // 0x0000000181E1D7B0-0x0000000181E1D8E0
		[Conditional("UNITY_ENABLE_CHECKS")]
		protected internal void ValidateTextureHandle([IsReadOnly] in TextureHandle h); // 0x0000000181E1DDA0-0x0000000181E1DFF0
		[Conditional("UNITY_ENABLE_CHECKS")]
		protected internal void ValidateTextureHandleRead([IsReadOnly] in TextureHandle h); // 0x0000000181E1D8E0-0x0000000181E1DAE0
		[Conditional("UNITY_ENABLE_CHECKS")]
		protected internal void ValidateTextureHandleWrite([IsReadOnly] in TextureHandle h); // 0x0000000181E1DAE0-0x0000000181E1DDA0
	}
}
