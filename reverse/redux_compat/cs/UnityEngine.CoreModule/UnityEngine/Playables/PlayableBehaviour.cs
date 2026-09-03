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
	[Serializable]
	[RequiredByNativeCode]
	public abstract class PlayableBehaviour : IPlayableBehaviour, ICloneable // TypeDefIndex: 8200
	{
		// Constructors
		public PlayableBehaviour(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void OnGraphStart(Playable playable); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnGraphStop(Playable playable); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnPlayableCreate(Playable playable); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnPlayableDestroy(Playable playable); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnBehaviourPlay(Playable playable, FrameData info); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void OnBehaviourPause(Playable playable, FrameData info); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void PrepareFrame(Playable playable, FrameData info); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void ProcessFrame(Playable playable, FrameData info, object playerData); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual object Clone(); // 0x0000000181560410-0x0000000181560420
	}
}
