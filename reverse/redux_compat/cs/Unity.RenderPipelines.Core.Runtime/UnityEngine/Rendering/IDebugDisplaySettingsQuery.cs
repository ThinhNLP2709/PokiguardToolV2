/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public interface IDebugDisplaySettingsQuery // TypeDefIndex: 5509
	{
		// Properties
		bool AreAnySettingsActive { get; }
		bool IsPostProcessingAllowed { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IsLightingActive { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Methods
		bool TryGetScreenClearColor(ref Color color); // 0x00000001802E7840-0x00000001802E7850
	}
}
