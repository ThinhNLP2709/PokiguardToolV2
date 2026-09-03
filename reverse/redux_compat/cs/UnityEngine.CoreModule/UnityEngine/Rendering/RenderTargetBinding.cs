/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct RenderTargetBinding // TypeDefIndex: 8283
	{
		// Fields
		private RenderTargetIdentifier[] m_ColorRenderTargets; // 0x00
		private RenderTargetIdentifier m_DepthRenderTarget; // 0x08
		private RenderBufferLoadAction[] m_ColorLoadActions; // 0x30
		private RenderBufferStoreAction[] m_ColorStoreActions; // 0x38
		private RenderBufferLoadAction m_DepthLoadAction; // 0x40
		private RenderBufferStoreAction m_DepthStoreAction; // 0x44
		private RenderTargetFlags m_Flags; // 0x48
	
		// Properties
		public RenderTargetIdentifier[] colorRenderTargets { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public RenderTargetIdentifier depthRenderTarget { get; } // 0x0000000181328430-0x0000000181328450 
		public RenderBufferLoadAction[] colorLoadActions { get; } // 0x000000018031E110-0x000000018031E120 
		public RenderBufferStoreAction[] colorStoreActions { get; } // 0x00000001803272A0-0x00000001803272B0 
		public RenderBufferLoadAction depthLoadAction { get; } // 0x000000018033D790-0x000000018033D7A0 
		public RenderBufferStoreAction depthStoreAction { get; } // 0x000000018033D780-0x000000018033D790 
		public RenderTargetFlags flags { get; } // 0x000000018033D1C0-0x000000018033D1D0 
	}
}
