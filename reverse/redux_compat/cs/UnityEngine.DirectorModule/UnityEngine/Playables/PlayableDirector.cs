/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 63: UnityEngine.DirectorModule.dll - Assembly: UnityEngine.DirectorModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15783-15793

namespace UnityEngine.Playables
{
	[NativeClass("PlayableDirector", PersistentTypeId = 320)]
	[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
	[NativeHeader("Modules/Director/PlayableDirector.h")]
	[RequiredByNativeCode]
	public class PlayableDirector : Behaviour // TypeDefIndex: 15788
	{
		// Fields
		[CompilerGenerated]
		private Action<PlayableDirector> played; // 0x18
		[CompilerGenerated]
		private Action<PlayableDirector> paused; // 0x20
		[CompilerGenerated]
		private Action<PlayableDirector> stopped; // 0x28
	
		// Methods
		[RequiredByNativeCode]
		private void SendOnPlayableDirectorPlay(); // 0x0000000182270F90-0x0000000182270FB0
		[RequiredByNativeCode]
		private void SendOnPlayableDirectorPause(); // 0x0000000182270F70-0x0000000182270F90
		[RequiredByNativeCode]
		private void SendOnPlayableDirectorStop(); // 0x0000000182270FB0-0x0000000182270FD0
	}
}
