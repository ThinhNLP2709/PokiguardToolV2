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
	[NativeHeader("Modules/Animation/Director/AnimatorControllerPlayable.h")]
	[NativeHeader("Modules/Animation/RuntimeAnimatorController.h")]
	[NativeHeader("Modules/Animation/AnimatorInfo.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerPlayable.bindings.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animator.bindings.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimatorControllerPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct AnimatorControllerPlayable : IEquatable<UnityEngine.Animations.AnimatorControllerPlayable> // TypeDefIndex: 14764
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimatorControllerPlayable m_NullPlayable; // 0x00
	
		// Constructors
		internal AnimatorControllerPlayable(PlayableHandle handle); // 0x0000000182158660-0x00000001821587D0
		static AnimatorControllerPlayable(); // 0x0000000182158480-0x0000000182158660
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public void SetHandle(PlayableHandle handle); // 0x0000000182158380-0x0000000182158480
		public bool Equals(AnimatorControllerPlayable other); // 0x0000000182158310-0x0000000182158380
	}
}
