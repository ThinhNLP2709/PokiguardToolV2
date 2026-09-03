/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.Universal
{
	public class CullContextData : ContextItem // TypeDefIndex: 5866
	{
		// Fields
		internal ScriptableRenderContext? m_RenderContext; // 0x10
	
		// Constructors
		public CullContextData(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override void Reset(); // 0x0000000181EBD080-0x0000000181EBD090
		public void SetRenderContext([IsReadOnly] in ScriptableRenderContext renderContext); // 0x0000000181EBD090-0x0000000181EBD0C0
		public CullingResults Cull(ref ScriptableCullingParameters parameters); // 0x0000000181EBCFA0-0x0000000181EBD080
		public void CullShadowCasters(CullingResults cullingResults, ShadowCastersCullingInfos shadowCastersCullingInfos); // 0x0000000181EBCEA0-0x0000000181EBCFA0
	}
}
