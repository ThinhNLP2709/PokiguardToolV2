/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.RadeonRays
{
	internal struct TopLevelAccelStruct : IDisposable // TypeDefIndex: 14241
	{
		// Fields
		public const GraphicsBuffer.Target topLevelBvhTarget = GraphicsBuffer.Target.Structured; // Metadata: 0x006A95ED
		public const GraphicsBuffer.Target instanceInfoTarget = GraphicsBuffer.Target.Structured; // Metadata: 0x006A95EE
		public GraphicsBuffer topLevelBvh; // 0x00
		public GraphicsBuffer bottomLevelBvhs; // 0x08
		public GraphicsBuffer instanceInfos; // 0x10
		public uint instanceCount; // 0x18
	
		// Methods
		public void Dispose(); // 0x0000000182124240-0x0000000182124280
	}
}
