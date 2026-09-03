/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering.RendererUtils
{
	public struct RendererListDesc // TypeDefIndex: 8461
	{
		// Fields
		public SortingCriteria sortingCriteria; // 0x00
		public PerObjectData rendererConfiguration; // 0x04
		public RenderQueueRange renderQueueRange; // 0x08
		public RenderStateBlock? stateBlock; // 0x10
		public Shader overrideShader; // 0x80
		public Material overrideMaterial; // 0x88
		public bool excludeObjectMotionVectors; // 0x90
		public int layerMask; // 0x94
		public uint renderingLayerMask; // 0x98
		[CompilerGenerated]
		private uint _batchLayerMask_k__BackingField; // 0x9C
		public int overrideMaterialPassIndex; // 0xA0
		public int overrideShaderPassIndex; // 0xA4
		[CompilerGenerated]
		private CullingResults _cullingResult_k__BackingField; // 0xA8
		[CompilerGenerated]
		private Camera _camera_k__BackingField; // 0xB8
		[CompilerGenerated]
		private ShaderTagId _passName_k__BackingField; // 0xC0
		[CompilerGenerated]
		private ShaderTagId[] _passNames_k__BackingField; // 0xC8
		private static readonly ShaderTagId s_EmptyName; // 0x00
	
		// Properties
		public uint batchLayerMask { [CompilerGenerated] [IsReadOnly] get; } // 0x000000018033D200-0x000000018033D210 
		internal CullingResults cullingResult { [IsReadOnly] [CompilerGenerated] get; } // 0x0000000181EE0880-0x0000000181EE0890 
		internal Camera camera { [CompilerGenerated] [IsReadOnly] get; } // 0x00000001806CCB90-0x00000001806CCBA0 
		internal ShaderTagId passName { [CompilerGenerated] [IsReadOnly] get; } // 0x0000000181239340-0x0000000181239350 
		internal ShaderTagId[] passNames { [IsReadOnly] [CompilerGenerated] get; } // 0x00000001806CCB50-0x00000001806CCB60 
	
		// Constructors
		static RendererListDesc(); // 0x0000000182264250-0x00000001822642A0
	
		// Methods
		public bool IsValid(); // 0x0000000182264170-0x0000000182264250
		public static RendererListParams ConvertToParameters([IsReadOnly] in RendererListDesc desc); // 0x00000001822636D0-0x0000000182264170
	}
}
