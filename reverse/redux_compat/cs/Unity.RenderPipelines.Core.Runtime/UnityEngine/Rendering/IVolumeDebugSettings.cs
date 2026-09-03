/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Obsolete("This is not longer supported Please use DebugDisplaySettingsVolume. #from(6000.2)")]
	public interface IVolumeDebugSettings // TypeDefIndex: 5511
	{
		// Properties
		int selectedComponent { get; set; }
		Camera selectedCamera { get; }
		IEnumerable<Camera> cameras { get; }
		int selectedCameraIndex { get; set; }
		VolumeStack selectedCameraVolumeStack { get; }
		LayerMask selectedCameraLayerMask { get; }
		Vector3 selectedCameraPosition { get; }
		Type selectedComponentType { get; set; }
	
		// Methods
		Volume[] GetVolumes();
		bool VolumeHasInfluence(Volume volume);
		bool RefreshVolumes(Volume[] newVolumes);
		float GetVolumeWeight(Volume volume);
	}
}
