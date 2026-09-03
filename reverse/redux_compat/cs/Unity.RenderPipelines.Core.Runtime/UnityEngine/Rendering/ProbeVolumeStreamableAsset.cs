/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[MovedFrom(false, "UnityEngine.Rendering", "Unity.RenderPipelines.Core.Runtime", "ProbeVolumeBakingSet.StreamableAsset")]
	internal class ProbeVolumeStreamableAsset // TypeDefIndex: 5622
	{
		// Fields
		[FormerlySerializedAs("assetGUID")]
		[SerializeField]
		private string m_AssetGUID; // 0x10
		[FormerlySerializedAs("streamableAssetPath")]
		[SerializeField]
		private string m_StreamableAssetPath; // 0x18
		[FormerlySerializedAs("elementSize")]
		[SerializeField]
		private int m_ElementSize; // 0x20
		[FormerlySerializedAs("streamableCellDescs")]
		[SerializeField]
		private SerializedDictionary<int, StreamableCellDesc> m_StreamableCellDescs; // 0x28
		[SerializeField]
		private TextAsset m_Asset; // 0x30
		private string m_FinalAssetPath; // 0x38
		private FileHandle m_AssetFileHandle; // 0x40
	
		// Properties
		public string assetGUID { get; } // 0x0000000180377550-0x0000000180377560 
		public TextAsset asset { get; } // 0x000000018031E110-0x000000018031E120 
		public int elementSize { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public SerializedDictionary<int, StreamableCellDesc> streamableCellDescs { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		[Serializable]
		[MovedFrom(false, "UnityEngine.Rendering", "Unity.RenderPipelines.Core.Runtime", "ProbeVolumeBakingSet.StreamableAsset.StreamableCellDesc")]
		public struct StreamableCellDesc // TypeDefIndex: 5623
		{
			// Fields
			public int offset; // 0x00
			public int elementCount; // 0x04
		}
	
		// Constructors
		public ProbeVolumeStreamableAsset(string apvStreamingAssetsPath, SerializedDictionary<int, StreamableCellDesc> cellDescs, int elementSize, string bakingSetGUID, string assetGUID); // 0x0000000181E88400-0x0000000181E88580
	
		// Methods
		internal void RefreshAssetPath(); // 0x0000000181E88360-0x0000000181E88400
		public string GetAssetPath(); // 0x0000000181E88120-0x0000000181E881E0
		internal bool HasValidAssetReference(); // 0x0000000181E88260-0x0000000181E882F0
		public bool FileExists(); // 0x0000000181E88040-0x0000000181E88120
		public long GetFileSize(); // 0x0000000181E881E0-0x0000000181E88260
		public bool IsOpen(); // 0x0000000181E882F0-0x0000000181E88300
		public FileHandle OpenFile(); // 0x0000000181E88300-0x0000000181E88360
		public void CloseFile(); // 0x0000000181E87F50-0x0000000181E87FD0
		public bool IsValid(); // 0x00000001803778B0-0x00000001803778D0
		public void Dispose(); // 0x0000000181E87FD0-0x0000000181E88040
	}
}
