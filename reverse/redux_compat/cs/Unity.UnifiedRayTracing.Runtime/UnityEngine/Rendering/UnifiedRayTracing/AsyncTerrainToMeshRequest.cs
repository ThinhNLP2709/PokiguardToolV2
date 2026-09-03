/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal struct AsyncTerrainToMeshRequest // TypeDefIndex: 14290
	{
		// Fields
		private JobHandle m_JobHandle; // 0x00
		private ComputeTerrainMeshJob m_Job; // 0x10
	
		// Properties
		public bool done { get; } // 0x0000000182111CC0-0x0000000182111CD0 
	
		// Constructors
		internal AsyncTerrainToMeshRequest(ComputeTerrainMeshJob job, JobHandle jobHandle); // 0x0000000182111C70-0x0000000182111CC0
	
		// Methods
		public Mesh GetMesh(); // 0x00000001821118D0-0x0000000182111A50
		public void WaitForCompletion(); // 0x0000000182111C60-0x0000000182111C70
		private List<int> TriangleIndicesWithoutHoles(); // 0x0000000182111A50-0x0000000182111C60
	}
}
