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
	internal struct GPUInstanceIndex : IEquatable<UnityEngine.Rendering.GPUInstanceIndex>, IComparable<UnityEngine.Rendering.GPUInstanceIndex> // TypeDefIndex: 12783
	{
		// Fields
		[CompilerGenerated]
		private int _index_k__BackingField; // 0x00
		public static readonly GPUInstanceIndex Invalid; // 0x00
	
		// Properties
		public int index { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public bool valid { get; } // 0x0000000181F0B820-0x0000000181F0B870 
	
		// Constructors
		static GPUInstanceIndex(); // 0x0000000181F0B7E0-0x0000000181F0B820
	
		// Methods
		public static GPUInstanceIndex Create(int index); // 0x0000000181F0B6F0-0x0000000181F0B740
		public bool Equals(GPUInstanceIndex other); // 0x0000000181F0B740-0x0000000181F0B790
		public int CompareTo(GPUInstanceIndex other); // 0x0000000181F0B680-0x0000000181F0B6F0
		public override int GetHashCode(); // 0x0000000181F0B790-0x0000000181F0B7E0
	}
}
