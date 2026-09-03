/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class CommandList : IDisposable // TypeDefIndex: 5017
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		public VisualElement m_Owner; // 0x10
		public UIRenderer m_UIRenderer; // 0x18
		public PanelRenderer m_PanelRenderer; // 0x20
		private readonly IntPtr m_VertexDecl; // 0x28
		private readonly IntPtr m_StencilState; // 0x30
		public MaterialPropertyBlock constantProps; // 0x38
		public GCHandle handle; // 0x40
		public Material m_Material; // 0x48
		public CommandFlags flags; // 0x50
		private NativeList<SerializedCommand> m_Commands; // 0x58
		private Vector4[] m_GpuTextureData; // 0x60
		private NativeList<DrawBufferRange> m_DrawRanges; // 0x68
		private List<MaterialPropertyBlock> m_UserPropBlocks; // 0x70
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x78
	
		// Properties
		public IntPtr stencilState { get; } // 0x000000018031E110-0x000000018031E120 
		public NativeList<DrawBufferRange> ActiveDrawRanges { get; } // 0x0000000180316960-0x0000000180316970 
		public NativeList<SerializedCommand> Commands { get; } // 0x00000001802F4000-0x00000001802F4010 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B255A0-0x0000000180B255B0 0x0000000180B262B0-0x0000000180B262C0
	
		// Constructors
		public CommandList(IntPtr vertexDecl, IntPtr stencilState); // 0x00000001823F2EF0-0x00000001823F3140
		static CommandList(); // 0x00000001823F2E60-0x00000001823F2EF0
	
		// Methods
		public void Reset(); // 0x00000001823F2B50-0x00000001823F2CE0
		public void Init(VisualElement owner, Material material, CommandFlags commandFlags); // 0x00000001823F2990-0x00000001823F2B50
		public void SetTexture(int name, Texture texture, int gpuDataOffset, Vector4 gpuData0, Vector4 gpuData1); // 0x00000001823F2CE0-0x00000001823F2E60
		public void ApplyUserProps(MaterialPropertyBlock userProps); // 0x00000001823F23E0-0x00000001823F2550
		public void ApplyBatchProps(); // 0x00000001823F2300-0x00000001823F23E0
		public void DrawRanges(Utility.GPUBuffer ib, Utility.GPUBuffer vb, NativeSlice<DrawBufferRange> ranges, KickRangesReason kickReason); // 0x00000001823F2840-0x00000001823F2990
		public void Dispose(); // 0x00000001823F26D0-0x00000001823F2840
		protected void Dispose(bool disposing); // 0x00000001823F2550-0x00000001823F26D0
	}
}
