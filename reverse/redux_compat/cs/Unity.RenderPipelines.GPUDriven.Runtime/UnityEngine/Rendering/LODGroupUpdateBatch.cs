/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct LODGroupUpdateBatch : IDisposable // TypeDefIndex: 12941
	{
		// Fields
		public JaggedSpan<EntityId> instanceIDs; // 0x00
		public JaggedSpan<float3> worldSpaceReferencePoints; // 0x20
		public JaggedSpan<float> worldSpaceSizes; // 0x40
		public JaggedSpan<InternalLODGroupSettings> lodGroupSettings; // 0x60
		public JaggedSpan<byte> forceLODMask; // 0x80
		public JaggedSpan<EmbeddedLODBuffer> lodBuffers; // 0xA0
		public LODGroupComponentMask componentMask; // 0xC0
		public LODGroupUpdateBatchMode updateMode; // 0xC4
	
		// Properties
		public int SectionCount { get; } // 0x0000000181F3ACE0-0x0000000181F3ACF0 
		public int TotalLength { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public LODGroupUpdateBatch(LODGroupComponentMask componentMask, LODGroupUpdateBatchMode updateMode, int initialCapacity, Allocator allocator); // 0x0000000181F3A820-0x0000000181F3AA00
		public LODGroupUpdateBatch([IsReadOnly] in LODGroupUpdateSection section, LODGroupUpdateBatchMode updateMode, Allocator allocator); // 0x0000000181F3AA00-0x0000000181F3ACE0
	
		// Methods
		public void Dispose(); // 0x0000000181F3A3E0-0x0000000181F3A440
		public int GetSectionLength(int sectionIndex); // 0x0000000181F3A440-0x0000000181F3A460
		public bool HasAnyComponent(LODGroupComponentMask bits); // 0x0000000181F3A460-0x0000000181F3A470
		public void AddSection([IsReadOnly] in LODGroupUpdateSection section); // 0x0000000181F3A2F0-0x0000000181F3A3E0
		internal void Validate(); // 0x00000001802E76C0-0x00000001802E76D0
		private void ValidateImpl(); // 0x0000000181F3A470-0x0000000181F3A730
		private bool DeepValidateImpl(); // 0x00000001802E7990-0x00000001802E79A0
		private bool ValidateRequiredComponentIsPresent(LODGroupComponentMask component); // 0x0000000181F3A730-0x0000000181F3A820
		private bool ValidateEmptyOrSameLayout<T>(LODGroupComponentMask component, JaggedSpan<T> components, JaggedSpan<EntityId> instanceIDs)
			where T : struct;
	}
}
