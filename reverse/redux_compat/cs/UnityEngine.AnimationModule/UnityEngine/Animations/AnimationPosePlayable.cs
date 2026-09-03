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
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationPosePlayable.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationPosePlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationPosePlayableBindings", StaticAccessorType.DoubleColon)]
	internal struct AnimationPosePlayable : IEquatable<UnityEngine.Animations.AnimationPosePlayable> // TypeDefIndex: 14760
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimationPosePlayable m_NullPlayable; // 0x00
	
		// Constructors
		internal AnimationPosePlayable(PlayableHandle handle); // 0x0000000182157CF0-0x0000000182157DA0
		static AnimationPosePlayable(); // 0x0000000182157BF0-0x0000000182157CF0
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(AnimationPosePlayable other); // 0x0000000182157B50-0x0000000182157BF0
	}
}
