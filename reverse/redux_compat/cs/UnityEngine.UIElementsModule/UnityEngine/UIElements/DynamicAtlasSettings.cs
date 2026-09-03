/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public class DynamicAtlasSettings // TypeDefIndex: 4174
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private int m_MinAtlasSize; // 0x10
		[HideInInspector]
		[SerializeField]
		private int m_MaxAtlasSize; // 0x14
		[HideInInspector]
		[SerializeField]
		private int m_MaxSubTextureSize; // 0x18
		[HideInInspector]
		[SerializeField]
		private DynamicAtlasFilters m_ActiveFilters; // 0x1C
		private DynamicAtlasCustomFilter m_CustomFilter; // 0x20
	
		// Properties
		public int minAtlasSize { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int maxAtlasSize { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public int maxSubTextureSize { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public DynamicAtlasFilters activeFilters { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public static DynamicAtlasFilters defaultFilters { get; } // 0x0000000182491610-0x0000000182491620 
		public DynamicAtlasCustomFilter customFilter { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public static DynamicAtlasSettings defaults { get; } // 0x0000000182491620-0x00000001824916B0 
	
		// Constructors
		public DynamicAtlasSettings(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
