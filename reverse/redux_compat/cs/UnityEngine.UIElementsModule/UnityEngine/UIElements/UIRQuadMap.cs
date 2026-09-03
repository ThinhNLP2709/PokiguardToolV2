/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class UIRQuadMap // TypeDefIndex: 4840
	{
		// Fields
		private readonly List<int> m_MeshStarts; // 0x10
		private Entry[] m_Entries; // 0x18
		private int m_Length; // 0x20
	
		// Nested types
		private struct Entry // TypeDefIndex: 4841
		{
			// Fields
			public int sliceIndex; // 0x00
			public int vertexOffset; // 0x04
		}
	
		// Constructors
		public UIRQuadMap(); // 0x00000001823DD230-0x00000001823DD300
	
		// Methods
		public void Clear(); // 0x00000001823DD180-0x00000001823DD1B0
		public void BeginMesh(int quadCount); // 0x00000001823DD030-0x00000001823DD180
		public void Record(int textElementInfoIndex, int sliceIndex, int vertexOffset); // 0x00000001823DD1B0-0x00000001823DD230
	}
}
