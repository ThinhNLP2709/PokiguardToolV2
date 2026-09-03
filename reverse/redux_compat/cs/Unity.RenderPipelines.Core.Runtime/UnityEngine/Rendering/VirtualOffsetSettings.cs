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
	[Serializable]
	internal struct VirtualOffsetSettings // TypeDefIndex: 5597
	{
		// Fields
		internal const int kPhysicsDefaultRaycastLayers = -5; // Metadata: 0x0066172A
		public bool useVirtualOffset; // 0x00
		[Range(0f, 0.95f)]
		public float validityThreshold; // 0x04
		[Range(0f, 1f)]
		public float outOfGeoOffset; // 0x08
		[Range(0f, 2f)]
		public float searchMultiplier; // 0x0C
		[Range(-0.05f, 0f)]
		public float rayOriginBias; // 0x10
		public LayerMask collisionMask; // 0x14
	
		// Methods
		internal void SetDefaults(); // 0x0000000181E8A5B0-0x0000000181E8A5F0
		internal void UpgradeFromTo(ProbeVolumeBakingProcessSettings.SettingsVersion from, ProbeVolumeBakingProcessSettings.SettingsVersion to); // 0x0000000181E8A5F0-0x0000000181E8A620
	}
}
