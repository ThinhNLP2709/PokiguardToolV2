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
	internal struct GPUArchetypeHandle : IEquatable<UnityEngine.Rendering.GPUArchetypeHandle>, IComparable<UnityEngine.Rendering.GPUArchetypeHandle> // TypeDefIndex: 12764
	{
		// Fields
		[CompilerGenerated]
		private short _index_k__BackingField; // 0x00
		public static readonly GPUArchetypeHandle Invalid; // 0x00
	
		// Properties
		public short index { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018123AD30-0x000000018123AD40 0x000000018123B250-0x000000018123B260
		public bool valid { get; } // 0x0000000181F072B0-0x0000000181F07300 
	
		// Constructors
		static GPUArchetypeHandle(); // 0x0000000181F07270-0x0000000181F072B0
	
		// Methods
		public static GPUArchetypeHandle Create(short index); // 0x0000000181F07170-0x0000000181F071C0
		public bool Equals(GPUArchetypeHandle other); // 0x0000000181F071C0-0x0000000181F07220
		public int CompareTo(GPUArchetypeHandle other); // 0x0000000181F07100-0x0000000181F07170
		public override int GetHashCode(); // 0x0000000181F07220-0x0000000181F07270
	}
}
