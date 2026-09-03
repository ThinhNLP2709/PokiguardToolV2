/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine.Animations
{
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationMixerPlayable.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationMixerPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationMixerPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct AnimationMixerPlayable : IEquatable<UnityEngine.Animations.AnimationMixerPlayable> // TypeDefIndex: 14756
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimationMixerPlayable m_NullPlayable; // 0x00
	
		// Constructors
		internal AnimationMixerPlayable(PlayableHandle handle); // 0x0000000182157630-0x00000001821576E0
		static AnimationMixerPlayable(); // 0x0000000182157530-0x0000000182157630
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(AnimationMixerPlayable other); // 0x00000001821574C0-0x0000000182157530
	}
}
