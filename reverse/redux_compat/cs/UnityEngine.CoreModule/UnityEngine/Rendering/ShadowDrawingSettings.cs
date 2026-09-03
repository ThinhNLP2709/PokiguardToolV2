/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	public struct ShadowDrawingSettings : IEquatable<ShadowDrawingSettings> // TypeDefIndex: 8436
	{
		// Fields
		private CullingResults m_CullingResults; // 0x00
		private int m_LightIndex; // 0x10
		private int m_SplitIndex; // 0x14
		private int m_UseRenderingLayerMaskTest; // 0x18
		private uint m_BatchLayerMask; // 0x1C
		private ShadowSplitData m_SplitData; // 0x20
		private ShadowObjectsFilter m_ObjectsFilter; // 0x11C
		private BatchCullingProjectionType m_ProjectionType; // 0x120
		private int m_SortShadowcastersByRenderQueue; // 0x124
	
		// Properties
		public bool useRenderingLayerMaskTest { set; } // 0x000000018225ADC0-0x000000018225ADD0
		public bool sortShadowcastersByRenderQueue { set; } // 0x000000018226A040-0x000000018226A050
	
		// Constructors
		public ShadowDrawingSettings(CullingResults cullingResults, int lightIndex); // 0x0000000182269FA0-0x000000018226A040
	
		// Methods
		public bool Equals(ShadowDrawingSettings other); // 0x00000001822697B0-0x0000000182269DA0
		public override bool Equals(object obj); // 0x0000000182269DA0-0x0000000182269EC0
		public override int GetHashCode(); // 0x0000000182269EC0-0x0000000182269FA0
	}
}
