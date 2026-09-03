/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.LookDev
{
	public class StageRuntimeInterface // TypeDefIndex: 6014
	{
		// Fields
		private Func<bool, GameObject> m_AddGameObject; // 0x10
		private Func<Camera> m_GetCamera; // 0x18
		private Func<Light> m_GetSunLight; // 0x20
		public object SRPData; // 0x28
	
		// Properties
		public Camera camera { get; } // 0x0000000181F031F0-0x0000000181F03210 
		public Light sunLight { get; } // 0x0000000181F03210-0x0000000181F03230 
	
		// Constructors
		public StageRuntimeInterface(Func<bool, GameObject> AddGameObject, Func<Camera> GetCamera, Func<Light> GetSunLight); // 0x00000001803A7D10-0x00000001803A7D80
	
		// Methods
		public GameObject AddGameObject(bool persistent = false /* Metadata: 0x00662D25 */); // 0x0000000181F031D0-0x0000000181F031F0
	}
}
