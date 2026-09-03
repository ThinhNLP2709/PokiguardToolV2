/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Playables
{
	[RequiredByNativeCode]
	public struct PlayableOutput : IEquatable<UnityEngine.Playables.PlayableOutput> // TypeDefIndex: 8205
	{
		// Fields
		private PlayableOutputHandle m_Handle; // 0x00
		private static readonly PlayableOutput m_NullPlayableOutput; // 0x00
	
		// Constructors
		[VisibleToOtherModules]
		internal PlayableOutput(PlayableOutputHandle handle); // 0x0000000180D17CD0-0x0000000180D17CE0
		static PlayableOutput(); // 0x000000018224B570-0x000000018224B5E0
	
		// Methods
		public PlayableOutputHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(PlayableOutput other); // 0x000000018224B500-0x000000018224B570
	}
}
