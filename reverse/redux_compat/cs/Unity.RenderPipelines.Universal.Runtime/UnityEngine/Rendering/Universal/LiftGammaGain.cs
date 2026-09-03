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
	[Serializable]
	[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
	[VolumeComponentMenu("Post-processing/Lift, Gamma, Gain")]
	public sealed class LiftGammaGain : VolumeComponent, IPostProcessComponent // TypeDefIndex: 9527
	{
		// Fields
		public Vector4Parameter lift; // 0x38
		public Vector4Parameter gamma; // 0x40
		public Vector4Parameter gain; // 0x48
	
		// Constructors
		public LiftGammaGain(); // 0x0000000181F921D0-0x0000000181F922D0
	
		// Methods
		public bool IsActive(); // 0x0000000181F92120-0x0000000181F921D0
		[Obsolete("Unused. #from(2023.1)")]
		public bool IsTileCompatible(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
