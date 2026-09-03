/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.RenderPipelines.Core.Runtime.Shared;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class ValidationHandler // TypeDefIndex: 9876
	{
		// Fields
		private string k_ErrorMesssageHowToResolve; // 0x10
		private OnTileValidationLayer m_OnTileValidationLayer; // 0x18
		[CompilerGenerated]
		private bool _active_k__BackingField; // 0x20
	
		// Properties
		public bool active { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Constructors
		public ValidationHandler(bool onTileValidation); // 0x0000000182030B90-0x0000000182030C50
	
		// Methods
		[Conditional("UNITY_ENABLE_CHECKS")]
		public void OnBeginRenderGraphFrame(); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("UNITY_ENABLE_CHECKS")]
		public void OnBeforeRendering(RenderGraph renderGraph, UniversalResourceData resourceData); // 0x0000000182030AB0-0x0000000182030B90
		[Conditional("UNITY_ENABLE_CHECKS")]
		public void OnBeforeGBuffers(RenderGraph renderGraph, UniversalResourceData resourceData); // 0x0000000182030A00-0x0000000182030AB0
	}
}
