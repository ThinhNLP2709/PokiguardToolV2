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
	internal struct InstanceHandle : IEquatable<UnityEngine.Rendering.InstanceHandle>, IComparable<UnityEngine.Rendering.InstanceHandle> // TypeDefIndex: 12784
	{
		// Fields
		[CompilerGenerated]
		private int _index_k__BackingField; // 0x00
		public static readonly InstanceHandle Invalid; // 0x00
	
		// Properties
		public int index { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public bool isValid { get; } // 0x0000000181F17F10-0x0000000181F17F60 
	
		// Constructors
		static InstanceHandle(); // 0x0000000181F17ED0-0x0000000181F17F10
	
		// Methods
		public static InstanceHandle Create(int index); // 0x0000000181F17DE0-0x0000000181F17E30
		public bool Equals(InstanceHandle other); // 0x0000000181F17E30-0x0000000181F17E80
		public int CompareTo(InstanceHandle other); // 0x0000000181F17D70-0x0000000181F17DE0
		public override int GetHashCode(); // 0x0000000181F17E80-0x0000000181F17ED0
	}
}
