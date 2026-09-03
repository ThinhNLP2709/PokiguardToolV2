/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct FilteringSettings : IEquatable<UnityEngine.Rendering.FilteringSettings> // TypeDefIndex: 8412
	{
		// Fields
		private RenderQueueRange m_RenderQueueRange; // 0x00
		private int m_LayerMask; // 0x08
		private uint m_RenderingLayerMask; // 0x0C
		private uint m_BatchLayerMask; // 0x10
		private int m_ExcludeMotionVectorObjects; // 0x14
		private int m_ForceAllMotionVectorObjects; // 0x18
		private SortingLayerRange m_SortingLayerRange; // 0x1C
	
		// Properties
		public RenderQueueRange renderQueueRange { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public uint batchLayerMask { set; } // 0x00000001805D5560-0x00000001805D5570
		public bool excludeMotionVectorObjects { set; } // 0x000000018225ADB0-0x000000018225ADC0
		public bool forceAllMotionVectorObjects { set; } // 0x000000018225ADC0-0x000000018225ADD0
	
		// Constructors
		public FilteringSettings([DefaultValue("RenderQueueRange.all")] RenderQueueRange? renderQueueRange = default, int layerMask = -1 /* Metadata: 0x0069DB98 */, uint renderingLayerMask = 4294967295 /* Metadata: 0x0069DB99 */, int excludeMotionVectorObjects = 0 /* Metadata: 0x0069DB9A */); // 0x000000018225ACB0-0x000000018225AD80
	
		// Methods
		public bool Equals(FilteringSettings other); // 0x000000018225AAD0-0x000000018225AB90
		public override bool Equals(object obj); // 0x000000018225AB90-0x000000018225AC30
		public override int GetHashCode(); // 0x000000018225AC30-0x000000018225ACB0
		public static bool operator ==(FilteringSettings left, FilteringSettings right); // 0x000000018225AD80-0x000000018225ADB0
	}
}
