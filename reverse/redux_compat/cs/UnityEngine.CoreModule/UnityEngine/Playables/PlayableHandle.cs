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
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Runtime/Export/Director/PlayableHandle.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
	[UsedByNativeCode]
	public struct PlayableHandle : IEquatable<UnityEngine.Playables.PlayableHandle> // TypeDefIndex: 8204
	{
		// Fields
		internal IntPtr m_Handle; // 0x00
		internal uint m_Version; // 0x08
		private static readonly PlayableHandle m_Null; // 0x00
	
		// Properties
		public static PlayableHandle Null { get; } // 0x000000018224B350-0x000000018224B3A0 
	
		// Methods
		[VisibleToOtherModules]
		internal bool IsPlayableOfType<T>();
		public static bool operator ==(PlayableHandle x, PlayableHandle y); // 0x000000018222B110-0x000000018222B130
		public override bool Equals(object p); // 0x000000018224B210-0x000000018224B2A0
		public bool Equals(PlayableHandle other); // 0x000000018222B110-0x000000018222B130
		public override int GetHashCode(); // 0x000000018224B2A0-0x000000018224B2D0
		internal static bool CompareVersion(PlayableHandle lhs, PlayableHandle rhs); // 0x0000000180C10DC0-0x0000000180C10DE0
		[VisibleToOtherModules]
		internal bool IsValid(); // 0x000000018224B310-0x000000018224B350
		[FreeFunction("PlayableHandleBindings::GetPlayableType", HasExplicitThis = true, ThrowsException = true)]
		[VisibleToOtherModules]
		internal Type GetPlayableType(); // 0x000000018224B2D0-0x000000018224B310
	}
}
