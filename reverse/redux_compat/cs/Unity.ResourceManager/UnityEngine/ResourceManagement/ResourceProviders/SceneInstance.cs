/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public struct SceneInstance // TypeDefIndex: 13756
	{
		// Fields
		private Scene m_Scene; // 0x00
		private bool m_ReleaseOnSceneUnloaded; // 0x08
		internal AsyncOperation m_Operation; // 0x10
	
		// Properties
		public Scene Scene { get; internal set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180CBE820-0x0000000180CBE830
		internal bool ReleaseSceneOnSceneUnloaded { get; set; } // 0x0000000181325D60-0x0000000181325D70 0x0000000181E6F9C0-0x0000000181E6F9D0
	
		// Methods
		public AsyncOperation ActivateAsync(); // 0x0000000182057D70-0x0000000182057DA0
		public override int GetHashCode(); // 0x0000000182057E60-0x0000000182057E80
		public override bool Equals(object obj); // 0x0000000182057DA0-0x0000000182057E60
	}
}
