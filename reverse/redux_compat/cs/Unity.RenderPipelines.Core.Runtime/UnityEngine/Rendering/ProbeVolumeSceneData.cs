/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[Obsolete("This class is no longer necessary for APV implementation. #from(2023.3)")]
	public class ProbeVolumeSceneData // TypeDefIndex: 5618
	{
		// Fields
		internal UnityEngine.Object parentAsset; // 0x10
		[FormerlySerializedAs("sceneBounds")]
		[Obsolete("This data is now serialized directly in the baking set asset. #from(2023.3)")]
		[SerializeField]
		internal SerializedDictionary<string, Bounds> obsoleteSceneBounds; // 0x18
		[FormerlySerializedAs("hasProbeVolumes")]
		[Obsolete("This data is now serialized directly in the baking set asset. #from(2023.3)")]
		[SerializeField]
		internal SerializedDictionary<string, bool> obsoleteHasProbeVolumes; // 0x20
	
		// Constructors
		public ProbeVolumeSceneData(UnityEngine.Object parentAsset); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		[Obsolete("#from(2023.3)")]
		public void SetParentObject(UnityEngine.Object parent); // 0x00000001803780D0-0x00000001803780E0
	}
}
