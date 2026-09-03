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
using UnityEngine.Scripting.APIUpdating;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine.Animations
{
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationScriptPlayable.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationScriptPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct AnimationScriptPlayable : IEquatable<UnityEngine.Animations.AnimationScriptPlayable> // TypeDefIndex: 14762
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly AnimationScriptPlayable m_NullPlayable; // 0x00
	
		// Constructors
		internal AnimationScriptPlayable(PlayableHandle handle); // 0x0000000182158160-0x0000000182158210
		static AnimationScriptPlayable(); // 0x0000000182158060-0x0000000182158160
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(AnimationScriptPlayable other); // 0x0000000182157FF0-0x0000000182158060
	}
}
