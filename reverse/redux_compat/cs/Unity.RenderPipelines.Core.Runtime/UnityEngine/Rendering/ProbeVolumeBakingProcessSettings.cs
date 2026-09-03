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
	internal struct ProbeVolumeBakingProcessSettings // TypeDefIndex: 5598
	{
		// Fields
		[SerializeField]
		private SettingsVersion m_Version; // 0x00
		public ProbeDilationSettings dilationSettings; // 0x04
		public VirtualOffsetSettings virtualOffsetSettings; // 0x18
	
		// Properties
		internal static ProbeVolumeBakingProcessSettings Default { get; } // 0x0000000181E80350-0x0000000181E803C0 
	
		// Nested types
		internal enum SettingsVersion // TypeDefIndex: 5599
		{
			Initial = 0,
			ThreadedVirtualOffset = 1,
			Current = 1,
			Max = 2
		}
	
		// Constructors
		internal ProbeVolumeBakingProcessSettings(ProbeDilationSettings dilationSettings, VirtualOffsetSettings virtualOffsetSettings); // 0x0000000181E80320-0x0000000181E80350
	
		// Methods
		internal void SetDefaults(); // 0x0000000181E80270-0x0000000181E802E0
		internal void Upgrade(); // 0x0000000181E802E0-0x0000000181E80320
	}
}
