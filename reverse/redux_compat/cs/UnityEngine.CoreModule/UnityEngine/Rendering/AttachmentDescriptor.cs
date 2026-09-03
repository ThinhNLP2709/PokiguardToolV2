/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct AttachmentDescriptor : IEquatable<AttachmentDescriptor> // TypeDefIndex: 8388
	{
		// Fields
		private RenderBufferLoadAction m_LoadAction; // 0x00
		private RenderBufferStoreAction m_StoreAction; // 0x04
		private GraphicsFormat m_Format; // 0x08
		private RenderTargetIdentifier m_LoadStoreTarget; // 0x10
		private RenderTargetIdentifier m_ResolveTarget; // 0x38
		private Color m_ClearColor; // 0x60
		private float m_ClearDepth; // 0x70
		private uint m_ClearStencil; // 0x74
	
		// Properties
		public RenderBufferLoadAction loadAction { set; } // 0x0000000180732D50-0x0000000180732D60
		public RenderBufferStoreAction storeAction { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public RenderTargetIdentifier loadStoreTarget { get; set; } // 0x0000000181102840-0x0000000181102860 0x0000000182254EC0-0x0000000182254EE0
		public RenderTargetIdentifier resolveTarget { set; } // 0x0000000182254EE0-0x0000000182254F00
		public Color clearColor { set; } // 0x000000018172A480-0x000000018172A490
		public float clearDepth { set; } // 0x0000000182141FE0-0x0000000182141FF0
		public uint clearStencil { set; } // 0x000000018198E760-0x000000018198E770
	
		// Constructors
		public AttachmentDescriptor(GraphicsFormat format); // 0x0000000182254DF0-0x0000000182254EC0
	
		// Methods
		public bool Equals(AttachmentDescriptor other); // 0x0000000182254B20-0x0000000182254CF0
		public override bool Equals(object obj); // 0x0000000182254A20-0x0000000182254B20
		public override int GetHashCode(); // 0x0000000182254CF0-0x0000000182254DF0
	}
}
