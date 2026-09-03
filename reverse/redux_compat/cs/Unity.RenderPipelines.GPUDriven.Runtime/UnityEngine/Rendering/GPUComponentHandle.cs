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
	internal struct GPUComponentHandle : IEquatable<UnityEngine.Rendering.GPUComponentHandle>, IComparable<UnityEngine.Rendering.GPUComponentHandle> // TypeDefIndex: 12763
	{
		// Fields
		[CompilerGenerated]
		private short _index_k__BackingField; // 0x00
		public static readonly GPUComponentHandle Invalid; // 0x00
	
		// Properties
		public short index { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018123AD30-0x000000018123AD40 0x000000018123B250-0x000000018123B260
		public bool valid { get; } // 0x0000000181F08230-0x0000000181F08280 
	
		// Constructors
		static GPUComponentHandle(); // 0x0000000181F081F0-0x0000000181F08230
	
		// Methods
		public static GPUComponentHandle Create(short index); // 0x0000000181F080F0-0x0000000181F08140
		public bool Equals(GPUComponentHandle other); // 0x0000000181F08140-0x0000000181F081A0
		public int CompareTo(GPUComponentHandle other); // 0x0000000181F08080-0x0000000181F080F0
		public override int GetHashCode(); // 0x0000000181F081A0-0x0000000181F081F0
	}
}
