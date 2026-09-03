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
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationLayerMixerPlayable.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationLayerMixerPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationLayerMixerPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct AnimationLayerMixerPlayable : IEquatable<UnityEngine.Animations.AnimationLayerMixerPlayable> // TypeDefIndex: 14755
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimationLayerMixerPlayable m_NullPlayable; // 0x00
	
		// Constructors
		internal AnimationLayerMixerPlayable(PlayableHandle handle, bool singleLayerOptimization = true /* Metadata: 0x006A980B */); // 0x00000001821573C0-0x00000001821574C0
		static AnimationLayerMixerPlayable(); // 0x0000000182157270-0x00000001821573C0
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(AnimationLayerMixerPlayable other); // 0x00000001821571B0-0x0000000182157220
		[NativeMethod(ThrowsException = true)]
		private static void SetSingleLayerOptimizationInternal(ref PlayableHandle handle, bool value); // 0x0000000182157220-0x0000000182157270
	}
}
