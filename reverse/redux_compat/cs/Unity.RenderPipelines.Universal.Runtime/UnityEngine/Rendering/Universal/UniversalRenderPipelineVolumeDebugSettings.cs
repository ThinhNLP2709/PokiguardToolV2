/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[Obsolete("This is not longer supported Please use DebugDisplaySettingsVolume. #from(6000.2)")]
	public class UniversalRenderPipelineVolumeDebugSettings : VolumeDebugSettings<UniversalAdditionalCameraData> // TypeDefIndex: 9400
	{
		// Properties
		public override VolumeStack selectedCameraVolumeStack { get; } // 0x0000000181F867B0-0x0000000181F868C0 
		public override LayerMask selectedCameraLayerMask { get; } // 0x0000000181F865E0-0x0000000181F866D0 
		public override Vector3 selectedCameraPosition { get; } // 0x0000000181F866D0-0x0000000181F867B0 
		[Obsolete("This property is obsolete and kept only for not breaking user code. VolumeDebugSettings will use current pipeline when it needs to gather volume component types and paths. #from(2023.2)")]
		public override Type targetRenderPipeline { get; } // 0x0000000181F868C0-0x0000000181F86900 
	
		// Constructors
		public UniversalRenderPipelineVolumeDebugSettings(); // 0x0000000181F86590-0x0000000181F865E0
	}
}
