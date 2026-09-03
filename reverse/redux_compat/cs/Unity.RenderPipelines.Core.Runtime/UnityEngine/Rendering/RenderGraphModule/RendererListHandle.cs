/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("RendererList ({handle})")]
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public struct RendererListHandle // TypeDefIndex: 5957
	{
		// Fields
		internal RendererListHandleType type; // 0x00
		private bool m_IsValid; // 0x04
		[CompilerGenerated]
		private int _handle_k__BackingField; // 0x08
	
		// Properties
		internal int handle { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
	
		// Constructors
		internal RendererListHandle(int handle, RendererListHandleType type = RendererListHandleType.Renderers /* Metadata: 0x00662C35 */); // 0x0000000181EEE260-0x0000000181EEE270
	
		// Methods
		public static implicit operator int(RendererListHandle handle); // 0x0000000180732D20-0x0000000180732D30
		public static implicit operator RendererList(RendererListHandle rendererList); // 0x0000000181EEE270-0x0000000181EEE470
		public bool IsValid(); // 0x00000001813282D0-0x00000001813282E0
	}
}
