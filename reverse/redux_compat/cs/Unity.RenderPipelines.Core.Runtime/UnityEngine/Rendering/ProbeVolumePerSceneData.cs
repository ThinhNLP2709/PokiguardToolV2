/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AddComponentMenu("")]
	[ExecuteAlways]
	public class ProbeVolumePerSceneData : MonoBehaviour // TypeDefIndex: 5614
	{
		// Fields
		[FormerlySerializedAs("bakingSet")]
		[SerializeField]
		internal ProbeVolumeBakingSet serializedBakingSet; // 0x20
		[SerializeField]
		internal string sceneGUID; // 0x28
		[FormerlySerializedAs("asset")]
		[SerializeField]
		internal ObsoleteProbeVolumeAsset obsoleteAsset; // 0x30
		[FormerlySerializedAs("cellSharedDataAsset")]
		[SerializeField]
		internal TextAsset obsoleteCellSharedDataAsset; // 0x38
		[FormerlySerializedAs("cellSupportDataAsset")]
		[SerializeField]
		internal TextAsset obsoleteCellSupportDataAsset; // 0x40
		[FormerlySerializedAs("serializedScenarios")]
		[SerializeField]
		private List<ObsoleteSerializablePerScenarioDataItem> obsoleteSerializedScenarios; // 0x48
	
		// Properties
		public ProbeVolumeBakingSet bakingSet { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Nested types
		[Serializable]
		internal struct ObsoletePerScenarioData // TypeDefIndex: 5615
		{
			// Fields
			public int sceneHash; // 0x00
			public TextAsset cellDataAsset; // 0x08
			public TextAsset cellOptionalDataAsset; // 0x10
		}
	
		[Serializable]
		private struct ObsoleteSerializablePerScenarioDataItem // TypeDefIndex: 5616
		{
			// Fields
			public string scenario; // 0x00
			public ObsoletePerScenarioData data; // 0x08
		}
	
		// Constructors
		public ProbeVolumePerSceneData(); // 0x0000000181E85E20-0x0000000181E85EC0
	
		// Methods
		internal void Clear(); // 0x0000000181E85830-0x0000000181E85860
		internal void QueueSceneLoading(); // 0x0000000181E85B50-0x0000000181E85C40
		internal void QueueSceneRemoval(); // 0x0000000181E85C40-0x0000000181E85D30
		private void OnEnable(); // 0x0000000181E85AA0-0x0000000181E85B50
		private void OnDisable(); // 0x0000000181E859F0-0x0000000181E85AA0
		private void OnValidate(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void Initialize(); // 0x0000000181E85860-0x0000000181E859F0
		internal bool ResolveCellData(); // 0x0000000181E85D30-0x0000000181E85E20
	}
}
