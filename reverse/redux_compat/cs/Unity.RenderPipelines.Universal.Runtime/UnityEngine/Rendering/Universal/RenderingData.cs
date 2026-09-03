/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public struct RenderingData // TypeDefIndex: 9840
	{
		// Fields
		internal ContextContainer frameData; // 0x00
		public CameraData cameraData; // 0x08
		public LightData lightData; // 0x10
		public ShadowData shadowData; // 0x18
		public PostProcessingData postProcessingData; // 0x20
	
		// Properties
		internal UniversalRenderingData universalRenderingData { get; } // 0x0000000181FF8CD0-0x0000000181FF8D20 
		public ref CullingResults cullResults { get; } // 0x0000000181FF8B90-0x0000000181FF8BE0 
		[Obsolete("supportsDynamicBatching is obsolete.", true)]
		public ref bool supportsDynamicBatching { get; } // 0x0000000181FF8C80-0x0000000181FF8CD0 
		public ref PerObjectData perObjectData { get; } // 0x0000000181FF8BE0-0x0000000181FF8C30 
		public ref bool postProcessingEnabled { get; } // 0x0000000181FF8C30-0x0000000181FF8C80 
	
		// Constructors
		internal RenderingData(ContextContainer frameData); // 0x0000000181FF8AD0-0x0000000181FF8B90
	}
}
