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
	[NativeHeader("Modules/Animation/Director/AnimationOffsetPlayable.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationOffsetPlayable.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationOffsetPlayableBindings", StaticAccessorType.DoubleColon)]
	internal struct AnimationOffsetPlayable : IEquatable<UnityEngine.Animations.AnimationOffsetPlayable> // TypeDefIndex: 14758
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimationOffsetPlayable m_NullPlayable; // 0x00
	
		// Constructors
		internal AnimationOffsetPlayable(PlayableHandle handle); // 0x0000000182157AA0-0x0000000182157B50
		static AnimationOffsetPlayable(); // 0x00000001821579A0-0x0000000182157AA0
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(AnimationOffsetPlayable other); // 0x0000000182157900-0x00000001821579A0
	}
}
