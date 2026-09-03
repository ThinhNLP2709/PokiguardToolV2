/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Playables
{
	public interface IPlayableBehaviour // TypeDefIndex: 8197
	{
		// Methods
		[RequiredByNativeCode]
		void OnGraphStart(Playable playable);
		[RequiredByNativeCode]
		void OnGraphStop(Playable playable);
		[RequiredByNativeCode]
		void OnPlayableCreate(Playable playable);
		[RequiredByNativeCode]
		void OnPlayableDestroy(Playable playable);
		[RequiredByNativeCode]
		void OnBehaviourPlay(Playable playable, FrameData info);
		[RequiredByNativeCode]
		void OnBehaviourPause(Playable playable, FrameData info);
		[RequiredByNativeCode]
		void PrepareFrame(Playable playable, FrameData info);
		[RequiredByNativeCode]
		void ProcessFrame(Playable playable, FrameData info, object playerData);
	}
}
