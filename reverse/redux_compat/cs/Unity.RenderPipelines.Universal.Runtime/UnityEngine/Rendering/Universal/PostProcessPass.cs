/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal abstract class PostProcessPass : ScriptableRenderPass, IDisposable // TypeDefIndex: 9618
	{
		// Fields
		private VolumeStack m_VolumeStackOverride; // 0x60
	
		// Properties
		public VolumeStack volumeStack { get; } // 0x0000000181FAEEF0-0x0000000181FAEF60 
		public VolumeStack volumeStackOverride { set; } // 0x00000001803780F0-0x0000000180378100
	
		// Constructors
		protected PostProcessPass(); // 0x0000000181FAEEE0-0x0000000181FAEEF0
	
		// Methods
		public abstract void Dispose();
	}
}
