/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("Buffer ({handle.index})")]
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public struct BufferHandle // TypeDefIndex: 5943
	{
		// Fields
		private static readonly BufferHandle s_NullHandle; // 0x00
		internal readonly ResourceHandle handle; // 0x00
	
		// Properties
		public static BufferHandle nullHandle { get; } // 0x0000000181ED7AE0-0x0000000181ED7B50 
	
		// Constructors
		internal BufferHandle([IsReadOnly] in ResourceHandle h); // 0x0000000181D8BED0-0x0000000181D8BEE0
		internal BufferHandle(int handle, bool shared = false /* Metadata: 0x00662C27 */); // 0x0000000181ED7A60-0x0000000181ED7AE0
		static BufferHandle(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		public static implicit operator GraphicsBuffer(BufferHandle buffer); // 0x0000000181ED7B50-0x0000000181ED7D40
		public bool IsValid(); // 0x0000000181ED79B0-0x0000000181ED7A60
	}
}
