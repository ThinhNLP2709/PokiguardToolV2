/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public class RenderPipelineGraphicsSettingsContainer : ISerializationCallbackReceiver // TypeDefIndex: 5657
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private RenderPipelineGraphicsSettingsCollection m_RuntimeSettings; // 0x10
	
		// Properties
		public List<IRenderPipelineGraphicsSettings> settingsList { get; } // 0x0000000180FB1BE0-0x0000000180FB1C00 
	
		// Constructors
		public RenderPipelineGraphicsSettingsContainer(); // 0x0000000181E98890-0x0000000181E98900
	
		// Methods
		public void OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		public void OnAfterDeserialize(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
