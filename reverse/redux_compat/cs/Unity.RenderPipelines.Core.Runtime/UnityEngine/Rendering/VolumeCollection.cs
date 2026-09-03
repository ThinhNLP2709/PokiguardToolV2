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
	internal class VolumeCollection // TypeDefIndex: 5798
	{
		// Fields
		internal const int k_MaxLayerCount = 32; // Metadata: 0x00661B1F
		private readonly Dictionary<int, List<Volume>> m_SortedVolumes; // 0x10
		private readonly List<Volume> m_Volumes; // 0x18
		private readonly Dictionary<int, bool> m_SortNeeded; // 0x20
	
		// Properties
		public int count { get; } // 0x00000001814EA450-0x00000001814EA470 
	
		// Constructors
		public VolumeCollection(); // 0x0000000181ECF1D0-0x0000000181ECF2E0
	
		// Methods
		public bool Register(Volume volume, int layer); // 0x0000000181ECEB20-0x0000000181ECEDB0
		public bool Unregister(Volume volume, int layer); // 0x0000000181ECEFB0-0x0000000181ECF1D0
		public bool ChangeLayer(Volume volume, int previousLayerIndex, int currentLayerIndex); // 0x0000000181ECE780-0x0000000181ECE880
		internal static void SortByPriority(List<Volume> volumes); // 0x0000000181ECEEE0-0x0000000181ECEFB0
		public List<Volume> GrabVolumes(LayerMask mask); // 0x0000000181ECE880-0x0000000181ECEB20
		public void SetLayerIndexDirty(int layerIndex); // 0x0000000181ECEDB0-0x0000000181ECEEE0
		public bool IsComponentActiveInMask<T>(LayerMask layerMask)
			where T : VolumeComponent;
	}
}
