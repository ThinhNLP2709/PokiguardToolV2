/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[IsReadOnly]
	internal struct ResourceHandle : IEquatable<UnityEngine.Rendering.RenderGraphModule.ResourceHandle> // TypeDefIndex: 5970
	{
		// Fields
		private const uint kIndexMask = 65535; // Metadata: 0x00662C4B
		private const uint kVersionMask = 2147418112; // Metadata: 0x00662C4F
		private const int kVersionShift = 16; // Metadata: 0x00662C54
		private const uint kNotVersionedBit = 2147483648; // Metadata: 0x00662C55
		private readonly uint m_VersionIndex; // 0x00
		private readonly uint m_Validity; // 0x04
		private readonly RenderGraphResourceType m_Type; // 0x08
		private static uint s_CurrentValidBit; // 0x00
	
		// Properties
		public int index { get; } // 0x000000018123AD30-0x000000018123AD40 
		public int iType { get; } // 0x0000000181EEEA60-0x0000000181EEEAB0 
		public int version { get; } // 0x0000000181EEEAB0-0x0000000181EEEAC0 
		public RenderGraphResourceType type { get; } // 0x0000000180732D20-0x0000000180732D30 
		public bool IsVersioned { get; } // 0x0000000181EEEA50-0x0000000181EEEA60 
	
		// Constructors
		internal ResourceHandle(int index, RenderGraphResourceType type, bool shared); // 0x0000000181EEE950-0x0000000181EEE9D0
		internal ResourceHandle([IsReadOnly] in ResourceHandle h, int version); // 0x0000000181EEE9D0-0x0000000181EEEA50
		static ResourceHandle(); // 0x0000000181EEE910-0x0000000181EEE950
	
		// Methods
		public bool IsValid(); // 0x0000000181EEE7F0-0x0000000181EEE860
		public bool IsNull(); // 0x0000000181EEE7A0-0x0000000181EEE7F0
		public static void NewFrame(int executionIndex); // 0x0000000181EEE860-0x0000000181EEE910
		public bool Equals(ResourceHandle hdl); // 0x0000000181EEE5E0-0x0000000181EEE650
		public static bool operator ==(ResourceHandle lhs, ResourceHandle rhs); // 0x0000000181EEEAC0-0x0000000181EEEBA0
		public static bool operator !=(ResourceHandle lhs, ResourceHandle rhs); // 0x0000000181EEEBA0-0x0000000181EEEC80
		public override bool Equals(object obj); // 0x0000000181EEE650-0x0000000181EEE750
		public override int GetHashCode(); // 0x0000000181EEE750-0x0000000181EEE7A0
	}
}
