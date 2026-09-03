/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Playables
{
	public struct FrameData // TypeDefIndex: 8193
	{
		// Fields
		internal ulong m_FrameID; // 0x00
		internal double m_DeltaTime; // 0x08
		internal float m_Weight; // 0x10
		internal float m_EffectiveWeight; // 0x14
		internal double m_EffectiveParentDelay; // 0x18
		internal float m_EffectiveParentSpeed; // 0x20
		internal float m_EffectiveSpeed; // 0x24
		internal Flags m_Flags; // 0x28
		internal PlayableOutput m_Output; // 0x30
	
		// Nested types
		[Flags]
		internal enum Flags // TypeDefIndex: 8194
		{
			Evaluate = 1,
			SeekOccured = 2,
			Loop = 4,
			Hold = 8,
			EffectivePlayStateDelayed = 16,
			EffectivePlayStatePlaying = 32
		}
	}
}
