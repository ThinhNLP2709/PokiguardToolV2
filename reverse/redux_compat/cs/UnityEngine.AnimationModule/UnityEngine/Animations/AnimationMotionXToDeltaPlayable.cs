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
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationMotionXToDeltaPlayable.bindings.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationMotionXToDeltaPlayableBindings", StaticAccessorType.DoubleColon)]
	internal struct AnimationMotionXToDeltaPlayable : IEquatable<UnityEngine.Animations.AnimationMotionXToDeltaPlayable> // TypeDefIndex: 14757
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimationMotionXToDeltaPlayable m_NullPlayable; // 0x00
	
		// Constructors
		private AnimationMotionXToDeltaPlayable(PlayableHandle handle); // 0x0000000182157850-0x0000000182157900
		static AnimationMotionXToDeltaPlayable(); // 0x0000000182157750-0x0000000182157850
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(AnimationMotionXToDeltaPlayable other); // 0x00000001821576E0-0x0000000182157750
	}
}
