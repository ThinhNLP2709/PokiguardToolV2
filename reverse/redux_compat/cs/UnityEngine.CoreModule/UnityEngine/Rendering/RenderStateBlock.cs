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
	public struct RenderStateBlock : IEquatable<UnityEngine.Rendering.RenderStateBlock> // TypeDefIndex: 8430
	{
		// Fields
		private BlendState m_BlendState; // 0x00
		private RasterState m_RasterState; // 0x44
		private DepthState m_DepthState; // 0x54
		private StencilState m_StencilState; // 0x56
		private int m_StencilReference; // 0x64
		private RenderStateMask m_Mask; // 0x68
	
		// Properties
		public BlendState blendState { set; } // 0x0000000182263440-0x0000000182263470
		public RasterState rasterState { set; } // 0x0000000182263480-0x0000000182263490
		public DepthState depthState { set; } // 0x0000000182263470-0x0000000182263480
		public StencilState stencilState { get; set; } // 0x0000000182263420-0x0000000182263440 0x0000000182263490-0x00000001822634A0
		public int stencilReference { get; set; } // 0x00000001802F2020-0x00000001802F2030 0x000000018033EA40-0x000000018033EA50
		public RenderStateMask mask { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
	
		// Constructors
		public RenderStateBlock(RenderStateMask mask); // 0x0000000182263200-0x0000000182263420
	
		// Methods
		public bool Equals(RenderStateBlock other); // 0x0000000182262E00-0x0000000182263030
		public override bool Equals(object obj); // 0x0000000182263030-0x0000000182263120
		public override int GetHashCode(); // 0x0000000182263120-0x0000000182263200
	}
}
