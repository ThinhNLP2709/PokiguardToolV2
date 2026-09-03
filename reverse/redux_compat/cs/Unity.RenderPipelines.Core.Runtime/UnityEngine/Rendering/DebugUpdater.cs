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
	[AddComponentMenu("")]
	internal class DebugUpdater : MonoBehaviour // TypeDefIndex: 5498
	{
		// Constructors
		public DebugUpdater(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void RuntimeInit(); // 0x00000001802E76C0-0x00000001802E76D0
		internal static void SetEnabled(bool enabled); // 0x0000000181E46C80-0x0000000181E46D30
		private static void EnableRuntime(); // 0x0000000181E46C20-0x0000000181E46C80
		private static void DisableRuntime(); // 0x0000000181E46BC0-0x0000000181E46C20
	}
}
