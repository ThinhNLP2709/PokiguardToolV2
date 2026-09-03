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

namespace UnityEngine.UIElements.UIR
{
	internal struct BitmapAllocator32 // TypeDefIndex: 5167
	{
		// Fields
		private int m_PageHeight; // 0x00
		private List<Page> m_Pages; // 0x08
		private List<uint> m_AllocMap; // 0x10
		private int m_EntryWidth; // 0x18
		private int m_EntryHeight; // 0x1C
	
		// Properties
		public int entryWidth { get; } // 0x0000000180B23260-0x0000000180B23270 
		public int entryHeight { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public int pageCount { get; } // 0x000000018237E3B0-0x000000018237E3D0 
	
		// Nested types
		private struct Page // TypeDefIndex: 5168
		{
			// Fields
			public ushort x; // 0x00
			public ushort y; // 0x02
			public int freeSlots; // 0x04
		}
	
		// Methods
		public void Construct(int pageHeight, int entryWidth = 1 /* Metadata: 0x00660AE7 */, int entryHeight = 1 /* Metadata: 0x00660AE8 */); // 0x0000000182435B20-0x0000000182435C30
		public void ForceFirstAlloc(ushort firstPageX, ushort firstPageY); // 0x0000000182435CB0-0x0000000182435E50
		public BMPAlloc Allocate(BaseShaderInfoStorage storage); // 0x0000000182435750-0x0000000182435B20
		public void Free(BMPAlloc alloc); // 0x0000000182435E50-0x0000000182435F50
		internal void GetAllocPageAtlasLocation(int page, out ushort x, out ushort y); // 0x0000000182435F50-0x0000000182435F90
		private static byte CountTrailingZeroes(uint val); // 0x0000000182435C30-0x0000000182435CB0
	}
}
