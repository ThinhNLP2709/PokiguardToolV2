/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Playables
{
	public struct PlayableBinding // TypeDefIndex: 8201
	{
		// Fields
		private string m_StreamName; // 0x00
		private UnityEngine.Object m_SourceObject; // 0x08
		private Type m_SourceBindingType; // 0x10
		private CreateOutputMethod m_CreateOutputMethod; // 0x18
		[NoAutoStaticsCleanup]
		public static readonly PlayableBinding[] None; // 0x00
		public static readonly double DefaultDuration; // 0x08
	
		// Nested types
		[VisibleToOtherModules]
		internal delegate PlayableOutput CreateOutputMethod(PlayableGraph graph, string name); // TypeDefIndex: 8202; 0x0000000182246210-0x0000000182246250
	
		// Constructors
		static PlayableBinding(); // 0x000000018224B160-0x000000018224B210
	}
}
