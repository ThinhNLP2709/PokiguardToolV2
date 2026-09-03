/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Experimental.Rendering
{
	public class XRLayout // TypeDefIndex: 5309
	{
		// Fields
		private readonly List<ValueTuple<Camera, XRPass>> m_ActivePasses; // 0x10
		public QuadViewState quadView; // 0x18
	
		// Nested types
		public struct QuadViewState // TypeDefIndex: 5310
		{
			// Fields
			public Vector4 cachedPeripheralVignetteCenter; // 0x00
		}
	
		// Constructors
		public XRLayout(); // 0x0000000181E2B980-0x0000000181E2BA00
	
		// Methods
		public void AddCamera(Camera camera, bool enableXR); // 0x0000000181E2AF90-0x0000000181E2B160
		public void ReconfigurePass(XRPass xrPass, Camera camera); // 0x0000000181E2B8E0-0x0000000181E2B980
		public List<ValueTuple<Camera, XRPass>> GetActivePasses(); // 0x0000000180377550-0x0000000180377560
		internal void AddPass(Camera camera, XRPass xrPass); // 0x0000000181E2B160-0x0000000181E2B280
		internal void Clear(); // 0x0000000181E2B280-0x0000000181E2B3A0
		internal void LogDebugInfo(); // 0x0000000181E2B3A0-0x0000000181E2B8E0
	}
}
