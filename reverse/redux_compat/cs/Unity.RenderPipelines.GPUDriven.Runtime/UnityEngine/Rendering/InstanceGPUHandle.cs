/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal struct InstanceGPUHandle : IEquatable<UnityEngine.Rendering.InstanceGPUHandle>, IComparable<UnityEngine.Rendering.InstanceGPUHandle> // TypeDefIndex: 12785
	{
		// Fields
		private int m_Data; // 0x00
		public static readonly InstanceGPUHandle Invalid; // 0x00
	
		// Properties
		public bool isValid { get; } // 0x0000000181EEEA50-0x0000000181EEEA60 
		public GPUArchetypeHandle archetype { get; } // 0x0000000181F17CE0-0x0000000181F17D70 
		public int archetypeInstanceIndex { get; } // 0x0000000181F17CD0-0x0000000181F17CE0 
	
		// Constructors
		static InstanceGPUHandle(); // 0x0000000181F17C90-0x0000000181F17CD0
	
		// Methods
		public static InstanceGPUHandle Create(GPUArchetypeHandle gpuArchetype, int gpuPerArchetypeIndex); // 0x0000000181F17C30-0x0000000181F17C90
		public bool Equals(InstanceGPUHandle other); // 0x00000001815FCAB0-0x00000001815FCAC0
		public int CompareTo(InstanceGPUHandle other); // 0x0000000181F17C20-0x0000000181F17C30
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
	}
}
