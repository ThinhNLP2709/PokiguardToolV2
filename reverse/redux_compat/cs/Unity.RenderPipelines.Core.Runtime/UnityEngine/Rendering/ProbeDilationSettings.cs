/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	internal struct ProbeDilationSettings // TypeDefIndex: 5596
	{
		// Fields
		public bool enableDilation; // 0x00
		public float dilationDistance; // 0x04
		public float dilationValidityThreshold; // 0x08
		public int dilationIterations; // 0x0C
		public bool squaredDistWeighting; // 0x10
	
		// Methods
		internal void SetDefaults(); // 0x0000000181E80230-0x0000000181E80250
		internal void UpgradeFromTo(ProbeVolumeBakingProcessSettings.SettingsVersion from, ProbeVolumeBakingProcessSettings.SettingsVersion to); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
