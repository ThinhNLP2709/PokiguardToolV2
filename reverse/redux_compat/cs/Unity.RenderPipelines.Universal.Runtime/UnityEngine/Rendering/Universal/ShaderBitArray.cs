/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal struct ShaderBitArray // TypeDefIndex: 9778
	{
		// Fields
		private const int k_BitsPerElement = 32; // Metadata: 0x0069F0BF
		private const int k_ElementShift = 5; // Metadata: 0x0069F0C0
		private const int k_ElementMask = 31; // Metadata: 0x0069F0C1
		private float[] m_Data; // 0x00
	
		// Properties
		public int elemLength { get; } // 0x0000000181FE4EB0-0x0000000181FE4EC0 
		public int bitCapacity { get; } // 0x0000000181FE4E90-0x0000000181FE4EB0 
		public float[] data { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public bool this[int index] { get => default; set {} } // 0x0000000181FE4E40-0x0000000181FE4E90 0x0000000181FE4EC0-0x0000000181FE4F20
	
		// Methods
		public void Resize(int bitCount); // 0x0000000181FE4BF0-0x0000000181FE4CF0
		public void Clear(); // 0x0000000181FE4B90-0x0000000181FE4BE0
		private void GetElementIndexAndBitOffset(int index, out int elemIndex, out int bitOffset); // 0x0000000181FE4BE0-0x0000000181FE4BF0
		public override string ToString(); // 0x0000000181FE4CF0-0x0000000181FE4E40
	}
}
