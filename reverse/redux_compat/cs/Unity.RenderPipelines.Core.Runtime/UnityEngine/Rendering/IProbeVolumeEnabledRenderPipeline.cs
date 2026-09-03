/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public interface IProbeVolumeEnabledRenderPipeline // TypeDefIndex: 5539
	{
		// Properties
		bool supportProbeVolume { get; }
		ProbeVolumeSHBands maxSHBands { get; }
		[Obsolete("This field is no longer necessary. #from(2023.3)")]
		ProbeVolumeSceneData probeVolumeSceneData { get; }
	}
}
