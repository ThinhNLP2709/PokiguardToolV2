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
	public struct Playable : IEquatable<UnityEngine.Playables.Playable> // TypeDefIndex: 8198
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
		private static readonly Playable m_NullPlayable; // 0x00
	
		// Properties
		public static Playable Null { get; } // 0x000000018224B6C0-0x000000018224B720 
	
		// Constructors
		[VisibleToOtherModules]
		internal Playable(PlayableHandle handle); // 0x0000000180D17CD0-0x0000000180D17CE0
		static Playable(); // 0x000000018224B650-0x000000018224B6C0
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(Playable other); // 0x000000018224B5E0-0x000000018224B650
	}
}
