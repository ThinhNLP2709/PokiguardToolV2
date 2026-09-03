/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("RayTracingAccelerationStructure ({handle.index})")]
	[IsReadOnly]
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public struct RayTracingAccelerationStructureHandle // TypeDefIndex: 5940
	{
		// Fields
		private static readonly RayTracingAccelerationStructureHandle s_NullHandle; // 0x00
		internal readonly ResourceHandle handle; // 0x00
	
		// Properties
		public static RayTracingAccelerationStructureHandle nullHandle { get; } // 0x0000000181EDA210-0x0000000181EDA280 
	
		// Constructors
		internal RayTracingAccelerationStructureHandle(int handle); // 0x0000000181EDA190-0x0000000181EDA210
		static RayTracingAccelerationStructureHandle(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		public static implicit operator RayTracingAccelerationStructure(RayTracingAccelerationStructureHandle handle); // 0x0000000181EDA280-0x0000000181EDA470
		public bool IsValid(); // 0x0000000181EDA0E0-0x0000000181EDA190
	}
}
