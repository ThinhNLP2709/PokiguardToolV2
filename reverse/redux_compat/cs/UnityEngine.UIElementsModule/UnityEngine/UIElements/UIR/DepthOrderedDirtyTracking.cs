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
	internal struct DepthOrderedDirtyTracking // TypeDefIndex: 5126
	{
		// Fields
		public RenderTree owner; // 0x00
		public List<RenderData> heads; // 0x08
		public List<RenderData> tails; // 0x10
		public int[] minDepths; // 0x18
		public int[] maxDepths; // 0x20
		public uint dirtyID; // 0x28
	
		// Methods
		public void EnsureFits(int maxDepth); // 0x000000018241FA10-0x000000018241FB40
		public void RegisterDirty(RenderData renderData, RenderDataDirtyTypes dirtyTypes, RenderDataDirtyTypeClasses dirtyTypeClass); // 0x000000018241FB40-0x000000018241FD00
		public void ClearDirty(RenderData renderData, RenderDataDirtyTypes dirtyTypesInverse); // 0x000000018241F8A0-0x000000018241FA10
		public void Reset(); // 0x000000018241FD00-0x000000018241FD80
	}
}
